REM  *****  BASIC  *****

Global oDialog1 as Object 'prueba con variable GLOBAL
Global oDialog2 as Object 'prueba con variable GLOBAL
Public Doc, Formularios, FormularioActual, Forma, Control, Componente As Object
Public filtros(4) As String

Option Explicit

Sub Main
	Dim oFrame As Object
	oFrame=ThisDatabaseDocument.CurrentController.Frame
	sMinimizaVentana(oFrame)
End Sub



Sub AbriendoDocumentos1()
	Dim sRuta As String
	Dim oRuta As String
	Dim oDocumento As Object
	Dim Form As Object
	Dim FileName as String
	Dim iFileLen as Integer
	Dim mArg(0) As New "com.sun.star.beans.PropertyValue"
	Dim CuadroCombinado As Object
	Dim plantillas(2) As String
	Dim NumeroPlantilla As Integer


        'Reemplaza esta ruta por la ruta de tu archivo
        'sRuta = ConvertToUrl( "Z:/Secretaria/Datos/Camilo/Elecciones/Andaluzas_2015/modelo_comunicacion_miembros.odt" )
        'sRuta = ConvertToUrl( "//PHOENIX/Departamentos/Secretaria/Datos/Juan Rodriguez/Mis Documentos/Elecciones/Elecciones Europeas 2014/sorteo_miembros_mesas/modelo_comunicacion_miembros.odt" )
        rem sRuta = ConvertToUrl("//PHOENIX/Departamentos/Secretaria/Datos/Juan Rodriguez/Mis Documentos/Elecciones/Elecciones Municipales 2015/BD/modelo_comunicacion_miembros.odt" )
        'sRuta = "file:///H:/datosasesoria.odb"
        'MsgBox sRuta, 64, "Título"
        rem oDocumento = StarDesktop.loadComponentFromURL( sRuta, "_blank", 0, mArg() ) 

	oDocumento = ThisComponent
	Form = oDocumento.DrawPage.Forms.GetByIndex(0)
	CuadroCombinado = Form.GetByName("cb_colegios")
	
	If CuadroCombinado.Text = "" then
		NumeroPlantilla = 0
	Else
		NumeroPlantilla = 1
	End If

	plantillas(0) = "modelo_comunicacion_miembros.odt"
	plantillas(1) = "Mesas.odt"
	
	mArg(0).Name = "Preview"
    mArg(0).Value = False
	
	oRuta = ConvertFromUrl(ThisDatabaseDocument.url)
	rem oRuta = ThisDatabaseDocument.url
	FileName = FileNameOutOfPath(oRuta)
	iFileLen = Len(FileName)
	sRuta = Left(oRuta, Len(oRuta)- iFileLen) + plantillas(NumeroPlantilla)
	oDocumento = StarDesktop.loadComponentFromURL( ConvertToUrl(sRuta), "_blank", 0, mArg() )

End Sub


Sub openSorteo1(Event As Object) 
   Dim Form As Object 
   Dim FormDoc AS Object 
   Dim FormCollection As Object 
   Dim DBDoc As Object 
   Dim Args(1) As New com.sun.star.beans.PropertyValue
   Dim oFrame As Object
    
   Form=Event.Source.Model.Parent 
   FormCollection=Form.Parent 
   FormDoc=FormCollection.Parent    
   DBDoc=FormDoc.Parent 

   Args(0).Name="ActiveConnection" 
   Args(0).Value=Form.ActiveConnection 
   Args(1).Name="OpenMode" 
   Args(1).Value="open" 

	DBDoc.FormDocuments.loadComponentFromURL("SORTEO_1","_blank",0,Args())
	oFrame=ThisDatabaseDocument.CurrentController.Frame
	sMinimizaVentana(oFrame)
End Sub 


Sub BorrarFicheroTmp 
	rem ThisComponent.CurrentController.Frame.close(True)
	Dim FileNo As Integer
	Dim FileName as String
	Dim iFileLen as Integer
	Dim oRuta, sRuta as String
	
	FileNo = FreeFile 
	oRuta = ConvertFromUrl(ThisDatabaseDocument.url)
	FileName = FileNameOutOfPath(oRuta)
	iFileLen = Len(FileName)
	sRuta = Left(oRuta, Len(oRuta)- iFileLen) + "tmp.txt"
	If FileExists(sRuta) Then 
		Kill(sRuta)
	End If
End Sub



Declare Function ShowWindow Lib "user32" (ByVal lHwnd As Long,ByVal lCmdShow As Long) As Boolean


Sub sMinimizaTodo()
   Dim oFrames As Object
   Dim oFrame As Object
   Dim i As Integer
   Dim c As Integer
   'Minimiza la ventana de Base
   oFrame=ThisDatabaseDocument.CurrentController.Frame
   sMinimizaVentana(oFrame)
   'Minimiza las otras ventanas
   oFrames=oFrame.Frames
   c=oFrames.Count
   For i=0 To c-1
      oFrame=oFrames(i)
      sMinimizaVentana(oFrame)
   Next
End Sub


Sub sMinimizaVentana(Frame As Object)
   Dim oConWin As Object
   Dim oHandle
   oConWin=Frame.GetContainerWindow()
   oHandle=oConWin.GetWindowHandle(dimarray(),1)
   ShowWindow(oHandle,2)   '2 para minimizar
End Sub


Sub ShowField

	Dim doc As Object
	Dim Form As Object
	Dim rowset As Object
	Dim Grid As Object
	Dim aValue As Object
	rem Retrieves a filename string from a field "URL"
	rem in the selected row of form having a grid control.
	rem This sub is activated
	rem by a push button on the form that is hooked to the 
	rem 'Mouse Button Pressed' event 
	rem Image is displayed via call to shell

	rem LibreOffice 3.5.4.2 with embedded database

	Doc = ThisComponent
	Form = Doc.DrawPage.Forms.GetByIndex(0)
	rowset=Form.getColumns
	rem data=rowset.getByName("NSORTEO").Value
	rem data=Form.GetByName("MainForm_Grid").currentvalue
	Grid = Form.GetByName("MainForm_Grid")
	rowset = Grid.getByName("NOMBRE")
	rem shell("/usr/bin/okular",1,filename)
	MsgBox rowset.currentvalue

end sub


Sub showInfo()

	Dim DatabaseContext As Object
	Dim Names
	Dim I As Integer
 
	DatabaseContext = createUnoService("com.sun.star.sdb.DatabaseContext")
 
	Names = DatabaseContext.getElementNames()
 
	For I = 0 To UBound(Names())
	  MsgBox Names(I)
	Next I

