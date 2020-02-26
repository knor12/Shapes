Public Class AnalogMeterShape
    Inherits CompositeShape

    Protected minValue As Double = 0
    Protected maxValue As Double = 30
    Protected unit_of_measure As String = ""
    Protected value As Double
    Protected minSpec As Double = 10
    Protected maxSpec As Double = 15
    Protected circleResolution As Double = 60
    Protected startAngle As Double = -5
    Protected endAngle As Double = 180 - startAngle
    Protected circleRadius As Double = 40
    Protected circleCenterX As Double = circleRadius
    Protected circleCenterY As Double = 0

    Public Sub New()
        MyBase.New()
        setOffset(10, 20)
    End Sub


    Public Sub setUnitOfMeasure(ByVal unit_of_measure As String)
        Me.unit_of_measure = unit_of_measure

    End Sub

    Public Sub setMinSpec(ByVal val As Double)
        Me.minSpec = val
    End Sub

    Public Sub setMaxSpec(ByVal val As Double)
        Me.maxSpec = val
    End Sub

    Public Function getMaxSpec(ByVal val As Double) As Double
        Return Me.maxSpec
    End Function

    Public Function getMinSpec(ByVal val As Double) As Double
        Return Me.minSpec
    End Function


    Public Sub setMinValue(ByVal val As Double)
        Me.minValue = val
    End Sub

    Public Sub setMaxValue(ByVal val As Double)
        Me.maxValue = val
    End Sub

    Public Function getMaxValue(ByVal val As Double) As Double
        Return Me.maxValue
    End Function

    Public Function getMinValue(ByVal val As Double) As Double
        Return Me.minValue
    End Function

    Public Sub setValue(ByVal val As Double)
        Me.value = val
    End Sub

    Public Sub update()
        Try
            removeShapes()
            drawGraticules()
            drawNeedle()



            'updateLimits()
            'drawXaxis()
            'drawYaxis()
            'drawSpectrums()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub drawGraticules()
        Try

            drawHalfCircle()

            drawLines()

            drawSpecs()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub drawNeedle()
        Try



            'draw the circle 
            Dim smallCircleRadius As Double = 2.5
            Dim needleBaseWidth As Double = 2.5
            Dim circle As CircleShape = New CircleShape(circleCenterX, circleCenterY, smallCircleRadius)
            Dim needlefillColor As Color = Color.Yellow

            If value > minSpec Then
                needlefillColor = Color.Green
            End If

            If value > maxSpec Then
                needlefillColor = Color.Red
            End If

            circle.setFillColor(needlefillColor)
            circle.setColor(needlefillColor)
            addShape(circle)


            'draw triangle 
            Dim x1, x2, x3, y1, y2, y3 As Double
            Dim needleAngle As Double = value * (endAngle - startAngle) / (maxValue - minValue) + startAngle


            y1 = Math.Sin(degreeToRadian(needleAngle)) * circleRadius
            x1 = circleRadius - circleRadius * Math.Cos(degreeToRadian(needleAngle))


            Dim baseAngle As Double = 90 - needleAngle

            x2 = circleCenterX + Math.Cos(degreeToRadian(180 + baseAngle)) * needleBaseWidth
            y2 = circleCenterY + Math.Sin(degreeToRadian(180 + baseAngle)) * needleBaseWidth


            x3 = circleCenterX + Math.Cos(degreeToRadian(baseAngle)) * needleBaseWidth
            y3 = circleCenterY + Math.Sin(degreeToRadian(baseAngle)) * needleBaseWidth


            Dim tri As TriangleShape = New TriangleShape(x1, y1, x2, y2, x3, y3)
            tri.setFillColor(needlefillColor)
            tri.setColor(needlefillColor)
            addShape(tri)

            'display current value
            Dim strShift As Integer = 0
            Dim strTicknes As Integer = 10
            Dim strVal As String = value.ToString()
            strShift = strTicknes * strVal.Length / 2
            Dim str As StringShape = New StringShape(circleCenterX - strShift, circleRadius + 35, strVal)
            str.setThickness(10)
            str.setColor(Color.White)
            addShape(str)

            'draw unit of mearure 
            strShift = 0
            strTicknes = 10
            strVal = unit_of_measure.ToString()
            strShift = strTicknes * strVal.Length / 2
            str = New StringShape(circleCenterX - strShift, -5, strVal)

            str.setThickness(10)
            str.setColor(Color.White)
            addShape(str)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub drawLines()
        Dim currentAngle As Double = startAngle
        Dim incrementAngle As Double = (endAngle - startAngle) / 10
        Dim x1, x2, y1, y2 As Double
        Dim tempRadius As Double
        Dim strShape As StringShape
        Dim incrementval As Double = (maxValue - minValue) / 10
        Dim currentval = minValue


        For i As Integer = 0 To 10
            tempRadius = circleRadius - 2.5
            y1 = tempRadius * Math.Sin(degreeToRadian(currentAngle))
            x1 = circleRadius - tempRadius * Math.Cos(degreeToRadian(currentAngle))

            tempRadius = circleRadius + 2.5
            y2 = tempRadius * Math.Sin(degreeToRadian(currentAngle))
            x2 = circleRadius - tempRadius * Math.Cos(degreeToRadian(currentAngle))
            addShape(New LineShape(x1, y1, x2, y2))
            If currentAngle < 90 Then
                x2 = x2 - 5
            ElseIf currentAngle < 90 Then
                x2 = x2 + 5
            End If
            strShape = New StringShape(x2, y2 + 2, currentval.ToString("0.000"))
            strShape.setThickness(2)
            strShape.setColor(Color.White)
            addShape(strShape)


            If i = 10 Then
                Exit For
            End If
            currentval = currentval + incrementval
            currentAngle = currentAngle + incrementAngle / 2
            tempRadius = circleRadius - 1
            y1 = tempRadius * Math.Sin(degreeToRadian(currentAngle))
            x1 = circleRadius - tempRadius * Math.Cos(degreeToRadian(currentAngle))

            tempRadius = circleRadius + 1
            y2 = tempRadius * Math.Sin(degreeToRadian(currentAngle))
            x2 = circleRadius - tempRadius * Math.Cos(degreeToRadian(currentAngle))

            addShape(New LineShape(x1, y1, x2, y2))

            currentAngle = currentAngle + incrementAngle / 2

        Next



    End Sub

    Private Sub drawSpecs()

        Dim minSpecAngle As Double
        Dim maxSpecAngle As Double
        Dim middleSpecAngle As Double
        Dim middleSpec As Double
        Dim tempradius As Double
        Dim x1, x2, y1, y2 As Double
        Dim temLine As LineShape

        Dim strShape As StringShape

        middleSpec = (minSpec + maxSpec) / 2

        minSpecAngle = minSpec * (endAngle - startAngle) / (maxValue - minValue) + startAngle
        maxSpecAngle = maxSpec * (endAngle - startAngle) / (maxValue - minValue) + startAngle
        middleSpecAngle = middleSpec * (endAngle - startAngle) / (maxValue - minValue) + startAngle

        '=======================================================
        tempradius = circleRadius - 2.5
        y1 = tempradius * Math.Sin(degreeToRadian(middleSpecAngle))
        x1 = circleRadius - tempradius * Math.Cos(degreeToRadian(middleSpecAngle))

        tempradius = circleRadius + 10
        y2 = tempradius * Math.Sin(degreeToRadian(middleSpecAngle))
        x2 = circleRadius - tempradius * Math.Cos(degreeToRadian(middleSpecAngle))

        temLine = New LineShape(x1, y1, x2, y2)
        temLine.setColor(Color.Green)
        addShape(temLine)
        strShape = New StringShape(x2, y2 + 2, middleSpec.ToString)
        strShape.setColor(Color.Green)
        addShape(strShape)
        '======================================
        tempradius = circleRadius - 2.5
        y1 = tempradius * Math.Sin(degreeToRadian(minSpecAngle))
        x1 = circleRadius - tempradius * Math.Cos(degreeToRadian(minSpecAngle))

        tempradius = circleRadius + 10
        y2 = tempradius * Math.Sin(degreeToRadian(minSpecAngle))
        x2 = circleRadius - tempradius * Math.Cos(degreeToRadian(minSpecAngle))

        temLine = New LineShape(x1, y1, x2, y2)
        temLine.setColor(Color.Green)
        addShape(temLine)
        strShape = New StringShape(x2, y2 + 2, minSpec.ToString)
        strShape.setColor(Color.Green)
        addShape(strShape)


        '========================================
        tempradius = circleRadius - 2.5
        y1 = tempradius * Math.Sin(degreeToRadian(maxSpecAngle))
        x1 = circleRadius - tempradius * Math.Cos(degreeToRadian(maxSpecAngle))

        tempradius = circleRadius + 10
        y2 = tempradius * Math.Sin(degreeToRadian(maxSpecAngle))
        x2 = circleRadius - tempradius * Math.Cos(degreeToRadian(maxSpecAngle))

        temLine = New LineShape(x1, y1, x2, y2)
        temLine.setColor(Color.Green)
        addShape(temLine)

        strShape = New StringShape(x2, y2 + 2, maxSpec.ToString)
        strShape.setColor(Color.Green)
        addShape(strShape)



    End Sub


    Private Sub drawHalfCircle()
        Try
            Dim x1, y1, x2, y2 As Double
            Dim currentAngle As Double = startAngle
            Dim AngleIncrement As Double = (endAngle - startAngle) / circleResolution
            x1 = circleRadius - circleRadius * Math.Cos(degreeToRadian(currentAngle))
            y1 = circleRadius * Math.Sin(degreeToRadian(currentAngle))

            For i As Integer = 1 To circleResolution
                currentAngle = currentAngle + AngleIncrement
                x2 = circleRadius - circleRadius * Math.Cos(degreeToRadian(currentAngle))
                y2 = circleRadius * Math.Sin(degreeToRadian(currentAngle))

                addShape(New LineShape(x1, y1, x2, y2))
                x1 = x2
                y1 = y2
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function degreeToRadian(ByVal degrees As Double) As Double
        Return degrees / (180 / Math.PI)
    End Function

End Class
