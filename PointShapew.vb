
'Public Class PointShape
'    Inherits AbstractShapeW
'    Protected x As Double
'    Protected y As Double
'    Protected size As Double



'    Public Sub New(ByVal x1 As Double, _
'                   ByVal y1 As Double, _
'                   ByVal canvas As Control)
'        Me.x = x1
'        Me.y = x1
'        Me.canvas = canvas
'    End Sub



'    Public Sub New(ByVal coord As Coordinate, _
'                    ByVal canvas As Control)
'        Me.x = coord.x
'        Me.y = coord.y
'        Me.canvas = canvas
'    End Sub


'    Public Overrides Sub draw(ByVal g As Graphics)
'        Try

'            Dim width As Integer = Math.Abs(X_RIGHT - X_LEFT / conditionX(100)) * defaultThickness
'            Dim height As Integer = Math.Abs(Y_TOP - Y_BOTTOM / conditionY(100)) * defaultThickness

'            If width < height Then
'                height = width
'            End If

'            Using br = New SolidBrush(defaultColor)
'                g.FillRectangle(br, conditionX(x), conditionY(y), 10, 10)
'            End Using



'            'g.DrawLine(defaultPen, Me.x, Me.y, Me.x + 10, Me.y + 10)
'            'setThickness(10)
'            'setColor(Color.Black)
'            'g.DrawLine(defaultPen, 0, Me.y, 0 + 10, Me.y + 10)
'        Catch ex As Exception
'            Throw ex
'        End Try
'    End Sub

'End Class