End Sub


Sub ShowResultSet

	Dim DatabaseContext As Object
	Dim DataSource As Object
	Dim Connection As Object
	Dim InteractionHandler as Object
	Dim Statement As Object
	Dim ResultSet As Object
 
	DatabaseContext = createUnoService("com.sun.star.sdb.DatabaseContext")
	DataSource = DatabaseContext.getByName("Elecciones_Andaluzas_2015")
 
	If Not DataSource.IsPasswordRequired Then
	  Connection = DataSource.GetConnection("","")
	Else
	  InteractionHandler = createUnoService("com.sun.star.sdb.InteractionHandler")
	  Connection = DataSource.ConnectWithCompletion(InteractionHandler)
	End If
 
	Statement = Connection.createStatement()
	ResultSet = Statement.executeQuery("SELECT ""CARGO"" FROM ""Mesas""") 
 
	If Not IsNull(ResultSet) Then
	  While ResultSet.next
	    MsgBox ResultSet.getString(1)
	  Wend
	End If
End Sub


Sub UpdateUser

	Dim doc As Object
	Dim Form As Object
	Dim rowset As Object
	Dim Grid As Object
	Dim DNI As String
	Dim SECC As String
	Dim MESA As String
	Dim NLOCAL As String
	Dim CARGO As String
	Dim NSORTEO As String
	
	Dim DatabaseContext As Object
	Dim DataSource As Object
	Dim Connection As Object
	Dim InteractionHandler as Object
	Dim Statement As Object
	Dim ResultSet As Object
	Dim NumRow As Integer
 
	Doc = ThisComponent
	Form = Doc.DrawPage.Forms.GetByIndex(0)
	Grid = Form.GetByName("MainForm_Grid")
	'MsgBox Grid.getSelectedRow
	'Doc.refresh
	rowset = Grid.GetByName("NSORTEO")
	NSORTEO = rowset.currentvalue
	rowset = Grid.getByName("SECC")
	SECC = rowset.currentvalue
	rowset = Grid.getByName("MESA")
	MESA = rowset.currentvalue
	rowset = Grid.getByName("NLOCAL")
	NLOCAL = rowset.currentvalue
	rowset = Grid.getByName("CARGO")
	CARGO = rowset.currentvalue

	'NumRow = Grid.LineCount
	
	'MsgBox NumRow

	'Doc.refresh
	
	If NSORTEO = "SORTEO 1" Then
		NSORTEO = "SORTEO_1"
	End If
	
	If NSORTEO = "SORTEO 2" Then
		NSORTEO = "SORTEO_2"
	End If
	
	If NSORTEO = "SORTEO 3" Then
		NSORTEO = "SORTEO_3"
	End If
	
	ConsultaListado(NSORTEO, SECC, MESA, NLOCAL, CARGO)
	
End Sub



Sub ConsultaListado(NSORTEO As String, SECC As String, MESA As String, NLOCAL As String, CARGO As String)

	Dim DatabaseContext As Object
	Dim DataSource As Object
	Dim Connection As Object
	Dim InteractionHandler as Object
	Dim Statement, Statement2 As Object
	Dim ResultSet As Object
	Dim ResultSet2 As Object
	Dim XPropertySet As Object
	Dim query, update As String

 	Dim NOLISTA As String
 	Dim GRES As String
 	Dim IDENT As String
 	Dim NOMBRE As String
 	Dim APELLIDO1 As String
 	Dim APELLIDO2 As String
 	Dim DOMI1 As String
	Dim DOMI2 As String
	Dim DOMI3 As String
	Dim DOMI4 As String
	Dim DOMI5 As String
	Dim CPOSTAL As String
 
	DatabaseContext = createUnoService("com.sun.star.sdb.DatabaseContext")
	DataSource = DatabaseContext.getByName("Elecciones_Generales_2016")
 
	If Not DataSource.IsPasswordRequired Then
	  Connection = DataSource.GetConnection("","")
	Else
	  InteractionHandler = createUnoService("com.sun.star.sdb.InteractionHandler")
	  Connection = DataSource.ConnectWithCompletion(InteractionHandler)
	End If
 
	Statement = Connection.createStatement()
	query = "SELECT * FROM """+NSORTEO+""" WHERE (""SECC"" LIKE '"+SECC+"' AND ""MESA"" LIKE '" +MESA+ "' AND ""NLOCAL"" LIKE '"+NLOCAL+"' AND ""CARGO"" LIKE '"+CARGO+"')" 
	'MsgBox query
	ResultSet = Statement.executeQuery(query)

	If Not IsNull(ResultSet) Then
	  While ResultSet.next
	  
		NOLISTA = ResultSet.getString(13)
		GRES = ResultSet.getString(14)
		IDENT = ResultSet.getString(15)
		NOMBRE = ResultSet.getString(16)
		APELLIDO1 = ResultSet.getString(17)
		APELLIDO2 = ResultSet.getString(18)
		DOMI1 = ResultSet.getString(19)
		DOMI2 = ResultSet.getString(20)
		DOMI3 = ResultSet.getString(21)
		DOMI4 = ResultSet.getString(22)
		DOMI5 = ResultSet.getString(23)
		CPOSTAL = ResultSet.getString(24)
		'MsgBox NOLISTA +" "+ GRES +" "+ IDENT +" "+	NOMBRE +" "+ APELLIDO1 +" "+ APELLIDO2 _
		'	+" "+ DOMI1 +" "+ DOMI2 +" "+ DOMI3 +" "+ DOMI4 +" "+ DOMI5 +" "+ CPOSTAL
	  Wend
	  
	  update = "UPDATE ""Mesas"" SET ""NOLISTA"" = '"+NOLISTA+"', " + _
	  	"""GRES"" = '"+GRES+"',  ""IDENT"" = '"+IDENT+"',  ""NOMBRE"" = '"+NOMBRE+"', " + _
	  	"""APELLIDO1"" = '"+APELLIDO1+"',  ""APELLIDO2"" = '"+APELLIDO2+"',  ""DOMI1"" = '"+DOMI1+"', " + _
	  	"""DOMI3"" = '"+DOMI3+"',  ""DOMI4"" = '"+DOMI4+"',  ""CPOSTAL"" = '"+CPOSTAL+"' " + _
	  	"WHERE (""SECC"" LIKE '"+SECC+"' AND ""MESA"" LIKE '" +MESA+ "' AND ""NLOCAL"" LIKE '"+NLOCAL+"' AND ""CARGO"" LIKE '"+CARGO+"')" 
	  
	  'MsgBox update
	  
	  Statement2 = Connection.createStatement()
	  Statement2.ResultSetConcurrency = 1008 'UPDATABLE
	  Statement2.executeUpdate(update)
	  grabar()
	  
	End If

