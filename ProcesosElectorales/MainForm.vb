'
' Creado por SharpDevelop.
' Usuario: cfernandez
' Fecha: 11/10/2018
' Hora: 11:40
'
' Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
'

Option Explicit On

Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.DataRow
Imports System.Text
Imports System.Text.RegularExpressions


Public Partial Class MainForm
	
	
	'		Dim strConnection As String = _
	'			"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" _
	'			& "C:\Users\cfernandez\Documents\Projects\SharpDevelop Projects\ProcesosElectorales\test.mdb"
	'		Dim cn As OleDbConnection = New OleDbConnection(strConnection)
	
	Dim databaseFile As String = ""
	Dim templateFolder As String
	Dim wordExe As String = ""
	'Dim colVisibles() As String =  {"False", "False", "True", "True", "True", "True", "True", "True", "True", "True", "True", "True", "True", "True", "True", "True", "True", "True", "True", "True", "True", "True", "True", "True", "True", "True", "True"}
	'Dim colVisibles() As Boolean = {True, True, True, True, True, True, True, True, True, True, True, True, True, True, True, True, True, True, True, True, True, True, True, True, True, True, True}
	Dim colVisibles As String = "001111111111111111111111111"
	Public strConnection As String = ""
	Public procesoElectoral As String = ""
	Public procesoElectoralLong As String = ""
	Public cn As OleDbConnection
	Dim strSelect As String = "SELECT * FROM Procesos"
	'Dim OleDbDataAdapter1 As New OleDbDataAdapter(strSelect, cn)
	Dim OleDbDataAdapter1 As OleDbDataAdapter
	Dim commandBuilder1 As OleDbCommandBuilder
	Dim dt As DataTable
	Dim procedureSelected As Boolean = False
	Dim listaBarcodes(1) As String
	
	'Dim command_builder As New OleDbCommandBuilder(OleDbDataAdapter1)
	
	Public Sub New()
		Me.InitializeComponent()
		cn = New OleDbConnection()
		loadBaseOptions()
		ConnData()
		loadColVisibles()
		'setVisibleColumns(colVisibles)
	End Sub
	
	Sub btnAbrirProcesoClick(ByVal sender As Object, ByVal e As EventArgs)
		'Me.dataGridView1.Visible = True
		If String.IsNullOrEmpty(databaseFile) Then
			getDatabaseFile()
		End If
		Dim f As New FormSelectProceso(databaseFile)
		If f.ShowDialog(Me) = DialogResult.OK Then
			procesoElectoralLong = f.GetProceso
			procesoElectoral = f.GetProceso.Replace(" ", String.Empty)
			f.Dispose
			procedureSelected = true
			loadMainTable()
			loadColVisibles()
			setVisibleColumns(colVisibles)
			FillComboColegio()
			FillComboMesa()
			FillComboSecc()
			Me.panel1.Visible = True
			Me.Text = ProcesoElectoralLong
		End If
		f.Dispose()
	End Sub
	
	Sub btnOptionsClick(ByVal sender As Object, ByVal e As EventArgs)
		Dim opciones As New FormOpciones(databaseFile, templateFolder, procesoElectoral, wordExe, colVisibles)
		If opciones.ShowDialog() = DialogResult.OK Then
			databaseFile = opciones.GetBaseName
			templateFolder = opciones.GetTemplateFolder
			wordExe = opciones.GetWordExe
			colVisibles = opciones.GetVisibleColumns
			SaveTemplateFolderOptions()
			SaveBaseOptions()
			SaveWordOptions()
			SaveColVisibles()
			'SetVisibleColumns()
			'SetMultiColumns(opciones.GetMultiSelect)
			'Me.dataGridView1.SelectionMode = opciones.GetSelectCellMode
			'Dim ops As Integer = opciones.GetVisibleColumns()
			Me.dataGridView1.MultiSelect = True
			Me.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			'Me.dataGridView1 = New System.Windows.Forms.DataGridView
			Me.dataGridView1.Update()
			MsgBox("Se reiniciará para que tenga efecto",, "Info")
		End If
		opciones.Dispose()
		Application.Restart()
	End Sub
	
	Sub loadBaseOptions()
		Dim readBaseValue As String
		readBaseValue = My.Computer.Registry.GetValue _
			("HKEY_CURRENT_USER\Software\cfr\Procesos Electorales", "BaseFile", Nothing)
		If  String.IsNullOrEmpty(readBaseValue) Then
			My.Computer.Registry.CurrentUser.CreateSubKey("Software\cfr\Procesos Electorales")
			My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\cfr\Procesos Electorales", "BaseFile", databaseFile)
		Else
			dataBaseFile = readBaseValue
		End If
	End Sub
	
	Sub SaveBaseOptions()
		Dim readBaseValue As String
		readBaseValue = My.Computer.Registry.GetValue _
			("HKEY_CURRENT_USER\Software\cfr\Procesos Electorales", "BaseFile", Nothing)
		If  String.IsNullOrEmpty(readBaseValue) Then
			My.Computer.Registry.CurrentUser.CreateSubKey("Software\cfr\Procesos Electorales")
		End If
		My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\cfr\Procesos Electorales", "BaseFile", dataBaseFile)
	End Sub
	
	Sub loadTemplateFolderOptions()
		Dim readFolderValue As String
		readFolderValue = My.Computer.Registry.GetValue _
			("HKEY_CURRENT_USER\Software\cfr\Procesos Electorales", "TemplateFolder", Nothing)
		If  String.IsNullOrEmpty(readFolderValue) Then
			My.Computer.Registry.CurrentUser.CreateSubKey("Software\cfr\Procesos Electorales")
			My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\cfr\Procesos Electorales", "TemplateFolder", templateFolder)
		Else
			templateFolder = readFolderValue
		End If
	End Sub
	
	Sub SaveTemplateFolderOptions()
		Dim readFolderValue As String
		readFolderValue = My.Computer.Registry.GetValue _
			("HKEY_CURRENT_USER\Software\cfr\Procesos Electorales", "TemplateFolder", Nothing)
		If  String.IsNullOrEmpty(readFolderValue) Then
			My.Computer.Registry.CurrentUser.CreateSubKey("Software\cfr\Procesos Electorales")
		End If
		My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\cfr\Procesos Electorales", "TemplateFolder", templateFolder)
	End Sub
	
	Sub loadWordExeOptions()
		Dim readWordExeValue As String
		readWordExeValue = My.Computer.Registry.GetValue _
			("HKEY_CURRENT_USER\Software\cfr\Procesos Electorales", "WordExe", Nothing)
		If  String.IsNullOrEmpty(readWordExeValue) Then
			My.Computer.Registry.CurrentUser.CreateSubKey("Software\cfr\Procesos Electorales")
			My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\cfr\Procesos Electorales", "WordExe", wordExe)
		Else
			wordExe = readWordExeValue
		End If
	End Sub
	
	Sub SaveWordOptions()
		Dim readWordExeValue As String
		readWordExeValue = My.Computer.Registry.GetValue _
			("HKEY_CURRENT_USER\Software\cfr\Procesos Electorales", "WordExe", Nothing)
		If  String.IsNullOrEmpty(readWordExeValue) Then
			My.Computer.Registry.CurrentUser.CreateSubKey("Software\cfr\Procesos Electorales")
		End If
		My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\cfr\Procesos Electorales", "WordExe", wordExe)
	End Sub
	
	Sub loadColVisibles()
		Dim readColVisibles As String
		readColVisibles = My.Computer.Registry.GetValue _
			("HKEY_CURRENT_USER\Software\cfr\Procesos Electorales", "ColVisibles", Nothing)
		If  String.IsNullOrEmpty(readColVisibles) Then
			My.Computer.Registry.CurrentUser.CreateSubKey("Software\cfr\Procesos Electorales")
			My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\cfr\Procesos Electorales", "ColVisibles", colVisibles)
		End If
		colVisibles = readColVisibles
	End Sub
	
	Sub SaveColVisibles()
		Dim readColVisibles As String =  My.Computer.Registry.GetValue _
			("HKEY_CURRENT_USER\Software\cfr\Procesos Electorales", "ColVisibles", Nothing)
		If  String.IsNullOrEmpty(readColVisibles) Then
			My.Computer.Registry.CurrentUser.CreateSubKey("Software\cfr\Procesos Electorales")
		End If
		My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\cfr\Procesos Electorales", "ColVisibles"  ,colVisibles)
	End Sub
	
	Sub ConnData()
		If String.IsNullOrEmpty(databaseFile) Then
			GetDatabaseFile()
			strConnection = _
				"Provider=Microsoft.Jet.OLEDB.4.0;" _
				& "Password=;" _
				& "Data Source=" & databaseFile
			Try
				cn.ConnectionString = strConnection
				cn.Open()
			Catch MyException As Exception
				MsgBox(MyException.ToString)
			End Try
		End If
	End Sub
	
	Sub GetDatabaseFile()
		Dim readBaseValue As String = My.Computer.Registry.GetValue _
			("HKEY_CURRENT_USER\Software\cfr\Procesos Electorales", "BaseFile", Nothing)
		If String.IsNullOrEmpty(readBaseValue) Then
			openFileDialog1.InitialDirectory = "C:\\Users\\usuario\\Documents"
			openFileDialog1.Filter = "Access files (*.mdb)|*.mdb|All files (*.*)|*.*"
			openFileDialog1.FilterIndex = 1
			openFileDialog1.FileName = ""
			openFileDialog1.Title = "Seleccione fichero de la base de datos"
			openFileDialog1.ShowDialog(Me)
			databaseFile = openFileDialog1.FileName
		End If
	End Sub
	
	Sub BtnNuevoProcesoClick(ByVal sender As Object, ByVal e As EventArgs)
		If String.IsNullOrEmpty(databaseFile) Then
			getDatabaseFile()
		End If
		Dim f As New FormNuevo(databaseFile)
		If f.ShowDialog(Me) = DialogResult.OK Then
			procesoElectoral = f.GetName()
			procesoElectoral = procesoElectoral.Replace(" ", String.Empty)
		End If
		f.Dispose()
	End Sub
	
	Function StrToBool(ByVal c As Char) As Boolean
		Dim  tempChar As Char = c
		Dim  tmp0 As Boolean = true
		If tempChar.Equals("1")  Then
			tmp0 = True
		Else
			tmp0 = False
		End If
		Return tmp0
	End Function
	
	Sub SetupGrid()
		'NMUNI
		Dim column0 As DataGridViewColumn = New DataGridViewTextBoxColumn()
		column0.DataPropertyName = Me.dataSet1.Tables(procesoElectoral).Columns(0).ToString
		column0.Name = Me.dataSet1.Tables(procesoElectoral).Columns(0).ToString.ToUpper()
		Me.dataGridView1.Columns.Add(column0)
		column0.Visible = False
		'		column0.Visible = StrToBool(colVisibles.Chars(0))
		'DIST
		Dim column1 As DataGridViewColumn = New DataGridViewTextBoxColumn()
		column1.DataPropertyName = Me.dataSet1.Tables(procesoElectoral).Columns(1).ToString
		column1.Name = Me.dataSet1.Tables(procesoElectoral).Columns(1).ToString.ToUpper()
		Me.dataGridView1.Columns.Add(column1)
		column1.Visible = False
		'		column0.Visible = StrToBool(colVisibles.Chars(1))
		
		'SECC
		Dim column2 As DataGridViewColumn = New DataGridViewTextBoxColumn()
		column2.DataPropertyName = Me.dataSet1.Tables(procesoElectoral).Columns(2).ToString
		column2.Name = Me.dataSet1.Tables(procesoElectoral).Columns(2).ToString.ToUpper()
		Me.dataGridView1.Columns.Add(column2)
		column2.Visible = True
		'		column2.Visible = Convert.ToBoolean(colVisibles.Chars(2))
		'		column2.Visible = CharToBool(colVisibles(2))
		'MESA
		Dim column3 As DataGridViewColumn = New DataGridViewTextBoxColumn()
		column3.DataPropertyName = Me.dataSet1.Tables(procesoElectoral).Columns(3).ToString
		column3.Name = Me.dataSet1.Tables(procesoElectoral).Columns(3).ToString.ToUpper()
		Me.dataGridView1.Columns.Add(column3)
		column3.Visible = True
		'		column3.Visible = Convert.ToBoolean(colVisibles.Chars(3))
		'NLOCAL
		Dim column4 As DataGridViewColumn = New DataGridViewTextBoxColumn()
		column4.DataPropertyName = Me.dataSet1.Tables(procesoElectoral).Columns(4).ToString
		column4.Name = Me.dataSet1.Tables(procesoElectoral).Columns(4).ToString.ToUpper()
		Me.dataGridView1.Columns.Add(column4)
		column4.Visible = True
		'		column4.Visible = Convert.ToBoolean(colVisibles.Chars(4))
		'NLOCALB
		Dim column5 As DataGridViewColumn = New DataGridViewTextBoxColumn()
		column5.DataPropertyName = Me.dataSet1.Tables(procesoElectoral).Columns(5).ToString
		column5.Name = Me.dataSet1.Tables(procesoElectoral).Columns(5).ToString.ToUpper()
		Me.dataGridView1.Columns.Add(column5)
		column5.Visible = True
		'		column5.Visible = Convert.ToBoolean(colVisibles.Chars(5))
		'INFADICIONAL
		Dim column6 As DataGridViewColumn = New DataGridViewTextBoxColumn()
		column6.DataPropertyName = Me.dataSet1.Tables(procesoElectoral).Columns(6).ToString
		column6.Name = Me.dataSet1.Tables(procesoElectoral).Columns(6).ToString.ToUpper()
		Me.dataGridView1.Columns.Add(column6)
		column6.Visible = True
		'		column6.Visible = Convert.ToBoolean(colVisibles.Chars(6))
		'DIRMESA1
		Dim column7 As DataGridViewColumn = New DataGridViewTextBoxColumn()
		column7.DataPropertyName = Me.dataSet1.Tables(procesoElectoral).Columns(7).ToString
		column7.Name = Me.dataSet1.Tables(procesoElectoral).Columns(7).ToString.ToUpper()
		Me.dataGridView1.Columns.Add(column7)
		column7.Visible = True
		'		column7.Visible = Convert.ToBoolean(colVisibles.Chars(7))
		'DIRMESA2
		Dim column8 As DataGridViewColumn = New DataGridViewTextBoxColumn()
		column8.DataPropertyName = Me.dataSet1.Tables(procesoElectoral).Columns(8).ToString
		column8.Name = Me.dataSet1.Tables(procesoElectoral).Columns(8).ToString.ToUpper()
		Me.dataGridView1.Columns.Add(column8)
		column8.Visible = True
		'		column8.Visible = Convert.ToBoolean(colVisibles.Chars(8))
		'DIRMESA3
		Dim column9 As DataGridViewColumn = New DataGridViewTextBoxColumn()
		column9.DataPropertyName = Me.dataSet1.Tables(procesoElectoral).Columns(9).ToString
		column9.Name = Me.dataSet1.Tables(procesoElectoral).Columns(9).ToString.ToUpper()
		Me.dataGridView1.Columns.Add(column9)
		column9.Visible = True
		'		column9.Visible = Convert.ToBoolean(colVisibles.Chars(9))
		'DIRMESA4
		Dim column10 As DataGridViewColumn = New DataGridViewTextBoxColumn()
		column10.DataPropertyName = Me.dataSet1.Tables(procesoElectoral).Columns(10).ToString
		column10.Name = Me.dataSet1.Tables(procesoElectoral).Columns(10).ToString.ToUpper()
		Me.dataGridView1.Columns.Add(column10)
		column10.Visible = True
		'		column10.Visible = Convert.ToBoolean(colVisibles.Chars(10))
		'CARGOFINAL
		'				Dim column11 As DataGridViewColumn = New DataGridViewTextBoxColumn()
		'				column11.DataPropertyName = Me.dataSet1.Tables(procesoElectoral).Columns(11).ToString
		'				column11.Name = Me.dataSet1.Tables(procesoElectoral).Columns(11).ToString.ToUpper()
		'				Me.dataGridView1.Columns.Add(column11)
		Dim column11 As DataGridViewColumn = CreateComboBoxCargos()
		Me.dataGridView1.Columns.Add(column11)
		column11.Visible = True
		'		column11.Visible = Convert.ToBoolean(colVisibles.Chars(11))
		'NOLISTA
		Dim column12 As DataGridViewColumn = New DataGridViewTextBoxColumn()
		column12.DataPropertyName = Me.dataSet1.Tables(procesoElectoral).Columns(12).ToString
		column12.Name = Me.dataSet1.Tables(procesoElectoral).Columns(12).ToString.ToUpper()
		Me.dataGridView1.Columns.Add(column12)
		column12.Visible = True
		'		column12.Visible = Convert.ToBoolean(colVisibles.Chars(12))
		'GRES
		Dim column13 As DataGridViewColumn = New DataGridViewTextBoxColumn()
		column13.DataPropertyName = Me.dataSet1.Tables(procesoElectoral).Columns(13).ToString
		column13.Name = Me.dataSet1.Tables(procesoElectoral).Columns(13).ToString.ToUpper()
		Me.dataGridView1.Columns.Add(column13)
		column13.Visible = True
		'		column13.Visible = Convert.ToBoolean(colVisibles.Chars(13))
		'IDENT
		Dim column14 As DataGridViewColumn = New DataGridViewTextBoxColumn()
		column14.DataPropertyName = Me.dataSet1.Tables(procesoElectoral).Columns(14).ToString
		column14.Name = Me.dataSet1.Tables(procesoElectoral).Columns(14).ToString.ToUpper()
		Me.dataGridView1.Columns.Add(column14)
		column14.Visible = True
		'		column14.Visible = Convert.ToBoolean(colVisibles(14))
		'NOMBRE
		Dim column15 As DataGridViewColumn = New DataGridViewTextBoxColumn()
		column15.DataPropertyName = Me.dataSet1.Tables(procesoElectoral).Columns(15).ToString
		column15.Name = Me.dataSet1.Tables(procesoElectoral).Columns(15).ToString.ToUpper()
		Me.dataGridView1.Columns.Add(column15)
		column15.Visible = True
		'		column15.Visible = Convert.ToBoolean(colVisibles(15))
		'APELLIDO1
		Dim column16 As DataGridViewColumn = New DataGridViewTextBoxColumn()
		column16.DataPropertyName = Me.dataSet1.Tables(procesoElectoral).Columns(16).ToString
		column16.Name = Me.dataSet1.Tables(procesoElectoral).Columns(16).ToString.ToUpper()
		Me.dataGridView1.Columns.Add(column16)
		column16.Visible = True
		'		column16.Visible = Convert.ToBoolean(colVisibles(16))
		'APELLIDO2
		Dim column17 As DataGridViewColumn = New DataGridViewTextBoxColumn()
		column17.DataPropertyName = Me.dataSet1.Tables(procesoElectoral).Columns(17).ToString
		column17.Name = Me.dataSet1.Tables(procesoElectoral).Columns(17).ToString.ToUpper()
		Me.dataGridView1.Columns.Add(column17)
		column17.Visible = True
		'		column17.Visible = Convert.ToBoolean(colVisibles(17))
		'DOMI1
		Dim column18 As DataGridViewColumn = New DataGridViewTextBoxColumn()
		column18.DataPropertyName = Me.dataSet1.Tables(procesoElectoral).Columns(18).ToString
		column18.Name = Me.dataSet1.Tables(procesoElectoral).Columns(18).ToString.ToUpper()
		Me.dataGridView1.Columns.Add(column18)
		column18.Visible = True
		'		column18.Visible = Convert.ToBoolean(colVisibles(18))
		'DOMI2
		Dim column19 As DataGridViewColumn = New DataGridViewTextBoxColumn()
		column19.DataPropertyName = Me.dataSet1.Tables(procesoElectoral).Columns(19).ToString
		column19.Name = Me.dataSet1.Tables(procesoElectoral).Columns(19).ToString.ToUpper()
		column19.Visible = True
		Me.dataGridView1.Columns.Add(column19)
		'		column19.Visible = Convert.ToBoolean(colVisibles(19))
		'DOMI3
		Dim column20 As DataGridViewColumn = New DataGridViewTextBoxColumn()
		column20.DataPropertyName = Me.dataSet1.Tables(procesoElectoral).Columns(20).ToString
		column20.Name = Me.dataSet1.Tables(procesoElectoral).Columns(20).ToString.ToUpper()
		Me.dataGridView1.Columns.Add(column20)
		column20.Visible = True
		'		column20.Visible = Convert.ToBoolean(colVisibles(20))
		'DOMI4
		Dim column21 As DataGridViewColumn = New DataGridViewTextBoxColumn()
		column21.DataPropertyName = Me.dataSet1.Tables(procesoElectoral).Columns(21).ToString
		column21.Name = Me.dataSet1.Tables(procesoElectoral).Columns(21).ToString.ToUpper()
		column21.Name = Me.dataSet1.Tables(procesoElectoral).Columns(21).ToString.ToUpper()
		Me.dataGridView1.Columns.Add(column21)
		column21.Visible = True
		'		column21.Visible = Convert.ToBoolean(colVisibles(21))
		'DOMI5
		Dim column22 As DataGridViewColumn = New DataGridViewTextBoxColumn()
		column22.DataPropertyName = Me.dataSet1.Tables(procesoElectoral).Columns(22).ToString
		column22.Name = Me.dataSet1.Tables(procesoElectoral).Columns(22).ToString.ToUpper()
		column22.Name = Me.dataSet1.Tables(procesoElectoral).Columns(22).ToString.ToUpper()
		Me.dataGridView1.Columns.Add(column22)
		column22.Visible = True
		'		column22.Visible = Convert.ToBoolean(colVisibles(22))
		'CPOSTAL
		Dim column23 As DataGridViewColumn = New DataGridViewTextBoxColumn()
		column23.DataPropertyName = Me.dataSet1.Tables(procesoElectoral).Columns(23).ToString
		column23.Name = Me.dataSet1.Tables(procesoElectoral).Columns(23).ToString.ToUpper()
		Me.dataGridView1.Columns.Add(column23)
		column23.Visible = True
		'		column23.Visible = Convert.ToBoolean(colVisibles(23))
		'ESTADO
		Dim column24 As DataGridViewColumn = CreateComboBoxEstado()
		Me.dataGridView1.Columns.Add(column24)
		column24.Visible = True
		'		column24.Visible = Convert.ToBoolean(colVisibles(24))
		'FECHA
		Dim column25 As DataGridViewColumn = New DataGridViewTextBoxColumn()
		column25.DataPropertyName = Me.dataSet1.Tables(procesoElectoral).Columns(25).ToString
		column25.Name = Me.dataSet1.Tables(procesoElectoral).Columns(25).ToString.ToUpper()
		Me.dataGridView1.Columns.Add(column25)
		column25.Visible = True
		'		column25.Visible = Convert.ToBoolean(colVisibles(25))
		'SORTEO
		Dim column26 As DataGridViewColumn = New DataGridViewTextBoxColumn()
		column26.DataPropertyName = Me.dataSet1.Tables(procesoElectoral).Columns(26).ToString
		column26.Name = Me.dataSet1.Tables(procesoElectoral).Columns(26).ToString.ToUpper()
		Me.dataGridView1.Columns.Add(column26)
		column26.Visible = True
		'		column26.Visible = Convert.ToBoolean(colVisibles(26))
	End Sub
	
	'	Sub ArrangeColumns()
	'DataGridView.Columns(index/name).Index = WhateverIndexYouWantHere
	'DataGridView.Columns(0).Index = 3
	'Me.dataGridView1.Columns(21).DisplayIndex = 11
	'	End Sub
	
	Sub SetVisibleColumn(ByVal numeroColumna As Integer, ByVal visible As Boolean)
		Me.dataGridView1.Columns(numeroColumna).Visible = Convert.ToBoolean(colVisibles(numeroColumna))
	End Sub
	
	Sub SetVisibleColumns(ByVal cols As String)
		Dim temp As String = cols
		For num As Integer = 0 To Me.dataGridView1.Columns.Count - 1
			If temp.Chars(num) = "1" Then
				Me.dataGridView1.Columns(num).Visible = True
			Else
				Me.dataGridView1.Columns(num).Visible = False
			End If
		Next
		Me.dataGridView1.Update()
	End Sub
	
	Function GetVisibleColumns() As String
		Return Me.colVisibles
	End Function
	
	'	Sub SetMultiColumns(ByVal multi As Boolean)
	'		If multi Then
	'			Me.dataGridView1.MultiSelect = True
	'			Me.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
	'		Else
	'			Me.dataGridView1.MultiSelect = False
	'			Me.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
	'		End If
	'	End Sub
	
	Function CreateComboBoxCargos() As DataGridViewComboBoxColumn
		Dim combo As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn
		Dim head As String = "CARGOFINAL"
		combo.HeaderText = head.ToUpper()
		combo.Name = "CARGOFINAL"
		combo.Items.Add("")
		combo.Items.Add("PRESIDENTE TITULAR")
		combo.Items.Add("PRESIDENTE 1º SUPLENTE")
		combo.Items.Add("PRESIDENTE 2º SUPLENTE")
		combo.Items.Add("1º VOCAL TITULAR")
		combo.Items.Add("1º VOCAL 1º SUPLENTE")
		combo.Items.Add("1º VOCAL 2º SUPLENTE")
		combo.Items.Add("2º VOCAL TITULAR")
		combo.Items.Add("2º VOCAL 1º SUPLENTE")
		combo.Items.Add("2º VOCAL 2º SUPLENTE")
		'combo.DataPropertyName = "CARGOFINAL"
		combo.DataPropertyName = Me.dataSet1.Tables(procesoElectoral).Columns(11).ToString.ToUpper()
		Return combo
	End Function
	
	Function CreateComboBoxEstado() As DataGridViewComboBoxColumn
		Dim combo As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn
		Dim head As String = "ESTADO"
		combo.HeaderText = head.ToUpper()
		combo.Name = "ESTADO"
		combo.Items.Add("")
		combo.Items.Add("NOTIFICADO")
		combo.Items.Add("ALEGACIONES")
		combo.Items.Add("IMPOSIBLE NOTIFICAR")
		combo.Items.Add("POR NOTIFICAR")
		combo.Items.Add("EXCUSADO")
		combo.Items.Add("NOTIFICADO & REMITIDO")
		combo.Items.Add("ALEGACIONES REMITIDAS")
		combo.Items.Add("IMPOSIBLE & REMITIDO")
		combo.Items.Add("REPETIDO")
		
		'combo.DataPropertyName = "ESTADO"
		combo.DataPropertyName = Me.dataSet1.Tables(procesoElectoral).Columns(24).ToString.ToUpper()
		Return combo
	End Function
	
	
	Sub LoadMainTable()
		Try
			Dim query As String = "SELECT * FROM  "& procesoElectoral
			strConnection = _
				"Provider=Microsoft.Jet.OLEDB.4.0;" _
				& "Password=;" _
				& "Data Source=" & databaseFile
			OleDbDataAdapter1 = New OleDbDataAdapter(query, strConnection)
			commandBuilder1 = New OleDbCommandBuilder(OleDbDataAdapter1)
			OleDbDataAdapter1.SelectCommand.CommandText = query
			dt = dataSet1.Tables.Add(procesoElectoral)
			'OleDbDataAdapter2.Fill(Me.dataSet1)
			OleDbDataAdapter1.Fill(dt)
			'			MsgBox(procesoElectoral  & VbCrLf & procesoElectoralLong  & VbCrLf _
			'					& procedureSelected & VbCrLf & query & strConnection & VbCrLf _
			'					& dt.TableName)
			Me.bindingSource1.DataSource = dt
			Me.bindingNavigator1.BindingSource = Me.bindingSource1
			Me.dataGridView1.AutoGenerateColumns = False
			Me.dataGridView1.DataSource = Me.bindingSource1
			SetupGrid()
			'Me.dataGridView1.Columns(0).Visible = False
			Me.dataGridView1.AutoResizeColumns()
			'			ArrangeColumns()
		Catch ex As Exception
			MsgBox(ex.ToString)
			System.Console.Write(ex.ToString)
		End Try
	End Sub
	
	Sub ToolStripBtnSaveClick(ByVal sender As Object, ByVal e As EventArgs)
		Try
			Me.dataGridView1.DataSource = dt
			Me.OleDbDataAdapter1.Update(dt)
			MsgBox("Guardado", , "Info")
			Me.dataGridView1.DataSource = Me.bindingSource1
		Catch ex As Exception
			MsgBox(ex.ToString)
		End Try
		
	End Sub
	
	Sub BtnPrintClick(ByVal sender As Object, ByVal e As EventArgs)
		loadTemplateFolderOptions()
		loadWordExeOptions()
		Dim append As Boolean = True
		Dim pHelp As New ProcessStartInfo
		If Me.dataGridView1.SelectedRows.Count > 0 Then
			ListadoPrintHeader(false)
			ListadoPrint(append)
			loadTemplateFolderOptions()
			pHelp.FileName = wordExe
			pHelp.Arguments = "modelo_comunicacion_miembros_CDB.odt"
			'MsgBox(pHelp.ToString)
			'pHelp.Arguments = templateFolder & ", modelo_comunicacion_miembros_CDB.odt"
			'Process.Start("explorer.exe", templateFolder)
			'Process.Start(wordExe)
			'MsgBox(wordExe & " " &templateFolder & " modelo_comunicacion_miembros_CDB.odt")
			'Process.Start(wordExe & " " &templateFolder & " modelo_comunicacion_miembros_CDB.odt")
			Process.Start(pHelp)
		End If
	End Sub
	
	Sub BtnMesaClick(ByVal sender As Object, ByVal e As EventArgs)
		ListadoPrintHeader(false)
		MesaPrint()
	End Sub
	
	Sub ListadoPrintHeader(ByVal b As Boolean)
		loadTemplateFolderOptions()
		Dim append As Boolean = b
		Dim objStreamWriter As StreamWriter
		objStreamWriter = New StreamWriter(templateFolder &"\Tempfile.csv", append, Encoding.Default)
		Dim salida As String = ""
		salida = "NMUNI;DIST;SECC;MESA;NLOCAL;" _
			& "NLOCALB;INFADICIONAL;DIRMESA1;DIRMESA2;" _
			& "DIRMESA3;DIRMESA4;NOLISTA;CARGOFINAL;GRES;" _
			& "IDENT;NOMBRE;APELLIDO1;APELLIDO2;DOMI1;" _
			& "DOMI2;DOMI3;DOMI4;DOMI5;CPOSTAL"
		objStreamWriter.WriteLine(salida)
		objStreamWriter.Close()
	End Sub
	
	Sub ListadoPrint (ByVal b As Boolean)
		loadTemplateFolderOptions()
		Dim append As Boolean = b
		Dim objStreamWriter As StreamWriter
		Dim salida As String = ""
		Dim row As new DataGridViewRow
		objStreamWriter = New StreamWriter(templateFolder &"\Tempfile.csv", append, Encoding.Default)
		If Me.dataGridView1.SelectedRows .Count > 0 Then
			For Each row  In Me.dataGridView1.SelectedRows
				If Not row.IsNewRow Then
					salida = row.Cells("NMUNI").Value.ToString & ";" & _
						row.Cells("DIST").Value.ToString & ";" & _
						row.Cells("SECC").Value.ToString & ";" & _
						row.Cells("MESA").Value.ToString & ";" & _
						row.Cells("NLOCAL").Value.ToString & ";" & _
						row.Cells("NLOCALB").Value.ToString & ";" & _
						row.Cells("INFADICIONAL").Value.ToString & ";" & _
						row.Cells("DIRMESA1").Value.ToString & ";" & _
						row.Cells("DIRMESA2").Value.ToString & ";" & _
						row.Cells("DIRMESA3").Value.ToString & ";" & _
						row.Cells("DIRMESA4").Value.ToString & ";" & _
						row.Cells("NOLISTA").Value.ToString & ";" & _
						row.Cells("CARGOFINAL").Value.ToString & ";" & _
						row.Cells("GRES").Value.ToString & ";" & _
						row.Cells("IDENT").Value.ToString & ";" & _
						row.Cells("NOMBRE").Value.ToString & ";" & _
						row.Cells("APELLIDO1").Value.ToString & ";" & _
						row.Cells("APELLIDO2").Value.ToString & ";" & _
						row.Cells("DOMI1").Value.ToString & ";" & _
						row.Cells("DOMI2").Value.ToString & ";" & _
						row.Cells("DOMI3").Value.ToString & ";" & _
						row.Cells("DOMI4").Value.ToString & ";" & _
						row.Cells("DOMI5").Value.ToString & ";" & _
						row.Cells("CPOSTAL").Value.ToString  '& _
					'				'Constants.vbNewLine
				End If
				objStreamWriter.WriteLine(salida)
			next
			objStreamWriter.Close()
			'Process.Start("explorer.exe", templateFolder)
		End if
	End Sub
	
	Sub MesaPrint()
		loadTemplateFolderOptions()
		loadWordExeOptions()
		Dim objStreamWriter As StreamWriter
		Dim salida As String = ""
		Dim PT As String = ""
		Dim V1T As String = ""
		Dim V2T As String = ""
		Dim PS1 As String = ""
		Dim PS2 As String = ""
		Dim V1S1 As String = ""
		Dim V1S2 As String = ""
		Dim V2S1 As String = ""
		Dim V2S2 As String = ""
		Dim tmpString As String = ""
		Dim tmpCargo As String = ""
		Dim pHelp As New ProcessStartInfo
		objStreamWriter = New StreamWriter(templateFolder &"\Tempfile.csv", true, Encoding.Default)
		For Each row As DataGridViewRow In DataGridView1.SelectedRows
			If Not row.IsNewRow Then
				tmpString = row.Cells("NMUNI").Value.ToString & ";" & _
					row.Cells("DIST").Value.ToString & ";" & _
					row.Cells("SECC").Value.ToString & ";" & _
					row.Cells("MESA").Value.ToString & ";" & _
					row.Cells("NLOCAL").Value.ToString & ";" & _
					row.Cells("NLOCALB").Value.ToString & ";" & _
					row.Cells("INFADICIONAL").Value.ToString & ";" & _
					row.Cells("DIRMESA1").Value.ToString & ";" & _
					row.Cells("DIRMESA2").Value.ToString & ";" & _
					row.Cells("DIRMESA3").Value.ToString & ";" & _
					row.Cells("DIRMESA4").Value.ToString & ";" & _
					row.Cells("CARGOFINAL").Value.ToString & ";" & _
					row.Cells("NOLISTA").Value.ToString & ";" & _
					row.Cells("GRES").Value.ToString & ";" & _
					row.Cells("IDENT").Value.ToString & ";" & _
					row.Cells("NOMBRE").Value.ToString & ";" & _
					row.Cells("APELLIDO1").Value.ToString & ";" & _
					row.Cells("APELLIDO2").Value.ToString & ";" & _
					row.Cells("DOMI1").Value.ToString & ";" & _
					row.Cells("DOMI2").Value.ToString & ";" & _
					row.Cells("DOMI3").Value.ToString & ";" & _
					row.Cells("DOMI4").Value.ToString & ";" & _
					row.Cells("DOMI5").Value.ToString & ";" & _
					row.Cells("CPOSTAL").Value.ToString  & _
					Constants.vbNewLine
				tmpCargo = row.Cells("CARGOFINAL").Value.ToString
				Select Case tmpCargo
					Case "PRESIDENTE TITULAR"
						PT = tmpString
					Case "1º VOCAL TITULAR"
						V1T = tmpString
					Case "2º VOCAL TITULAR"
						V2T = tmpString
					Case "PRESIDENTE 1º SUPLENTE"
						PS1 = tmpString
					Case "PRESIDENTE 2º SUPLENTE"
						PS2 = tmpString
					Case "1º VOCAL 1º SUPLENTE"
						V1S1 = tmpString
					Case "1º VOCAL 2º SUPLENTE"
						V1S2 = tmpString
					Case "2º VOCAL 1º SUPLENTE"
						V2S1 = tmpString
					Case "2º VOCAL 2º SUPLENTE"
						V2S2 = tmpString
				End Select
			End If
		Next
		salida = PT + V1T + V2T + PS1 + PS2 + V1S1 + V1S2 + V2S1 + V2S2
		objStreamWriter.WriteLine(salida)
		objStreamWriter.Close()
		pHelp.FileName = wordExe
		pHelp.Arguments = "Composicion_Mesas.odt"
		Process.Start(pHelp)
	End Sub
	
	Sub FillComboColegio()
		Try
			strConnection = _
				"Provider=Microsoft.Jet.OLEDB.4.0;" _
				& "Password=;" _
				& "Data Source=" & databaseFile
			Dim MyConnection As New OleDbConnection(strConnection)
			MyConnection.Open()
			Dim query As String = "SELECT DISTINCT NLOCAL FROM  "& procesoElectoral
			Dim MyCommand As New OleDbCommand
			MyCommand.Connection = MyConnection
			MyCommand.CommandText = query
			MyCommand.ExecuteNonQuery()
			Dim MyDataReader As OleDbDataReader
			MyDataReader = MyCommand.ExecuteReader
			Me.cmbColegio.Items.Add("")
			While MyDataReader.Read
				Me.cmbColegio.Items.Add(MyDataReader("NLOCAL").ToString)
			End While
			MyConnection.Close()
		Catch ex As Exception
			MsgBox(ex.ToString)
			System.Console.Write(ex.ToString)
		End Try
	End Sub
	
	Sub FillComboMesa()
		Try
			strConnection = _
				"Provider=Microsoft.Jet.OLEDB.4.0;" _
				& "Password=;" _
				& "Data Source=" & databaseFile
			Dim MyConnection As New OleDbConnection(strConnection)
			MyConnection.Open()
			Dim query As String = "SELECT DISTINCT MESA FROM  "& procesoElectoral
			Dim MyCommand As New OleDbCommand
			MyCommand.Connection = MyConnection
			MyCommand.CommandText = query
			MyCommand.ExecuteNonQuery()
			Dim MyDataReader As OleDbDataReader
			MyDataReader = MyCommand.ExecuteReader
			Me.cmbMesa.Items.Add("")
			While MyDataReader.Read
				Me.cmbMesa.Items.Add(MyDataReader("MESA").ToString)
			End While
			MyConnection.Close()
		Catch ex As Exception
			MsgBox(ex.ToString)
			System.Console.Write(ex.ToString)
		End Try
	End Sub
	
	Sub FillComboSecc()
		Try
			strConnection = _
				"Provider=Microsoft.Jet.OLEDB.4.0;" _
				& "Password=;" _
				& "Data Source=" & databaseFile
			Dim MyConnection As New OleDbConnection(strConnection)
			MyConnection.Open()
			Dim query As String = "SELECT DISTINCT SECC FROM  "& procesoElectoral
			Dim MyCommand As New OleDbCommand
			MyCommand.Connection = MyConnection
			MyCommand.CommandText = query
			MyCommand.ExecuteNonQuery()
			Dim MyDataReader As OleDbDataReader
			MyDataReader = MyCommand.ExecuteReader
			Me.cbxSecc.Items.Add("")
			While MyDataReader.Read
				Me.cbxSecc.Items.Add(MyDataReader("SECC").ToString)
			End While
			MyConnection.Close()
		Catch ex As Exception
			MsgBox(ex.ToString)
			System.Console.Write(ex.ToString)
		End Try
	End Sub
	
	Sub BtnFiltrarClick(ByVal sender As Object, ByVal e As EventArgs)
		Dim boton As Button = sender
		Me.bindingSource1.RemoveFilter()
		Dim mesa As String = Me.cmbMesa.Text
		Dim cole As String = Me.cmbColegio.Text
		Dim estado As String = Me.cboxNotificado.Text
		Dim cargo As String = Me.cmbBoxCargo.Text
		Dim sorteo As String = Me.cmbBoxSorteo.Text
		Dim secc As String = Me.cbxSecc.Text
		Dim colFilter As String = String.Format("NLOCAL = '" & cole & "'", "NLOCAL Desc", DataViewRowState.CurrentRows)
		Dim mesaFilter As String = String.Format("MESA = '" & mesa & "'", "MESA Desc", DataViewRowState.CurrentRows)
		Dim seccFilter As String = String.Format("SECC = '" & secc & "'", "SECC Desc", DataViewRowState.CurrentRows)
		Dim notiFilter As String = String.Format("ESTADO = '" & estado & "'", "ESTADO Desc", DataViewRowState.CurrentRows)
		Dim cargoFilter As String = String.Format("CARGOFINAL = '" & cargo & "'", "CARGOFINAL Desc", DataViewRowState.CurrentRows)
		Dim sorteoFilter As String = String.Format("SORTEO = '" & sorteo & "'", "SORTEO Desc", DataViewRowState.CurrentRows)
		'Aplicar los filtros..
		If Not String.IsNullOrEmpty(cole) Then
			Me.bindingSource1.Filter = colFilter
		End If
		If Not String.IsNullOrEmpty(mesa) Then
			if String.IsNullOrEmpty(Me.bindingSource1.Filter)
			Me.bindingSource1.Filter = mesaFilter
		Else
			Me.bindingSource1.Filter = Me.bindingSource1.Filter & " And " & mesaFilter
		End If
	End If
	If Not String.IsNullOrEmpty(secc) Then
		if String.IsNullOrEmpty(Me.bindingSource1.Filter)
		Me.bindingSource1.Filter = seccFilter
	Else
		Me.bindingSource1.Filter = Me.bindingSource1.Filter & " And " & seccFilter
	End If
