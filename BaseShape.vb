
Public Class BaseShape

    Protected strName As String = "BaseShape"
    Protected isVisible_ As Boolean = False
    Protected defaultColor As Color = Color.Red
    Protected defaultThickness As Integer = 2
    Protected defaultPen As Pen = New Pen(defaultColor, defaultThickness)
  

    Protected Y_Offset As Integer = 0
    Protected X_Offset As Integer = 0

    Public Function getShapeType() As String
        Return strName
    End Function


    Public Sub New()

    End Sub

    Public Overridable Function getOffsetX() As Integer
        Return (X_Offset)
    End Function

    Public Overridable Function getOffsetY() As Integer
        Return (Y_Offset)
    End Function

   

    Public Overridable Sub setOffset(ByVal X_Offset As Integer, ByVal Y_Offset As Integer)
        Me.Y_Offset = (Y_Offset)
        Me.X_Offset = (X_Offset)
    End Sub

    Public Overridable Function isVisible()
        Return isVisible_
    End Function


    Public Overridable Sub setVisible(ByVal isVisible_ As Boolean)
        Me.isVisible_ = isVisible_
    End Sub
    Public Overridable Sub draw(ByVal gr As Graphics, ByVal canvas As ConcreteCanvas)
        'do nothing this is an abstract 
    End Sub

    Public Overridable Function getTypeName() As String
        Return strName
    End Function


    Public Sub setColor(ByVal colour As Color)
        defaultColor = colour
        defaultPen.Color = defaultColor
    End Sub

    Public Function getColor() As Color
        Return defaultColor
    End Function


    Public Overridable Sub setThickness(ByVal Thickness As Integer)
        defaultThickness = Thickness
        defaultPen.Width = Thickness
    End Sub

    Public Function getThickness() As Integer
        Return defaultThickness
    End Function








 






 


End Class


