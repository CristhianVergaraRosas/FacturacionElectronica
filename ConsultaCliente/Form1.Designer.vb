<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer
    Private txtQuery As TextBox
    Private dgvResultados As DataGridView

    Private Sub InitializeComponent()
        Me.txtQuery = New System.Windows.Forms.TextBox()
        Me.dgvResultados = New System.Windows.Forms.DataGridView()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.btnEjecutar = New System.Windows.Forms.Button()
        CType(Me.dgvResultados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtQuery
        '
        Me.txtQuery.Location = New System.Drawing.Point(12, 12)
        Me.txtQuery.Multiline = True
        Me.txtQuery.Name = "txtQuery"
        Me.txtQuery.Size = New System.Drawing.Size(600, 80)
        Me.txtQuery.TabIndex = 0
        '
        'dgvResultados
        '
        Me.dgvResultados.AllowUserToAddRows = False
        Me.dgvResultados.AllowUserToDeleteRows = False
        Me.dgvResultados.Location = New System.Drawing.Point(12, 100)
        Me.dgvResultados.Name = "dgvResultados"
        Me.dgvResultados.ReadOnly = True
        Me.dgvResultados.Size = New System.Drawing.Size(728, 400)
        Me.dgvResultados.TabIndex = 3
        '
        'btnExportar
        '
        Me.btnExportar.Location = New System.Drawing.Point(620, 54)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(120, 40)
        Me.btnExportar.TabIndex = 4
        Me.btnExportar.Text = "Exportar CSV"
        '
        'btnEjecutar
        '
        Me.btnEjecutar.Location = New System.Drawing.Point(620, 12)
        Me.btnEjecutar.Name = "btnEjecutar"
        Me.btnEjecutar.Size = New System.Drawing.Size(120, 40)
        Me.btnEjecutar.TabIndex = 5
        Me.btnEjecutar.Text = "Ejecutar"
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(752, 520)
        Me.Controls.Add(Me.btnEjecutar)
        Me.Controls.Add(Me.btnExportar)
        Me.Controls.Add(Me.txtQuery)
        Me.Controls.Add(Me.dgvResultados)
        Me.Name = "Form1"
        Me.Text = "Consulta SQL con WCF"
        CType(Me.dgvResultados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents btnExportar As System.Windows.Forms.Button
    Private WithEvents btnEjecutar As System.Windows.Forms.Button


End Class
