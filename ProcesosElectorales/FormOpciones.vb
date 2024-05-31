'
' Creado por SharpDevelop.
' Usuario: usuario
' Fecha: 04/11/2018
' Hora: 18:31
'
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.DataRow
Imports System.Text.RegularExpressions
Imports System.Text
Imports System.IO

Public Partial Class FormOpciones
	
	Dim proceso As String = ""
	Dim base As String = ""
	Dim word As String = ""
	Dim myColVisibles As String = ""
	Dim formSize As String =""
	Dim MyConnection As New OleDbConnection()
	Dim sqlCommand As New OleDbCommand
	
	Public Sub New(ByVal baseDir as String, ByVal tplDir as String, ByVal nombreProceso as String, ByVal wordExe As String, ByVal colVisibles As String)
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
		proceso = nombreProceso
		base = baseDir
		word = wordExe
		myColVisibles = colVisibles
		toolTip1.SetToolTip(Me.btnImport, "Seleccione sorteos para el presente Proceso Electoral")
		toolTip1.SetToolTip(Me.btnBase, "Seleccione fichero de la Base de datos")
		tooltip1.SetToolTip(Me.btnPlantillas, "Seleccione la carpeta de plantillas para el presente Proceso")
		tooltip1.SetToolTip(Me.listBoxColumnas, "Seleccione las columnas visibles")
		tooltip1.SetToolTip(Me.btnWord, "Seleccione el ejecutable de Word")
		Me.txbBase.Text = baseDir
		Me.txtWord.Text = word
		loadOptions()
	End Sub
	
	Sub BtnCancelClick(ByVal sender As Object, ByVal e As EventArgs)
		Me.DialogResult = DialogResult.Cancel
	End Sub
	
	Sub BtnOkClick(ByVal sender As Object, ByVal e As EventArgs)
		Me.DialogResult = DialogResult.OK
	End Sub
	
	Sub loadOptions()
		Dim readFolderValue As String
		readFolderValue = My.Computer.Registry.GetValue _
			("HKEY_CURRENT_USER\Software\cfr\Procesos Electorales", "TemplateFolder", Nothing)
		Me.txtTempl.Text = readFolderValue
		Dim readWordExeValue As String
		readWordExeValue = My.Computer.Registry.GetValue _
			("HKEY_CURRENT_USER\Software\cfr\Procesos Electorales", "WordExe", Nothing)
		Me.txtWord.Text = readWordExeValue
		ChkBoxCelSetVisiblecols()
