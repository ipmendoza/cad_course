<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrincipal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.AdmonToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConectarConAutoCADToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EjemplosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LeyendoUnaCoordenadaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LeesSecuenciaDeCoordinadasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InputDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SeleccionDeObjetosEnElPlanoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UnObjetoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectivaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ElementsoDentroDeUnRectanguloToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.dwgActual = New System.Windows.Forms.TextBox()
        Me.ClasificandoLineasYCirculosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClasificandoConRespectoAUnaLineaVerticalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AdmonToolStripMenuItem, Me.EjemplosToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(4, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(600, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'AdmonToolStripMenuItem
        '
        Me.AdmonToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConectarConAutoCADToolStripMenuItem})
        Me.AdmonToolStripMenuItem.Name = "AdmonToolStripMenuItem"
        Me.AdmonToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.AdmonToolStripMenuItem.Text = "Admon"
        '
        'ConectarConAutoCADToolStripMenuItem
        '
        Me.ConectarConAutoCADToolStripMenuItem.Name = "ConectarConAutoCADToolStripMenuItem"
        Me.ConectarConAutoCADToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.ConectarConAutoCADToolStripMenuItem.Text = "Conectar con AutoCAD"
        '
        'EjemplosToolStripMenuItem
        '
        Me.EjemplosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LeyendoUnaCoordenadaToolStripMenuItem, Me.LeesSecuenciaDeCoordinadasToolStripMenuItem, Me.InputDataToolStripMenuItem, Me.SeleccionDeObjetosEnElPlanoToolStripMenuItem, Me.ClasificandoConRespectoAUnaLineaVerticalToolStripMenuItem})
        Me.EjemplosToolStripMenuItem.Name = "EjemplosToolStripMenuItem"
        Me.EjemplosToolStripMenuItem.Size = New System.Drawing.Size(67, 20)
        Me.EjemplosToolStripMenuItem.Text = "Ejemplos"
        '
        'LeyendoUnaCoordenadaToolStripMenuItem
        '
        Me.LeyendoUnaCoordenadaToolStripMenuItem.Name = "LeyendoUnaCoordenadaToolStripMenuItem"
        Me.LeyendoUnaCoordenadaToolStripMenuItem.Size = New System.Drawing.Size(243, 22)
        Me.LeyendoUnaCoordenadaToolStripMenuItem.Text = "Leyendo una coordenada"
        '
        'LeesSecuenciaDeCoordinadasToolStripMenuItem
        '
        Me.LeesSecuenciaDeCoordinadasToolStripMenuItem.Name = "LeesSecuenciaDeCoordinadasToolStripMenuItem"
        Me.LeesSecuenciaDeCoordinadasToolStripMenuItem.Size = New System.Drawing.Size(243, 22)
        Me.LeesSecuenciaDeCoordinadasToolStripMenuItem.Text = "Lees secuencia de coordinadas"
        '
        'InputDataToolStripMenuItem
        '
        Me.InputDataToolStripMenuItem.Name = "InputDataToolStripMenuItem"
        Me.InputDataToolStripMenuItem.Size = New System.Drawing.Size(243, 22)
        Me.InputDataToolStripMenuItem.Text = "Input Data"
        '
        'SeleccionDeObjetosEnElPlanoToolStripMenuItem
        '
        Me.SeleccionDeObjetosEnElPlanoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UnObjetoToolStripMenuItem, Me.SelectivaToolStripMenuItem, Me.ElementsoDentroDeUnRectanguloToolStripMenuItem, Me.ClasificandoLineasYCirculosToolStripMenuItem})
        Me.SeleccionDeObjetosEnElPlanoToolStripMenuItem.Name = "SeleccionDeObjetosEnElPlanoToolStripMenuItem"
        Me.SeleccionDeObjetosEnElPlanoToolStripMenuItem.Size = New System.Drawing.Size(243, 22)
        Me.SeleccionDeObjetosEnElPlanoToolStripMenuItem.Text = "Seleccion de objetos en el plano"
        '
        'UnObjetoToolStripMenuItem
        '
        Me.UnObjetoToolStripMenuItem.Name = "UnObjetoToolStripMenuItem"
        Me.UnObjetoToolStripMenuItem.Size = New System.Drawing.Size(260, 22)
        Me.UnObjetoToolStripMenuItem.Text = "Un objeto"
        '
        'SelectivaToolStripMenuItem
        '
        Me.SelectivaToolStripMenuItem.Name = "SelectivaToolStripMenuItem"
        Me.SelectivaToolStripMenuItem.Size = New System.Drawing.Size(260, 22)
        Me.SelectivaToolStripMenuItem.Text = "Selectiva"
        '
        'ElementsoDentroDeUnRectanguloToolStripMenuItem
        '
        Me.ElementsoDentroDeUnRectanguloToolStripMenuItem.Name = "ElementsoDentroDeUnRectanguloToolStripMenuItem"
        Me.ElementsoDentroDeUnRectanguloToolStripMenuItem.Size = New System.Drawing.Size(260, 22)
        Me.ElementsoDentroDeUnRectanguloToolStripMenuItem.Text = "Elementso dentro de un rectangulo"
        '
        'dwgActual
        '
        Me.dwgActual.Location = New System.Drawing.Point(9, 36)
        Me.dwgActual.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.dwgActual.Name = "dwgActual"
        Me.dwgActual.Size = New System.Drawing.Size(487, 20)
        Me.dwgActual.TabIndex = 1
        '
        'ClasificandoLineasYCirculosToolStripMenuItem
        '
        Me.ClasificandoLineasYCirculosToolStripMenuItem.Name = "ClasificandoLineasYCirculosToolStripMenuItem"
        Me.ClasificandoLineasYCirculosToolStripMenuItem.Size = New System.Drawing.Size(260, 22)
        Me.ClasificandoLineasYCirculosToolStripMenuItem.Text = "Clasificando lineas y circulos"
        '
        'ClasificandoConRespectoAUnaLineaVerticalToolStripMenuItem
        '
        Me.ClasificandoConRespectoAUnaLineaVerticalToolStripMenuItem.Name = "ClasificandoConRespectoAUnaLineaVerticalToolStripMenuItem"
        Me.ClasificandoConRespectoAUnaLineaVerticalToolStripMenuItem.Size = New System.Drawing.Size(311, 22)
        Me.ClasificandoConRespectoAUnaLineaVerticalToolStripMenuItem.Text = "Clasificando con respecto a una linea vertical"
        '
        'frmPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 366)
        Me.Controls.Add(Me.dwgActual)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "frmPrincipal"
        Me.Text = "Form1"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents AdmonToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConectarConAutoCADToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents dwgActual As TextBox
    Friend WithEvents EjemplosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LeyendoUnaCoordenadaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LeesSecuenciaDeCoordinadasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InputDataToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SeleccionDeObjetosEnElPlanoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UnObjetoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SelectivaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ElementsoDentroDeUnRectanguloToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClasificandoLineasYCirculosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClasificandoConRespectoAUnaLineaVerticalToolStripMenuItem As ToolStripMenuItem
End Class
