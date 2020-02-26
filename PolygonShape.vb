Public Class PolygonShape
    Inherits ClosedShape

    Protected con_points() As Point
    Protected points() As Point

    Public Sub New(ByVal points_() As Point)
        MyBase.new()



        Me.points = points_


    End Sub



    Public Overrides Sub draw(ByVal g As Graphics, ByVal canvas As ConcreteCanvas)
        Try

            Dim br As New SolidBrush(defaultFillColor)

            ReDim con_points(points.Length - 1)

            For i As Integer = 0 To points.Length - 1
                con_points(i) = New Point(canvas.conditionX(points(i).X), canvas.conditionY(points(i).Y))
            Next



            g.DrawPolygon(defaultPen, con_points)

            g.FillPolygon(br, con_points)





        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
