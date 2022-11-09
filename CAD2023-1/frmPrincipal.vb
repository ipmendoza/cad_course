Public Class frmPrincipal
    Private Sub ConectarConAutoCADToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConectarConAutoCADToolStripMenuItem.Click
        inicializa_conexion("2022")

        If IsNothing(DOCUMENTO) Then
            dwgActual.Text = ""
        Else
            dwgActual.Text = DOCUMENTO.Name
        End If
    End Sub

    Private Sub LeyendoUnaCoordenadaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LeyendoUnaCoordenadaToolStripMenuItem.Click
        Dim p(0 To 2) As Double
        Dim p1(0 To 2) As Double
        Dim linea As AcadLine

        Me.Visible = False

        appactivateAutoCAD()

        p = solicitarCoordenada("Indica una coordenada")
        p1 = solicitarCoordenada("Indica siguiente coordenada", p)
        linea = DOCUMENTO.ModelSpace.AddLine(p, p1)

        Me.Visible = True
    End Sub

    Private Sub LeesSecuenciaDeCoordinadasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LeesSecuenciaDeCoordinadasToolStripMenuItem.Click
        Dim p(0 To 2) As Double
        Dim p1(0 To 2) As Double
        Dim linea As AcadLine

        appactivateAutoCAD()

        p = solicitarCoordenada("Indica una coordenada")
        While Not IsNothing(p)
            p1 = solicitarCoordenada("Indica siguiente coordenada", p)
            If IsNothing(p1) Then
            Else
                linea = DOCUMENTO.ModelSpace.AddLine(p, p1)
            End If
            p = p1
        End While
    End Sub

    Private Sub InputDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InputDataToolStripMenuItem.Click
        Dim answer As String
        Dim answer2 As String
        Dim answer3 As Double

        answer = InputBox("Dato inicial", "SISTEMA CAD", "A")
        answer2 = DOCUMENTO.Utility.GetString(1, "Dato inicial ")
        answer3 = DOCUMENTO.Utility.GetReal("Dame la distancia ")

    End Sub

    Private Sub UnObjetoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnObjetoToolStripMenuItem.Click
        seleccionObjetos("D")
    End Sub

    Private Sub SelectivaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectivaToolStripMenuItem.Click
        seleccionObjetos("A")
    End Sub

    Private Sub ElementsoDentroDeUnRectanguloToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ElementsoDentroDeUnRectanguloToolStripMenuItem.Click
        seleccionObjetos("B")
    End Sub

    Private Sub ClasificandoLineasYCirculosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClasificandoLineasYCirculosToolStripMenuItem.Click
        analizaSeleccion("Clasifica por tipo")
    End Sub

    Private Sub ClasificandoConRespectoAUnaLineaVerticalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClasificandoConRespectoAUnaLineaVerticalToolStripMenuItem.Click
        trasladaCirculos()
    End Sub
End Class