End If
If Not String.IsNullOrEmpty(estado) Then
	If estado = "NOTIFICADO/POR NOTIFICAR" Then
		notiFilter = String.Format("ESTADO = 'NOTIFICADO'", "ESTADO Desc", DataViewRowState.CurrentRows) _
		& " Or " & String.Format("ESTADO = 'POR NOTIFICAR'", "ESTADO Desc", DataViewRowState.CurrentRows)
	End If
	if String.IsNullOrEmpty(Me.bindingSource1.Filter)
	Me.bindingSource1.Filter = notiFilter
Else
	Me.bindingSource1.Filter = Me.bindingSource1.Filter & " And " & notiFilter
End If
End If
If Not String.IsNullOrEmpty(cargo) Then
	if String.IsNullOrEmpty(Me.bindingSource1.Filter)
	Me.bindingSource1.Filter = cargoFilter
Else
	Me.bindingSource1.Filter = Me.bindingSource1.Filter & " And " & cargoFilter
End If
End If
If Not String.IsNullOrEmpty(sorteo) Then
	If String.IsNullOrEmpty(Me.bindingSource1.Filter)
	Me.bindingSource1.Filter = sorteoFilter
Else
	Me.bindingSource1.Filter = Me.bindingSource1.Filter & " And " & sorteoFilter
