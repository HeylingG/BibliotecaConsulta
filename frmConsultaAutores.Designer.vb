<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaAutores
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        dgvAutores = New DataGridView()
        cboNacionalidad = New ComboBox()
        StatusStrip1 = New StatusStrip()
        lblRegistros = New ToolStripStatusLabel()
        Label1 = New Label()
        Panel1 = New Panel()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        txtApellidos = New TextBox()
        txtNombres = New TextBox()
        txtNacionalidad = New TextBox()
        CType(dgvAutores, ComponentModel.ISupportInitialize).BeginInit()
        StatusStrip1.SuspendLayout()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' dgvAutores
        ' 
        dgvAutores.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvAutores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvAutores.Location = New Point(12, 139)
        dgvAutores.Name = "dgvAutores"
        dgvAutores.RowHeadersWidth = 50
        dgvAutores.Size = New Size(843, 174)
        dgvAutores.TabIndex = 0
        ' 
        ' cboNacionalidad
        ' 
        cboNacionalidad.FormattingEnabled = True
        cboNacionalidad.Location = New Point(148, 73)
        cboNacionalidad.Name = "cboNacionalidad"
        cboNacionalidad.Size = New Size(239, 33)
        cboNacionalidad.TabIndex = 2
        ' 
        ' StatusStrip1
        ' 
        StatusStrip1.ImageScalingSize = New Size(24, 24)
        StatusStrip1.Items.AddRange(New ToolStripItem() {lblRegistros})
        StatusStrip1.Location = New Point(0, 532)
        StatusStrip1.Name = "StatusStrip1"
        StatusStrip1.Size = New Size(878, 32)
        StatusStrip1.TabIndex = 3
        StatusStrip1.Text = "StatusStrip1"
        ' 
        ' lblRegistros
        ' 
        lblRegistros.Name = "lblRegistros"
        lblRegistros.Size = New Size(180, 25)
        lblRegistros.Text = "ToolStripStatusLabel1"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(23, 76)
        Label1.Name = "Label1"
        Label1.Size = New Size(119, 25)
        Label1.TabIndex = 4
        Label1.Text = "Nacionalidad:"
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Panel1.BorderStyle = BorderStyle.FixedSingle
        Panel1.Controls.Add(txtNacionalidad)
        Panel1.Controls.Add(txtNombres)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(txtApellidos)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(Label3)
        Panel1.Location = New Point(12, 356)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(843, 155)
        Panel1.TabIndex = 5
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(22, 41)
        Label2.Name = "Label2"
        Label2.Size = New Size(90, 25)
        Label2.TabIndex = 0
        Label2.Text = "Nombres:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(328, 41)
        Label3.Name = "Label3"
        Label3.Size = New Size(90, 25)
        Label3.TabIndex = 1
        Label3.Text = "Apellidos:"
        ' 
        ' Label4
        ' 
        Label4.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        Label4.AutoSize = True
        Label4.Location = New Point(619, 41)
        Label4.Name = "Label4"
        Label4.Size = New Size(119, 25)
        Label4.TabIndex = 2
        Label4.Text = "Nacionalidad:"
        ' 
        ' txtApellidos
        ' 
        txtApellidos.Location = New Point(308, 85)
        txtApellidos.Name = "txtApellidos"
        txtApellidos.ReadOnly = True
        txtApellidos.Size = New Size(241, 31)
        txtApellidos.TabIndex = 4
        ' 
        ' txtNombres
        ' 
        txtNombres.Location = New Point(22, 85)
        txtNombres.Name = "txtNombres"
        txtNombres.ReadOnly = True
        txtNombres.Size = New Size(236, 31)
        txtNombres.TabIndex = 3
        ' 
        ' txtNacionalidad
        ' 
        txtNacionalidad.Location = New Point(570, 85)
        txtNacionalidad.Name = "txtNacionalidad"
        txtNacionalidad.ReadOnly = True
        txtNacionalidad.Size = New Size(247, 31)
        txtNacionalidad.TabIndex = 5
        ' 
        ' frmConsultaAutores
        ' 
        AutoScaleMode = AutoScaleMode.None
        ClientSize = New Size(878, 564)
        Controls.Add(Panel1)
        Controls.Add(Label1)
        Controls.Add(StatusStrip1)
        Controls.Add(cboNacionalidad)
        Controls.Add(dgvAutores)
        MinimumSize = New Size(780, 560)
        Name = "frmConsultaAutores"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Consulta de Autores"
        CType(dgvAutores, ComponentModel.ISupportInitialize).EndInit()
        StatusStrip1.ResumeLayout(False)
        StatusStrip1.PerformLayout()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents dgvAutores As DataGridView
    Friend WithEvents cboNacionalidad As ComboBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblRegistros As ToolStripStatusLabel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtNombres As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtApellidos As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtNacionalidad As TextBox
End Class
