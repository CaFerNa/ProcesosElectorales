'
' Creado por SharpDevelop.
' Usuario: cfernandez
' Fecha: 07/11/2018
' Hora: 14:37
' 
' Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
'

Public Partial Class FormScan
	Public Sub New()
		Me.InitializeComponent()
		Me.dateTimePicker1.Format = DateTimePickerFormat.Custom
	End Sub
	
	Sub BtnAceptarClick(ByVal sender As Object, ByVal e As EventArgs)
		If Me.textBox1.Lines.Length > 0 Then
			'ImportarDatos()
			AceptarListado()
		End If
		Me.textBox1.Text = ""
		Me.textBox1.Focus
	End Sub
	
	Sub BtnSoloListaClick(ByVal sender As Object, ByVal e As EventArgs)
		If Me.textBox1.Lines.Length > 0 Then
			AceptarSoloListado()
		End If
		Me.textBox1.Text = ""
		Me.textBox1.Focus
	End Sub
	
	Sub FormScanLoad(ByVal sender As Object, ByVal e As EventArgs)
		Me.textBox1.Focus
	End Sub
	
	Sub AceptarListado
		Dim MyParent As MainForm
		Dim n, i As Integer
		i = Me.textBox1.Lines.Length -1
		Dim listaItems(i) As String
		n = 0
		For Each strLine As String In Me.textBox1.Lines  'Text.Split(vbnewLine)
			If strLine.Length > 0 Then
				listaItems(n) = strLine
				n = n +1
			End If
		Next
		Me.textBox1.Focus
		' Directast presenta una operación de conversión de tipos basada en la herencia o implementación:
		' DirectCast(expression, typename)
		' expression (required; any) The data item to be converted 
		' typename (required; Keyword) The data type, object type, structure, or interface to which expression is to be converted
		
		MyParent = DirectCast(Me.Owner, MainForm)
		MyParent.ImportarBarcodes(i, listaItems, dateTimePicker1.Text, comboBox1.Text)
	End Sub
	
	Sub AceptarSoloListado
		Dim MyParent As MainForm
		Dim n, i As Integer
		i = Me.textBox1.Lines.Length -1
		Dim listaItems(i) As String
		n = 0
		For Each strLine As String In Me.textBox1.Lines  'Text.Split(vbnewLine)
			If strLine.Length > 0 Then
				listaItems(n) = strLine
				n = n +1
			End If
		Next
		Me.textBox1.Focus
		MyParent = DirectCast(Me.Owner, MainForm)
		MyParent.SoloListado(i, listaItems)
	End Sub
	
	Sub BtnCloseClick(ByVal sender As Object, ByVal e As EventArgs)
		Me.Dispose()
	End Sub
	
	Sub BtnLimpiarClick(ByVal sender As Object, ByVal e As EventArgs)
		Me.textBox1.Text = ""
	End Sub
	
End Class
