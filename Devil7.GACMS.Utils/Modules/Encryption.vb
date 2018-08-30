'=========================================================================='
'                                                                          '
'                    (C) Copyright 2018 Devil7 Softwares.                  '
'                                                                          '
' Licensed under the Apache License, Version 2.0 (the "License");          '
' you may not use this file except in compliance with the License.         '
' You may obtain a copy of the License at                                  '
'                                                                          '
'                http://www.apache.org/licenses/LICENSE-2.0                '
'                                                                          '
' Unless required by applicable law or agreed to in writing, software      '
' distributed under the License is distributed on an "AS IS" BASIS,        '
' WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. '
' See the License for the specific language governing permissions and      '
' limitations under the License.                                           '
'                                                                          '
' Contributors :                                                           '
'     Dineshkumar T                                                        '
'                                                                          '
'=========================================================================='

Imports System.IO
Imports System.Security.Cryptography

Namespace Modules
    Public Class Encryption
#Region "Encryption Keys & Settings"
        Private Shared PassPhrase As String = "QS@14#%1S478"
        Private Shared m_strSaltValue As String = "G$M@RT@^"            '---- Should be minimum 8 characters
        Private Shared m_strInitVector As String = "@D$7@RL#$DKS$#@D"   '--- must be 16 bytes

        Private Shared m_strIterations As Integer = 47                  '--- can be any number
        Private Shared m_intKeySize As Integer = 256                    '--- can be 192 or 128 or 256
#End Region
#Region "EncryptDecryptClass"
        'Encrypt Function: 
        Public Shared Function Encrypt(ByVal plainText As String) As String
            Dim strReturn As String = String.Empty
            Try
                Dim initVectorBytes As Byte()
                initVectorBytes = System.Text.Encoding.ASCII.GetBytes(m_strInitVector)

                Dim saltValueBytes As Byte()
                saltValueBytes = System.Text.Encoding.ASCII.GetBytes(m_strSaltValue)

                Dim plainTextBytes As Byte()
                plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText)

                Dim mkey As New Rfc2898DeriveBytes(PassPhrase,
                                          saltValueBytes,
                                          m_strIterations)

                Dim keyBytes As Byte()
                Dim intKeySize As Integer = 0
                intKeySize = CType((m_intKeySize / 8), Integer)
                keyBytes = mkey.GetBytes(intKeySize)

                Dim symmetricKey As New Security.Cryptography.RijndaelManaged
                symmetricKey.Mode = Security.Cryptography.CipherMode.CBC

                Dim encryptor As Security.Cryptography.ICryptoTransform = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes)
                Dim memoryStream As New IO.MemoryStream
                Dim cryptoStream As New Security.Cryptography.CryptoStream(memoryStream,
                                            encryptor,
                                             Security.Cryptography.CryptoStreamMode.Write)
                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length)
                cryptoStream.FlushFinalBlock()

                Dim cipherTextBytes As Byte()
                cipherTextBytes = memoryStream.ToArray()
                memoryStream.Close()
                cryptoStream.Close()
                Dim cipherText As String
                cipherText = Convert.ToBase64String(cipherTextBytes)
                strReturn = cipherText
            Catch ex As Exception
                strReturn = Nothing
            End Try
            Return strReturn
        End Function

        'Decrypt Function: 
        Public Shared Function Decrypt(ByVal cipherText As String) As String
            Dim strReturn As String = String.Empty
            Try
                Dim initVectorBytes As Byte()
                initVectorBytes = System.Text.Encoding.ASCII.GetBytes(m_strInitVector)

                Dim saltValueBytes As Byte()
                saltValueBytes = System.Text.Encoding.ASCII.GetBytes(m_strSaltValue)

                Dim cipherTextBytes As Byte()
                cipherTextBytes = Convert.FromBase64String(cipherText)

                Dim mkey As New Rfc2898DeriveBytes(PassPhrase,
                                            saltValueBytes,
                                            m_strIterations)

                Dim keyBytes As Byte()
                Dim intKeySize As Integer
                intKeySize = CType((m_intKeySize / 8), Integer)
                keyBytes = mkey.GetBytes(intKeySize)

                Dim symmetricKey As New Security.Cryptography.RijndaelManaged
                symmetricKey.Mode = Security.Cryptography.CipherMode.CBC

                Dim decryptor As Security.Cryptography.ICryptoTransform
                decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes)

                Dim memoryStream As IO.MemoryStream
                memoryStream = New IO.MemoryStream(cipherTextBytes)

                Dim cryptoStream As New Security.Cryptography.CryptoStream(memoryStream,
                                            decryptor,
                                             Security.Cryptography.CryptoStreamMode.Read)

                Dim plainTextBytes As Byte()
                ReDim plainTextBytes(cipherTextBytes.Length)

                Dim decryptedByteCount As Integer
                decryptedByteCount = cryptoStream.Read(plainTextBytes,
                                                0,
                                                plainTextBytes.Length)
                memoryStream.Close()
                cryptoStream.Close()

                Dim plainText As String = System.Text.Encoding.UTF8.GetString(plainTextBytes,
                                                0,
                                                decryptedByteCount)
                strReturn = plainText
            Catch ex As Exception
                strReturn = Nothing
            End Try
            Return strReturn
        End Function
#End Region
    End Class
End Namespace