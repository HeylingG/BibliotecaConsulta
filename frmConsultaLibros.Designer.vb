<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmConsultaLibros
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        lblCategoria = New Label()
        cboCategoria = New ComboBox()
        lblBuscar = New Label()
        txtBuscar = New TextBox()
        dgvLibros = New DataGridView()
        grpFiltros = New GroupBox()
        Label7 = New Label()
        cboAutor = New ComboBox()
        stsEstado = New StatusStrip()
        lblRegistros = New ToolStripStatusLabel()
        lblSumaEjemplares = New ToolStripStatusLabel()
        grpDetalle = New GroupBox()
        tlpDetalle = New TableLayoutPanel()
        txtCategoria = New TextBox()
        txtAnio = New TextBox()
        txtPrecio = New TextBox()
        txtEjemplares = New TextBox()
        txtTitulo = New TextBox()
        txtAutor = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        CType(dgvLibros, ComponentModel.ISupportInitialize).BeginInit()
        grpFiltros.SuspendLayout()
        stsEstado.SuspendLayout()
        grpDetalle.SuspendLayout()
        tlpDetalle.SuspendLayout()
        SuspendLayout()
        ' 
        ' lblCategoria
        ' 
        lblCategoria.AutoSize = True
        lblCategoria.Location = New Point(6, 40)
        lblCategoria.Name = "lblCategoria"
        lblCategoria.Size = New Size(92, 25)
        lblCategoria.TabIndex = 0
        lblCategoria.Text = "Categoría:"
        ' 
        ' cboCategoria
        ' 
        cboCategoria.DropDownStyle = ComboBoxStyle.DropDownList
        cboCategoria.FormattingEnabled = True
        cboCategoria.Location = New Point(93, 32)
        cboCategoria.Name = "cboCategoria"
        cboCategoria.Size = New Size(161, 33)
        cboCategoria.TabIndex = 1
        ' 
        ' lblBuscar
        ' 
        lblBuscar.AutoSize = True
        lblBuscar.Location = New Point(520, 38)
        lblBuscar.Name = "lblBuscar"
        lblBuscar.Size = New Size(146, 25)
        lblBuscar.TabIndex = 2
        lblBuscar.Text = "Buscar por título:"
        ' 
        ' txtBuscar
        ' 
        txtBuscar.Location = New Point(672, 33)
        txtBuscar.Name = "txtBuscar"
        txtBuscar.PlaceholderText = "Escriba parte del título"
        txtBuscar.Size = New Size(194, 31)
        txtBuscar.TabIndex = 3
        ' 
        ' dgvLibros
        ' 
        dgvLibros.AllowUserToAddRows = False
        dgvLibros.AllowUserToDeleteRows = False
        dgvLibros.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvLibros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvLibros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvLibros.Location = New Point(12, 133)
        dgvLibros.MultiSelect = False
        dgvLibros.Name = "dgvLibros"
        dgvLibros.ReadOnly = True
        dgvLibros.RowHeadersVisible = False
        dgvLibros.RowHeadersWidth = 62
        dgvLibros.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvLibros.Size = New Size(822, 160)
        dgvLibros.TabIndex = 4
        ' 
        ' grpFiltros
        ' 
        grpFiltros.Controls.Add(Label7)
        grpFiltros.Controls.Add(cboAutor)
        grpFiltros.Controls.Add(cboCategoria)
        grpFiltros.Controls.Add(lblCategoria)
        grpFiltros.Controls.Add(txtBuscar)
        grpFiltros.Controls.Add(lblBuscar)
        grpFiltros.Dock = DockStyle.Top
        grpFiltros.Location = New Point(0, 0)
        grpFiltros.Name = "grpFiltros"
        grpFiltros.Size = New Size(878, 70)
        grpFiltros.TabIndex = 5
        grpFiltros.TabStop = False
        grpFiltros.Text = "Filtros de consulta"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(278, 38)
        Label7.Name = "Label7"
        Label7.Size = New Size(57, 25)
        Label7.TabIndex = 5
        Label7.Text = "Autor"
        ' 
        ' cboAutor
        ' 
        cboAutor.FormattingEnabled = True
        cboAutor.Location = New Point(341, 32)
        cboAutor.Name = "cboAutor"
        cboAutor.Size = New Size(159, 33)
        cboAutor.TabIndex = 4
        ' 
        ' stsEstado
        ' 
        stsEstado.ImageScalingSize = New Size(24, 24)
        stsEstado.Items.AddRange(New ToolStripItem() {lblRegistros, lblSumaEjemplares})
        stsEstado.Location = New Point(0, 532)
        stsEstado.Name = "stsEstado"
        stsEstado.Size = New Size(878, 32)
        stsEstado.SizingGrip = False
        stsEstado.TabIndex = 6
        stsEstado.Text = "StatusStrip1"
        ' 
        ' lblRegistros
        ' 
        lblRegistros.Name = "lblRegistros"
        lblRegistros.Size = New Size(136, 25)
        lblRegistros.Text = "0 de 0 registros"
        ' 
        ' lblSumaEjemplares
        ' 
        lblSumaEjemplares.Name = "lblSumaEjemplares"
        lblSumaEjemplares.Size = New Size(0, 25)
        ' 
        ' grpDetalle
        ' 
        grpDetalle.Controls.Add(tlpDetalle)
        grpDetalle.Dock = DockStyle.Bottom
        grpDetalle.Location = New Point(0, 343)
        grpDetalle.Name = "grpDetalle"
        grpDetalle.Size = New Size(878, 189)
        grpDetalle.TabIndex = 7
        grpDetalle.TabStop = False
        grpDetalle.Text = "Detalle del registro seleccionado"
        ' 
        ' tlpDetalle
        ' 
        tlpDetalle.ColumnCount = 3
        tlpDetalle.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 45.3333321F))
        tlpDetalle.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 54.6666679F))
        tlpDetalle.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 271F))
        tlpDetalle.Controls.Add(txtCategoria, 2, 1)
        tlpDetalle.Controls.Add(txtAnio, 0, 3)
        tlpDetalle.Controls.Add(txtPrecio, 2, 3)
        tlpDetalle.Controls.Add(txtEjemplares, 1, 3)
        tlpDetalle.Controls.Add(txtTitulo, 0, 1)
        tlpDetalle.Controls.Add(txtAutor, 1, 1)
        tlpDetalle.Controls.Add(Label1, 0, 0)
        tlpDetalle.Controls.Add(Label2, 1, 0)
        tlpDetalle.Controls.Add(Label3, 2, 0)
        tlpDetalle.Controls.Add(Label4, 0, 2)
        tlpDetalle.Controls.Add(Label5, 1, 2)
        tlpDetalle.Controls.Add(Label6, 2, 2)
        tlpDetalle.Dock = DockStyle.Fill
        tlpDetalle.Location = New Point(3, 27)
        tlpDetalle.Name = "tlpDetalle"
        tlpDetalle.RowCount = 4
        tlpDetalle.RowStyles.Add(New RowStyle(SizeType.Percent, 46.1538467F))
        tlpDetalle.RowStyles.Add(New RowStyle(SizeType.Percent, 53.8461533F))
        tlpDetalle.RowStyles.Add(New RowStyle(SizeType.Absolute, 41F))
        tlpDetalle.RowStyles.Add(New RowStyle(SizeType.Absolute, 34F))
        tlpDetalle.Size = New Size(872, 159)
        tlpDetalle.TabIndex = 0
        ' 
        ' txtCategoria
        ' 
        txtCategoria.BorderStyle = BorderStyle.FixedSingle
        txtCategoria.Location = New Point(603, 41)
        txtCategoria.Name = "txtCategoria"
        txtCategoria.ReadOnly = True
        txtCategoria.Size = New Size(260, 31)
        txtCategoria.TabIndex = 2
        txtCategoria.TabStop = False
        ' 
        ' txtAnio
        ' 
        txtAnio.BorderStyle = BorderStyle.FixedSingle
        txtAnio.Location = New Point(3, 127)
        txtAnio.Name = "txtAnio"
        txtAnio.ReadOnly = True
        txtAnio.Size = New Size(266, 31)
        txtAnio.TabIndex = 3
        txtAnio.TabStop = False
        ' 
        ' txtPrecio
        ' 
        txtPrecio.BorderStyle = BorderStyle.FixedSingle
        txtPrecio.Location = New Point(603, 127)
        txtPrecio.Name = "txtPrecio"
        txtPrecio.ReadOnly = True
        txtPrecio.Size = New Size(260, 31)
        txtPrecio.TabIndex = 5
        txtPrecio.TabStop = False
        ' 
        ' txtEjemplares
        ' 
        txtEjemplares.BorderStyle = BorderStyle.FixedSingle
        txtEjemplares.Location = New Point(275, 127)
        txtEjemplares.Name = "txtEjemplares"
        txtEjemplares.ReadOnly = True
        txtEjemplares.Size = New Size(322, 31)
        txtEjemplares.TabIndex = 4
        txtEjemplares.TabStop = False
        ' 
        ' txtTitulo
        ' 
        txtTitulo.BorderStyle = BorderStyle.FixedSingle
        txtTitulo.Location = New Point(3, 41)
        txtTitulo.Name = "txtTitulo"
        txtTitulo.ReadOnly = True
        txtTitulo.Size = New Size(266, 31)
        txtTitulo.TabIndex = 0
        txtTitulo.TabStop = False
        ' 
        ' txtAutor
        ' 
        txtAutor.BorderStyle = BorderStyle.FixedSingle
        txtAutor.Location = New Point(275, 41)
        txtAutor.Name = "txtAutor"
        txtAutor.ReadOnly = True
        txtAutor.Size = New Size(322, 31)
        txtAutor.TabIndex = 1
        txtAutor.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(3, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(56, 25)
        Label1.TabIndex = 6
        Label1.Text = "Titulo"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(275, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(57, 25)
        Label2.TabIndex = 7
        Label2.Text = "Autor"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(603, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(88, 25)
        Label3.TabIndex = 8
        Label3.Text = "Categoria"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(3, 83)
        Label4.Name = "Label4"
        Label4.Size = New Size(45, 25)
        Label4.TabIndex = 9
        Label4.Text = "Año"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(275, 83)
        Label5.Name = "Label5"
        Label5.Size = New Size(97, 25)
        Label5.TabIndex = 10
        Label5.Text = "Ejemplares"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(603, 83)
        Label6.Name = "Label6"
        Label6.Size = New Size(60, 25)
        Label6.TabIndex = 11
        Label6.Text = "Precio"
        ' 
        ' frmConsultaLibros
        ' 
        AutoScaleMode = AutoScaleMode.None
        ClientSize = New Size(878, 564)
        Controls.Add(grpDetalle)
        Controls.Add(stsEstado)
        Controls.Add(grpFiltros)
        Controls.Add(dgvLibros)
        MinimumSize = New Size(780, 560)
        Name = "frmConsultaLibros"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Consulta de libros — Biblioteca"
        CType(dgvLibros, ComponentModel.ISupportInitialize).EndInit()
        grpFiltros.ResumeLayout(False)
        grpFiltros.PerformLayout()
        stsEstado.ResumeLayout(False)
        stsEstado.PerformLayout()
        grpDetalle.ResumeLayout(False)
        tlpDetalle.ResumeLayout(False)
        tlpDetalle.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblCategoria As Label
    Friend WithEvents cboCategoria As ComboBox
    Friend WithEvents lblBuscar As Label
    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents dgvLibros As DataGridView
    Friend WithEvents grpFiltros As GroupBox
    Friend WithEvents stsEstado As StatusStrip
    Friend WithEvents grpDetalle As GroupBox
    Friend WithEvents tlpDetalle As TableLayoutPanel
    Friend WithEvents txtTitulo As TextBox
    Friend WithEvents txtAutor As TextBox
    Friend WithEvents txtCategoria As TextBox
    Friend WithEvents txtAnio As TextBox
    Friend WithEvents txtEjemplares As TextBox
    Friend WithEvents txtPrecio As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblRegistros As ToolStripStatusLabel
    Friend WithEvents Label7 As Label
    Friend WithEvents cboAutor As ComboBox
    Friend WithEvents lblSumaEjemplares As ToolStripStatusLabel

End Class
