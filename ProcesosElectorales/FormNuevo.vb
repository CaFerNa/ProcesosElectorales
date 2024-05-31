'
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.DataRow
Imports System.Text

Public Partial Class FormNuevo
	
	Dim nombreProceso As String = ""
	Dim nombreProcesoLong As String = ""
	Dim importFile As String = ""
	Dim MyConnection As New OleDbConnection()
	Dim sqlCommand As New OleDbCommand
	Dim file as String = ""

	
	Public Sub New(ByVal databaseFile As String)
		file = databaseFile
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
	End Sub
	
	Function GetName() As String
		return nombreProceso
	End Function
	
	Function GetLongName() As String
		Return nombreProcesoLong
	End Function
	
	Sub BtnOkClick(ByVal sender As Object, ByVal e As EventArgs)
		nombreProcesoLong = textBoxNombreProceso.Text
		nombreProceso = textBoxNombreProceso.Text.Replace(" ", String.Empty)
		If MsgBox("¿Desea crear el proceso electoral?", MsgBoxStyle.OkCancel,"Confirme") = DialogResult.OK Then
			CreateTables()
			'FormatCargos()
			Me.DialogResult = DialogResult.OK
		Else
			Me.DialogResult = DialogResult.Cancel
		End If
	End Sub
	
	Sub BtnCancelClick(ByVal sender As Object, ByVal e As EventArgs)
		Me.DialogResult = DialogResult.Cancel
	End Sub
	
	Sub CreateTables()
		Dim MyConString As String = _
			"Provider=Microsoft.Jet.OLEDB.4.0;" _
			& "Password=;" _
			& "Data Source=" & file
		Try
			MyConnection.ConnectionString = MyConString
			MyConnection.Open()
			sqlCommand.Connection = MyConnection
			sqlCommand.CommandText = "DROP TABLE " & nombreProceso
			sqlCommand.ExecuteNonQuery()
		Catch MyException As Exception
			System.Console.Write(MyException.ToString)
		End Try
		Try
			openFileDialog1.InitialDirectory = "C:\\Users\\usuario\\Documents"
			openFileDialog1.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*"
			openFileDialog1.FilterIndex = 1
			openFileDialog1.FileName = ""
			openFileDialog1.ShowDialog(Me)
			Dim seleccion As String = openFileDialog1.FileName
			importFile = seleccion
			CreateTable()
			'ImportData(nombreProceso)
		Catch MyException As Exception
			System.Console.Write(MyException.ToString)
			MsgBox(MyException.ToString)
		End Try
		Try
			'Insertar la nueva tabla en 'Procesos'
			Dim fecha As String = String.Format(System.DateTime.Now.ToString("dd/MM/yyyy"))
			
			'sqlCommand.CommandText = "SELECT MAX(Num) FROM Procesos"
			'sqlCommand.ExecuteNonQuery()			
			
			sqlCommand.CommandText = "INSERT INTO Procesos VALUES('" _
			& nombreProcesoLong & "', '" & fecha & "','', '" & nombreProceso & "')"
			sqlCommand.ExecuteNonQuery()
			MyConnection.Close()
			MsgBox("Proceso " & nombreProcesoLong & " creado",,"Info")
		Catch ex As Exception
			System.Console.WriteLine(ex.ToString)
			MsgBox(ex.ToString)
		End Try
	End Sub
	
	Sub CreateTable()
		Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(importFile.ToString, System.Text.Encoding.UTF8)
			MyReader.TextFieldType = FileIO.FieldType.Delimited
			MyReader.SetDelimiters(";")
			Dim currentRow As String()
			Dim sqlString As String = ""
			While Not MyReader.LineNumber > 1
				Try
					currentRow = MyReader.ReadFields()
					Dim currentField As String
					sqlString = "CREATE TABLE " & nombreProceso & " ("
					For Each currentField In currentRow
						If currentField.Length > 0  Then
							sqlString = sqlString & currentField & " varchar(255), "
						End If
						'MsgBox(sqlString)
					next
					'sqlString = sqlString.Substring(0, sqlString.Length - 2)
					'sqlString = sqlString & ")"
					'MsgBox(sqlString)
					sqlString = sqlString & "ESTADO varchar(255), FECHA varchar(255), SORTEO varchar(255))"
					sqlCommand.CommandText = sqlString
					MsgBox(sqlString)
				Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
					System.Console.WriteLine("Line " & ex.Message & "is not valid and will be skipped.")
				End Try
			End While
			Try
				sqlCommand.ExecuteNonQuery()
				'sqlString = "ALTER TABLE " & nombreProceso &" ADD PRIMARY KEY (IDENT)"
				sqlString = "ALTER TABLE " & nombreProceso &" ADD PRIMARY KEY (IDENT,SORTEO)"
				sqlCommand.CommandText = sqlString
				sqlCommand.ExecuteNonQuery()
			Catch ex As Exception
				MsgBox(ex.ToString)
			End Try
		End Using
	End Sub
	