End If
End If
If Not Me.cbxSecc.Text  = "" And  Not  Me.cmbMesa.Text = "" And Me.cboxNotificado.Text = "NOTIFICADO" Then
	Me.btnMesa.Visible = True
Else
	Me.btnMesa.Visible = False
End If
End Sub

Sub BtnQuitarFiltrosClick(ByVal sender As Object, ByVal e As EventArgs)
	Me.cmbMesa.Text = ""
	Me.cmbColegio.Text = ""
	Me.cboxNotificado.Text = ""
	Me.cmbBoxCargo.Text = ""
	Me.cmbBoxSorteo.Text = ""
	Me.cbxSecc.Text = ""
	Me.toolStripTextBox1.Text = ""
	BtnFiltrarClick(Me.btnQuitarFiltros, EventArgs.Empty)
	Me.btnMesa.Visible = False
End Sub

Sub MainFormFormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs)
	loadBaseOptions()
End Sub

Sub ChkBoxTodosCheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
	If Me.chkBoxTodos.Checked Then
		Me.dataGridView1.SelectAll()
	Else
		Me.dataGridView1.ClearSelection()
	End If
End Sub

Sub ToolStripBtnImportClick(ByVal sender As Object, ByVal e As EventArgs)
	Dim scan As FormScan = New FormScan
	scan.Owner = Me
	scan.Show()