End Sub


sub grabar
	rem ----------------------------------------------------------------------
	rem define variables
	dim document   as object
	dim dispatcher as object
	rem ----------------------------------------------------------------------
	rem get access to the document
	document   = ThisComponent.CurrentController.Frame
	dispatcher = createUnoService("com.sun.star.frame.DispatchHelper")

	rem ----------------------------------------------------------------------
	dispatcher.executeDispatch(document, ".uno:Refresh", "", 0, Array())
end sub

Sub PantallaCompleta(Event As Object)
   Dim oFrame As Object
   Dim oDispatchHelper
   oFrame=Event.Source.Parent.Parent.CurrentController.Frame
   oDispatchHelper=CreateUnoService("com.sun.star.frame.DispatchHelper")
   oDispatchHelper.ExecuteDispatch(oFrame,".uno:FullScreen","",0,Array())
End Sub

Sub MaximizaF(Frame As Object)
   Dim oConWin As Object
   Dim oHandle
   oConWin=Frame.GetContainerWindow()
   oHandle=oConWin.GetWindowHandle(dimarray(),1)
   ShowWindow(oHandle,3)
End Sub

Sub AlAbrir(Event As Object)
   Dim oFrame As Object
   oFrame=Event.Source.Parent.Parent.CurrentController.Frame
   MaximizaF(oFrame)
End Sub

Sub FormularioInicio()
	Dim Control as Object
	Control = ThisDatabaseDocument.CurrentController
	If Not Control.IsConnected Then	Control.Connect
	ThisDatabaseDocument.FormDocuments.GetByName("Formulario_Mesas").Open
End Sub

Sub CerrarBase()
	Dim opcion As integer
		opcion = MsgBox ("¿Realmente deseas salir de la BD?",36,"Opcion de salir BD")
	If opcion = 6 Then
		BorrarFicheroTmp()
		ThisDatabaseDocument.CurrentController.CloseSubComponents()	'Cierra todos los formularios y pregunta si guarda los datos
		'Wait(1000) 'sin esta espera de tiempo daba error para enviar a Oracle
		ThisDataBaseDocument.Close(True)'Cierra la base de datos (no pregunta nada)
	End if							
End Sub

Sub AplicarFiltros (Event As Object)
	Dim oFormulario As Object
	Dim oDocumento As Object
	Dim colegio, mesa, notificado As String
	Dim check, combo1, combo2 As Object
	
	'select distinct nlocal from Prueba2018
	
	oDocumento = ThisComponent
	oFormulario = Event.Source.getModel.Parent()
	combo1 = oFormulario.GetByName("cb_colegios")
	colegio =  combo1.Text
	combo2 = oFormulario.GetByName("cb_mesa")
	mesa = combo2.Text
	check = oFormulario.GetByName("check_notificado")
	notificado = check.State
	
	If Len(oFormulario.Filter) > 1 Then
			oFormulario.Filter = ""
	End If
	
	If Len (colegio) > 0 Then 
		colegio = "NLOCAL='" & colegio & "'" 
	End If
	If Len (mesa) > 0 Then 
		mesa = "AND MESA='" & mesa & "'" 
	End If
	If notificado > 0 Then 
		notificado = " AND ESTADO = 'NOTIFICADO'" 
	Else 
		notificado = ""
	End If	
	
	oFormulario.Filter = colegio &  mesa & notificado
	oFormulario.ApplyFilter = True
	oFormulario.reload()	
	
	REM MostrarFiltro

End Sub


Sub AplicarFiltrosLocal(Event As Object)
	Dim oFormulario As Object
	Dim oDocumento As Object
	Dim Form As Object
	Dim nFiltros As integer
	Dim filtro As String

	oDocumento = ThisComponent
	oFormulario = Event.Source.getModel.Parent()
	Form = oDocumento.DrawPage.Forms.GetByIndex(0)
	oFormulario = Event.Source.getModel.Parent()

	If Len(Event.Source.getText) = 0 Then
		oFormulario.ApplyFilter = False
		oFormulario.reload()
	Else
		filtro = Event.Source.getText("cb_colegios")
		oFormulario.Filter = "NLOCAL='" & filtro & "' AND ESTADO = 'NOTIFICADO'"
		oFormulario.ApplyFilter = True
		oFormulario.reload()	
	End If
End Sub

Sub AplicarFiltrosMesa (Event As Object)
	Dim oFormulario As Object
	Dim Form As Object
	Dim oDocumento As Object
	Dim CuadroCombinado As Object
	Dim colegio As String
	Dim filtro As String
	Dim mesa As String

	'SELECT DISTINCT "MESA" FROM "Mesas"


	oDocumento = ThisComponent
	oFormulario = Event.Source.getModel.Parent()
	Form = oDocumento.DrawPage.Forms.GetByIndex(0)
	CuadroCombinado = Form.GetByName("cb_mesa")
	colegio =  CuadroCombinado.Text
	filtro = oFormulario.Filter
	If Len(filtro) = 0 Then
		oFormulario.ApplyFilter = False
		oFormulario.reload()
	Else		
		oFormulario.Filter = "NLOCAL='" & colegio & "' AND ESTADO = 'NOTIFICADO'  AND MESA='" &  mesa & "'"
		oFormulario.ApplyFilter = True
		oFormulario.reload()
	End If
End Sub

Sub AplicarFiltrosSorteo(Event As Object)
	Dim oFormulario As Object
	Dim filtro As String
	oFormulario = Event.Source.getModel.Parent()
	If Len(Event.Source.getText) = 0 Then
		oFormulario.ApplyFilter = False
		oFormulario.reload()
	Else
		filtro = Event.Source.getText("Campo_combinado_filtro_sorteo")
		oFormulario.Filter = "NSORTEO={D '" & filtro & "'}"
		oFormulario.ApplyFilter = True
		oFormulario.reload()
	EndIf

End Sub

