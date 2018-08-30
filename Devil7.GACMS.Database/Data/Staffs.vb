'==========================================================================
'
'                   (C) Copyright 2018 Devil7 Softwares.
' 
' Licensed under the Apache License, Version 2.0 (the "License");
' you may Not use this file except in compliance with the License.
' You may obtain a copy of the License at
' 
'     http://www.apache.org/licenses/LICENSE-2.0
' 
' Unless required by applicable law Or agreed to in writing, software
' distributed under the License Is distributed on an "AS IS" BASIS,
' WITHOUT WARRANTIES Or CONDITIONS OF ANY KIND, either express Or implied.
' See the License for the specific language governing permissions And
' limitations under the License.
' 
' Contributors:
'     Dineshkumar T
'==========================================================================

Imports Devil7.GACMS.Utils.Objects
Imports Devil7.GACMS.Database.Misc
Imports System.Data.SqlClient


Namespace Data
    Public Class Staffs

        Public Shared Function Authendicate(ByVal Username As String, ByVal Password As String) As Boolean
            Try
                Dim Connection = GetConnection()
                If Connection.State = ConnectionState.Closed Then Connection.Open()

                Dim CommandText As String = "SELECT COUNT(0) FROM Staffs WHERE [Username]=@Username AND [Password]=@Password;"

                Using Command As New SqlCommand(CommandText, Connection)
                    Command.Parameters.AddWithValue("@Username", Username)
                    Command.Parameters.AddWithValue("@Password", Password)
                    If Command.ExecuteScalar = 1 Then
                        Return True
                    End If
                End Using
            Catch ex As Exception
                MsgBox("Authendication failed..!" & vbNewLine & vbNewLine &
                   "Additional Information:" & vbNewLine &
                   ex.Message & vbNewLine & vbNewLine &
                   ex.StackTrace, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error")
            End Try

            Return False
        End Function

        Public Shared Function GetStaff(ByVal Username As String, ByVal Password As String)
            Dim R As Staff = Nothing

            Dim Connection = GetConnection()
            If Connection.State = ConnectionState.Closed Then Connection.Open()

            Dim CommandText As String = "SELECT * FROM Staffs WHERE [Username]=@Username AND [Password]=@Password;"

            Using Command As New SqlCommand(CommandText, Connection)
                Command.Parameters.AddWithValue("@Username", Username)
                Command.Parameters.AddWithValue("@Password", Password)
                Using Reader As SqlDataReader = Command.ExecuteReader
                    If Reader.Read Then
                        R = Read(Reader)
                    End If
                End Using
            End Using

            Return R
        End Function

        Private Shared Function Read(ByVal Reader As SqlDataReader) As Staff
            Dim ID As Integer = Reader.Item("ID")
            Dim Username As String = Reader.Item("Username")
            Dim Password As String = Reader.Item("Password")
            Dim Info_ As String = Reader.Item("Info").ToString
            Dim Info As StaffInfo = Nothing
            If Info_ IsNot Nothing AndAlso Info_ <> "" Then
                Info = Serializer.FromXML(Of StaffInfo)(Info_)
            End If

            Return New Staff(ID, Username, Password, Info)
        End Function

    End Class
End Namespace