'	Sub FormatCargos()
'		Dim nombre As String = nombreProceso
'		Try
'			MyConnection.Open()
'			'Update Presidente
'			Try
'				sqlCommand.Connection = MyConnection
'				sqlCommand.CommandText = "UPDATE " & nombre & " Set CARGOFINAL = 'PRESIDENTE TITULAR' WHERE CARGOFINAL = 'P'"
'				sqlCommand.ExecuteNonQuery()
'			Catch ex As Exception
'				System.Console.WriteLine(ex.ToString)
'			End Try
'			
'			Try
'				sqlCommand.Connection = MyConnection
'				sqlCommand.CommandText =  "UPDATE " & nombre & " SET CARGOFINAL = 'PRESIDENTE 1º SUPLENTE' WHERE CARGOFINAL = 'PS1'"
'				sqlCommand.ExecuteNonQuery()
'			Catch ex As Exception
'				System.Console.WriteLine(ex.ToString)
'			End Try
'			
'			Try
'				sqlCommand.Connection = MyConnection
'				sqlCommand.CommandText =  "UPDATE " & nombre & " Set CARGOFINAL = 'PRESIDENTE 2º SUPLENTE' WHERE CARGOFINAL = 'PS2'"
'				sqlCommand.ExecuteNonQuery()
'			Catch ex As Exception
'				System.Console.WriteLine(ex.ToString)
'			End Try
'			
'			'Update Vocal 1º
'			Try
'				sqlCommand.Connection = MyConnection
'				sqlCommand.CommandText = "UPDATE " & nombre & " Set CARGOFINAL = '1º VOCAL TITULAR' WHERE CARGOFINAL = 'V1'"
'				sqlCommand.ExecuteNonQuery()
'			Catch ex As Exception
'				System.Console.WriteLine(ex.ToString)
'			End Try
'			
'			Try
'				sqlCommand.Connection = MyConnection
'				sqlCommand.CommandText =  "UPDATE " & nombre & " SET CARGOFINAL = '1º VOCAL 1º SUPLENTE' WHERE CARGOFINAL = 'V1S1'"
'				sqlCommand.ExecuteNonQuery()
'			Catch ex As Exception
'				System.Console.WriteLine(ex.ToString)
'			End Try
'			
'			Try
'				sqlCommand.Connection = MyConnection
'				sqlCommand.CommandText =  "UPDATE " & nombre & " Set CARGOFINAL = '1º VOCAL 2º SUPLENTE' WHERE CARGOFINAL = 'V1S2'"
'				sqlCommand.ExecuteNonQuery()
'			Catch ex As Exception
'				System.Console.WriteLine(ex.ToString)
'			End Try
'			
'			'Update Vocal 2º
'			Try
'				sqlCommand.Connection = MyConnection
'				sqlCommand.CommandText = "UPDATE " & nombre & " Set CARGOFINAL = '2º VOCAL TITULAR' WHERE CARGOFINAL = 'V2'"
'				sqlCommand.ExecuteNonQuery()
'			Catch ex As Exception
'				System.Console.WriteLine(ex.ToString)
'			End Try
'			
'			Try
'				sqlCommand.Connection = MyConnection
'				sqlCommand.CommandText =  "UPDATE " & nombre & " SET CARGOFINAL = '2º VOCAL 1º SUPLENTE' WHERE CARGOFINAL = 'V2S1'"
'				sqlCommand.ExecuteNonQuery()
'			Catch ex As Exception
'				System.Console.WriteLine(ex.ToString)
'			End Try
'			
'			Try
'				sqlCommand.Connection = MyConnection
'				sqlCommand.CommandText =  "UPDATE " & nombre & " Set CARGOFINAL = '2º VOCAL 2º SUPLENTE' WHERE CARGOFINAL = 'V2S2'"
'				sqlCommand.ExecuteNonQuery()
'			Catch ex As Exception
'				System.Console.WriteLine(ex.ToString)
'			End Try
'		Catch subex As Exception
'			System.Console.WriteLine(subex.ToString)
'		End Try
'			MyConnection.Close()
'	End Sub
	
	Sub ImportData(ByVal nombreElecciones As String)
		Dim nombre As String = nombreElecciones
		Dim objStreamWriter As StreamWriter
		objStreamWriter = New StreamWriter("Log.txt", True, Encoding.Default)
		Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(importFile.ToString, System.Text.Encoding.UTF7)
			MyReader.TextFieldType = FileIO.FieldType.Delimited
			MyReader.SetDelimiters(";")
			Dim currentRow As String()
			While Not MyReader.EndOfData
				Try
					sqlCommand.Connection = MyConnection
					currentRow = MyReader.ReadFields()
					Dim currentField As String
					Dim sqlString As String = "INSERT INTO " & nombre & " VALUES('"
					For Each currentField In currentRow
						sqlString = sqlString & currentField & "','"
					next
'					sqlString = sqlString.Substring(0, sqlString.Length - 3)
'					sqlString = sqlString & ")"
					sqlString = sqlString & "POR NOTIFICAR','','SORTEO 1')"
					If MyReader.LineNumber <> 2 Then
						sqlCommand.CommandText = sqlString
						Try
							sqlCommand.ExecuteNonQuery()
						Catch ex As Exception
							System.Console.WriteLine(ex.ToString)
						End Try
					End If
				Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
					System.Console.WriteLine("Line " & ex.Message & "is not valid and will be skipped.")
				End Try
			End While
'			Dim sqlStringUpdate As String = "UPDATE " & nombre & " Set ESTADO = 'POR NOTIFICAR' WHERE SORTEO = 'SORTEO 1'"
'			sqlCommand.CommandText = sqlStringUpdate
'			Try
'				sqlCommand.ExecuteNonQuery()
'			Catch ex as Exception
'				objStreamWriter.WriteLine(ex.ToString)
'			End Try
		End Using
	End Sub
	
	Sub NewProceso()
		' TODO?
	End Sub
	
End Class