End Sub

Sub ToolStripButtonSearchClick(ByVal sender As Object, ByVal e As EventArgs)
	Dim strSearchString As String = Me.toolStripTextBox1.Text
	Dim encontrado As Boolean = False
	'dataGridView1.ClearSelection
	Dim i As Integer = 0
	Dim cell As DataGridViewCell = dataGridView1.Rows(0).cells(0)
	Dim salida As Integer
	dataGridView1.Select()
	cell.Selected = true
	'For Each myRow  In dataGridView1.Rows
	For Each myRow As DataGridViewRow In dataGridView1.Rows
		For Each myCell As DataGridViewCell In myRow.Cells
			If InStr(myCell.Value.ToString, strSearchString, CompareMethod.Text) Then
				myRow.Selected = True
				dataGridView1.CurrentCell = myCell
				encontrado = True
				i+=1
				If MsgBox(strSearchString & " encontrado", MsgBoxStyle.OkCancel + MsgBoxStyle.Information, "Busqueda") = 1 Then
					exit for
				End If
				'MsgBox(strSearchString & " encontrado",, "Busqueda")
			End If
		Next
	Next
	If i > 1 Then
		MsgBox("Se han encontrado " & i  &  "  coincidencias de " & strSearchString,, "Busqueda")
	End If
	If Not encontrado Then
		MsgBox("No encontrado",,"Busqueda")
	End If