Sub AplicarFiltrosEstado(Event As Object)
	Dim oFormulario As Object
	Dim filtro As String
	oFormulario = Event.Source.getModel.Parent()
	If Len(Event.Source.getText) = 0 Then
	oFormulario.ApplyFilter = False
	oFormulario.reload()
	Else
		filtro = Event.Source.getText("campo_combinado_filtro_estado")
		oFormulario.Filter = "ESTADO={D '" & filtro & "'}"
		oFormulario.ApplyFilter = True
		oFormulario.reload()	
	End If
	
End Sub

Sub AplicarFiltrosCargo(Event As Object)
	Dim oFormulario As Object
	Dim filtro As String
	oFormulario = Event.Source.getModel.Parent()

	If Len(Event.Source.getText) = 0 Then
		oFormulario.ApplyFilter = False
		oFormulario.reload()
	Else
		filtro = Event.Source.getText("Campo_combinado_filtro_cargo")
		oFormulario.Filter =  "CARGO={D '" & filtro & "'}"
		oFormulario.ApplyFilter = True
		oFormulario.reload()	
	End If

End Sub

Sub MostrarFiltro
	Dim oFormulario As Object
	Dim filtro As String
	Dim Doc As Object
	Dim Form As Object
	
	Doc = ThisComponent
	Form = Doc.DrawPage.Forms.GetByIndex(0)
	filtro = Form.Filter
	MsgBox filtro
	Form.ApplyFilter = True
	Form.reload()
	
End Sub

Sub InsertarEnTablaTmp

	Dim doc As Object
	Dim Form As Object
	Dim rowset As Object
	Dim Grid As Object
	Dim aValue As Object
	
	Dim DatabaseContext As Object
	Dim DataSource As Object
	Dim Connection As Object
	Dim oCon As Object
	Dim InteractionHandler as Object
	Dim Statement1, Statement2, Statement3 As Object
	Dim ResultSet As Object
	Dim ResultSet2 As Object
	Dim XPropertySet As Object
	Dim sql, update As String
	Dim sRuta As String
	Dim mArg(0) As New "com.sun.star.beans.PropertyValue"
	Dim oDocumento As Object
	Dim NMUNI As String
	Dim DIST As String
	Dim SECC As String
	Dim MESA As String
	Dim NLOCAL As String
	Dim NLOCALB As String
	Dim INFADICIONAL As String
	Dim DIRMESA1 As String
	Dim DIRMESA2 As String
	Dim DIRMESA3 As String
	Dim DIRMESA4 As String
	Dim CARGO As String
	Dim NOLISTA As String
 	Dim GRES As String
 	Dim IDENT As String
 	Dim NOMBRE As String
 	Dim APELLIDO1 As String
 	Dim APELLIDO2 As String
 	Dim DOMI1 As String
	Dim DOMI2 As String
	Dim DOMI3 As String
	Dim DOMI4 As String
	Dim DOMI5 As String
	Dim CPOSTAL As String
	Dim NSORTEO As String
	Dim ESTADO As String
	rem Dim numero, puntero As Integer
  
 	Doc = ThisComponent
	Form = Doc.DrawPage.Forms.GetByIndex(0)
	Grid = Form.GetByName("MainForm_Grid")
	rem numero = Grid.RowSet.RowCount
	
	
	rowset = Grid.getByName("NMUNI")
	NMUNI = rowset.currentvalue	
 	rowset = Grid.getByName("DIST")
 	DIST = rowset.currentvalue
 	rowset = Grid.getByName("SECC")
 	SECC = rowset.currentvalue 	
 	rowset = Grid.getByName("MESA")
 	MESA = rowset.currentvalue 	
 	rowset = Grid.getByName("NLOCAL")
 	NLOCAL = rowset.currentvalue 	
 	rowset = Grid.getByName("NLOCALB")
 	NLOCALB = rowset.currentvalue 	
 	rowset = Grid.getByName("INFADICIONAL")
 	INFADICIONAL = rowset.currentvalue 	
 	rowset = Grid.getByName("DIRMESA1")
 	DIRMESA1 = rowset.currentvalue 	
 	rowset = Grid.getByName("DIRMESA2")
 	DIRMESA2 = rowset.currentvalue 	
 	rowset = Grid.getByName("DIRMESA3")
 	DIRMESA3 = rowset.currentvalue 	
 	rowset = Grid.getByName("DIRMESA4")
 	DIRMESA4 = rowset.currentvalue 	
 	rowset = Grid.getByName("CARGO")
 	CARGO = rowset.currentvalue 	
 	rowset = Grid.getByName("NOLISTA")
	NOLISTA = rowset.currentvalue 	
	rowset = Grid.getByName("GRES")
	GRES = rowset.currentvalue 	
	rowset = Grid.getByName("IDENT")
	IDENT = rowset.currentvalue
	rowset = Grid.getByName("NOMBRE")
	NOMBRE = rowset.currentvalue
	rowset = Grid.getByName("APELLIDO1")
	APELLIDO1 = rowset.currentvalue
	rowset = Grid.getByName("APELLIDO2")
	APELLIDO2 = rowset.currentvalue
	rowset = Grid.getByName("DOMI1")
	DOMI1 = rowset.currentvalue
	rowset = Grid.getByName("DOMI2")
	DOMI2 = rowset.currentvalue
	rowset = Grid.getByName("DOMI3")
	DOMI3 = rowset.currentvalue
	rowset = Grid.getByName("DOMI4")
	DOMI4 = rowset.currentvalue
	'rowset = Grid.getByName("DOMI5")
	'DOMI5 = rowset.currentvalue
	rowset = Grid.getByName("CPOSTAL")
 	CPOSTAL = rowset.currentvalue
 	rowset = Grid.getByName("NSORTEO")
 	NSORTEO = rowset.currentvalue
 	rowset = Grid.getByName("ESTADO")
 	ESTADO = rowset.currentvalue
 
	'DatabaseContext = createUnoService("com.sun.star.sdb.DatabaseContext")
	'DataSource = DatabaseContext.getByName("Elecciones_Andaluzas_2015")
 
	'If Not DataSource.IsPasswordRequired Then
	  'Connection = DataSource.GetConnection("","")
	'Else
	  'InteractionHandler = createUnoService("com.sun.star.sdb.InteractionHandler")
	  'Connection = DataSource.ConnectWithCompletion(InteractionHandler)
	'End If

	oCon = ThisDatabaseDocument.CurrentController.ActiveConnection
	Statement1 = oCon.CreateStatement
	'Statement1 = Connection.createStatement()
	Resultset = Statement1.executeQuery("SELECT * FROM ""Tabla_temporal""")
	grabar() 
	
	If Not IsNull(ResultSet) Then
		Statement2 = oCon.createStatement()
		Statement2.ResultSetConcurrency = 1008 'UPDATABLE
		Statement2.executeUpdate("DELETE FROM ""Tabla_temporal""")
		rem grabar()
	End If
	  
	sql = "insert into ""Tabla_temporal""(NMUNI, DIST, SECC, MESA, NLOCAL, NLOCALB, INFADICIONAL, DIRMESA1, DIRMESA2, "&_
	"DIRMESA3, DIRMESA4, CARGO, NOLISTA, GRES, IDENT, NOMBRE, APELLIDO1, APELLIDO2, DOMI1, DOMI2, DOMI3, DOMI4, CPOSTAL, NSORTEO, ESTADO) "&_
	"values (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"
	  
	Statement3 =oCon.PrepareStatement(sql)
	Statement3.SetString( 1, NMUNI)
	Statement3.SetString( 2, DIST)
	Statement3.SetString( 3, SECC)
	Statement3.SetString( 4, MESA)
	Statement3.SetString( 5, NLOCAL)
	Statement3.SetString( 6, NLOCALB)
	Statement3.SetString( 7, INFADICIONAL)
	Statement3.SetString( 8, DIRMESA1)
	Statement3.SetString( 9, DIRMESA2)
	Statement3.SetString( 10, DIRMESA3)
	Statement3.SetString( 11, DIRMESA4)
	Statement3.SetString( 12, CARGO)
	Statement3.SetString( 13, NOLISTA)
	Statement3.SetString( 14, GRES)
	Statement3.SetString( 15, IDENT)
	Statement3.SetString( 16, NOMBRE)
	Statement3.SetString( 17, APELLIDO1)
	Statement3.SetString( 18, APELLIDO2)
	Statement3.SetString( 19, DOMI1)
	Statement3.SetString( 20, DOMI2)
	Statement3.SetString( 21, DOMI3)
	Statement3.SetString( 22, DOMI4)
	Statement3.SetString( 23, CPOSTAL)
	Statement3.SetString( 24, NSORTEO)
	Statement3.SetString( 25, ESTADO)
	Statement3.executeUpdate(sql)
	rem grabar()
	
	
	mArg(0).Name = "Preview"
  mArg(0).Value = False
	
	rem sRuta = ConvertToUrl("//PHOENIX/Departamentos/Secretaria/Datos/Juan Rodriguez/Mis Documentos/Elecciones/Elecciones Municipales 2015/BD/modelo_comunicacion_miembros_temp.odt" )
    rem oDocumento = StarDesktop.loadComponentFromURL( sRuta, "_blank", 0, mArg() )
    
  Dim FileName as String
	Dim iFileLen as Integer
	Dim oRuta as String
	
	oRuta = ConvertFromUrl(ThisDatabaseDocument.url)
	rem oRuta = ThisDatabaseDocument.url
	FileName = FileNameOutOfPath(oRuta)
	iFileLen = Len(FileName)
	sRuta = Left(oRuta, Len(oRuta)- iFileLen) + "modelo_comunicacion_miembros_temp.odt"
	oDocumento = StarDesktop.loadComponentFromURL( ConvertToUrl(sRuta), "_blank", 0, mArg() )
	  
