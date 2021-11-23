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

    ' Button Click
    Private Sub btn0_Click(sender As Object, e As EventArgs) Handles btn0.Click
        If txtNumBox.TextLength < 13 Then
            txtNumBox.Text = txtNumBox.Text & 0
        End If
    End Sub

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        If txtNumBox.TextLength < 13 Then
            txtNumBox.Text = txtNumBox.Text & 1
        End If
    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        If txtNumBox.TextLength < 13 Then
            txtNumBox.Text = txtNumBox.Text & 2
        End If
    End Sub

    Private Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        If txtNumBox.TextLength < 13 Then
            txtNumBox.Text = txtNumBox.Text & 3
        End If
    End Sub

    Private Sub btn4_Click(sender As Object, e As EventArgs) Handles btn4.Click
        If txtNumBox.TextLength < 13 Then
            txtNumBox.Text = txtNumBox.Text & 4
        End If
    End Sub

    Private Sub btn5_Click(sender As Object, e As EventArgs) Handles btn5.Click
        If txtNumBox.TextLength < 13 Then
            txtNumBox.Text = txtNumBox.Text & 5
        End If
    End Sub

    Private Sub btn6_Click(sender As Object, e As EventArgs) Handles btn6.Click
        If txtNumBox.TextLength < 13 Then
            txtNumBox.Text = txtNumBox.Text & 6
        End If
    End Sub

    Private Sub btn7_Click(sender As Object, e As EventArgs) Handles btn7.Click
        If txtNumBox.TextLength < 13 Then
            txtNumBox.Text = txtNumBox.Text & 7
        End If
    End Sub

    Private Sub btn8_Click(sender As Object, e As EventArgs) Handles btn8.Click
        If txtNumBox.TextLength < 13 Then
            txtNumBox.Text = txtNumBox.Text & 8
        End If
    End Sub

    Private Sub btn9_Click(sender As Object, e As EventArgs) Handles btn9.Click
        If txtNumBox.TextLength < 13 Then
            txtNumBox.Text = txtNumBox.Text & 9
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