End Sub

Sub ImportarBarcodes(ByVal numItems as Integer, ByVal items as String(), ByVal fecha as String, ByVal estado as String)
	Dim i As Integer = numItems
	ReDim listaBarcodes(i)
	Dim dia As String = fecha
	Dim state as String = estado
	Dim MyConnection As New OleDbConnection(strConnection)
	Dim query As String = ""
	Dim MyCommand As New OleDbCommand
	Dim MyCommand2 As New OleDbCommand
	Dim MyCommand3 As New OleDbCommand
	Try
		MyConnection.Open()
		MyCommand.Connection = MyConnection
		MyCommand2.Connection = MyConnection
		MyCommand3.Connection = MyConnection
		Dim MyDataReader As OleDbDataReader
		Dim MyDataReader2 As OleDbDataReader
		Dim n As Integer = 0
		Dim result As String = ""
		Dim actualizar As Boolean = True
		dataGridView1.ClearSelection()
		For Each strLine As String In items
			'UPDATE IDENT
			query = "SELECT * FROM " & procesoElectoral & " WHERE ident Like '" & strLine & "'"
			MyCommand.CommandText = query
			MyDataReader = MyCommand.ExecuteReader
			While MyDataReader.Read
				result = MyDataReader("ESTADO")
			End While
			MyDataReader.Close()
			If result.Equals("REPETIDO") Then
				actualizar = False
				MsgBox("REPETIDO")
				Else If result.Equals("EXCUSADO") Then
				actualizar = False
				MsgBox("EXCUSADO")
				Else If result.Contains("ALEGACIONES") Then
				actualizar = False
				MsgBox("ALEGACIONES")
			Else
				actualizar = True
			End If
			If actualizar Then
				query = "UPDATE " & procesoElectoral & " SET ESTADO = '" _
				& state & "', FECHA = '" & dia & "' WHERE IDENT = '" & strLine & "'"
				MyCommand.CommandText = query
				MyCommand.ExecuteNonQuery()
			End if
			
			'UPDATE IDENT (ORIGINAL)
			'			query = "UPDATE " & procesoElectoral & " SET ESTADO = '" _
			'			& state & "', FECHA = '" & dia & "' WHERE IDENT = '" & strLine & "' AND ESTADO NOT LIKE 'REPETIDO'"
			'			MyCommand.CommandText = query
			'			MyCommand.ExecuteNonQuery()
			
			'Aquí finaliza  pero si es imposible hay que seguir
			'GET DATA
			If state = "IMPOSIBLE NOTIFICAR" Then
				query = "SELECT * FROM " & procesoElectoral & " WHERE IDENT = '" & strline & "'"
				MyCommand.CommandText = query
				MyDataReader = MyCommand.ExecuteReader
				Dim secc, mesa, cargo, num, ident As String
				Dim bucle As Int32
				While MyDataReader.Read
					If bucle < 1 Then
						ListadoPrintHeader(False)
					End If
					mesa = MyDataReader("MESA").ToString
					cargo = MyDataReader("CARGOFINAL").ToString
					num = MyDataReader("SORTEO").ToString
					secc = MyDataReader("SECC").ToString
					num = Regex.Replace(num, "\D", "")
					n = Convert.toInt32(num)
					If n = 4 Then
						MsgBox("Sorteo 4 ya nombrado!!")
					End If
					n = n + 1
					query = "UPDATE " & procesoElectoral & " SET ESTADO = 'POR NOTIFICAR'" _
					&" WHERE (SECC = '" & secc & "' AND MESA = '" & mesa & "' AND CARGOFINAL = '" & cargo & _
					"' AND SORTEO = 'SORTEO " & String.Format(n) &"')"
					MyCommand2.CommandText = query
					MyCommand2.ExecuteNonQuery
					query = "SELECT * FROM " & procesoElectoral & " WHERE (" _
						& "SECC = '" & secc & "' AND MESA = '" & mesa & "' AND CARGOFINAL = '" & cargo _
					& "' AND SORTEO = 'SORTEO " & String.Format(n) &"')"
					MyCommand3.CommandText = query
					MyDataReader2 = MyCommand3.ExecuteReader
					While MyDataReader2.Read
						ident = MyDataReader2("IDENT").ToString
						For Each myRow As DataGridViewRow In Me.dataGridView1.Rows
							For Each myCell As DataGridViewCell In myRow.Cells
								If	InStr(myCell.Value.ToString, ident, CompareMethod.Text) Then
									dataGridView1.CurrentCell = myCell
									ListadoPrint(True)
								End If
							Next
						Next
					End While
					MyDataReader2.Close()
					bucle = bucle + 1
				End While
				MyDataReader.Close()
				loadTemplateFolderOptions()
				Process.Start("explorer.exe", templateFolder)
			End If
		Next
		MyConnection.Close()
		MyConnection.Open()
		dt.AcceptChanges()
		Application.Restart()
	Catch ex As Exception
		MsgBox(ex.ToString)
	End Try
