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

Imports Devil7.GACMS.Utils.Modules
Imports System.Data.SqlClient

Public Module Connection

    Dim ServerSettings As Settings
    Dim Connection As SqlConnection

    Public Function GetConnection() As SqlConnection
        If Connection Is Nothing Then
            Connection = CreateConnection()
        End If
        Return Connection
    End Function

    Private Function CreateConnection() As SqlConnection
        If ServerSettings Is Nothing Then
            ServerSettings = Settings.GetSettings
        End If
        Return New SqlConnection(String.Format("Server={0};Database={1};User Id={2};Password={3};Pooling={5}",
                                               ServerSettings.ServerName, ServerSettings.DatabaseName, ServerSettings.UserName, Encryption.Decrypt(ServerSettings.Password), ServerSettings.Pooling))
    End Function

End Module
