Module CODIGO
    Public Sub inicializa_conexion(ByVal versionDeAutoCAD As String)
        Dim R As String

        If versionDeAutoCAD = "2000" Then
            R = "AUTOCAD.Application.15" 'R2000-2002
        ElseIf versionDeAutoCAD = "2004" Then
            R = "AUTOCAD.Application.16" 'R2004-R2006
        ElseIf versionDeAutoCAD = "2007" Or versionDeAutoCAD = "2009" Then
            R = "AUTOCAD.Application.17" 'R2007-R2008-R2009"
        ElseIf versionDeAutoCAD = "2010" Then
            R = "AUTOCAD.Application.18" 'R2010-R2011-R2012
        ElseIf versionDeAutoCAD = "2013" Then
            R = "AUTOCAD.Application.19" 'R2013-R2014
        ElseIf versionDeAutoCAD = "2015" Then
            R = "AUTOCAD.Application.20" 'R2015-R16
        ElseIf versionDeAutoCAD = "2017" Then
            R = "AUTOCAD.Application.21" 'R2017
        ElseIf versionDeAutoCAD = "2018" Then
            R = "AUTOCAD.Application.22" 'R2018
        ElseIf versionDeAutoCAD = "2021" Or versionDeAutoCAD = "2022" Then        'R2021 R2022
            R = "AUTOCAD.Application.24"
        Else
            R = ""
        End If

        Try
            DOCUMENTO = Nothing
            AUTOCADAPP = GetObject(, R)
            DOCUMENTO = AUTOCADAPP.ActiveDocument
            UTILITY = DOCUMENTO.Utility
            AUTOCADAPP.Visible = True
        Catch er As Exception
            MsgBox(er.Message, MsgBoxStyle.Information, "CAD")
        End Try
    End Sub

    Public Function solicitarCoordenada(ByVal mensaje As String, Optional ByVal pb() As Double = Nothing) As Double()
        Dim p(0 To 2) As Double

        Try
            If IsNothing(pb) Then
                p = DOCUMENTO.Utility.GetPoint(, mensaje)
            Else
                p = DOCUMENTO.Utility.GetPoint(pb, mensaje)
            End If
            Return p
        Catch e As Exception
            Return Nothing
        End Try
    End Function

    Public Sub seleccionObjetos(metodo As String)

        Dim conjunto As AcadSelectionSet
        Dim dT As Double = 0
        Dim entidad As AcadEntity = Nothing
        Dim Objeto As AcadObject = Nothing
        Dim objetoAsociado As AcadObject = Nothing
        Dim atrObj As AcadAttribute
        Dim PickedPoint(0 To 2) As Double, TransMatrix(0 To 3, 0 To 3) As Double
        Dim ContextData As Object = Nothing
        Dim HasContextData As String
        Dim esquinas(11) As Double
        Dim coordCirculo() As Double
        Dim p(0 To 2) As Double
        Dim p1(0 To 2) As Double
        Dim radio As Double
        Dim np As Integer

        appactivateAutoCAD()

        Select Case metodo
            Case "A"    'seleccion selectiva del plano
                conjunto = conjunto_vacio(DOCUMENTO, "IDLE")
                If Not IsNothing(conjunto) Then
                    conjunto.SelectOnScreen()
                    If tieneElementos(conjunto) Then
                        MsgBox(conjunto.Count)
                    Else
                        MsgBox("No hay elementos en el conjunto")
                    End If
                End If
            Case "B"
                p = solicitarCoordenada("Esquina 1")
                If Not IsNothing(p) Then
                    p1 = solicitarCoordenada("Esquina opuesta", p)
                    If Not IsNothing(p1) Then
                        'cada 3 indices representan una coordenada XYZ
                        esquinas(0) = p(0) : esquinas(1) = p(1) : esquinas(2) = 0 'coord1
                        esquinas(3) = p1(0) : esquinas(4) = p(1) : esquinas(5) = 0 'coord2
                        esquinas(6) = p1(0) : esquinas(7) = p1(1) : esquinas(8) = 0 'coord3
                        esquinas(9) = p(0) : esquinas(10) = p1(1) : esquinas(11) = 0 'coord4
                        conjunto = conjunto_vacio(DOCUMENTO, "IDLE")
                        If Not IsNothing(conjunto) Then
                            conjunto.SelectByPolygon(AcSelect.acSelectionSetCrossingPolygon, esquinas)
                            MsgBox(conjunto.Count)
                        End If
                    End If
                End If
            Case "C"
                'todos los elementos del plano
                conjunto = conjunto_vacio(DOCUMENTO, "IDLE")
                If Not IsNothing(conjunto) Then
                    conjunto.Select(AcSelect.acSelectionSetAll)
                    MsgBox(conjunto.Count)
                End If
            Case "D"
                Try
                    DOCUMENTO.Utility.GetEntity(entidad, p, "Selecciona una entidad ")
                Catch
                    'observe que estamos monitoriando todos los errores incluidos los COM por eso es catch sin parametros
                    'Esta forma de cachar error funciona para este caso de error
                    entidad = Nothing
                End Try
                If Not IsNothing(entidad) Then
                    MsgBox(entidad.ObjectName)
                End If
            Case "E"
                p = solicitarCoordenada("Centro")
                If Not IsNothing(p) Then
                    p1 = solicitarCoordenada("Indica el radio", p)
                    If Not IsNothing(p1) Then
                        'radio = getDistancia(p, p1)
                        'coordCirculo = arrDinamicoCirculo(10, p, radio)
                        conjunto = conjunto_vacio(DOCUMENTO, "IDLE")
                        If Not IsNothing(conjunto) Then
                            conjunto.SelectByPolygon(AcSelect.acSelectionSetCrossingPolygon, coordCirculo)
                            MsgBox(conjunto.Count)
                        End If
                        'graficaPolygono(coordCirculo, True)
                    End If
                End If
            Case "F"
                'seleccion de un subElemento
                ' Get information about selected object
                Try
                    DOCUMENTO.Utility.GetSubEntity(Objeto, PickedPoint, TransMatrix, ContextData)
                Catch
                    'no se selecciono un objeto 
                End Try
                If Not IsNothing(Objeto) Then
                    ' Process and display selected object properties
                    HasContextData = IIf(VarType(ContextData) = vbEmpty, " does not ", " does ")
                    MsgBox("The object you chose was an: " & Objeto.ObjectName & vbCrLf &
                    "Your point of selection was: " & PickedPoint(0) & ", " &
                                                      PickedPoint(1) & ", " &
                                                      PickedPoint(2) & vbCrLf &
                   "This object" & HasContextData & "have nested objects.")

                    If Not IsNothing(ContextData) Then
                        objetoAsociado = DOCUMENTO.ObjectIdToObject(ContextData(0))
                        MsgBox("Objeto Asociado es " & objetoAsociado.ObjectName)
                    End If
                End If
                'si tengo acceso a la subentidad entonces tendre acceso a sus propiedades?
                If Not IsNothing(Objeto) AndAlso Objeto.ObjectName = "AcDbAttribute" Then
                    MsgBox(Objeto.Handle & "Tipo=" & Objeto.tagstring & "  " & Objeto.textstring)
                    atrObj = Objeto

                End If
            Case Else
                'sin seleccion de metodo
        End Select
    End Sub

    Public Function tieneElementos(ByRef conjunto As AcadSelectionSet) As Boolean
        'Nos indica si un conjunto existente tiene elementos
        tieneElementos = False
        Try
            If conjunto.Count > 0 Then
                tieneElementos = True
            End If
        Catch e As ApplicationException
            MsgBox(e.Message, MsgBoxStyle.Information, "CAD")
        End Try
        Return tieneElementos
    End Function
    Public Sub appactivateAutoCAD()
        'activando AutoCAD para los select o  gets
        Dim AUTOCADWINDNAME As String
        Dim acadProcess() As Process = Process.GetProcessesByName("ACAD")
        Try
            'guardando variables para activar autocad cuando sea necesario en los select o gets
            AUTOCADWINDNAME = acadProcess(0).MainWindowTitle
            AppActivate(AUTOCADWINDNAME)
            'tambien puede emplearse el caption del objeto de conexion a AutoCAD
            'AppActivate(AUTOCADAPP.Caption)
        Catch er As Exception
            MsgBox(er.Message)
        End Try
    End Sub

    Public Function conjunto_vacio(ByRef DOCUMENTO As AcadDocument, ByRef nombre As String) As AcadSelectionSet
        Dim indice As Integer
        nombre = nombre.Trim.ToUpper 'los conjuntos deben ser con mayusculas
        conjunto_vacio = Nothing

        Try
            'revisando la existencia del conjunto y en su caso eliminandolo
            For indice = 0 To DOCUMENTO.SelectionSets.Count - 1
                If DOCUMENTO.SelectionSets.Item(indice).Name = nombre Then
                    DOCUMENTO.SelectionSets.Item(indice).Delete()
                    Exit For
                End If
            Next
            conjunto_vacio = DOCUMENTO.SelectionSets.Add(nombre)
        Catch e As ApplicationException
            MsgBox(e.Message, MsgBoxStyle.Information, "CAD")
        End Try
        Return conjunto_vacio
    End Function

    Public Sub analizaSeleccion(tipo As String)
        Dim conjunto As AcadSelectionSet
        Dim elemento As AcadEntity
        Dim numCircles As Integer = 0
        Dim numLineas As Integer = 0
        Dim numOtros As Integer = 0
        Dim tipoEntidad As String

        Select Case tipo
            Case "Clasifica por tipo"
                conjunto = conjunto_vacio(DOCUMENTO, "IDLE")
                If Not IsNothing(conjunto) Then
                    conjunto.Select(AcSelect.acSelectionSetAll)
                    For Each elemento In conjunto
                        tipoEntidad = elemento.ObjectName
                        Select Case tipoEntidad
                            Case "AcDbCircle"
                                numCircles = numCircles + 1
                            Case "AcDbLine"
                                numLineas = numLineas + 1
                            Case Else
                                numOtros = numOtros + 1
                        End Select
                    Next
                    MsgBox("Lineas =" & numLineas & " Circulos= " & numCircles & " Otros =" & numOtros)
                End If
        End Select
    End Sub

    Public Sub trasladaCirculos()
        Dim conjunto As AcadSelectionSet
        Dim elemento As AcadEntity
        Dim lineaVertical As AcadLine = Nothing
        Dim tipoEntidad As String
        Dim pL(0 To 2) As Double
        Dim pC(0 To 2) As Double
        Dim pM(0 To 2) As Double
        Dim radio As Integer = 0
        Dim endpoint(0 To 2) As Double

        appactivateAutoCAD()

        Try
            DOCUMENTO.Utility.GetEntity(lineaVertical, pL, "Selecciona una linea vertical")
        Catch
            'observe que estamos monitoriando todos los errores incluidos los COM por eso es catch sin parametros
            'Esta forma de cachar error funciona para este caso de error
            lineaVertical = Nothing
        End Try
        If Not IsNothing(lineaVertical) Then
            pL = lineaVertical.StartPoint
        End If

        pM = calculaPuntoMedioLinea(lineaVertical)


        conjunto = conjunto_vacio(DOCUMENTO, "IDLE")
        If Not IsNothing(conjunto) Then
            conjunto.Select(AcSelect.acSelectionSetAll)
            For Each elemento In conjunto
                tipoEntidad = elemento.ObjectName
                If tipoEntidad = "AcDbCircle" Then
                    radio = elemento.Radius
                    pC = elemento.Center
                    If pC(0) > pL(0) Then
                        pC(0) = pL(0) + radio
                        pC(1) = pC(1)
                        pC(2) = pC(2)

                        elemento.Center = pC
                        elemento.Update()
                    Else
                        pC(0) = pL(0) + radio
                        pC(1) = pC(1)
                        pC(2) = pC(2)

                        elemento.Center = pC
                        elemento.Update()
                    End If
                ElseIf tipoEntidad = "AcDbLine" AndAlso elemento IsNot lineaVertical Then
                    endpoint = obtenerEndpointLine(elemento)
                    elemento.Move(endpoint, pM)
                    elemento.Update()
                End If
            Next
            MsgBox("Elementos trasladados!")
        End If
        conjunto.Delete()
    End Sub

    Public Function calculaPuntoMedioLinea(ByRef linea As AcadLine) As Double()
        Dim p1(0 To 2) As Double
        Dim p2(0 To 2) As Double
        Dim result(0 To 2) As Double

        p1 = linea.StartPoint
        p2 = linea.EndPoint
        result(0) = (p1(0) + p2(0)) / 2
        result(1) = (p1(1) + p2(1)) / 2
        result(2) = (p1(2) + p2(2)) / 2

        Return result
    End Function

    Public Function obtenerEndpointLine(ByVal linea As AcadLine) As Double()
        Dim p1() As Double
        Dim p2() As Double

        p1 = linea.StartPoint
        p2 = linea.EndPoint
        If p1(0) > p2(0) Then
            Return p1
        Else
            Return p2
        End If
    End Function
End Module
