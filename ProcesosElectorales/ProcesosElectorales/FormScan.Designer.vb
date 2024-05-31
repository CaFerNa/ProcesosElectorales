'
' Creado por SharpDevelop.
' Usuario: cfernandez
' Fecha: 07/11/2018
' Hora: 14:37
' 
' Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
'
Partial Class FormScan
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormScan))
		Me.textBox1 = New System.Windows.Forms.TextBox
		Me.btnAceptar = New System.Windows.Forms.Button
		Me.btnLimpiar = New System.Windows.Forms.Button
		Me.btnClose = New System.Windows.Forms.Button
		Me.dateTimePicker1 = New System.Windows.Forms.DateTimePicker
		Me.comboBox1 = New System.Windows.Forms.ComboBox
		Me.btnSoloLista = New System.Windows.Forms.Button
		Me.SuspendLayout
		'
		'textBox1
		'
		Me.textBox1.Location = New System.Drawing.Point(12, 12)
		Me.textBox1.Multiline = true
		Me.textBox1.Name = "textBox1"
		Me.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.textBox1.Size = New System.Drawing.Size(247, 370)
		Me.textBox1.TabIndex = 0
		'
		'btnAceptar
		'
		Me.btnAceptar.Location = New System.Drawing.Point(12, 495)
		Me.btnAceptar.Name = "btnAceptar"
		Me.btnAceptar.Size = New System.Drawing.Size(103, 39)
		Me.btnAceptar.TabIndex = 2
		Me.btnAceptar.Text = "Aceptar Listado"
		Me.btnAceptar.UseVisualStyleBackColor = true
		AddHandler Me.btnAceptar.Click, AddressOf Me.BtnAceptarClick
		'
		'btnLimpiar
		'
		Me.btnLimpiar.Location = New System.Drawing.Point(206, 450)
		Me.btnLimpiar.Name = "btnLimpiar"
		Me.btnLimpiar.Size = New System.Drawing.Size(53, 39)
		Me.btnLimpiar.TabIndex = 3
		Me.btnLimpiar.Text = "Limpiar"
		Me.btnLimpiar.UseVisualStyleBackColor = true
		AddHandler Me.btnLimpiar.Click, AddressOf Me.BtnLimpiarClick
		'
		'btnClose
		'
		Me.btnClose.Location = New System.Drawing.Point(156, 495)
		Me.btnClose.Name = "btnClose"
		Me.btnClose.Size = New System.Drawing.Size(103, 39)
		Me.btnClose.TabIndex = 5
		Me.btnClose.Text = "Cerrar"
		Me.btnClose.UseVisualStyleBackColor = true
		AddHandler Me.btnClose.Click, AddressOf Me.BtnCloseClick
		'
		'dateTimePicker1
		'
		Me.dateTimePicker1.CustomFormat = "dd/MM/yyyy"
		Me.dateTimePicker1.Location = New System.Drawing.Point(12, 425)
		Me.dateTimePicker1.Name = "dateTimePicker1"
		Me.dateTimePicker1.Size = New System.Drawing.Size(247, 20)
		Me.dateTimePicker1.TabIndex = 6
		'
		'comboBox1
		'
		Me.comboBox1.FormattingEnabled = true
		Me.comboBox1.Items.AddRange(New Object() {"", "NOTIFICADO", "ALEGACIONES", "IMPOSIBLE NOTIFICAR", "POR NOTIFICAR", "EXCUSADO", "NOTIFICADO & REMITIDO", "ALEGACIONES REMITIDAS", "IMPOSIBLE & REMITIDO"})
		Me.comboBox1.Location = New System.Drawing.Point(12, 398)
		Me.comboBox1.Name = "comboBox1"
		Me.comboBox1.Size = New System.Drawing.Size(247, 21)
		Me.comboBox1.TabIndex = 7
		'
		'btnSoloLista
		'
		Me.btnSoloLista.Location = New System.Drawing.Point(12, 450)
		Me.btnSoloLista.Name = "btnSoloLista"
		Me.btnSoloLista.Size = New System.Drawing.Size(103, 39)
		Me.btnSoloLista.TabIndex = 8
		Me.btnSoloLista.Text = "Solo Listar"
		Me.btnSoloLista.UseVisualStyleBackColor = true
		AddHandler Me.btnSoloLista.Click, AddressOf Me.BtnSoloListaClick
		'
		'FormScan
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(271, 546)
		Me.Controls.Add(Me.btnSoloLista)
		Me.Controls.Add(Me.comboBox1)
		Me.Controls.Add(Me.dateTimePicker1)
		Me.Controls.Add(Me.btnClose)
		Me.Controls.Add(Me.btnLimpiar)
		Me.Controls.Add(Me.btnAceptar)
		Me.Controls.Add(Me.textBox1)
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.Name = "FormScan"
		Me.Text = "Lector Código de Barras"
		AddHandler Load, AddressOf Me.FormScanLoad
		Me.ResumeLayout(false)
		Me.PerformLayout
	End Sub
	Private btnSoloLista As System.Windows.Forms.Button
	Private comboBox1 As System.Windows.Forms.ComboBox
	Private dateTimePicker1 As System.Windows.Forms.DateTimePicker
	Private btnClose As System.Windows.Forms.Button
	Private btnLimpiar As System.Windows.Forms.Button
	Private btnAceptar As System.Windows.Forms.Button
	Private textBox1 As System.Windows.Forms.TextBox
End Class
