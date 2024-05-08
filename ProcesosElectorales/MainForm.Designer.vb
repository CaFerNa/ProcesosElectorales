'
' Creado por SharpDevelop.
' Usuario: cfernandez
' Fecha: 11/10/2018
' Hora: 11:40
' 
' Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
'
Partial Class MainForm
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
		Me.btnAbrirProceso = New System.Windows.Forms.Button
		Me.btnNuevoProceso = New System.Windows.Forms.Button
		Me.bindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
		Me.dataSet1 = New System.Data.DataSet
		Me.label1 = New System.Windows.Forms.Label
		Me.panel1 = New System.Windows.Forms.Panel
		Me.btnMesa = New System.Windows.Forms.Button
		Me.btnQuitarFiltros = New System.Windows.Forms.Button
		Me.cbxSecc = New System.Windows.Forms.ComboBox
		Me.label7 = New System.Windows.Forms.Label
		Me.label6 = New System.Windows.Forms.Label
		Me.cmbBoxSorteo = New System.Windows.Forms.ComboBox
		Me.label5 = New System.Windows.Forms.Label
		Me.cmbBoxCargo = New System.Windows.Forms.ComboBox
		Me.dataGridView1 = New System.Windows.Forms.DataGridView
		Me.label4 = New System.Windows.Forms.Label
		Me.cboxNotificado = New System.Windows.Forms.ComboBox
		Me.chkBoxTodos = New System.Windows.Forms.CheckBox
		Me.btnFiltrar = New System.Windows.Forms.Button
		Me.btnOptions = New System.Windows.Forms.Button
		Me.cmbMesa = New System.Windows.Forms.ComboBox
		Me.label3 = New System.Windows.Forms.Label
		Me.cmbColegio = New System.Windows.Forms.ComboBox
		Me.label2 = New System.Windows.Forms.Label
		Me.btnPrint = New System.Windows.Forms.Button
		Me.bindingNavigator1 = New System.Windows.Forms.BindingNavigator(Me.components)
		Me.bindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton
		Me.bindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
		Me.bindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton
		Me.bindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
		Me.bindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
		Me.bindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
		Me.bindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox
		Me.bindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
		Me.bindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
		Me.bindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
		Me.bindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator
		Me.toolStripBtnSave = New System.Windows.Forms.ToolStripButton
		Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
		Me.toolStripBtnImport = New System.Windows.Forms.ToolStripButton
		Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
		Me.toolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox
		Me.toolStripButtonSearch = New System.Windows.Forms.ToolStripButton
		Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog
		CType(Me.bindingSource1,System.ComponentModel.ISupportInitialize).BeginInit
		CType(Me.dataSet1,System.ComponentModel.ISupportInitialize).BeginInit
		Me.panel1.SuspendLayout
		CType(Me.dataGridView1,System.ComponentModel.ISupportInitialize).BeginInit
		CType(Me.bindingNavigator1,System.ComponentModel.ISupportInitialize).BeginInit
		Me.bindingNavigator1.SuspendLayout
		Me.SuspendLayout
		'
		'btnAbrirProceso
		'
		Me.btnAbrirProceso.Font = New System.Drawing.Font("Microsoft Sans Serif", 15!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.btnAbrirProceso.Location = New System.Drawing.Point(292, 349)
		Me.btnAbrirProceso.Name = "btnAbrirProceso"
		Me.btnAbrirProceso.Size = New System.Drawing.Size(200, 68)
		Me.btnAbrirProceso.TabIndex = 0
		Me.btnAbrirProceso.Text = "Abrir Proceso Electoral"
		Me.btnAbrirProceso.UseVisualStyleBackColor = true
		AddHandler Me.btnAbrirProceso.Click, AddressOf Me.btnAbrirProcesoClick
		'
		'btnNuevoProceso
		'
		Me.btnNuevoProceso.Font = New System.Drawing.Font("Microsoft Sans Serif", 15!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.btnNuevoProceso.Location = New System.Drawing.Point(800, 349)
		Me.btnNuevoProceso.Name = "btnNuevoProceso"
		Me.btnNuevoProceso.Size = New System.Drawing.Size(200, 68)
		Me.btnNuevoProceso.TabIndex = 1
		Me.btnNuevoProceso.Text = "Nuevo"
		Me.btnNuevoProceso.UseVisualStyleBackColor = true
		AddHandler Me.btnNuevoProceso.Click, AddressOf Me.BtnNuevoProcesoClick
		'
		'dataSet1
		'
		Me.dataSet1.DataSetName = "NewDataSet"
		'
		'label1
		'
		Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 40!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.label1.Location = New System.Drawing.Point(400, 90)
		Me.label1.Name = "label1"
		Me.label1.Size = New System.Drawing.Size(533, 147)
		Me.label1.TabIndex = 3
		Me.label1.Text = "Procesos Electorales"
		Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'panel1
		'
		Me.panel1.Controls.Add(Me.btnMesa)
		Me.panel1.Controls.Add(Me.btnQuitarFiltros)
		Me.panel1.Controls.Add(Me.cbxSecc)
		Me.panel1.Controls.Add(Me.label7)
		Me.panel1.Controls.Add(Me.label6)
		Me.panel1.Controls.Add(Me.cmbBoxSorteo)
		Me.panel1.Controls.Add(Me.label5)
		Me.panel1.Controls.Add(Me.cmbBoxCargo)
		Me.panel1.Controls.Add(Me.dataGridView1)
		Me.panel1.Controls.Add(Me.label4)
		Me.panel1.Controls.Add(Me.cboxNotificado)
		Me.panel1.Controls.Add(Me.chkBoxTodos)
		Me.panel1.Controls.Add(Me.btnFiltrar)
		Me.panel1.Controls.Add(Me.btnOptions)
		Me.panel1.Controls.Add(Me.cmbMesa)
		Me.panel1.Controls.Add(Me.label3)
		Me.panel1.Controls.Add(Me.cmbColegio)
		Me.panel1.Controls.Add(Me.label2)
		Me.panel1.Controls.Add(Me.btnPrint)
		Me.panel1.Controls.Add(Me.bindingNavigator1)
		Me.panel1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.panel1.Location = New System.Drawing.Point(0, 0)
		Me.panel1.Name = "panel1"
		Me.panel1.Size = New System.Drawing.Size(1366, 706)
		Me.panel1.TabIndex = 4
		Me.panel1.Visible = false
		'
		'btnMesa
		'
		Me.btnMesa.Anchor = System.Windows.Forms.AnchorStyles.Bottom
		Me.btnMesa.Location = New System.Drawing.Point(1191, 656)
		Me.btnMesa.Name = "btnMesa"
		Me.btnMesa.Size = New System.Drawing.Size(56, 23)
		Me.btnMesa.TabIndex = 23
		Me.btnMesa.Text = "Mesa"
		Me.btnMesa.UseVisualStyleBackColor = true
		Me.btnMesa.Visible = false
		AddHandler Me.btnMesa.Click, AddressOf Me.BtnMesaClick
		'
		'btnQuitarFiltros
		'
		Me.btnQuitarFiltros.Anchor = System.Windows.Forms.AnchorStyles.Bottom
		Me.btnQuitarFiltros.Location = New System.Drawing.Point(1086, 656)
		Me.btnQuitarFiltros.Name = "btnQuitarFiltros"
		Me.btnQuitarFiltros.Size = New System.Drawing.Size(54, 23)
		Me.btnQuitarFiltros.TabIndex = 22
		Me.btnQuitarFiltros.Text = "No Filtro"
		Me.btnQuitarFiltros.UseVisualStyleBackColor = true
		AddHandler Me.btnQuitarFiltros.Click, AddressOf Me.BtnQuitarFiltrosClick
		'
		'cbxSecc
		'
		Me.cbxSecc.Anchor = System.Windows.Forms.AnchorStyles.Bottom
		Me.cbxSecc.FormattingEnabled = true
		Me.cbxSecc.Location = New System.Drawing.Point(396, 628)
		Me.cbxSecc.Name = "cbxSecc"
		Me.cbxSecc.Size = New System.Drawing.Size(40, 21)
		Me.cbxSecc.TabIndex = 21
		'
		'label7
		'
		Me.label7.Anchor = System.Windows.Forms.AnchorStyles.Bottom
		Me.label7.Location = New System.Drawing.Point(357, 631)
		Me.label7.Name = "label7"
		Me.label7.Size = New System.Drawing.Size(33, 21)
		Me.label7.TabIndex = 20
		Me.label7.Text = "Secc:"
		'
		'label6
		'
		Me.label6.Anchor = System.Windows.Forms.AnchorStyles.Bottom
		Me.label6.Location = New System.Drawing.Point(931, 632)
		Me.label6.Name = "label6"
		Me.label6.Size = New System.Drawing.Size(41, 23)
		Me.label6.TabIndex = 19
		Me.label6.Text = "Sorteo"
		'
		'cmbBoxSorteo
		'
		Me.cmbBoxSorteo.Anchor = System.Windows.Forms.AnchorStyles.Bottom
		Me.cmbBoxSorteo.FormattingEnabled = true
		Me.cmbBoxSorteo.Items.AddRange(New Object() {"", "SORTEO 1", "SORTEO 2", "SORTEO 3", "SORTEO 4"})
		Me.cmbBoxSorteo.Location = New System.Drawing.Point(976, 629)
		Me.cmbBoxSorteo.Name = "cmbBoxSorteo"
		Me.cmbBoxSorteo.Size = New System.Drawing.Size(92, 21)
		Me.cmbBoxSorteo.TabIndex = 18
		'
		'label5
		'
		Me.label5.Anchor = System.Windows.Forms.AnchorStyles.Bottom
		Me.label5.Location = New System.Drawing.Point(721, 631)
		Me.label5.Name = "label5"
		Me.label5.Size = New System.Drawing.Size(41, 23)
		Me.label5.TabIndex = 17
		Me.label5.Text = "Cargo"
		'
		'cmbBoxCargo
		'
		Me.cmbBoxCargo.Anchor = System.Windows.Forms.AnchorStyles.Bottom
		Me.cmbBoxCargo.FormattingEnabled = true
		Me.cmbBoxCargo.Items.AddRange(New Object() {"", "PRESIDENTE TITULAR", "PRESIDENTE 1º SUPLENTE", "PRESIDENTE 2º SUPLENTE", "1º VOCAL TITULAR", "1º VOCAL 1º SUPLENTE", "1º VOCAL 2º SUPLENTE", "2º VOCAL TITULAR", "2º VOCAL 1º SUPLENTE", "2º VOCAL 2º SUPLENTE"})
		Me.cmbBoxCargo.Location = New System.Drawing.Point(768, 628)
		Me.cmbBoxCargo.Name = "cmbBoxCargo"
		Me.cmbBoxCargo.Size = New System.Drawing.Size(147, 21)
		Me.cmbBoxCargo.TabIndex = 16
		'
		'dataGridView1
		'
		Me.dataGridView1.AllowUserToAddRows = false
		Me.dataGridView1.AllowUserToDeleteRows = false
		Me.dataGridView1.AllowUserToOrderColumns = true
		Me.dataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
						Or System.Windows.Forms.AnchorStyles.Left)  _
						Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
		Me.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dataGridView1.Location = New System.Drawing.Point(3, 0)
		Me.dataGridView1.Name = "dataGridView1"
		Me.dataGridView1.RowHeadersVisible = false
		Me.dataGridView1.RowTemplate.Height = 24
		Me.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.dataGridView1.ShowCellErrors = false
		Me.dataGridView1.ShowRowErrors = false
		Me.dataGridView1.Size = New System.Drawing.Size(1360, 622)
		Me.dataGridView1.TabIndex = 3
		'
		'label4
		'
		Me.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom
		Me.label4.Location = New System.Drawing.Point(521, 631)
		Me.label4.Name = "label4"
		Me.label4.Size = New System.Drawing.Size(41, 23)
		Me.label4.TabIndex = 15
		Me.label4.Text = "Estado"
		'
		'cboxNotificado
		'
		Me.cboxNotificado.Anchor = System.Windows.Forms.AnchorStyles.Bottom
		Me.cboxNotificado.FormattingEnabled = true
		Me.cboxNotificado.Items.AddRange(New Object() {"", "NOTIFICADO", "ALEGACIONES", "IMPOSIBLE NOTIFICAR", "POR NOTIFICAR", "EXCUSADO", "NOTIFICADO & REMITIDO", "ALEGACIONES REMITIDAS", "IMPOSIBLE & REMITIDO", "REPETIDO"})
		Me.cboxNotificado.Location = New System.Drawing.Point(568, 628)
		Me.cboxNotificado.Name = "cboxNotificado"
		Me.cboxNotificado.Size = New System.Drawing.Size(147, 21)
		Me.cboxNotificado.TabIndex = 14
		'
		'chkBoxTodos
		'
		Me.chkBoxTodos.Anchor = System.Windows.Forms.AnchorStyles.Bottom
		Me.chkBoxTodos.Location = New System.Drawing.Point(1252, 628)
		Me.chkBoxTodos.Margin = New System.Windows.Forms.Padding(2)
		Me.chkBoxTodos.Name = "chkBoxTodos"
		Me.chkBoxTodos.Size = New System.Drawing.Size(60, 21)
		Me.chkBoxTodos.TabIndex = 13
		Me.chkBoxTodos.Text = "Todos"
		Me.chkBoxTodos.UseVisualStyleBackColor = true
		AddHandler Me.chkBoxTodos.CheckedChanged, AddressOf Me.ChkBoxTodosCheckedChanged
		'
		'btnFiltrar
		'
		Me.btnFiltrar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
		Me.btnFiltrar.Location = New System.Drawing.Point(1086, 628)
		Me.btnFiltrar.Name = "btnFiltrar"
		Me.btnFiltrar.Size = New System.Drawing.Size(56, 23)
		Me.btnFiltrar.TabIndex = 12
		Me.btnFiltrar.Text = "Filtrar"
		Me.btnFiltrar.UseVisualStyleBackColor = true
		AddHandler Me.btnFiltrar.Click, AddressOf Me.BtnFiltrarClick
		'
		'btnOptions
		'
		Me.btnOptions.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.btnOptions.Image = CType(resources.GetObject("btnOptions.Image"),System.Drawing.Image)
		Me.btnOptions.Location = New System.Drawing.Point(1325, 621)
		Me.btnOptions.Name = "btnOptions"
		Me.btnOptions.Size = New System.Drawing.Size(38, 38)
		Me.btnOptions.TabIndex = 5
		Me.btnOptions.UseVisualStyleBackColor = true
		AddHandler Me.btnOptions.Click, AddressOf Me.btnOptionsClick
		'
		'cmbMesa
		'
		Me.cmbMesa.Anchor = System.Windows.Forms.AnchorStyles.Bottom
		Me.cmbMesa.FormattingEnabled = true
		Me.cmbMesa.Location = New System.Drawing.Point(481, 628)
		Me.cmbMesa.Name = "cmbMesa"
		Me.cmbMesa.Size = New System.Drawing.Size(34, 21)
		Me.cmbMesa.TabIndex = 10
		'
		'label3
		'
		Me.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom
		Me.label3.Location = New System.Drawing.Point(442, 631)
		Me.label3.Name = "label3"
		Me.label3.Size = New System.Drawing.Size(33, 21)
		Me.label3.TabIndex = 9
		Me.label3.Text = "Mesa: "
		'
		'cmbColegio
		'
		Me.cmbColegio.Anchor = System.Windows.Forms.AnchorStyles.Bottom
		Me.cmbColegio.FormattingEnabled = true
		Me.cmbColegio.Location = New System.Drawing.Point(93, 628)
		Me.cmbColegio.Name = "cmbColegio"
		Me.cmbColegio.Size = New System.Drawing.Size(255, 21)
		Me.cmbColegio.TabIndex = 8
		'
		'label2
		'
		Me.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom
		Me.label2.Location = New System.Drawing.Point(4, 631)
		Me.label2.Name = "label2"
		Me.label2.Size = New System.Drawing.Size(100, 17)
		Me.label2.TabIndex = 7
		Me.label2.Text = "Colegio Electoral: "
		'
		'btnPrint
		'
		Me.btnPrint.Anchor = System.Windows.Forms.AnchorStyles.Bottom
		Me.btnPrint.Location = New System.Drawing.Point(1191, 628)
		Me.btnPrint.Name = "btnPrint"
		Me.btnPrint.Size = New System.Drawing.Size(56, 23)
		Me.btnPrint.TabIndex = 6
		Me.btnPrint.Text = "Print"
		Me.btnPrint.UseVisualStyleBackColor = true
		AddHandler Me.btnPrint.Click, AddressOf Me.BtnPrintClick
		'
		'bindingNavigator1
		'
		Me.bindingNavigator1.AddNewItem = Me.bindingNavigatorAddNewItem
		Me.bindingNavigator1.CountItem = Me.bindingNavigatorCountItem
		Me.bindingNavigator1.DeleteItem = Me.bindingNavigatorDeleteItem
		Me.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.bindingNavigator1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.bindingNavigatorMoveFirstItem, Me.bindingNavigatorMovePreviousItem, Me.bindingNavigatorSeparator, Me.bindingNavigatorPositionItem, Me.bindingNavigatorCountItem, Me.bindingNavigatorSeparator1, Me.bindingNavigatorMoveNextItem, Me.bindingNavigatorMoveLastItem, Me.bindingNavigatorSeparator2, Me.bindingNavigatorAddNewItem, Me.bindingNavigatorDeleteItem, Me.toolStripBtnSave, Me.toolStripSeparator2, Me.toolStripBtnImport, Me.toolStripSeparator1, Me.toolStripTextBox1, Me.toolStripButtonSearch})
		Me.bindingNavigator1.Location = New System.Drawing.Point(0, 679)
		Me.bindingNavigator1.MoveFirstItem = Me.bindingNavigatorMoveFirstItem
		Me.bindingNavigator1.MoveLastItem = Me.bindingNavigatorMoveLastItem
		Me.bindingNavigator1.MoveNextItem = Me.bindingNavigatorMoveNextItem
		Me.bindingNavigator1.MovePreviousItem = Me.bindingNavigatorMovePreviousItem
		Me.bindingNavigator1.Name = "bindingNavigator1"
		Me.bindingNavigator1.PositionItem = Me.bindingNavigatorPositionItem
		Me.bindingNavigator1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
		Me.bindingNavigator1.Size = New System.Drawing.Size(1366, 27)
		Me.bindingNavigator1.TabIndex = 4
		Me.bindingNavigator1.Text = "bindingNavigator1"
		'
		'bindingNavigatorAddNewItem
		'
		Me.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.bindingNavigatorAddNewItem.Image = CType(resources.GetObject("bindingNavigatorAddNewItem.Image"),System.Drawing.Image)
		Me.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem"
		Me.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true
		Me.bindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 24)
		Me.bindingNavigatorAddNewItem.Text = "Agregar nuevo"
		Me.bindingNavigatorAddNewItem.Visible = false
		'
		'bindingNavigatorCountItem
		'
		Me.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem"
		Me.bindingNavigatorCountItem.Size = New System.Drawing.Size(48, 24)
		Me.bindingNavigatorCountItem.Text = "de {0}"
		Me.bindingNavigatorCountItem.ToolTipText = "Número total de elementos"
		'
		'bindingNavigatorDeleteItem
		'
		Me.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.bindingNavigatorDeleteItem.Image = CType(resources.GetObject("bindingNavigatorDeleteItem.Image"),System.Drawing.Image)
		Me.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem"
		Me.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true
		Me.bindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 24)
		Me.bindingNavigatorDeleteItem.Text = "Eliminar"
		Me.bindingNavigatorDeleteItem.Visible = false
		'
		'bindingNavigatorMoveFirstItem
		'
		Me.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.bindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("bindingNavigatorMoveFirstItem.Image"),System.Drawing.Image)
		Me.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem"
		Me.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true
		Me.bindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 24)
		Me.bindingNavigatorMoveFirstItem.Text = "Mover primero"
		'
		'bindingNavigatorMovePreviousItem
		'
		Me.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.bindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("bindingNavigatorMovePreviousItem.Image"),System.Drawing.Image)
		Me.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem"
		Me.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true
		Me.bindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 24)
		Me.bindingNavigatorMovePreviousItem.Text = "Mover anterior"
		'
		'bindingNavigatorSeparator
		'
		Me.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator"
		Me.bindingNavigatorSeparator.Size = New System.Drawing.Size(6, 27)
		'
		'bindingNavigatorPositionItem
		'
		Me.bindingNavigatorPositionItem.AccessibleName = "Posición"
		Me.bindingNavigatorPositionItem.AutoSize = false
		Me.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem"
		Me.bindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
		Me.bindingNavigatorPositionItem.Text = "0"
		Me.bindingNavigatorPositionItem.ToolTipText = "Posición actual"
		'
		'bindingNavigatorSeparator1
		'
		Me.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1"
		Me.bindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 27)
		'
		'bindingNavigatorMoveNextItem
		'
		Me.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.bindingNavigatorMoveNextItem.Image = CType(resources.GetObject("bindingNavigatorMoveNextItem.Image"),System.Drawing.Image)
		Me.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem"
		Me.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true
		Me.bindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 24)
		Me.bindingNavigatorMoveNextItem.Text = "Mover siguiente"
		'
		'bindingNavigatorMoveLastItem
		'
		Me.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.bindingNavigatorMoveLastItem.Image = CType(resources.GetObject("bindingNavigatorMoveLastItem.Image"),System.Drawing.Image)
		Me.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem"
		Me.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true
		Me.bindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 24)
		Me.bindingNavigatorMoveLastItem.Text = "Mover último"
		'
		'bindingNavigatorSeparator2
		'
		Me.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2"
		Me.bindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 27)
		'
		'toolStripBtnSave
		'
		Me.toolStripBtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.toolStripBtnSave.Image = CType(resources.GetObject("toolStripBtnSave.Image"),System.Drawing.Image)
		Me.toolStripBtnSave.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.toolStripBtnSave.Name = "toolStripBtnSave"
		Me.toolStripBtnSave.Size = New System.Drawing.Size(23, 24)
		Me.toolStripBtnSave.Text = "Guardar cambios"
		AddHandler Me.toolStripBtnSave.Click, AddressOf Me.ToolStripBtnSaveClick
		'
		'toolStripSeparator2
		'
		Me.toolStripSeparator2.Name = "toolStripSeparator2"
		Me.toolStripSeparator2.Size = New System.Drawing.Size(6, 27)
		'
		'toolStripBtnImport
		'
		Me.toolStripBtnImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.toolStripBtnImport.Image = CType(resources.GetObject("toolStripBtnImport.Image"),System.Drawing.Image)
		Me.toolStripBtnImport.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.toolStripBtnImport.Name = "toolStripBtnImport"
		Me.toolStripBtnImport.Size = New System.Drawing.Size(23, 24)
		Me.toolStripBtnImport.Text = "toolStripButton1"
		AddHandler Me.toolStripBtnImport.Click, AddressOf Me.ToolStripBtnImportClick
		'
		'toolStripSeparator1
		'
		Me.toolStripSeparator1.Name = "toolStripSeparator1"
		Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 27)
		'
		'toolStripTextBox1
		'
		Me.toolStripTextBox1.Name = "toolStripTextBox1"
		Me.toolStripTextBox1.Size = New System.Drawing.Size(76, 27)
		AddHandler Me.toolStripTextBox1.KeyDown, AddressOf Me.ToolStripTextBox1KeyDown
		'
		'toolStripButtonSearch
		'
		Me.toolStripButtonSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.toolStripButtonSearch.Image = CType(resources.GetObject("toolStripButtonSearch.Image"),System.Drawing.Image)
		Me.toolStripButtonSearch.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.toolStripButtonSearch.Name = "toolStripButtonSearch"
		Me.toolStripButtonSearch.Size = New System.Drawing.Size(23, 24)
		Me.toolStripButtonSearch.Text = "..."
		Me.toolStripButtonSearch.ToolTipText = "Buscar"
		AddHandler Me.toolStripButtonSearch.Click, AddressOf Me.ToolStripButtonSearchClick
		'
		'openFileDialog1
		'
		Me.openFileDialog1.FileName = "openFileDialog1"
		'
		'MainForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(1366, 706)
		Me.Controls.Add(Me.panel1)
		Me.Controls.Add(Me.label1)
		Me.Controls.Add(Me.btnNuevoProceso)
		Me.Controls.Add(Me.btnAbrirProceso)
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.Name = "MainForm"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Procesos Electorales"
		AddHandler FormClosing, AddressOf Me.MainFormFormClosing
		CType(Me.bindingSource1,System.ComponentModel.ISupportInitialize).EndInit
		CType(Me.dataSet1,System.ComponentModel.ISupportInitialize).EndInit
		Me.panel1.ResumeLayout(false)
		Me.panel1.PerformLayout
		CType(Me.dataGridView1,System.ComponentModel.ISupportInitialize).EndInit
		CType(Me.bindingNavigator1,System.ComponentModel.ISupportInitialize).EndInit
		Me.bindingNavigator1.ResumeLayout(false)
		Me.bindingNavigator1.PerformLayout
		Me.ResumeLayout(false)
	End Sub
	Private btnMesa As System.Windows.Forms.Button
	Private btnQuitarFiltros As System.Windows.Forms.Button
	Private label7 As System.Windows.Forms.Label
	Private cbxSecc As System.Windows.Forms.ComboBox
	Private toolStripButtonSearch As System.Windows.Forms.ToolStripButton
	Private toolStripTextBox1 As System.Windows.Forms.ToolStripTextBox
	Private toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
	Private toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
	Private cmbBoxSorteo As System.Windows.Forms.ComboBox
	Private label6 As System.Windows.Forms.Label
	Private cmbBoxCargo As System.Windows.Forms.ComboBox
	Private label5 As System.Windows.Forms.Label
	Private label4 As System.Windows.Forms.Label
	Private cboxNotificado As System.Windows.Forms.ComboBox
	Private toolStripBtnImport As System.Windows.Forms.ToolStripButton
	Private toolStripBtnSave As System.Windows.Forms.ToolStripButton
	Private chkBoxTodos As System.Windows.Forms.CheckBox
	Private btnFiltrar As System.Windows.Forms.Button
	Private label3 As System.Windows.Forms.Label
	Private cmbMesa As System.Windows.Forms.ComboBox
	Private cmbColegio As System.Windows.Forms.ComboBox
	Private label2 As System.Windows.Forms.Label
	Private btnPrint As System.Windows.Forms.Button
	Private bindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
	Private bindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
	Private bindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
	Private bindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
	Private bindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
	Private bindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
	Private bindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
	Private bindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
	Private bindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
	Private bindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
	Private bindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
	Private bindingNavigator1 As System.Windows.Forms.BindingNavigator
	Private openFileDialog1 As System.Windows.Forms.OpenFileDialog
	Private btnAbrirProceso As System.Windows.Forms.Button
	Private btnNuevoProceso As System.Windows.Forms.Button
	Private btnOptions As System.Windows.Forms.Button
	Private panel1 As System.Windows.Forms.Panel
	Private label1 As System.Windows.Forms.Label
	Private bindingSource1 As System.Windows.Forms.BindingSource
	Private dataSet1 As System.Data.DataSet
	Private dataGridView1 As System.Windows.Forms.DataGridView
End Class
