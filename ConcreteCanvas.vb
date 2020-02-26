Public Class ConcreteCanvas
    Implements AbstractCanvas


    Protected Friend WithEvents canvas As Control
    Protected shapesList As ArrayList
    Protected xyMultyPlier As Integer = 100
    Protected X_RIGHT As Integer = 105 * xyMultyPlier
    Protected X_LEFT As Integer = -5 * xyMultyPlier
    Protected Y_TOP As Integer = 105 * xyMultyPlier
    Protected Y_BOTTOM As Integer = -5 * xyMultyPlier

    Function conditionStringY(ByVal ycord As Double) As Integer Implements AbstractCanvas.conditionStringY
        Try

            Return CInt(Y_BOTTOM + Y_TOP - ycord * xyMultyPlier)

        Catch ex As Exception
            Throw New Exception("conditionStringY failed" & ex.Message)
        End Try
    End Function

    Function conditionX(ByVal xcord As Double) As Integer Implements AbstractCanvas.conditionX
        Try

            Return CInt(xcord * xyMultyPlier)

        Catch ex As Exception
            Throw New Exception("conditionX failed" & ex.Message)
        End Try
    End Function


    Function conditionY(ByVal ycord As Double) As Integer Implements AbstractCanvas.conditionY
        Try

            Return CInt(ycord * xyMultyPlier)

        Catch ex As Exception
            Throw New Exception("conditionY failed" & ex.Message)
        End Try
    End Function


    Private Sub canvas_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles canvas.Resize
        canvas.Invalidate()
        'canvas.Update()
    End Sub
    Protected Sub canvas_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles canvas.Paint
        Try



            Dim shape As BaseShape
            For Each item In shapesList
                shape = CType(item, BaseShape)
                drawRecursively(e.Graphics, shape)
              

            Next


        Catch ex As Exception
            MessageBox.Show("canvas_Paint failed " & ex.Message)
        End Try
    End Sub


    Public Sub drawRecursively(ByVal g As Graphics, ByVal shape As BaseShape)

        Try
            Dim com As CompositeShape
            If shape.getTypeName = "Composite" Then

                com = CType(shape, CompositeShape)
                For Each item In com.getShapes
                    drawRecursively(g, CType(item, BaseShape))
                Next

            Else
                If shape.getTypeName() = "String" Then
                    SetScale(g, canvas.Width, canvas.Height, X_LEFT, X_RIGHT, Y_BOTTOM, Y_TOP)
                    shape.draw(g, Me)

                Else
                    SetScale(g, canvas.Width, canvas.Height, X_LEFT, X_RIGHT, Y_TOP, Y_BOTTOM)
                    shape.draw(g, Me)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub



    Public Sub New(ByVal canvas As Control)
        Me.canvas = canvas
        shapesList = New ArrayList()
    End Sub


    Public Sub update() Implements AbstractCanvas.update
        canvas.Invalidate()
        canvas.Update()
        canvas.Refresh()
        For Each item In shapesList


        Next
    End Sub

    Public Sub addShape(ByVal shape As BaseShape) Implements AbstractCanvas.addShape
        Try
            'If shape.getTypeName() = "Composite" Then
            '    For Each item In CType(shape, CompositeShape).getShapes
            '        addShape(CType(item, BaseShape))
            '    Next
            'Else

            'End If

            shapesList.Add(shape)



        Catch ex As Exception
            Throw New Exception("addShape failed :" & ex.Message)
        End Try
    End Sub

    Function removeShape(ByVal shape As BaseShape) As Boolean Implements AbstractCanvas.removeShape
        Try
            shapesList.Remove(shape)
            update()
            Return True
        Catch ex As Exception
            Throw New Exception("removeShape failed :" & ex.Message)
        End Try

    End Function

    Public Function removeShapes() As Boolean Implements AbstractCanvas.removeShapes
        Try
            shapesList.Clear()
            Return True
        Catch ex As Exception
            Throw New Exception("removeShapes failed :" & ex.Message)
        End Try
    End Function

    Public Sub setBackColor(ByVal colour As Color) Implements AbstractCanvas.setBackColor
        Try
            canvas.BackColor = colour
        Catch ex As Exception
            Throw New Exception("setBackColor failed: " & ex.Message)
        End Try
    End Sub

    Function getBackColor() As Color Implements AbstractCanvas.getBackColor
        Try
            Return canvas.BackColor
        Catch ex As Exception
            Throw New Exception("getBackColor failed: " & ex.Message)
        End Try
    End Function


    ' Set transformations for the Graphics object
    ' so its coordinate system matches the one specified.
    ' Return the horizontal scale.
    Protected Sub SetScale(ByVal gr As Graphics, ByVal gr_width _
        As Integer, ByVal gr_height As Integer, ByVal left_x As _
        Single, ByVal right_x As Single, ByVal top_y As Single, _
        ByVal bottom_y As Single)
        ' Start from scratch.
        gr.ResetTransform()

        ' Scale so the viewport's width and height
        ' map to the Graphics object's width and height.
        Dim bounds As RectangleF = gr.ClipBounds
        gr.ScaleTransform( _
            gr_width / (right_x - left_x), _
            gr_height / (bottom_y - top_y))

        ' Translate (left_x, top_y) to the Graphics
        ' object's origin.
        gr.TranslateTransform(-left_x, -top_y)
    End Sub


End Class
