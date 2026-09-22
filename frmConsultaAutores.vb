Imports System.Data
Imports MySqlConnector

Public Class frmConsultaAutores

    Private ReadOnly bsAutores As New BindingSource()
    Private ReadOnly bnAutores As New BindingNavigator(True)
    Private dtAutores As New DataTable()
    Private cargando As Boolean = True

    Private Sub frmConsultaAutores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Configurar y posicionar el BindingNavigator arriba automáticamente
            bnAutores.Dock = DockStyle.Top
            Me.Controls.Add(bnAutores)
            bnAutores.BringToFront()

            cargando = True
            CargarNacionalidades()
            CargarAutores()
            ConfigurarColumnas()
            EnlazarDetalle()
            cargando = False
            ActualizarContador()

        Catch ex As Exception
            MessageBox.Show("Error al cargar autores: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ==========================================
    ' MÉTODOS DE DATOS Y CARGA
    ' ==========================================
    Private Sub CargarNacionalidades()
        Dim dtNac As New DataTable()
        Using cn As MySqlConnection = ObtenerConexion()
            ' Instrucción requerida para traer las nacionalidades sin repetir
            Dim sql As String = "SELECT DISTINCT nacionalidad FROM autor ORDER BY nacionalidad;"
            Using da As New MySqlDataAdapter(sql, cn)
                da.Fill(dtNac)
            End Using
        End Using

        ' Agregar la opción por defecto para ver todos
        Dim filaTodas As DataRow = dtNac.NewRow()
        filaTodas("nacionalidad") = "(Todas las nacionalidades)"
        dtNac.Rows.InsertAt(filaTodas, 0)

        cboNacionalidad.DataSource = dtNac
        cboNacionalidad.DisplayMember = "nacionalidad"
        cboNacionalidad.ValueMember = "nacionalidad"
        cboNacionalidad.SelectedIndex = 0
    End Sub

    Private Sub CargarAutores()
        dtAutores = New DataTable()
        Using cn As MySqlConnection = ObtenerConexion()
            Dim sql As String = "SELECT id_autor, nombres, apellidos, nacionalidad FROM autor ORDER BY nombres;"
            Using da As New MySqlDataAdapter(sql, cn)
                da.Fill(dtAutores)
            End Using
        End Using

        ' Enlazar la fuente de datos a la cuadrícula y al BindingNavigator de forma unificada
        bsAutores.DataSource = dtAutores
        dgvAutores.DataSource = bsAutores
        bnAutores.BindingSource = bsAutores
    End Sub

    ' ==========================================
    ' CONFIGURACIÓN VISUAL Y ENLACES (DATA BINDING)
    ' ==========================================
    Private Sub ConfigurarColumnas()
        dgvAutores.Columns("id_autor").Visible = False
        dgvAutores.Columns("nombres").HeaderText = "Nombres"
        dgvAutores.Columns("apellidos").HeaderText = "Apellidos"
        dgvAutores.Columns("nacionalidad").HeaderText = "Nacionalidad"
        dgvAutores.Columns("nombres").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgvAutores.Columns("apellidos").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgvAutores.Columns("nacionalidad").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub

    Private Sub EnlazarDetalle()
        ' Conecta las cajas de texto inferiores con el BindingSource para sincronizar los registros
        txtNombres.DataBindings.Add("Text", bsAutores, "nombres")
        txtApellidos.DataBindings.Add("Text", bsAutores, "apellidos")
        txtNacionalidad.DataBindings.Add("Text", bsAutores, "nacionalidad")
    End Sub

    ' ==========================================
    ' FILTRADO Y CONTADOR DE REGISTROS
    ' ==========================================
    Private Sub AplicarFiltro()
        If cargando Then Exit Sub

        If cboNacionalidad.SelectedIndex > 0 Then
            Dim nacSel As String = cboNacionalidad.SelectedValue.ToString().Replace("'", "''")
            bsAutores.Filter = String.Format("nacionalidad = '{0}'", nacSel)
        Else
            bsAutores.Filter = ""
        End If

        ActualizarContador()
    End Sub

    Private Sub ActualizarContador()
        lblRegistros.Text = $"{bsAutores.Count} de {dtAutores.Rows.Count} autor(es) en la vista"
    End Sub

    Private Sub cboNacionalidad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboNacionalidad.SelectedIndexChanged
        AplicarFiltro()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class