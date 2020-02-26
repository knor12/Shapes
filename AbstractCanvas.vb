Public Interface AbstractCanvas



    Sub update()
    Sub addShape(ByVal shape As BaseShape)
    Function removeShape(ByVal shape As BaseShape) As Boolean
    Function removeShapes() As Boolean
    Sub setBackColor(ByVal colour As Color)
    Function getBackColor() As Color

    Function conditionX(ByVal xcord As Double) As Integer
    Function conditionY(ByVal ycord As Double) As Integer

    Function conditionStringY(ByVal ycord As Double) As Integer




End Interface
