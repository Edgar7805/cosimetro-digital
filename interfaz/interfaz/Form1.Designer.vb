<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.PuertoCom = New System.IO.Ports.SerialPort(Me.components)
        Me.Lbrespuesta = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.Ayuda2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Btnconectar = New System.Windows.Forms.Button()
        Me.Cbopuertos = New System.Windows.Forms.ComboBox()
        Me.Btnbuscarpuertos = New System.Windows.Forms.Button()
        Me.Txtdatosrecibidos = New System.Windows.Forms.TextBox()
        Me.Btnevniardatos = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PuertoCom
        '
        '
        'Lbrespuesta
        '
        Me.Lbrespuesta.AutoSize = True
        Me.Lbrespuesta.BackColor = System.Drawing.Color.Transparent
        Me.Lbrespuesta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbrespuesta.Location = New System.Drawing.Point(120, 165)
        Me.Lbrespuesta.Name = "Lbrespuesta"
        Me.Lbrespuesta.Size = New System.Drawing.Size(111, 15)
        Me.Lbrespuesta.TabIndex = 7
        Me.Lbrespuesta.Text = "Datos recibidos:"
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.SlateGray
        Me.MenuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Ayuda2ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuStrip1.Size = New System.Drawing.Size(753, 24)
        Me.MenuStrip1.TabIndex = 16
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'Ayuda2ToolStripMenuItem
        '
        Me.Ayuda2ToolStripMenuItem.Name = "Ayuda2ToolStripMenuItem"
        Me.Ayuda2ToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.Ayuda2ToolStripMenuItem.Text = "Ayuda"
        '
        'Btnconectar
        '
        Me.Btnconectar.Location = New System.Drawing.Point(187, 43)
        Me.Btnconectar.Name = "Btnconectar"
        Me.Btnconectar.Size = New System.Drawing.Size(75, 23)
        Me.Btnconectar.TabIndex = 3
        Me.Btnconectar.Text = "CONECTAR"
        Me.Btnconectar.UseVisualStyleBackColor = True
        '
        'Cbopuertos
        '
        Me.Cbopuertos.FormattingEnabled = True
        Me.Cbopuertos.Location = New System.Drawing.Point(91, 43)
        Me.Cbopuertos.Name = "Cbopuertos"
        Me.Cbopuertos.Size = New System.Drawing.Size(90, 21)
        Me.Cbopuertos.TabIndex = 1
        Me.Cbopuertos.Text = "-Seleccionar-"
        '
        'Btnbuscarpuertos
        '
        Me.Btnbuscarpuertos.Location = New System.Drawing.Point(10, 41)
        Me.Btnbuscarpuertos.Name = "Btnbuscarpuertos"
        Me.Btnbuscarpuertos.Size = New System.Drawing.Size(75, 23)
        Me.Btnbuscarpuertos.TabIndex = 2
        Me.Btnbuscarpuertos.Text = "buscar puertos"
        Me.Btnbuscarpuertos.UseVisualStyleBackColor = True
        '
        'Txtdatosrecibidos
        '
        Me.Txtdatosrecibidos.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Txtdatosrecibidos.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtdatosrecibidos.ForeColor = System.Drawing.Color.Lime
        Me.Txtdatosrecibidos.Location = New System.Drawing.Point(9, 205)
        Me.Txtdatosrecibidos.Multiline = True
        Me.Txtdatosrecibidos.Name = "Txtdatosrecibidos"
        Me.Txtdatosrecibidos.Size = New System.Drawing.Size(732, 52)
        Me.Txtdatosrecibidos.TabIndex = 6
        Me.Txtdatosrecibidos.Text = "Esperando datos....."
        '
        'Btnevniardatos
        '
        Me.Btnevniardatos.Location = New System.Drawing.Point(10, 162)
        Me.Btnevniardatos.Name = "Btnevniardatos"
        Me.Btnevniardatos.Size = New System.Drawing.Size(75, 23)
        Me.Btnevniardatos.TabIndex = 4
        Me.Btnevniardatos.Text = "enviar datos"
        Me.Btnevniardatos.UseVisualStyleBackColor = True
        Me.Btnevniardatos.Visible = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(753, 262)
        Me.Controls.Add(Me.Btnbuscarpuertos)
        Me.Controls.Add(Me.Btnconectar)
        Me.Controls.Add(Me.Btnevniardatos)
        Me.Controls.Add(Me.Cbopuertos)
        Me.Controls.Add(Me.Lbrespuesta)
        Me.Controls.Add(Me.Txtdatosrecibidos)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Power Monitor"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PuertoCom As IO.Ports.SerialPort
    Friend WithEvents Lbrespuesta As Label
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents Ayuda2ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Btnconectar As Button
    Friend WithEvents Cbopuertos As ComboBox
    Friend WithEvents Btnbuscarpuertos As Button
    Friend WithEvents Txtdatosrecibidos As TextBox
    Friend WithEvents Btnevniardatos As Button
End Class
