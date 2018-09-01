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
Imports System.Reflection
Imports System.Security.Cryptography.X509Certificates

Namespace Modules
    Public Class Certificate

        Private Shared CertificatePath As String = IO.Path.Combine(My.Computer.FileSystem.GetFileInfo((New System.Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath.Replace("%20", " ")).Directory.FullName, "ServerCertificate.cer")

        Public Shared Sub BindCertificateToPort(ByVal Port As Integer)
            Dim certificate As X509Certificate2 = New X509Certificate2(CertificatePath)
            Dim bindPortToCertificate As Process = New Process()
            bindPortToCertificate.StartInfo.FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.SystemX86), "netsh.exe")
            bindPortToCertificate.StartInfo.Arguments = String.Format("http add sslcert ipport=0.0.0.0:{0} certhash={1} appid={{{2}}}", Port, certificate.Thumbprint, Guid.NewGuid())
            bindPortToCertificate.Start()
            bindPortToCertificate.WaitForExit()
        End Sub

        Public Shared Sub RemoveBinding()
            Dim cert As X509Certificate2 = New X509Certificate2(CertificatePath)
            Dim store As X509Store = New X509Store(StoreName.My, StoreLocation.LocalMachine)
            store.Open(OpenFlags.ReadWrite)
            store.Remove(cert)
            store.Close()
        End Sub

    End Class
End Namespace