End Sub

Function FileNameoutofPath(ByVal Path as String, Optional Separator as String) as String
Dim i as Integer
Dim SepList() as String
	If IsMissing(Separator) Then
		Path = ConvertFromUrl(Path)
		Separator = GetPathSeparator()		
	End If
	SepList() = ArrayoutofString(Path, Separator,i)
	FileNameoutofPath = SepList(i)
End Function

Function RetrieveFileName(LocDoc as Object)
Dim LocURL as String
Dim LocURLArray() as String
Dim MaxArrIndex as integer

	LocURL = LocDoc.Url
	LocURLArray() = ArrayoutofString(LocURL,"/",MaxArrIndex)
	RetrieveFileName = LocURLArray(MaxArrIndex)
End Function

Function ArrayOutOfString(BigString, Separator as String, Optional MaxIndex as Integer)
Dim LocList() as String
	LocList=Split(BigString,Separator)
	If not isMissing(MaxIndex) then maxIndex=ubound(LocList())	
	ArrayOutOfString=LocList
End Function

Sub Sonido
	Dim sRuta As String
	Dim oManager As Object
	
	sRuta = ConvertToURL("C:\audio.mp3")
	oManager = CreateUnoService("com.sun.star.media.Manager_DirectX")
	oPlay = oManager.createPLayer(sRuta)
	oPlay.start()

End Sub


Sub SonidoBeep
	Dim TempDir
	TempDir=Environ ("WINDIR")
	rem Shell(ConvertToURL(Pathname), Windowstyle, Param, bSync)
	Shell("notepad.exe", 1, "nuevo.txt", false )
	MsgBox TempDir
	WaitUntil Now + TimeValue("00:00:02")
	Beep
End Sub

Sub CrearArchivoTemp()
	Dim FileNo As Integer
	Dim FileName as String
	Dim iFileLen as Integer
	Dim oRuta, sRuta as String
	
	FileNo = FreeFile 
	oRuta = ConvertFromUrl(ThisDatabaseDocument.url)
	FileName = FileNameOutOfPath(oRuta)
	iFileLen = Len(FileName)
	sRuta = Left(oRuta, Len(oRuta)- iFileLen) + "tmp.txt"
	Open sRuta For Output As #FileNo         ' Open file (writing mode)
	Print #FileNo, "This is a line of text"      ' Save line 
	Print #FileNo, "This is another line of text"   ' Save line 
	Close #FileNo                  ' Close file
	WaitUntil Now + TimeValue("00:00:15")
	Kill(sRuta)
	
End Sub

