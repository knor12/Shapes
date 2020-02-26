Public Class SevenSegmentDisplay
    Inherits CompositeShape
    Protected number_of_digits As Integer
    Protected value As Double
    Protected horizontal_unit As Double
    Protected vertical_unit As Double
    Protected defaultFillColor As Color

    Protected strSevSeg() As String = _
    {"abcdef", _
     "bc", _
     "abged ", _
     "abgcd", _
     "fgcb", _
     "afgcd", _
     "fedcg", _
     "abc", _
     "abcdefg", _
     "abcgf"}





    Public Sub New(ByVal num_of_digits As Integer)
        MyBase.new()
        Me.number_of_digits = num_of_digits
        defaultColor = Color.LightGreen
        defaultFillColor = Color.LightGreen

        vertical_unit = 100.0 / 51
        horizontal_unit = 100.0 / 28
        horizontal_unit = horizontal_unit / num_of_digits
    End Sub



    Private Sub drawDigit(ByVal digit As Integer, ByVal location As Integer)
        Dim startX As Double = 26 * location * horizontal_unit
        Dim x, y As Double
        Dim pointsA(5) As Point
        'Dim points(5) As Point
        Dim poly(6) As PolygonShape

        vertical_unit = 100.0 / 51
        horizontal_unit = 100.0 / 28
        horizontal_unit = horizontal_unit / number_of_digits

        ' draw A
        x = 4 * horizontal_unit + startX
        y = 45 * vertical_unit
        pointsA(0) = New Point(x, y)

        x = 6 * horizontal_unit + startX
        y = 47 * vertical_unit
        pointsA(1) = New Point(x, y)

        x = 20 * horizontal_unit + startX
        y = 47 * vertical_unit
        pointsA(2) = New Point(x, y)

        x = 22 * horizontal_unit + startX
        y = 45 * vertical_unit
        pointsA(3) = New Point(x, y)

        x = 20 * horizontal_unit + startX
        y = 43 * vertical_unit
        pointsA(4) = New Point(x, y)

        x = 6 * horizontal_unit + startX
        y = 43 * vertical_unit
        pointsA(5) = New Point(x, y)
        poly(0) = New PolygonShape(pointsA)
        poly(0).setColor(defaultColor)
        poly(0).setFillColor(defaultFillColor)
        addShape(poly(0))

        'draw B
        Dim pointsB(5) As Point
        x = 4 * horizontal_unit + startX
        y = 44 * vertical_unit
        pointsB(0) = New Point(x, y)

        x = 6 * horizontal_unit + startX
        y = 42 * vertical_unit
        pointsB(1) = New Point(x, y)

        x = 6 * horizontal_unit + startX
        y = 28 * vertical_unit
        pointsB(2) = New Point(x, y)

        x = 4 * horizontal_unit + startX
        y = 26 * vertical_unit
        pointsB(3) = New Point(x, y)

        x = 2 * horizontal_unit + startX
        y = 28 * vertical_unit
        pointsB(4) = New Point(x, y)

        x = 2 * horizontal_unit + startX
        y = 42 * vertical_unit
        pointsB(5) = New Point(x, y)
        poly(1) = New PolygonShape(pointsB)
        poly(1).setColor(defaultColor)
        poly(1).setFillColor(defaultFillColor)
        addShape(poly(1))


        'draw c 

        'draw d 

        'draw e 

        'draw f


        'draw g

    End Sub

    Public Sub update()
        Try
            removeShapes()

            drawDigit(8, 0)


           
        Catch ex As Exception
            Throw ex
        End Try
    End Sub



End Class
