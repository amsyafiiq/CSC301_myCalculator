Public Class frmCalculator
    ' Universal Variable
    Private number As String
    Private operation As String
    Private value As Decimal
    Private operationBefore As String = ""

    ' Button click event for numeric buttons
    Private Sub btn_Click(sender As Object, e As EventArgs) Handles btn0.Click, btn1.Click, btn2.Click, btn3.Click,
            btn4.Click, btn5.Click, btn6.Click, btn7.Click, btn8.Click, btn9.Click

        If operation = "=" Then btnClear_Click(sender, e)
        If operationBefore = "=" Then txtNumBox.Clear()

        Select Case DirectCast(sender, Button).Name
            Case "btn0"
                numDisplay(0)
            Case "btn1"
                numDisplay(1)
            Case "btn2"
                numDisplay(2)
            Case "btn3"
                numDisplay(3)
            Case "btn4"
                numDisplay(4)
            Case "btn5"
                numDisplay(5)
            Case "btn6"
                numDisplay(6)
            Case "btn7"
                numDisplay(7)
            Case "btn8"
                numDisplay(8)
            Case "btn9"
                numDisplay(9)
        End Select

        operationBefore = ""
    End Sub

    ' Clear Button
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtNumBox.Clear()
        number = ""
        operation = ""
        operationBefore = ""
    End Sub

    ' Arithmethic calculation button
    Private Sub btnPlus_Click(sender As Object, e As EventArgs) Handles btnPlus.Click
        operatorValidate("+")
    End Sub

    Private Sub btnMinus_Click(sender As Object, e As EventArgs) Handles btnMinus.Click
        operatorValidate("-")
    End Sub

    Private Sub btnMultiply_Click(sender As Object, e As EventArgs) Handles btnMultiply.Click
        operatorValidate("*")
    End Sub

    Private Sub btnDivide_Click(sender As Object, e As EventArgs) Handles btnDivide.Click
        operatorValidate("/")
    End Sub

    ' Equal button
    Private Sub btnEqual_Click(sender As Object, e As EventArgs) Handles btnEqual.Click
        value = Val(number)

        If operationBefore <> "" And operation = "=" Then
            operation = operationBefore
            calc()
            displayAnswer()
            operation = "="
        Else
            calc()
            displayAnswer()
            number = txtNumBox.Text
            operationBefore = operation
            operation = "="
        End If
    End Sub


    ' Display and Calculation Subroutine
    ' Calculation
    Sub calc()
        value = Val(number)
        Try
            Select Case operation
                Case "+"
                    value += Val(txtNumBox.Text)
                Case "-"
                    value -= Val(txtNumBox.Text)
                Case "*"
                    value *= Val(txtNumBox.Text)
                Case "/"
                    value /= Val(txtNumBox.Text)
            End Select
            number = value

        Catch ex As Exception
            MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    ' Answer output validation
    Private Sub displayAnswer()
        If number.Length < 13 Then
            txtNumBox.Text = number
        Else
            txtNumBox.Text = number.Substring(0, 13)
        End If
    End Sub

    ' Numeric button input validation
    Private Sub numDisplay(num As Integer)
        If txtNumBox.Text = "0" Then
            txtNumBox.Text = String.Empty
        End If

        If txtNumBox.TextLength < 13 Then
            txtNumBox.Text = txtNumBox.Text & num
        End If
    End Sub

    ' Calculation button input validation
    Private Sub operatorValidate(ByVal operators As String)
        value = Val(number)
        If operation = "=" Then txtNumBox.Clear()

        If number = "" Then
            number = Val(txtNumBox.Text)
            txtNumBox.Clear()
            operation = operators
        Else
            calc()
            If operation <> "=" Then displayAnswer() Else txtNumBox.Clear()
            number = value
            operation = operators
            operationBefore = "="
        End If
    End Sub
End Class