Sub ImprimirRegistroSeleccionado
	Dim Doc As Object
	Dim Form As Object
	Dim rowset As Object
	Dim Grid As Object
	Dim aValue As Object
	
	Dim DatabaseContext As Object
	Dim DataSource As Object
	Dim Connection As Object
	Dim oCon As Object
	Dim InteractionHandler as Object
	Dim Statement1, Statement2, Statement3 As Object
	Dim ResultSet As Object
	Dim ResultSet2 As Object
	Dim XPropertySet As Object
	Dim sql, update As String
	Dim mArg(1) As New "com.sun.star.beans.PropertyValue"
	Dim oDocumento As Object
	
	Dim NMUNI As String
	Dim DIST As String
	Dim SECC As String
	Dim MESA As String
	Dim NLOCAL As String
	Dim NLOCALB As String
	Dim INFADICIONAL As String
	Dim DIRMESA1 As String
	Dim DIRMESA2 As String
	Dim DIRMESA3 As String
	Dim DIRMESA4 As String
	Dim CARGO As String
	Dim NOLISTA As String
 	Dim GRES As String
 	Dim IDENT As String
 	Dim NOMBRE As String
 	Dim APELLIDO1 As String
 	Dim APELLIDO2 As String
 	Dim DOMI1 As String
	Dim DOMI2 As String
	Dim DOMI3 As String
	Dim DOMI4 As String
	Dim DOMI5 As String
	Dim CPOSTAL As String
	Dim NSORTEO As String
	Dim ESTADO As String
  
 	Dim FileNo As Integer
	Dim FileName as String
	Dim iFileLen as Integer
	Dim oRuta, sRuta as String
	Dim plantilla As String
	
	Doc = ThisComponent
	Form = Doc.DrawPage.Forms.GetByIndex(0)
	Grid = Form.GetByName("MainForm_Grid")
	
	FileNo = FreeFile 
	oRuta = ConvertFromUrl(ThisDatabaseDocument.url)
	FileName = FileNameOutOfPath(oRuta)
	iFileLen = Len(FileName)
	sRuta = Left(oRuta, Len(oRuta)- iFileLen) + "tmp.txt"
	Open sRuta For Output As #FileNo
	
	rowset = Grid.getByName("NMUNI")
	NMUNI = rowset.currentvalue	
 	rowset = Grid.getByName("DIST")
 	DIST = rowset.currentvalue
 	rowset = Grid.getByName("SECC")
 	SECC = rowset.currentvalue 	
 	rowset = Grid.getByName("MESA")
 	MESA = rowset.currentvalue 	
 	rowset = Grid.getByName("NLOCAL")
 	NLOCAL = rowset.currentvalue 	
 	rowset = Grid.getByName("NLOCALB")
 	NLOCALB = rowset.currentvalue 	
 	rowset = Grid.getByName("INFADICIONAL")
 	INFADICIONAL = rowset.currentvalue 	
 	rowset = Grid.getByName("DIRMESA1")
 	DIRMESA1 = rowset.currentvalue 	
 	rowset = Grid.getByName("DIRMESA2")
 	DIRMESA2 = rowset.currentvalue 	
 	rowset = Grid.getByName("DIRMESA3")
 	DIRMESA3 = rowset.currentvalue 	
 	rowset = Grid.getByName("DIRMESA4")
 	DIRMESA4 = rowset.currentvalue 	
 	rowset = Grid.getByName("CARGO")
 	CARGO = rowset.currentvalue 	
 	rowset = Grid.getByName("NOLISTA")
	NOLISTA = rowset.currentvalue 	
	rowset = Grid.getByName("GRES")
	GRES = rowset.currentvalue 	
	rowset = Grid.getByName("IDENT")
	IDENT = rowset.currentvalue
	rowset = Grid.getByName("NOMBRE")
	NOMBRE = rowset.currentvalue
	rowset = Grid.getByName("APELLIDO1")
	APELLIDO1 = rowset.currentvalue
	rowset = Grid.getByName("APELLIDO2")
	APELLIDO2 = rowset.currentvalue
	rowset = Grid.getByName("DOMI1")
	DOMI1 = rowset.currentvalue
	rowset = Grid.getByName("DOMI2")
	DOMI2 = rowset.currentvalue
	rowset = Grid.getByName("DOMI3")
	DOMI3 = rowset.currentvalue
	rowset = Grid.getByName("DOMI4")
	DOMI4 = rowset.currentvalue
	rowset = Grid.getByName("DOMI5")
	DOMI5 = rowset.currentvalue
	rowset = Grid.getByName("CPOSTAL")
 	CPOSTAL = rowset.currentvalue
 	rowset = Grid.getByName("NSORTEO")
 	NSORTEO = rowset.currentvalue
 	rowset = Grid.getByName("ESTADO")
 	ESTADO = rowset.currentvalue
 	
 	Print #FileNo, "NMUNI"+"	"+"DIST"+"	"+"SECC"+"	"+"MESA"+"	"+"NLOCAL"+"	"+"NLOCALB"+"	"+_
	"INFADICIONAL"+"	"+"DIRMESA1"+"	"+"DIRMESA2"+"	"+"DIRMESA3"+"	"+"DIRMESA4"+"	"+"CARGO"+"	"+_
	"NOLISTA"+"	"+"GRES"+"	"+"IDENT"+"	"+"NOMBRE"+"	"+"APELLIDO1"+"	"+"APELLIDO2"+"	"+"DOMI1"+"	"+_
	"DOMI2"+"	"+"DOMI3"+"	"+"DOMI4"+"	"+"DOMI5"+"	"+"CPOSTAL"+"	"+"NSORTEO"+"	"+"ESTADO"
	Print #FileNo, NMUNI+"	"+DIST+"	"+SECC+"	"+MESA+"	"+NLOCAL+"	"+NLOCALB+"	"+_
	INFADICIONAL+"	"+DIRMESA1+"	"+DIRMESA2+"	"+DIRMESA3+"	"+DIRMESA4+"	"+CARGO+"	"+_
	NOLISTA+"	"+GRES+"	"+IDENT+"	"+NOMBRE+"	"+APELLIDO1+"	"+APELLIDO2+"	"+DOMI1+"	"+_
	DOMI2+"	"+DOMI3+"	"+DOMI4+"	"+DOMI5+"	"+CPOSTAL+"	"+NSORTEO+"	"+ESTADO
	
	Close #FileNo
	
	mArg(0).Name = "Preview"
    mArg(0).Value = False
    mArg(1).Name = "ZoomSlider.CurrentZoom"
    mArg(1).Value = 100
	
	plantilla = "modelo_comunicacion_miembros_single.odt"
	
	sRuta = Left(oRuta, Len(oRuta)- iFileLen) + plantilla
	oDocumento = StarDesktop.loadComponentFromURL( ConvertToUrl(sRuta), "_blank", 0, mArg() )

End Sub

