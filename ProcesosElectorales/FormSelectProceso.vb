
' Formulario FormSelectProceso

Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.DataRow

Public Partial Class FormSelectProceso
	
	Dim proceso as String = "Ninguno seleccionado"
	
	Public Sub New(byVal databaseFile as String)	
		'Dim strSelect As String = "SELECT Proceso FROM Procesos ORDER BY Num DESC"
		Dim strSelect As String = "SELECT Proceso FROM Procesos"
		Dim MyConnection As New OleDbConnection()
		Dim tabla as string = "Procesos"
		Me.InitializeComponent()
		Dim objDataAdapter As System.Data.OleDb.OleDbDataAdapter
		Dim MyConString As String = _
			"Provider=Microsoft.Jet.OLEDB.4.0;" _
			& "Password=;" _
			& "Data Source=" _
			& databaseFile
		Try
			MyConnection.ConnectionString = MyConString
			MyConnection.Open()
		Catch MyException As Exception
			MsgBox(MyException.ToString)
		End Try
		objDataAdapter = New OleDbDataAdapter(strSelect, MyConnection)
		objDataAdapter.Fill(Me.dataSet1)
		Me.dataGridView1.AutoResizeColumns()
		Me.dataGridView1.DataSource = Me.dataSet1
		Me.dataGridView1.DataMember = Me.dataSet1.Tables(0).TableName
		MyConnection.Close()
	End Sub
	
	Public Function GetProceso() As String
		return proceso
	End Function
	
	Sub BtnOkClick(ByVal sender As Object, ByVal e As EventArgs)	
		Dim numRows As Integer = Me.dataGridView1.RowCount
		If numRows > 0 Then
			proceso = Me.dataGridView1.SelectedCells(0).Value.ToString
			Me.DialogResult = DialogResult.Ok
		Else
			Me.DialogResult = DialogResult.Cancel
		End If
	End Sub
	
	Sub BtnCancelClick(ByVal sender As Object, ByVal e As EventArgs)
		Me.DialogResult = DialogResult.Cancel
	End Sub
	
End Class
