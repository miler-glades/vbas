Imports System.Windows.Forms

Public Class CalculatorForm
    Inherits Form

    ' Declare controls
    Private WithEvents btnAdd As New Button With {.Text = "+"}
    Private WithEvents btnSubtract As New Button With {.Text = "-"}
    Private WithEvents btnMultiply As New Button With {.Text = "*"}
    Private WithEvents btnDivide As New Button With {.Text = "/"}
    Private WithEvents btnEquals As New Button With {.Text = "="}
    Private WithEvents btnClear As New Button With {.Text = "C"}
    Private WithEvents txtDisplay As New TextBox

    Private operand1 As Double
    Private operation As String

    Public Sub New()
        ' Set form properties
        Me.Text = "Simple Calculator"
        Me.Size = New Size(300, 400)
        Me.StartPosition = FormStartPosition.CenterScreen

        ' Set control properties
        txtDisplay.Dock = DockStyle.Top
        txtDisplay.Multiline = True
        txtDisplay.Height = 50
        txtDisplay.ReadOnly = True
        txtDisplay.TextAlign = HorizontalAlignment.Right

        btnAdd.Dock = DockStyle.Fill
        btnSubtract.Dock = DockStyle.Fill
        btnMultiply.Dock = DockStyle.Fill
        btnDivide.Dock = DockStyle.Fill
        btnEquals.Dock = DockStyle.Fill
        btnClear.Dock = DockStyle.Fill

        ' Add controls to the form
        Me.Controls.Add(txtDisplay)
        Me.Controls.Add(btnAdd)
        Me.Controls.Add(btnSubtract)
        Me.Controls.Add(btnMultiply)
        Me.Controls.Add(btnDivide)
        Me.Controls.Add(btnEquals)
        Me.Controls.Add(btnClear)
    End Sub

    Private Sub NumberButtonClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdd.Click, btnSubtract.Click, btnMultiply.Click, btnDivide.Click
        If Double.TryParse(txtDisplay.Text, operand1) Then
            operation = DirectCast(sender, Button).Text
            txtDisplay.Clear()
        End If
    End Sub

    Private Sub EqualsButtonClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnEquals.Click
        Dim operand2 As Double
        If Double.TryParse(txtDisplay.Text, operand2) Then
            Select Case operation
                Case "+"
                    txtDisplay.Text = (operand1 + operand2).ToString()
                Case "-"
                    txtDisplay.Text = (operand1 - operand2).ToString()
                Case "*"
                    txtDisplay.Text = (operand1 * operand2).ToString()
                Case "/"
                    If operand2 <> 0 Then
                        txtDisplay.Text = (operand1 / operand2).ToString()
                    Else
                        txtDisplay.Text = "Error"
                    End If
            End Select
        End If
    End Sub

    Private Sub ClearButtonClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnClear.Click
        txtDisplay.Clear()
    End Sub

    Shared Sub Main()
        Application.Run(New CalculatorForm())
    End Sub
End Class