Sub ImprimirContenidoTabla
	Dim Doc As Object
	Dim Form As Object
	Dim rowset As Object
	Dim Grid As Object
	Dim aValue As Object
	
	Dim DatabaseContext As Object
	Dim DataSource As Object
	Dim Connection As Object
	Dim oCon As Object
	Dim InteractionHandler as Object
	Dim Statement1, Statement2, Statement3 As Object
	Dim ResultSet As Object
	Dim ResultSet2 As Object
	Dim XPropertySet As Object
	Dim sql, update As String
	Dim mArg(1) As New "com.sun.star.beans.PropertyValue"
	Dim oDocumento As Object
	Dim dispatcher As Object
	Dim document As Object
	Dim formulario As Object

	Dim NMUNI As String
	Dim DIST As String
	Dim SECC As String
	Dim MESA As String
	Dim NLOCAL As String
	Dim NLOCALB As String
	Dim INFADICIONAL As String
	Dim DIRMESA1 As String
	Dim DIRMESA2 As String
	Dim DIRMESA3 As String
	Dim DIRMESA4 As String
	Dim CARGO As String
	Dim NOLISTA As String
 	Dim GRES As String
 	Dim IDENT As String
 	Dim NOMBRE As String
 	Dim APELLIDO1 As String
 	Dim APELLIDO2 As String
 	Dim DOMI1 As String
	Dim DOMI2 As String
	Dim DOMI3 As String
	Dim DOMI4 As String
	Dim DOMI5 As String
	Dim CPOSTAL As String
	Dim NSORTEO As String
	Dim ESTADO As String
	Dim numero, puntero As Integer
  
 	Dim FileNo As Integer
	Dim FileName as String
	Dim iFileLen as Integer
	Dim oRuta, sRuta as String
	Dim plantilla As String
	

	
	dispatcher = createUnoService("com.sun.star.frame.DispatchHelper")
	formulario   = ThisComponent.CurrentController.Frame
	dispatcher.executeDispatch(formulario, ".uno:FirstRecord", "", 0, Array())	
	Doc = ThisComponent
	Form = Doc.DrawPage.Forms.GetByIndex(0)
	Grid = Form.GetByName("MainForm_Grid")
	numero = Grid.Rowset.RowCount

	FileNo = FreeFile 
	oRuta = ConvertFromUrl(ThisDatabaseDocument.url)
	FileName = FileNameOutOfPath(oRuta)
	iFileLen = Len(FileName)
	sRuta = Left(oRuta, Len(oRuta)- iFileLen) + "tmp.txt"
	Open sRuta For Output As #FileNo

	Print #FileNo, "NMUNI"+"	"+"DIST"+"	"+"SECC"+"	"+"MESA"+"	"+"NLOCAL"+"	"+"NLOCALB"+"	"+_
	"INFADICIONAL"+"	"+"DIRMESA1"+"	"+"DIRMESA2"+"	"+"DIRMESA3"+"	"+"DIRMESA4"+"	"+"CARGO"+"	"+_
	"NOLISTA"+"	"+"GRES"+"	"+"IDENT"+"	"+"NOMBRE"+"	"+"APELLIDO1"+"	"+"APELLIDO2"+"	"+"DOMI1"+"	"+_
	"DOMI2"+"	"+"DOMI3"+"	"+"DOMI4"+"	"+"DOMI5"+"	"+"CPOSTAL"+"	"+"NSORTEO"+"	"+"ESTADO"
	
	for puntero = 0 to numero -1
		
		rowset = Grid.getByName("NMUNI")
		NMUNI = rowset.currentvalue	
 		rowset = Grid.getByName("DIST")
	 	DIST = rowset.currentvalue
	 	rowset = Grid.getByName("SECC")
	 	SECC = rowset.currentvalue 	
	 	rowset = Grid.getByName("MESA")
	 	MESA = rowset.currentvalue 	
	 	rowset = Grid.getByName("NLOCAL")
	 	NLOCAL = rowset.currentvalue 	
	 	rowset = Grid.getByName("NLOCALB")
	 	NLOCALB = rowset.currentvalue 	
	 	rowset = Grid.getByName("INFADICIONAL")
	 	INFADICIONAL = rowset.currentvalue 	
	 	rowset = Grid.getByName("DIRMESA1")
	 	DIRMESA1 = rowset.currentvalue 	
	 	rowset = Grid.getByName("DIRMESA2")
	 	DIRMESA2 = rowset.currentvalue 	
 		rowset = Grid.getByName("DIRMESA3")
 		DIRMESA3 = rowset.currentvalue 	
	 	rowset = Grid.getByName("DIRMESA4")
	 	DIRMESA4 = rowset.currentvalue 	
	 	rowset = Grid.getByName("CARGO")
	 	CARGO = rowset.currentvalue 	
	 	rowset = Grid.getByName("NOLISTA")
		NOLISTA = rowset.currentvalue 	
		rowset = Grid.getByName("GRES")
		GRES = rowset.currentvalue 	
		rowset = Grid.getByName("IDENT")
		IDENT = rowset.currentvalue
		rowset = Grid.getByName("NOMBRE")
		NOMBRE = rowset.currentvalue
		rowset = Grid.getByName("APELLIDO1")
		APELLIDO1 = rowset.currentvalue
		rowset = Grid.getByName("APELLIDO2")
		APELLIDO2 = rowset.currentvalue
		rowset = Grid.getByName("DOMI1")
		DOMI1 = rowset.currentvalue
		rowset = Grid.getByName("DOMI2")
		DOMI2 = rowset.currentvalue
		rowset = Grid.getByName("DOMI3")
		DOMI3 = rowset.currentvalue
		rowset = Grid.getByName("DOMI4")
		DOMI4 = rowset.currentvalue
		rowset = Grid.getByName("DOMI5")
		DOMI5 = rowset.currentvalue
		rowset = Grid.getByName("CPOSTAL")
	 	CPOSTAL = rowset.currentvalue
	 	rowset = Grid.getByName("NSORTEO")
	 	NSORTEO = rowset.currentvalue
	 	rowset = Grid.getByName("ESTADO")
	 	ESTADO = rowset.currentvalue
 	
		Print #FileNo, NMUNI+"	"+DIST+"	"+SECC+"	"+MESA+"	"+NLOCAL+"	"+NLOCALB+"	"+_
		INFADICIONAL+"	"+DIRMESA1+"	"+DIRMESA2+"	"+DIRMESA3+"	"+DIRMESA4+"	"+CARGO+"	"+_
		NOLISTA+"	"+GRES+"	"+IDENT+"	"+NOMBRE+"	"+APELLIDO1+"	"+APELLIDO2+"	"+DOMI1+"	"+_
		DOMI2+"	"+DOMI3+"	"+DOMI4+"	"+DOMI5+"	"+CPOSTAL+"	"+NSORTEO+"	"+ESTADO
		
		dispatcher.executeDispatch(formulario, ".uno:NextRecord", "", 0, Array())
	
	next puntero
	
	
	Close #FileNo
	
	mArg(0).Name = "Preview"
    mArg(0).Value = False
    mArg(1).Name = "ZoomSlider.CurrentZoom"
    mArg(1).Value = 100
	
	plantilla = "Mesas.odt"
	
	sRuta = Left(oRuta, Len(oRuta)- iFileLen) + plantilla
	oDocumento = StarDesktop.loadComponentFromURL( ConvertToUrl(sRuta), "_blank", 0, mArg() )

