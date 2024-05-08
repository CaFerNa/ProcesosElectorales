'
' Creado por SharpDevelop.
' Usuario: cfernandez
' Fecha: 26/10/2018
' Hora: 12:10
' 
' Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
'
Partial Class FormSelectProceso
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
		Me.btnOk = New System.Windows.Forms.Button
		Me.btnCancel = New System.Windows.Forms.Button
		Me.dataGridView1 = New System.Windows.Forms.DataGridView
		Me.dataSet1 = New System.Data.DataSet
		CType(Me.dataGridView1,System.ComponentModel.ISupportInitialize).BeginInit
		CType(Me.dataSet1,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'btnOk
		'
		Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.btnOk.Location = New System.Drawing.Point(479, 279)
		Me.btnOk.Name = "btnOk"
		Me.btnOk.Size = New System.Drawing.Size(75, 23)
		Me.btnOk.TabIndex = 0
		Me.btnOk.Text = "Ok"
		Me.btnOk.UseVisualStyleBackColor = true
		AddHandler Me.btnOk.Click, AddressOf Me.BtnOkClick
		'
		'btnCancel
		'
		Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.btnCancel.Location = New System.Drawing.Point(560, 279)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(75, 23)
		Me.btnCancel.TabIndex = 1
		Me.btnCancel.Text = "Cancelar"
		Me.btnCancel.UseVisualStyleBackColor = true
		AddHandler Me.btnCancel.Click, AddressOf Me.BtnCancelClick
		'
		'dataGridView1
		'
		Me.dataGridView1.AllowUserToAddRows = false
		Me.dataGridView1.AllowUserToDeleteRows = false
		Me.dataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
						Or System.Windows.Forms.AnchorStyles.Left)  _
						Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
		Me.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
		Me.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control
		Me.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dataGridView1.ColumnHeadersVisible = false
		Me.dataGridView1.ImeMode = System.Windows.Forms.ImeMode.Off
		Me.dataGridView1.Location = New System.Drawing.Point(12, 12)
		Me.dataGridView1.MultiSelect = false
		Me.dataGridView1.Name = "dataGridView1"
		Me.dataGridView1.ReadOnly = true
		Me.dataGridView1.RowHeadersVisible = false
		Me.dataGridView1.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
		Me.dataGridView1.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.dataGridView1.RowTemplate.Height = 24
		Me.dataGridView1.RowTemplate.ReadOnly = true
		Me.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.dataGridView1.Size = New System.Drawing.Size(623, 261)
		Me.dataGridView1.TabIndex = 2
		AddHandler Me.dataGridView1.DoubleClick, AddressOf Me.BtnOkClick
		'
		'dataSet1
		'
		Me.dataSet1.DataSetName = "NewDataSet"
		'
		'FormSelectProceso
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(647, 327)
		Me.ControlBox = false
		Me.Controls.Add(Me.dataGridView1)
		Me.Controls.Add(Me.btnCancel)
		Me.Controls.Add(Me.btnOk)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "FormSelectProceso"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Seleccione Proceso Electoral"
		CType(Me.dataGridView1,System.ComponentModel.ISupportInitialize).EndInit
		CType(Me.dataSet1,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)
	End Sub
	Private dataSet1 As System.Data.DataSet
	Private dataGridView1 As System.Windows.Forms.DataGridView
	Private btnCancel As System.Windows.Forms.Button
	Private btnOk As System.Windows.Forms.Button
End Class
