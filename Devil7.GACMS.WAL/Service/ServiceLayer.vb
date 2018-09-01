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

Imports System.ServiceModel.Description

Public Class ServiceLayer

    Private m_svcHost As ServiceHost = Nothing
    Private m_Port As Integer = 9001
    Private m_HttpsAddresses As String() = {
        "https://localhost:{0}/DatabaseService"
    }

    Private Function GetURIs() As Uri()
        Dim R As New List(Of Uri)
        For Each i As String In m_HttpsAddresses
            R.Add(New Uri(String.Format(i, m_Port)))
        Next
        Return R.ToArray
    End Function

    Protected Overrides Sub OnStart(ByVal args As String())

        Utils.Modules.Certificate.BindCertificateToPort(m_Port)

        If m_svcHost IsNot Nothing Then m_svcHost.Close()

        m_svcHost = New ServiceHost(GetType(DatabaseService), GetURIs)

        Dim mBehave_MetaData As ServiceMetadataBehavior = New ServiceMetadataBehavior()
        m_svcHost.Description.Behaviors.Add(mBehave_MetaData)

        Dim mBehave_Security As New Description.ServiceCredentials
        With mBehave_Security.UserNameAuthentication
            .UserNamePasswordValidationMode = Security.UserNamePasswordValidationMode.Custom
            .CustomUserNamePasswordValidator = New Authendication
        End With
        m_svcHost.Description.Behaviors.Add(mBehave_Security)

        Dim httpb As WSHttpBinding = New WSHttpBinding()
        httpb.Security.Mode = SecurityMode.TransportWithMessageCredential
        httpb.Security.Message.ClientCredentialType = MessageCredentialType.UserName
        httpb.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic

        For Each i As String In m_HttpsAddresses
            m_svcHost.AddServiceEndpoint(GetType(IDatabaseService), httpb, String.Format(i, m_Port))
        Next
        m_svcHost.AddServiceEndpoint(GetType(IMetadataExchange), MetadataExchangeBindings.CreateMexHttpsBinding(), "mex")

        m_svcHost.Open()
    End Sub

    Protected Overrides Sub OnStop()
        If m_svcHost IsNot Nothing Then
            m_svcHost.Close()
            m_svcHost = Nothing
        End If
        Utils.Modules.Certificate.RemoveBinding()
    End Sub

End Class
