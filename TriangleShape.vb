Public Class TriangleShape
    Inherits ClosedShape

    Protected x1, x2, x3, y1, y2, y3 As Double

    Public Sub New(ByVal x1 As Double, ByVal y1 As Double, _
                    ByVal x2 As Double, ByVal y2 As Double, _
                    ByVal x3 As Double, ByVal y3 As Double)
        MyBase.new()

        Me.x1 = x1
        Me.x2 = x2
        Me.x3 = x3

        Me.y1 = y1
        Me.y2 = y2
        Me.y3 = y3


    End Sub



    Public Overrides Sub draw(ByVal g As Graphics, ByVal canvas As ConcreteCanvas)
        Try

            Dim br As New SolidBrush(defaultFillColor)

            Dim points(2) As Point

            points(0) = New Point(canvas.conditionX(Me.x1 + X_Offset), canvas.conditionY(Me.y1 + Y_Offset))
            points(1) = New Point(canvas.conditionX(Me.x2 + X_Offset), canvas.conditionY(Me.y2 + Y_Offset))
            points(2) = New Point(canvas.conditionX(Me.x3 + X_Offset), canvas.conditionY(Me.y3 + Y_Offset))

            


        
            g.DrawPolygon(defaultPen, points)

            g.FillPolygon(br, points)


           


        Catch ex As Exception
            Throw ex
        End Try
    End Sub



End Class
