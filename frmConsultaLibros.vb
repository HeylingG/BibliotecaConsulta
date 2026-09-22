Imports System.Data
Imports MySqlConnector

Public Class frmConsultaLibros
    Private ReadOnly bsLibros As New BindingSource()
    Private ReadOnly bnLibros As New BindingNavigator(True)

    ' Puente entre los datos en memoria y los controles.
    ' Es ReadOnly porque el objeto se crea una vez y no se reemplaza:
    ' lo que cambia es su DataSource, no la variable.
    'Private ReadOnly bsLibros As New BindingSource()
    'Private ReadOnly bsLibros As New BindingSource()

    ' Copia en memoria del resultado de la consulta.
    Private dtLibros As New DataTable()

    ' Bandera de control. Mientras vale True significa que el
    ' formulario está cargando datos y los eventos de los filtros
    ' deben ignorarse. Sin esto, asignar el DataSource del ComboBox
    ' dispara SelectedIndexChanged antes de que exista dtLibros.
    Private cargando As Boolean = True

    ' Llena cboCategoria con el catálogo de categorías.
    Private Sub CargarCategorias()

        Dim dtCategorias As New DataTable()

        ' Using garantiza que la conexión se cierre y se libere
        ' aunque ocurra un error dentro del bloque.
        Using cn As MySqlConnection = ObtenerConexion()

            Dim sql As String =
                "SELECT id_categoria, nombre FROM categoria ORDER BY nombre;"

            ' El adaptador abre la conexión, ejecuta, copia el
            ' resultado en el DataTable y vuelve a cerrarla.
            Using da As New MySqlDataAdapter(sql, cn)
                da.Fill(dtCategorias)
            End Using

        End Using

        ' Fila artificial en la posición 0 para "ver todo".
        ' El id 0 no existe en la base, así que sirve como marca.
        Dim filaTodas As DataRow = dtCategorias.NewRow()
        filaTodas("id_categoria") = 0
        filaTodas("nombre") = "(Todas las categorías)"
        dtCategorias.Rows.InsertAt(filaTodas, 0)

        ' DisplayMember: lo que lee el usuario.
        ' ValueMember : lo que usa el programa para filtrar.
        cboCategoria.DataSource = dtCategorias
        cboCategoria.DisplayMember = "nombre"
        cboCategoria.ValueMember = "id_categoria"
        cboCategoria.SelectedIndex = 0

    End Sub

    ' Consulta la vista vw_libros y arma el enlace de datos.
    Private Sub CargarLibros()

        dtLibros = New DataTable()

        Using cn As MySqlConnection = ObtenerConexion()

            ' La vista ya trae el nombre del autor y de la categoría,
            ' así que la aplicación no necesita resolver el JOIN.
            Dim sql As String =
                "SELECT id_libro, id_autor, titulo, autor, categoria, id_categoria, " &
                "       anio_publicacion, ejemplares, precio " &
                "FROM vw_libros ORDER BY titulo;"

            Using da As New MySqlDataAdapter(sql, cn)
                da.Fill(dtLibros)
            End Using

        End Using

        ' --- Los tres enlaces que hacen funcionar todo ---
        ' 1) El puente toma los datos de la tabla en memoria.
        bsLibros.DataSource = dtLibros

        ' 2) La cuadrícula muestra lo que hay en el puente.
        dgvLibros.DataSource = bsLibros

        ' 3) La barra de navegación controla la posición del puente.
        '    Desde este momento sus flechas ya funcionan solas.
        bnLibros.BindingSource = bsLibros

    End Sub


    ' Ajusta el aspecto de las columnas de la cuadrícula.
    ' Debe llamarse DESPUÉS de asignar el DataSource, porque
    ' antes de eso las columnas todavía no existen.
    Private Sub ConfigurarColumnas()

        ' Columnas técnicas: se necesitan para filtrar, pero
        ' al usuario no le dicen nada, así que se ocultan.
        dgvLibros.Columns("id_libro").Visible = False
        dgvLibros.Columns("id_categoria").Visible = False
        dgvLibros.Columns("id_autor").Visible = False

        ' Encabezados legibles en lugar del nombre de la columna.
        dgvLibros.Columns("titulo").HeaderText = "Titulo"
        dgvLibros.Columns("autor").HeaderText = "Autor"
        dgvLibros.Columns("categoria").HeaderText = "Categoría"
        dgvLibros.Columns("anio_publicacion").HeaderText = "Año"
        dgvLibros.Columns("ejemplares").HeaderText = "Ejemplares"
        dgvLibros.Columns("precio").HeaderText = "Precio"

        ' Formato de moneda y alineación a la derecha para números.
        dgvLibros.Columns("precio").DefaultCellStyle.Format = "C$ #,##0.00"
        dgvLibros.Columns("precio").DefaultCellStyle.Alignment =
            DataGridViewContentAlignment.MiddleRight
        dgvLibros.Columns("ejemplares").DefaultCellStyle.Alignment =
            DataGridViewContentAlignment.MiddleCenter
        dgvLibros.Columns("anio_publicacion").DefaultCellStyle.Alignment =
            DataGridViewContentAlignment.MiddleCenter

        ' El título es el dato más largo: que se lleve el espacio sobrante.
        dgvLibros.Columns("titulo").AutoSizeMode =
            DataGridViewAutoSizeColumnMode.Fill
        dgvLibros.Columns("titulo").FillWeight = 180

    End Sub

    ' Conecta cada TextBox del panel inferior con una columna.
    ' Sintaxis: Control.DataBindings.Add(propiedad, origen, columna)
    Private Sub EnlazarDetalle()

        ' Limpiar primero evita enlaces duplicados si este
        ' procedimiento llegara a ejecutarse dos veces.
        txtTitulo.DataBindings.Clear()
        txtAutor.DataBindings.Clear()
        txtCategoria.DataBindings.Clear()
        txtAnio.DataBindings.Clear()
        txtEjemplares.DataBindings.Clear()
        txtPrecio.DataBindings.Clear()

        ' "Text" es la propiedad del control que recibirá el dato.
        txtTitulo.DataBindings.Add("Text", bsLibros, "titulo")
        txtAutor.DataBindings.Add("Text", bsLibros, "autor")
        txtCategoria.DataBindings.Add("Text", bsLibros, "categoria")
        txtAnio.DataBindings.Add("Text", bsLibros, "anio_publicacion")
        txtEjemplares.DataBindings.Add("Text", bsLibros, "ejemplares")

        ' El precio necesita formato de moneda. Los parámetros son:
        '   formattingEnabled = True  -> permite aplicar formato
        '   updateMode = Never        -> el control nunca escribe
        '                                de vuelta en los datos
        '   nullValue = Nothing
        '   formatString = "C2"       -> moneda con dos decimales
        txtPrecio.DataBindings.Add("Text", bsLibros, "precio",
                                   True, DataSourceUpdateMode.Never,
                                   Nothing, "C$ #,##0.00")

    End Sub

    ' Arma la condición de filtro combinando los dos controles.
    Private Sub AplicarFiltro()
        If cargando Then Exit Sub

        Dim condiciones As New List(Of String)

        ' 1. Filtro de Categoría
        If cboCategoria.SelectedIndex > 0 Then
            condiciones.Add("id_categoria = " & cboCategoria.SelectedValue.ToString())
        End If

        ' 2. Filtro de Autor (NUEVO)
        If cboAutor.SelectedIndex > 0 Then
            condiciones.Add("id_autor = " & cboAutor.SelectedValue.ToString())
        End If

        ' 3. Filtro de Texto (Búsqueda por título o autor)
        If Not String.IsNullOrWhiteSpace(txtBuscar.Text) Then
            Dim busqueda As String = txtBuscar.Text.Trim().Replace("'", "''")
            condiciones.Add(String.Format("(titulo LIKE '%{0}%' OR autor LIKE '%{0}%')", busqueda))
        End If

        ' Aplicar la condición combinada
        If condiciones.Count > 0 Then
            bsLibros.Filter = String.Join(" AND ", condiciones)
        Else
            bsLibros.Filter = ""
        End If

        ' Actualiza la cantidad de registros y la suma de ejemplares
        ActualizarContador()
        CalcularSumaEjemplares()
    End Sub


    ' Muestra en la barra inferior cuántos registros se ven.
    ' bsLibros.Count refleja el filtro aplicado; dtLibros.Rows.Count
    ' refleja el total traído del servidor.
    Private Sub ActualizarContador()
        lblRegistros.Text =
            $"{bsLibros.Count} de {dtLibros.Rows.Count} libro(s) en la vista"
    End Sub


    ' Ambos filtros llaman al mismo procedimiento.
    Private Sub cboCategoria_SelectedIndexChanged(sender As Object,
            e As EventArgs) Handles cboCategoria.SelectedIndexChanged
        AplicarFiltro()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object,
            e As EventArgs) Handles txtBuscar.TextChanged
        AplicarFiltro()
    End Sub


    ' ===== Punto de entrada del formulario =====
    Private Sub frmConsultaLibros_Load(sender As Object,
            e As EventArgs) Handles MyBase.Load

        Try
            ' 1. Agg la barra fisica al formulario
            bnLibros.Dock = DockStyle.Top
            Me.Controls.Add(bnLibros)
            bnLibros.BringToFront()
            cargando = True          ' se ignoran los eventos de filtro

            CargarCategorias()        ' 1. catálogo del ComboBox
            CargarAutores()
            CargarLibros()            ' 2. datos y enlaces
            ConfigurarColumnas()      ' 3. aspecto de la cuadrícula
            EnlazarDetalle()          ' 4. panel inferior

            cargando = False         ' ya se pueden atender los filtros
            ActualizarContador()      ' 5. estado inicial

        Catch ex As MySqlException
            ' Error propio de la base de datos: servidor apagado,
            ' credenciales incorrectas, base inexistente.
            MessageBox.Show("No se pudo consultar MariaDB." & vbCrLf & ex.Message,
                            "Error de base de datos",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception
            ' Cualquier otro error no previsto.
            MessageBox.Show("Error inesperado." & vbCrLf & ex.Message,
                            "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub CargarAutores()
        Dim dt As New DataTable()
        Dim sql As String = "SELECT id_autor, CONCAT(nombres, ' ', apellidos) AS nombre_completo FROM autor ORDER BY nombres"

        Using con As MySqlConnection = ModConexion.ObtenerConexion()
            Dim da As New MySqlDataAdapter(sql, con)
            da.Fill(dt)
        End Using

        ' Insertar la opción inicial (Todos los autores)
        Dim dr As DataRow = dt.NewRow()
        dr("id_autor") = 0
        dr("nombre_completo") = "(Todos los autores)"
        dt.Rows.InsertAt(dr, 0)

        cboAutor.DataSource = dt
        cboAutor.DisplayMember = "nombre_completo"
        cboAutor.ValueMember = "id_autor"
        cboAutor.SelectedIndex = 0
    End Sub

    Private Sub CalcularSumaEjemplares()
        Dim totalEjemplares As Integer = 0

        ' Recorrer el DataView filtrado exactamente como pide la pista del profe
        For Each drv As DataRowView In CType(bsLibros.List, DataView)
            If Not IsDBNull(drv("ejemplares")) Then
                totalEjemplares += Convert.ToInt32(drv("ejemplares"))
            End If
        Next

        ' Actualiza el nuevo Label del StatusStrip
        lblSumaEjemplares.Text = "Total ejemplares: " & totalEjemplares.ToString()
    End Sub

    Private Sub cboAutor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAutor.SelectedIndexChanged
        AplicarFiltro()
    End Sub
End Class
