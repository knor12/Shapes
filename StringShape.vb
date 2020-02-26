

Public Class StringShape
    Inherits BaseShape


    Protected x1, x2, y1, y2 As Double
    Protected strText As String
    Protected Defaultfont As Font = New Font("Courier New", 100)

    Public Sub New(ByVal x1 As Double, ByVal y1 As Double, _
                      ByVal strText As String)

        Me.x1 = x1
        Me.x2 = x2
        Me.y1 = y1
        Me.y2 = y2
        Me.strText = strText
        Me.strName = "String"

    End Sub

    Public Sub setText(ByVal strText As String)
        Me.strText = strText
    End Sub

    Public Overrides Sub setThickness(ByVal Thickness As Integer)
        MyBase.setThickness(Thickness)
        Defaultfont = New Font(Defaultfont.Name, Thickness, Defaultfont.Style, Defaultfont.Unit)
    End Sub

 


    Public Overrides Sub draw(ByVal g As Graphics, ByVal canvas As ConcreteCanvas)
        Try
            Dim br As SolidBrush = New SolidBrush(defaultColor)
            'g.DrawLine(defaultPen, canvas.conditionX(x1), canvas.conditionY(y1), _
            '          canvas.conditionX(x2), canvas.conditionY(y2))
            Defaultfont = New Font("Courier New", canvas.conditionX(defaultThickness))
            g.DrawString(strText, Defaultfont, br, canvas.conditionX(x1 + X_Offset), canvas.conditionStringY(y1 + Y_Offset))


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class


