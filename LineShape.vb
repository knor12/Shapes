
Public Class LineShape
    Inherits BaseShape


    Protected x1, x2, y1, y2 As Double


    Public Sub New(ByVal x1 As Double, ByVal y1 As Double, _
                      ByVal x2 As Double, ByVal y2 As Double)

        Me.x1 = x1
        Me.x2 = x2
        Me.y1 = y1
        Me.y2 = y2

        Me.strName = "Line"

    End Sub



    Public Overrides Sub draw(ByVal g As Graphics, ByVal canvas As ConcreteCanvas)
        Try

            g.DrawLine(defaultPen, canvas.conditionX(x1 + X_Offset), canvas.conditionY(y1 + Y_Offset), _
                      canvas.conditionX(x2 + X_Offset), canvas.conditionY(y2 + Y_Offset))


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class