End Sub

Function DniRepetido (ByVal ident As String) As Boolean
	Dim MyConnection As New OleDbConnection(strConnection)
	Dim query As String = ""
	Dim MyCommand As New OleDbCommand
	Try
		MyConnection.Open()
		MyCommand.Connection = MyConnection
		query = "SELECT COUNT (*) FROM " & procesoElectoral & " WHERE IDENT = '" _
		& ident & "'"
		MyCommand.CommandText = query
		MyCommand.ExecuteNonQuery()
	Catch ex As Exception
		'TODO
	End Try
	Return true
End Function

Sub SoloListado(ByVal numItems As Integer, ByVal items As String())
	'Dim i As Integer = numItems
	'ReDim listaBarcodes(i)
	Dim MyConnection As New OleDbConnection(strConnection)
	Dim query As String = ""
	Dim MyCommand As New OleDbCommand
	Try
		'Dim MyDataReader As OleDbDataReader
		Dim MyDataReader4 As OleDbDataReader
		MyConnection.Open()
		MyCommand.Connection = MyConnection
		Dim n As Integer = 0
		Dim ident As String = ""
		dataGridView1.ClearSelection()
		'			Dim bucle As Int32 = 0
		ListadoPrintHeader(False)
		For Each strLine As String In items
			query = "SELECT * FROM " & procesoElectoral & " WHERE IDENT = '" & strline & "'"
			MyCommand.CommandText = query
			MyDataReader4 = MyCommand.ExecuteReader
			While MyDataReader4.Read
				'					If bucle < 1 Then
				'						ListadoPrintHeader(False)
				'					End If
				ident = MyDataReader4("IDENT").ToString
				For Each myRow As DataGridViewRow In Me.dataGridView1.Rows
					For Each myCell As DataGridViewCell In myRow.Cells
						If	InStr(myCell.Value.ToString, ident, CompareMethod.Text) Then
							dataGridView1.CurrentCell = myCell
							ListadoPrint(True)
						End If
					Next
				Next
			End While
			MyDataReader4.Close()
			'				bucle = bucle + 1
		Next
		MyConnection.Close()
		loadTemplateFolderOptions()
		Process.Start("explorer.exe", templateFolder)
	Catch ex As Exception
		MsgBox(ex.ToString)
	End Try
End Sub

Sub ToolStripTextBox1KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
	If e.KeyCode = Keys.Enter Then
		ToolStripButtonSearchClick(Me.toolStripTextBox1, e)
	End If
End Sub

End Class
