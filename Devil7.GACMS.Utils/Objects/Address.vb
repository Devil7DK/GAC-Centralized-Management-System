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

Imports System.ComponentModel
Imports System.Xml.Serialization

Namespace Objects

    <XmlRoot("Address")>
    Public Class Address

        <DisplayName("Address Line 1")>
        Property AddressLine1 As String
        <DisplayName("Address Line 2")>
        Property AddressLine2 As String
        <DisplayName("City")>
        Property City As String
        <DisplayName("PIN Code")>
        Property PINCode As String
        <DisplayName("State")>
        Property State As String

        Sub New()
            Me.AddressLine1 = ""
            Me.AddressLine2 = ""
            Me.City = ""
            Me.PINCode = ""
            Me.State = ""
        End Sub

        Sub New(AddressLine1 As String, AddressLine2 As String, City As String, PINCode As String, State As String)
            Me.AddressLine1 = AddressLine1
            Me.AddressLine2 = AddressLine2
            Me.City = City
            Me.PINCode = PINCode
            Me.State = State
        End Sub

    End Class

End Namespace