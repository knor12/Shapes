Public Class CircleShape
    Inherits ClosedShape

    Protected x_Center As Double = 0
    Protected y_Center As Double = 0
    Protected radius As Double = 10

    Public Sub New(ByVal xCenter As Double, ByVal yCenter As Double, _
                    ByVal raduis As Double)
        MyBase.new()
        Me.x_Center = xCenter
        Me.y_Center = yCenter
        Me.radius = raduis
    End Sub


    Public Overrides Sub draw(ByVal g As Graphics, ByVal canvas As ConcreteCanvas)
        Try

            Dim br As New SolidBrush(defaultFillColor)




            Dim x1 As Double = x_Center - radius
            Dim y1 As Double = y_Center - radius
            Dim diameter As Double = radius * 2

            
            Dim c_width As Integer = canvas.conditionY(diameter)
            Dim c_height As Integer = canvas.conditionX(diameter)
            Dim c_x1 As Integer = canvas.conditionX(x1 + X_Offset)


            Dim c_y1 As Integer = canvas.conditionX(y1 + Y_Offset)


            g.DrawEllipse(defaultPen, c_x1, c_y1, _
                          c_height, c_width)


            g.FillEllipse(br, c_x1, c_y1, _
                          c_width, c_height)


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
