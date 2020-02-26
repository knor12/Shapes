Public Class CompositeShape
    Inherits BaseShape

    Protected ShapesList As ArrayList


    Public Sub New()
        ShapesList = New ArrayList()
        Me.strName = "Composite" ' keep this the same if you inherit from this class 
    End Sub


    Public Sub addShape(ByVal shape As BaseShape)
        shape.setOffset(Me.getOffsetX, Me.getOffsetY)
        ShapesList.Add(shape)

    End Sub


    Public Sub removeShape(ByVal shape As BaseShape)
        ShapesList.Remove(shape)
    End Sub

    Public Sub removeShapes()
        ShapesList.Clear()
    End Sub

    Public Function getShapes() As ArrayList
        Return ShapesList
    End Function


    Public Overrides Sub draw(ByVal gr As Graphics, ByVal canvas As ConcreteCanvas)
        Dim shape As BaseShape

        For Each item In ShapesList
            shape = CType(item, BaseShape)
            shape.draw(gr, canvas)
        Next
    End Sub


End Class
