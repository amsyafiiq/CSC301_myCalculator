Public Class frmCalculator
    ' Universal Variable
    Private number As String
    Private operation As String
    Private value As Integer

    ' Auto select textbox for user input
    Private Sub frmCalculator_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtNumBox.Select()
    End Sub

    ' Handle user input restrictions
    Private Sub txtNumBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumBox.KeyPress
        Dim character As String = e.KeyChar

        Select Case character
            Case "+"
                btnPlus_Click(sender, e)
            Case "-"
                btnMinus_Click(sender, e)
            Case "*"
                btnMultiply_Click(sender, e)
            Case "/"
                btnDivide_Click(sender, e)
            Case "="
                btnEqual_Click(sender, e)
        End Select

        If e.KeyChar = ChrW(Keys.Delete) Then btnClear_Click(sender, e)
        If e.KeyChar = ChrW(Keys.Enter) Then btnEqual_Click(sender, e)

        If Not Char.IsNumber(e.KeyChar) And Not e.KeyChar = ChrW(Keys.Back) Then
            e.Handled = True
        End If
    End Sub

    ' Handle button click event for numeric button
    Private Sub btn_Click(sender As Object, e As EventArgs) Handles btn0.Click, btn1.Click, btn2.Click, btn3.Click,
            btn4.Click, btn5.Click, btn6.Click, btn7.Click, btn8.Click, btn9.Click

        If txtNumBox.TextLength < 13 Then
            Select Case DirectCast(sender, Button).Name
                Case "btn0"
                    txtNumBox.Text = txtNumBox.Text & 0
                Case "btn1"
                    txtNumBox.Text = txtNumBox.Text & 1
                Case "btn2"
                    txtNumBox.Text = txtNumBox.Text & 2
                Case "btn3"
                    txtNumBox.Text = txtNumBox.Text & 3
                Case "btn4"
                    txtNumBox.Text = txtNumBox.Text & 4
                Case "btn5"
                    txtNumBox.Text = txtNumBox.Text & 5
                Case "btn6"
                    txtNumBox.Text = txtNumBox.Text & 6
                Case "btn7"
                    txtNumBox.Text = txtNumBox.Text & 7
                Case "btn8"
                    txtNumBox.Text = txtNumBox.Text & 8
                Case "btn9"
                    txtNumBox.Text = txtNumBox.Text & 9
            End Select
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtNumBox.Clear()
        number = ""
    End Sub

    Private Sub btnPlus_Click(sender As Object, e As EventArgs) Handles btnPlus.Click
        value = Val(number)
        If number = "" Then
            number = Val(txtNumBox.Text)
            txtNumBox.Clear()
            operation = "+"
        Else
            calc()
            number = value
            txtNumBox.Clear()
            operation = "+"
        End If
    End Sub

    Private Sub btnMinus_Click(sender As Object, e As EventArgs) Handles btnMinus.Click
        value = Val(number)
        If number = "" Then
            number = Val(txtNumBox.Text)
            txtNumBox.Clear()
            operation = "-"
        Else
            calc()
            number = value
            txtNumBox.Clear()
            operation = "-"
        End If
    End Sub

    Private Sub btnMultiply_Click(sender As Object, e As EventArgs) Handles btnMultiply.Click
        value = Val(number)
        If number = "" Then
            number = Val(txtNumBox.Text)
            txtNumBox.Clear()
            operation = "*"
        Else
            calc()
            number = value
            txtNumBox.Clear()
            operation = "*"
        End If

    End Sub

    Private Sub btnDivide_Click(sender As Object, e As EventArgs) Handles btnDivide.Click
        value = Val(number)
        If number = "" Then
            number = Val(txtNumBox.Text)
            txtNumBox.Clear()
            operation = "/"
        Else
            calc()
            number = value
            txtNumBox.Clear()
            operation = "/"
        End If
    End Sub

    Private Sub btnEqual_Click(sender As Object, e As EventArgs) Handles btnEqual.Click
        value = Val(number)
        calc()
        txtNumBox.Text = number
    End Sub

    ' Calculation
    Sub calc()
        value = Val(number)
        Try
            Select Case operation
                Case "+"
                    value += Val(txtNumBox.Text)
                    number = value
                Case "-"
                    value -= Val(txtNumBox.Text)
                    number = value
                Case "*"
                    value *= Val(txtNumBox.Text)
                    number = value
                Case "/"
                    value /= Val(txtNumBox.Text)
                    number = value
            End Select
        Catch ex As OverflowException
            MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub
End Class