Imports Microsoft.VisualBasic
Imports System.Security.Cryptography
Imports System.IO
Imports System
Public Class Encryption

    Public Class Encryption
        Public Class Encoder
            Private _sEncryptPassword As String = "lp"
            ' Sub New(ByVal sPassword As String)
            '   _sEncryptPassword = sPassword
            ' End Sub
            Public Property Passkey() As String
                Get
                    Return _sEncryptPassword
                End Get
                Set(ByVal value As String)
                    _sEncryptPassword = value
                End Set
            End Property
            
            Public Function RijndaelDecrypt(ByVal sCypher As String) As String
                Dim oCypher As Byte() = Convert.FromBase64String(sCypher)
                Dim oKey As Byte() = GetKey()
                If oCypher Is Nothing OrElse oCypher.Length <= 0 Then
                    Throw New ArgumentNullException("oCypher")
                End If
                If oKey Is Nothing OrElse oKey.Length <= 0 Then
                    Throw New ArgumentNullException("Key")
                End If
                Dim msDecrypt As MemoryStream = Nothing
                Dim csDecrypt As CryptoStream = Nothing
                Dim srDecrypt As StreamReader = Nothing
                Dim aesAlg As RijndaelManaged = Nothing
                Dim plaintext As String = Nothing
                Try
                    aesAlg = New RijndaelManaged
                    aesAlg.Key = oKey
                    aesAlg.IV = oKey
                    ' Create a decrytor to perform the stream transform.
                    Dim decryptor As ICryptoTransform = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV)
                    ' Create the streams used for decryption.
                    msDecrypt = New MemoryStream(oCypher)
                    csDecrypt = New CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read)
                    srDecrypt = New StreamReader(csDecrypt)
                    ' Read the decrypted bytes from the decrypting stream
                    plaintext = srDecrypt.ReadToEnd()
                Finally
                    If Not (srDecrypt Is Nothing) Then
                        srDecrypt.Close()
                    End If
                    If Not (csDecrypt Is Nothing) Then
                        csDecrypt.Close()
                    End If
                    If Not (msDecrypt Is Nothing) Then
                        msDecrypt.Close()
                    End If
                    If Not (aesAlg Is Nothing) Then
                        aesAlg.Clear()
                    End If
                End Try
                Return plaintext
            End Function
            Private Function GetKey() As Byte()
                Return (New System.Text.UnicodeEncoding).GetBytes(Passkey.PadRight(8, "*"))
            End Function
        End Class
    End Class

End Class
