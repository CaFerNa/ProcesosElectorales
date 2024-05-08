'
' Creado por SharpDevelop.
' Usuario: usuario
' Fecha: 04/11/2018
' Hora: 18:31
' 
' Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
'
Partial Class FormOpciones
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
		Me.components = New System.ComponentModel.Container
		Me.txbBase = New System.Windows.Forms.TextBox
		Me.label1 = New System.Windows.Forms.Label
		Me.btnBase = New System.Windows.Forms.Button
		Me.btnCancel = New System.Windows.Forms.Button
		Me.btnOk = New System.Windows.Forms.Button
		Me.btnPlantillas = New System.Windows.Forms.Button
		Me.label2 = New System.Windows.Forms.Label
		Me.txtTempl = New System.Windows.Forms.TextBox
		Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog
		Me.folderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
		Me.btnImport = New System.Windows.Forms.Button
		Me.toolTip1 = New System.Windows.Forms.ToolTip(Me.components)
		Me.listBoxColumnas = New System.Windows.Forms.CheckedListBox
		Me.label3 = New System.Windows.Forms.Label
		Me.btnWord = New System.Windows.Forms.Button
		Me.label4 = New System.Windows.Forms.Label
		Me.txtWord = New System.Windows.Forms.TextBox
		Me.chkBoxCellSelectAll = New System.Windows.Forms.CheckBox
		Me.SuspendLayout
		'
		'txbBase
		'
		Me.txbBase.Location = New System.Drawing.Point(128, 15)
		Me.txbBase.Name = "txbBase"
		Me.txbBase.Size = New System.Drawing.Size(300, 20)
		Me.txbBase.TabIndex = 0
		'
		'label1
		'
		Me.label1.Location = New System.Drawing.Point(12, 15)
		Me.label1.Name = "label1"
		Me.label1.Size = New System.Drawing.Size(87, 17)
		Me.label1.TabIndex = 1
		Me.label1.Text = "Base de Datos:"
		'
		'btnBase
		'
		Me.btnBase.Location = New System.Drawing.Point(434, 10)
		Me.btnBase.Name = "btnBase"
		Me.btnBase.Size = New System.Drawing.Size(26, 28)
		Me.btnBase.TabIndex = 2
		Me.btnBase.Text = "..."
		Me.btnBase.UseVisualStyleBackColor = true
		AddHandler Me.btnBase.Click, AddressOf Me.BtnBaseClick
		'
		'btnCancel
		'
		Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
		Me.btnCancel.Location = New System.Drawing.Point(380, 272)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(69, 23)
		Me.btnCancel.TabIndex = 3
		Me.btnCancel.Text = "Cancelar"
		Me.btnCancel.UseVisualStyleBackColor = true
		AddHandler Me.btnCancel.Click, AddressOf Me.BtnCancelClick
		'
		'btnOk
		'
		Me.btnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom
		Me.btnOk.Location = New System.Drawing.Point(305, 272)
		Me.btnOk.Name = "btnOk"
		Me.btnOk.Size = New System.Drawing.Size(69, 23)
		Me.btnOk.TabIndex = 4
		Me.btnOk.Text = "Aceptar"
		Me.btnOk.UseVisualStyleBackColor = true
		AddHandler Me.btnOk.Click, AddressOf Me.BtnOkClick
		'
		'btnPlantillas
		'
		Me.btnPlantillas.Location = New System.Drawing.Point(434, 58)
		Me.btnPlantillas.Name = "btnPlantillas"
		Me.btnPlantillas.Size = New System.Drawing.Size(26, 28)
		Me.btnPlantillas.TabIndex = 7
		Me.btnPlantillas.Text = "..."
		Me.btnPlantillas.UseVisualStyleBackColor = true
		AddHandler Me.btnPlantillas.Click, AddressOf Me.btnPlantillasClick
		'
		'label2
		'
		Me.label2.Location = New System.Drawing.Point(12, 63)
		Me.label2.Name = "label2"
		Me.label2.Size = New System.Drawing.Size(111, 17)
		Me.label2.TabIndex = 6
		Me.label2.Text = "Carpeta de Plantillas"
		'
		'txtTempl
		'
		Me.txtTempl.Location = New System.Drawing.Point(128, 63)
		Me.txtTempl.Name = "txtTempl"
		Me.txtTempl.Size = New System.Drawing.Size(300, 20)
		Me.txtTempl.TabIndex = 5
		'
		'openFileDialog1
		'
		Me.openFileDialog1.FileName = "openFileDialog1"
		'
		'btnImport
		'
		Me.btnImport.Location = New System.Drawing.Point(12, 163)
		Me.btnImport.Name = "btnImport"
		Me.btnImport.Size = New System.Drawing.Size(75, 36)
		Me.btnImport.TabIndex = 8
		Me.btnImport.Text = "Importar Sorteos"
		Me.btnImport.UseVisualStyleBackColor = true
		AddHandler Me.btnImport.Click, AddressOf Me.BtnImportClick
		'
		'listBoxColumnas
		'
		Me.listBoxColumnas.CheckOnClick = true
		Me.listBoxColumnas.FormattingEnabled = true
		Me.listBoxColumnas.Items.AddRange(New Object() {"NMUNI", "DIST", "SECC", "MESA", "NLOCAL", "NLOCALB", "INFADICIONAL", "DIRMESA1", "DIRMESA2", "DIRMESA3", "DIRMESA4", "CARGOFINAL", "NOLISTA", "GRES", "IDENT", "NOMBRE", "APELLIDO1", "APELLIDO2", "DOMI1", "DOMI2", "DOMI3", "DOMI4", "DOMI5", "CPOSTAL", "ESTADO", "FECHA", "SORTEO"})
		Me.listBoxColumnas.Location = New System.Drawing.Point(305, 163)
		Me.listBoxColumnas.Name = "listBoxColumnas"
		Me.listBoxColumnas.ScrollAlwaysVisible = true
		Me.listBoxColumnas.Size = New System.Drawing.Size(144, 94)
		Me.listBoxColumnas.TabIndex = 9
		'
		'label3
		'
		Me.label3.Location = New System.Drawing.Point(199, 163)
		Me.label3.Name = "label3"
		Me.label3.Size = New System.Drawing.Size(100, 23)
		Me.label3.TabIndex = 10
		Me.label3.Text = "Columnas Visibles"
		'
		'btnWord
		'
		Me.btnWord.Location = New System.Drawing.Point(434, 104)
		Me.btnWord.Name = "btnWord"
		Me.btnWord.Size = New System.Drawing.Size(26, 28)
		Me.btnWord.TabIndex = 14
		Me.btnWord.Text = "..."
		Me.btnWord.UseVisualStyleBackColor = true
		AddHandler Me.btnWord.Click, AddressOf Me.BtnWordClick
		'
		'label4
		'
		Me.label4.Location = New System.Drawing.Point(12, 109)
		Me.label4.Name = "label4"
		Me.label4.Size = New System.Drawing.Size(111, 17)
		Me.label4.TabIndex = 13
		Me.label4.Text = "Word"
		'
		'txtWord
		'
		Me.txtWord.Location = New System.Drawing.Point(128, 109)
		Me.txtWord.Name = "txtWord"
		Me.txtWord.Size = New System.Drawing.Size(300, 20)
		Me.txtWord.TabIndex = 12
		'
		'chkBoxCellSelectAll
		'
		Me.chkBoxCellSelectAll.Location = New System.Drawing.Point(12, 249)
		Me.chkBoxCellSelectAll.Name = "chkBoxCellSelectAll"
		Me.chkBoxCellSelectAll.Size = New System.Drawing.Size(160, 24)
		Me.chkBoxCellSelectAll.TabIndex = 15
		Me.chkBoxCellSelectAll.Text = "Seleccionar Todos"
		Me.chkBoxCellSelectAll.UseVisualStyleBackColor = true
		AddHandler Me.chkBoxCellSelectAll.CheckedChanged, AddressOf Me.ChkBoxCellSelectModeCheckedChanged
		'
		'FormOpciones
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(467, 317)
		Me.ControlBox = false
		Me.Controls.Add(Me.chkBoxCellSelectAll)
		Me.Controls.Add(Me.btnWord)
		Me.Controls.Add(Me.label4)
		Me.Controls.Add(Me.txtWord)
		Me.Controls.Add(Me.label3)
		Me.Controls.Add(Me.listBoxColumnas)
		Me.Controls.Add(Me.btnImport)
		Me.Controls.Add(Me.btnPlantillas)
		Me.Controls.Add(Me.label2)
		Me.Controls.Add(Me.txtTempl)
		Me.Controls.Add(Me.btnOk)
		Me.Controls.Add(Me.btnCancel)
		Me.Controls.Add(Me.btnBase)
		Me.Controls.Add(Me.label1)
		Me.Controls.Add(Me.txbBase)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "FormOpciones"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Opciones"
		Me.ResumeLayout(false)
		Me.PerformLayout
	End Sub
	Private listBoxColumnas As System.Windows.Forms.CheckedListBox
	Private chkBoxCellSelectAll As System.Windows.Forms.CheckBox
	Private txtWord As System.Windows.Forms.TextBox
	Private label4 As System.Windows.Forms.Label
	Private btnWord As System.Windows.Forms.Button
	Private label3 As System.Windows.Forms.Label
	Private toolTip1 As System.Windows.Forms.ToolTip
	Private btnImport As System.Windows.Forms.Button
	Private btnPlantillas As System.Windows.Forms.Button
	Private folderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
	Private txtTempl As System.Windows.Forms.TextBox
	Private openFileDialog1 As System.Windows.Forms.OpenFileDialog
	Private txbBase As System.Windows.Forms.TextBox
	Private label2 As System.Windows.Forms.Label
	Private btnOk As System.Windows.Forms.Button
	Private btnCancel As System.Windows.Forms.Button
	Private btnBase As System.Windows.Forms.Button
	Private label1 As System.Windows.Forms.Label
End Class
