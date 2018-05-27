Public Class Form1
    Function EncryptDecrypt(ByVal text1 As String, ByVal key As String, ByVal isEncrypt As Boolean) As String
        Dim char1 As String
        Dim char2 As String
        Dim CKEY As Byte
        Dim strLength As Integer
        Dim result As String = ""
        Dim j As Integer = -1
        If text1 <> "" And IsNumeric(key) Then
            strLength = text1.Length
            For i As Integer = 0 To strLength - 1
                char1 = text1.Substring(i, 1)
                If j < key.Length - 1 Then
                    j = j + 1
                Else
                    j = 0
                End If
                CKEY = Val(key.Substring(j, 1))
                If isEncrypt Then
                    If (Asc(char1) + CKEY) > 255 Then
                        char2 = Chr(Asc(char1) + CKEY - 255)
                    Else
                        char2 = Chr(Asc(char1) + CKEY)
                    End If
                Else
                    If (Asc(char1) - CKEY) < 1 Then
                        char2 = Chr(Asc(char1) - CKEY + 255)
                    Else
                        char2 = Chr(Asc(char1) - CKEY)
                    End If
                End If
                result &= char2
            Next
        Else
            MsgBox("Enter text or key!")
        End If
        Return result
    End Function
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnEncrypt_Click(sender As Object, e As EventArgs) Handles btnEncrypt.Click
        txtResult.Text = EncryptDecrypt(txtText.Text, txtKey.Text, True)
    End Sub

    Private Sub btnDecrypt_Click(sender As Object, e As EventArgs) Handles btnDecrypt.Click
        txtResult.Text = EncryptDecrypt(txtText.Text, txtKey.Text, False)
    End Sub
    Sub bersih()
        txtText.Clear()
        txtKey.Clear()
        txtResult.Clear()
        txtText.Focus()
    End Sub
    Private Sub btnBersih_Click(sender As Object, e As EventArgs) Handles btnBersih.Click
        bersih()
    End Sub
End Class
