Public Class SpectrumsShape
    Inherits CompositeShape

    Protected dataList As ArrayList
    Protected colorList As ArrayList
    Protected nameList As ArrayList
    Protected x_largest As Integer = 10
    Protected x_smallest As Integer = 0
    Protected y_largest As Integer = 10
    Protected y_smallest As Integer = 0
    Private xLines(30) As BaseShape
    Private yLines(30) As BaseShape
    Private xString(30) As BaseShape
    Private yString(30) As BaseShape

   

    Private Sub updateLimits()
        'find the bigger abd the smaller value in te arrsys 
        Dim current_array As Double()
        Dim y_max As Double = 0
        Dim y_min As Double = 0

        Dim x_min As Double = 0
        Dim x_max As Double = 0

        For Each item In dataList

            current_array = CType(item, Double())

            If y_max < current_array.Max Then
                y_max = current_array.Max
            End If

            If y_min > current_array.Max Then
                y_min = current_array.Max
            End If


            If x_max < current_array.Length Then
                x_max = current_array.Length
            End If

        Next


        x_largest = 10
        While (True)

            If x_largest > x_max Then
                Exit While
            End If
            x_largest = x_largest * 2

        End While



        y_largest = 10

        While (True)

            If y_largest > y_max Then
                Exit While
            End If
            y_largest = y_largest * 2

        End While

    End Sub

    Public Sub New()
        dataList = New ArrayList
        colorList = New ArrayList
        nameList = New ArrayList
        updateLimits()
        drawXaxis()
        drawYaxis()
        drawSpectrums()
    End Sub

    Public Overrides Sub draw(ByVal g As Graphics, ByVal canvas As ConcreteCanvas)
        Try
            updateLimits()
            drawXaxis()
            drawYaxis()
            drawSpectrums()
            MyBase.draw(g, canvas)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub update()
        Try
            removeShapes()
            updateLimits()
            drawXaxis()
            drawYaxis()
            drawSpectrums()
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub drawXaxis()


        xLines(12) = New LineShape(0, 0, 100, 0)
        addShape(xLines(12))
        For i As Integer = 0 To 100 Step 10
            xLines(i / 10) = New LineShape(i + 5, 1.5, i + 5, -1.5)
            addShape(xLines(i / 10))
            xLines(i / 10 + 1) = New LineShape(i, 2.5, i, -2.5)
            addShape(xLines(i / 10 + 1))
        Next

        'xString(30) As BaseShape

        For i As Integer = 0 To 100 Step 10
            xString(i / 10) = New StringShape(i, -1, (x_largest - x_smallest) * i / 100)
            xString(i / 10).setThickness(2)
            addShape(xString(i / 10))
        Next





    End Sub

    Private Sub drawYaxis()
        yLines(12) = New LineShape(0, 0, 0, 100)
        addShape(yLines(12))
        For i As Integer = 0 To 100 Step 10
            yLines(i / 10) = New LineShape(1.5, i - 5, -1.5, i - 5)
            addShape(yLines(i / 10))
            yLines(i / 10 + 1) = New LineShape(2.5, i, -2.5, i)
            addShape(yLines(i / 10 + 1))
        Next

        'xString(30) As BaseShape

        For i As Integer = 0 To 100 Step 10
            yString(i / 10) = New StringShape(-5, i, (y_largest - y_smallest) * i / 100)
            yString(i / 10).setThickness(2)

            addShape(yString(i / 10))
        Next
    End Sub

    Private Sub drawSpectrums()
        Try
            Dim currentData() As Double
            Dim currentColor As Color
            Dim tempLine As BaseShape
            Dim x1, x2 As Double
            Dim y1, y2 As Double
            For Each item In dataList
                currentData = CType(item, Double())
                currentColor = CType(colorList(dataList.IndexOf(item)), Color)

                For i As Integer = 0 To currentData.Length - 2
                    'y1 = currentData(i) * 100 / (x_largest - x_smallest)
                    'y2 = currentData(i + 1) * 100 / (x_largest - x_smallest)

                    'x1 = i * 100 / (y_largest - y_smallest)
                    'x2 = (i + 1) * 100 / (y_largest - y_smallest)

                    y1 = currentData(i) * 100 / (y_largest - y_smallest)
                    y2 = currentData(i + 1) * 100 / (y_largest - y_smallest)

                    x1 = i * 100 / (x_largest - x_smallest)
                    x2 = (i + 1) * 100 / (x_largest - x_smallest)


                    tempLine = New LineShape(x1, y1, x2, y2)
                    tempLine.setColor(currentColor)
                    addShape(tempLine)
                Next

            Next
        Catch ex As Exception
            Throw New Exception("drawSpectrums failed: " & ex.Message)
        End Try

    End Sub

    Public Sub addSpectrum(ByVal data As Double(), _
                           ByVal colour As Color, _
                           ByVal name As String)

        Try
            dataList.Add(data)
            colorList.Add(colour)
            nameList.Add(name)
        Catch ex As Exception
            Throw New Exception("addSpectrum failed: " & ex.Message)
        End Try

    End Sub


    'Public Sub removeSpectrum(ByVal data As Double())
    '    Try

    '        colorList.RemoveAt(dataList.IndexOf(data))
    '        nameList.RemoveAt(dataList.IndexOf(data))
    '        dataList.Remove(data)

    '    Catch ex As Exception
    '        Throw New Exception("removeSpectrum failed: " & ex.Message)
    '    End Try
    'End Sub


    Public Sub removeSpectrumByName(ByVal strName As String)
        Try
            Dim str As String
            Dim index As Integer = -1

            For i As Integer = 0 To nameList.Count - 1
                If nameList.Item(i).ToString = (strName) Then
                    index = i
                    Exit For
                End If
            Next




            'For Each item In nameList
            'str = CType(item, String)
            '  If str.ToUpper = strName.ToUpper Then
            dataList.RemoveAt(index)
            colorList.RemoveAt(index)
            nameList.Remove(index)
            ' End If

            'Next

        Catch ex As Exception
            Throw New Exception("removeSpectrumByName failed: " & ex.Message)
        End Try
    End Sub





End Class
