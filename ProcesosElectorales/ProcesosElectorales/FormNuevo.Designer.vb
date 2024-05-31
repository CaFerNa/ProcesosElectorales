'
' Creado por SharpDevelop.
' Usuario: cfernandez
' Fecha: 29/10/2018
' Hora: 15:00
' 
' Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
'
Partial Class FormNuevo
	Inherits System.Windows.Forms.Form
	
	''' <summary>
	''' Designer variable used to keep track of non-visual components.
	''' </summary>
	Private components As System.ComponentModel.IContainer
	
	''' <summary>
	''' Disposes resources used by the form.
	''' </summary>
	''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing Then
			If components IsNot Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(disposing)
	End Sub
	
	''' <summary>
	''' This method is required for Windows Forms designer support.
	''' Do not change the method contents inside the source code editor. The Forms designer might
	''' not be able to load this method if it was changed manually.
	''' </summary>
	Private Sub InitializeComponent()
		Me.label1 = New System.Windows.Forms.Label
		Me.textBoxNombreProceso = New System.Windows.Forms.TextBox
		Me.btnOk = New System.Windows.Forms.Button
		Me.btnCancel = New System.Windows.Forms.Button
		Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog
		Me.SuspendLayout
		'
		'label1
		'
		Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.label1.Location = New System.Drawing.Point(12, 9)
		Me.label1.Name = "label1"
		Me.label1.Size = New System.Drawing.Size(471, 69)
		Me.label1.TabIndex = 0
		Me.label1.Text = "Nuevo Proceso Electoral"
		Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'textBoxNombreProceso
		'
		Me.textBoxNombreProceso.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.textBoxNombreProceso.Location = New System.Drawing.Point(12, 96)
		Me.textBoxNombreProceso.Name = "textBoxNombreProceso"
		Me.textBoxNombreProceso.Size = New System.Drawing.Size(471, 23)
		Me.textBoxNombreProceso.TabIndex = 1
		'
		'btnOk
		'
		Me.btnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom
		Me.btnOk.Location = New System.Drawing.Point(327, 163)
		Me.btnOk.Name = "btnOk"
		Me.btnOk.Size = New System.Drawing.Size(75, 23)
		Me.btnOk.TabIndex = 2
		Me.btnOk.Text = "Ok"
		Me.btnOk.UseVisualStyleBackColor = true
		AddHandler Me.btnOk.Click, AddressOf Me.BtnOkClick
		'
		'btnCancel
		'
		Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
		Me.btnCancel.Location = New System.Drawing.Point(408, 163)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(75, 23)
		Me.btnCancel.TabIndex = 3
		Me.btnCancel.Text = "Cancelar"
		Me.btnCancel.UseVisualStyleBackColor = true
		AddHandler Me.btnCancel.Click, AddressOf Me.BtnCancelClick
		'
		'openFileDialog1
		'
		Me.openFileDialog1.FileName = "openFileDialog1"
		'
		'FormNuevo
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(495, 198)
		Me.ControlBox = false
		Me.Controls.Add(Me.btnCancel)
		Me.Controls.Add(Me.btnOk)
		Me.Controls.Add(Me.textBoxNombreProceso)
		Me.Controls.Add(Me.label1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "FormNuevo"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Nuevo Proceso Electoral"
		Me.ResumeLayout(false)
		Me.PerformLayout
	End Sub
	Private openFileDialog1 As System.Windows.Forms.OpenFileDialog
	Private btnCancel As System.Windows.Forms.Button
	Private btnOk As System.Windows.Forms.Button
	Private textBoxNombreProceso As System.Windows.Forms.TextBox
	Private label1 As System.Windows.Forms.Label
End Class