'		Dim readSizeValue As String
'		readSizeValue = My.Computer.Registry.GetValue _
'			("HKEY_CURRENT_USER\Software\cfr\Procesos Electorales", "FormSize", Nothing)
'			My.Computer.Registry.CurrentUser.CreateSubKey("Software\cfr\Procesos Electorales")
'			My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\cfr\Procesos Electorales", "FormSize", Me.ParentForm.Size.ToString)
'		Me.formSize = readSizeValue
	End Sub
	
	Sub BtnBaseClick(ByVal sender As Object, ByVal e As EventArgs)
		openFileDialog1.InitialDirectory = "C:\\Users\\usuario\\Documents"
		openFileDialog1.Filter = "Access files (*.mdb)|*.mdb|All files (*.*)|*.*"
		openFileDialog1.FilterIndex = 1
		openFileDialog1.Title = "Seleccione fichero de la Base de datos"
		openFileDialog1.FileName = ""
		openFileDialog1.ShowDialog(Me)
		Me.txbBase.Text = openFileDialog1.FileName
	End Sub
	
	Sub btnPlantillasClick(ByVal sender As Object, ByVal e As EventArgs)
		folderBrowserDialog1.ShowDialog()
		Me.txtTempl.Text = folderBrowserDialog1.SelectedPath
		Dim readFolderValue As String
		readFolderValue = My.Computer.Registry.GetValue _
			("HKEY_CURRENT_USER\Software\cfr\Procesos Electorales", "TemplateFolder", Nothing)
		My.Computer.Registry.CurrentUser.CreateSubKey("Software\cfr\Procesos Electorales")
		My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\cfr\Procesos Electorales", "TemplateFolder", Me.txtTempl.Text)
	End Sub
	
	Sub BtnWordClick(ByVal sender As Object, ByVal e As EventArgs)
		openFileDialog1.InitialDirectory = "C:\\Users\\usuario\\Documents"
		openFileDialog1.Filter = "Exe files (*.exe)|*.exe|All files (*.*)|*.*"
		openFileDialog1.FilterIndex = 1
		openFileDialog1.Title = "Seleccione ejecutable de Word"
		openFileDialog1.FileName = ""
		openFileDialog1.ShowDialog(Me)
		Me.txtWord.Text = openFileDialog1.FileName
		Dim readWordExe As String
		readWordExe = My.Computer.Registry.GetValue _
			("HKEY_CURRENT_USER\Software\cfr\Procesos Electorales", "WordExe", Nothing)
		My.Computer.Registry.CurrentUser.CreateSubKey("Software\cfr\Procesos Electorales")
		My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\cfr\Procesos Electorales", "WordExe", Me.txtWord.Text)
	End Sub
	
	Function GetBaseName As String
		return Me.txbBase.Text
	End Function
	
	Function GetTemplateFolder As String
		return Me.txtTempl.Text
	End Function
	
	Function GetWordExe As String
		return Me.txtWord.Text
	End Function
	
	Function GetColVisibles As String
		return GetVisibleColumns()
	End Function
	
	Function GetMainFormSize As String
		return chkBoxMainFormSize.Checked.ToString
	End Function
	
	Sub BtnImportClick(ByVal sender As Object, ByVal e As EventArgs)
		openFileDialog1.InitialDirectory = "C:\\Users\\usuario\\Documents"
		openFileDialog1.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"
		openFileDialog1.FilterIndex = 1
		openFileDialog1.Title = "Seleccione fichero del Sorteo"
		openFileDialog1.FileName = ""
		Dim seleccion As String = ""
		Dim seleccionNombre As String = ""
		Dim match As String = ""
		If openFileDialog1.ShowDialog(Me) = DialogResult.OK Then
			seleccion = openFileDialog1.FileName
			seleccionNombre = openFileDialog1.SafeFileName.Substring(0, openFileDialog1.SafeFileName.Length - 4).Replace(" ", String.Empty)
			match = Regex.Replace(seleccionNombre, "\D", "")
			Try
				Dim MyConString As String = _
					"Provider=Microsoft.Jet.OLEDB.4.0;" _
					& "Password=;" _
					& "Data Source=" & base
				MyConnection.ConnectionString = MyConString
				MyConnection.Open()
				sqlCommand.Connection = MyConnection
			Catch ex As Exception
				MsgBox(ex.ToString)
				System.Console.Write(ex.ToString)
			End Try
			Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(seleccion.ToString, System.Text.Encoding.UTF7)
				MyReader.TextFieldType = FileIO.FieldType.Delimited
				MyReader.SetDelimiters(";")
				Dim ckeckOut As Integer = vbYes
				Dim currentRow As String()
				While Not MyReader.EndOfData
					Try
						Dim nombreTable As String = proceso '& seleccionNombre
						currentRow = MyReader.ReadFields()
						Dim currentField As String
						Dim sqlString As String = "INSERT INTO " & nombreTable & " VALUES('"
						Dim col As Integer = 0
						For Each currentField In currentRow
							'CARGOFINAL es el 11 en el 2024
							If col = 11 Then
								Select Case currentField
									Case "P"
										currentField = "PRESIDENTE TITULAR"
									Case "PS1"
										currentField = "PRESIDENTE 1º SUPLENTE"
									Case "PS2"
										currentField = "PRESIDENTE 2º SUPLENTE"
									Case "V1"
										currentField = "1º VOCAL TITULAR"
									Case "V1S1"
										currentField = "1º VOCAL 1º SUPLENTE"
									Case "V1S2"
										currentField = "1º VOCAL 2º SUPLENTE"
									Case "V2"
										currentField = "2º VOCAL TITULAR"
									Case "V2S1"
										currentField = "2º VOCAL 1º SUPLENTE"
									Case "V2S2"
										currentField = "2º VOCAL 2º SUPLENTE"
									Case Else
										'DO NOTHING
								End Select
							End If
							col+=1
							sqlString = sqlString & currentField & "','"
							'MsgBox(sqlString)
						Next
						'sqlString = sqlString & "','SORTEO "& match &"')"
						sqlString = sqlString & "','','SORTEO "& match &"')"
						If MyReader.LineNumber <> 2 Then
							sqlCommand.CommandText = sqlString
							Try
								'MsgBox(sqlString)
								If (ckeckOut = vbYes) Then
									ckeckOut = MsgBox(sqlString & vbCrLf & vbCrLf & "¿Volver a ver el mensaje?", MsgBoxStyle.YesNo)
								End If						
								sqlCommand.ExecuteNonQuery()
							Catch ex As Exception
								'								objStreamWriter.WriteLine(sqlCommand.CommandText)
								System.Console.WriteLine(ex.ToString)
								MsgBox(ex.ToString)
							End Try
						End If
					Catch ex As Exception
						System.Console.WriteLine(ex.ToString)
						'MsgBox(ex.Message)
					End Try
				End While
			End Using
			MyConnection.Close()
			MsgBox(sqlCommand.CommandText)
			MsgBox("Sorteo " & match & " importado")
		End If
		'objStreamWriter.Close
	End Sub
	
	Function GetVisibleColumns() As String
		Dim cols As String = ""
		For num As Integer = 0 To listBoxColumnas.Items.Count - 1
			If (Me.listBoxColumnas.GetItemChecked(num)) Then
				cols = cols + "1"
			Else
				cols = cols + "0"
			End if
		Next
		Return cols
	End Function
	
	Sub ChkBoxCelSetVisiblecols()
		For i As Integer = 0 To Me.listBoxColumnas.Items.Count -1
			If myColVisibles.Chars(i) = "0"   Then
				Me.listBoxColumnas.SetItemChecked(i, False)
			Else
				Me.listBoxColumnas.SetItemChecked(i, True)
			End If
		Next
	End Sub
	
	Sub ChkBoxCellSelectModeCheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
		If (Me.chkBoxCellSelectAll.Checked) Then
			For i As Integer = 0 To Me.listBoxColumnas.Items.Count -1
				Me.listBoxColumnas.SetItemChecked(i, True)
			Next
		Else
			For i As Integer = 0 To Me.listBoxColumnas.Items.Count -1
				Me.listBoxColumnas.SetItemChecked(i, False)
			Next
		End If
	End Sub
	
	Sub BtnBackupClick(ByVal sender As Object, ByVal e As EventArgs)
		MsgBox(base)
	End Sub
End Class
