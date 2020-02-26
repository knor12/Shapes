Public Class ClosedShape
    Inherits BaseShape

    Protected defaultFillColor As Color = Color.Red

    Public Sub setFillColor(ByVal colour As Color)
        defaultFillColor = colour
    End Sub


End Class
