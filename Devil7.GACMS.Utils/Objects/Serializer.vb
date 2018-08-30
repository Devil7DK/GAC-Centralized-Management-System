'==========================================================================
'
'                   (C) Copyright 2018 Devil7 Softwares.
' 
'      This file is part of 'Devil7 - College Management System' designed
' for Government Arts College (Autonomous), Coimbatore, Tamilnadu, India.
'
'      Licensed under the Apache License, Version 2.0 (the "License");
' you may Not use this file except in compliance with the License. You
' may obtain a copy of the License at
' 
'           http://www.apache.org/licenses/LICENSE-2.0
' 
'      Unless required by applicable law Or agreed to in writing, software
' distributed under the License Is distributed on an "AS IS" BASIS,
' WITHOUT WARRANTIES Or CONDITIONS OF ANY KIND, either express Or implied.
' See the License for the specific language governing permissions And
' limitations under the License.
' 
' Contributors:
'     Dineshkumar T
'==========================================================================

Imports System.Xml.Serialization

Namespace Objects
    Public Class Serializer

        Public Shared Function ToXML(Of T)(ByVal Obj As T) As String
            Dim X As New XmlSerializer(GetType(T))
            Using MS As New IO.MemoryStream
                X.Serialize(MS, Obj)
                Return Text.Encoding.ASCII.GetString(MS.ToArray)
            End Using
        End Function

        Public Sub ToFile(Of T)(ByVal Obj As T, ByVal Filename As String)
            My.Computer.FileSystem.WriteAllText(Filename, ToXML(Obj), False)
        End Sub

        Public Function FromXML(Of T)(ByVal XML As String) As T
            Dim X As New XmlSerializer(GetType(T))
            Using MS As New IO.MemoryStream(Text.Encoding.ASCII.GetBytes(XML))
                Return X.Deserialize(MS)
            End Using
        End Function

        Public Function FromFile(Of T)(ByVal Filename As String) As T
            Return FromXML(Of T)(My.Computer.FileSystem.ReadAllText(Filename))
        End Function

    End Class
End Namespace