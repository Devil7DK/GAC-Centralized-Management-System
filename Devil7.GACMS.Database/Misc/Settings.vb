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

Imports Devil7.GACMS.Utils
Imports System.Reflection

Public Class Settings

    Private Shared ConfigFilePath As String = IO.Path.Combine(My.Computer.FileSystem.GetFileInfo((New System.Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath).Directory.FullName, "DatabseServer.config")

    Public Shared Function GetSettings() As Settings
        On Error Resume Next
        Dim R As New Settings
        If My.Computer.FileSystem.FileExists(ConfigFilePath) Then
            R = Objects.Serializer.FromFile(Of Settings)(ConfigFilePath)
            CheckPassword(R)
        Else
            Objects.Serializer.ToFile(New Settings, ConfigFilePath)
        End If
        Return R
    End Function

    Private Shared Sub CheckPassword(ByVal Settings As Settings)
        If Settings.Password = Modules.Encryption.Decrypt(Settings.Password) Then
            Settings.Password = Modules.Encryption.Encrypt(Settings.Password)
            Objects.Serializer.ToFile(Settings, ConfigFilePath)
        End If
    End Sub

    Property DatabaseName As String = "GACMS"
    Property ServerName As String = "LOCALHOST"
    Property Password As String = "admin"
    Property UserName As String = "admin"
    Property Pooling As Boolean = False

End Class
