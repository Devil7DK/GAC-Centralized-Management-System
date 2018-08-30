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

    Protected Overrides Sub OnStart(ByVal args As String())
        If m_svcHost IsNot Nothing Then m_svcHost.Close()

        Dim strAdrHTTP As String = "http://localhost:9001/DatabaseService"

        Dim adrbase As Uri() = {New Uri(strAdrHTTP)}
        m_svcHost = New ServiceHost(GetType(IDatabaseService), adrbase)
        Dim mBehave As ServiceMetadataBehavior = New ServiceMetadataBehavior()
        m_svcHost.Description.Behaviors.Add(mBehave)

        Dim httpb As WSHttpBinding = New WSHttpBinding()
        m_svcHost.AddServiceEndpoint(GetType(IDatabaseService), httpb, strAdrHTTP)
        m_svcHost.AddServiceEndpoint(GetType(IMetadataExchange), MetadataExchangeBindings.CreateMexHttpBinding(), "mex")

        m_svcHost.Open()
    End Sub

    Protected Overrides Sub OnStop()
        If m_svcHost IsNot Nothing Then
            m_svcHost.Close()
            m_svcHost = Nothing
        End If
    End Sub

End Class