End Sub

Sub VerPdf()

	Dim doc As Object
	Dim Form As Object
	Dim rowset As Object
	Dim Grid As Object
	Dim aValue As Object
	Dim mArg(0) As New "com.sun.star.beans.PropertyValue"
	Dim oDocumento As Object
	Dim FileName as String
	
	Dim INFADICIONAL As String
	Dim iFileLen as Integer
	Dim oRuta, sRuta as String
  
 	Doc = ThisComponent
	Form = Doc.DrawPage.Forms.GetByIndex(0)
	Grid = Form.GetByName("MainForm_Grid")

 	rowset = Grid.getByName("INFADICIONAL")
 	INFADICIONAL = rowset.currentvalue 	
 	
 	oRuta = ConvertFromUrl(ThisDatabaseDocument.url)
 	FileName = FileNameOutOfPath(oRuta)
	iFileLen = Len(FileName)
 	sRuta = Left(oRuta, Len(oRuta)- iFileLen) + "oficios\" + INFADICIONAL
 	'oDocumento = StarDesktop.loadComponentFromURL( ConvertToUrl(sRuta), "_blank", 0, mArg() )
 	'C:\program files (x86)\adobe\reader 11.0\reader>
 	MsgBox "C:\program files (x86)\adobe\reader 11.0\reader\acrord32.exe " + sRuta
 	Shell ("C:\program files (x86)\adobe\reader 11.0\reader\acrord32.exe ", 1, sRuta)
 
End Sub


sub VistaImpresion
rem ----------------------------------------------------------------------
rem define variables
	dim document   as object
	dim dispatcher as object
rem ----------------------------------------------------------------------
rem get access to the document
	document   = ThisComponent.CurrentController.Frame
	dispatcher = createUnoService("com.sun.star.frame.DispatchHelper")

rem ----------------------------------------------------------------------
rem dispatcher.executeDispatch(document, ".uno:PrintPreview", "", 0, Array())

rem ----------------------------------------------------------------------
	dispatcher.executeDispatch(document, ".uno:Print", "", 0, Array())
End Sub


sub BuscarRegistro
rem ----------------------------------------------------------------------
rem define variables
dim document   as object
dim dispatcher as object
rem ----------------------------------------------------------------------
rem get access to the document
document   = ThisComponent.CurrentController.Frame
dispatcher = createUnoService("com.sun.star.frame.DispatchHelper")

rem ----------------------------------------------------------------------
dispatcher.executeDispatch(document, ".uno:RecSearch", "", 0, Array())


end sub


sub MoverPorRegistros
rem ----------------------------------------------------------------------
rem define variables
dim document   as object
dim dispatcher as object
rem ----------------------------------------------------------------------
rem get access to the document
document   = ThisComponent.CurrentController.Frame
dispatcher = createUnoService("com.sun.star.frame.DispatchHelper")

rem ----------------------------------------------------------------------
dispatcher.executeDispatch(document, ".uno:NextRecord", "", 0, Array())

rem ----------------------------------------------------------------------
dispatcher.executeDispatch(document, ".uno:NextRecord", "", 0, Array())

rem ----------------------------------------------------------------------
dispatcher.executeDispatch(document, ".uno:NextRecord", "", 0, Array())

rem ----------------------------------------------------------------------
dispatcher.executeDispatch(document, ".uno:NextRecord", "", 0, Array())

rem ----------------------------------------------------------------------
dispatcher.executeDispatch(document, ".uno:NextRecord", "", 0, Array())

rem ----------------------------------------------------------------------
dispatcher.executeDispatch(document, ".uno:NextRecord", "", 0, Array())

rem ----------------------------------------------------------------------
dispatcher.executeDispatch(document, ".uno:NextRecord", "", 0, Array())

rem ----------------------------------------------------------------------
dispatcher.executeDispatch(document, ".uno:PrevRecord", "", 0, Array())

rem ----------------------------------------------------------------------
dispatcher.executeDispatch(document, ".uno:PrevRecord", "", 0, Array())

rem ----------------------------------------------------------------------
dispatcher.executeDispatch(document, ".uno:PrevRecord", "", 0, Array())

rem ----------------------------------------------------------------------
dispatcher.executeDispatch(document, ".uno:PrevRecord", "", 0, Array())

rem ----------------------------------------------------------------------
dispatcher.executeDispatch(document, ".uno:PrevRecord", "", 0, Array())

rem ----------------------------------------------------------------------
dispatcher.executeDispatch(document, ".uno:PrevRecord", "", 0, Array())

rem ----------------------------------------------------------------------
dispatcher.executeDispatch(document, ".uno:PrevRecord", "", 0, Array())

rem ----------------------------------------------------------------------
dispatcher.executeDispatch(document, ".uno:NewRecord", "", 0, Array())


end sub


sub ActualizarRegistros
rem ----------------------------------------------------------------------
rem define variables
dim document   as object
dim dispatcher as object
rem ----------------------------------------------------------------------
rem get access to the document
document   = ThisComponent.CurrentController.Frame
dispatcher = createUnoService("com.sun.star.frame.DispatchHelper")

rem ----------------------------------------------------------------------
dispatcher.executeDispatch(document, ".uno:Refresh", "", 0, Array())
dispatcher.executeDispatch(document, ".uno:LastRecord", "", 0, Array())
dispatcher.executeDispatch(document, ".uno:FirstRecord", "", 0, Array())


end sub


rem CREATE TABLE Procesos (Proceso varchar(255), Fecha varchar (10), Observaciones varchar(255), Mesas varchar(255))
rem ALTER TABLE EleccionesAndaluzas2018 ADD PRIMARY KEY (IDENT);
