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

Imports Devil7.GACMS.Utils.Enums
Imports System.ComponentModel
Imports System.Xml.Serialization

Namespace Objects

    <XmlRoot("Staff"), Serializable>
    Public Class Staff

        <DisplayName("ID"), Browsable(False)>
        Property ID As Integer
        <DisplayName("Username")>
        Property UserName As String
        <DisplayName("Password"), Browsable(False)>
        Property Password As String
        <DisplayName("Additional Information")>
        Property Info As New StaffInfo

        Sub New()
            Me.Info.Gender = Enums.Gender.Male
            Me.Info.PermanentAddress = New Address
            Me.Info.ResidentalAddress = New Address
            Me.Info.Photo = My.Resources.staff_128x128
        End Sub

        Sub New(ID As Integer, UserName As String, Password As String, FirstName As String, LastName As String,
                FatherOrHusbandName As String, Department As String, Designation As String, AdditionalRoles As String,
                Qualification As String, StaffID As String, DateOfJoining As Date, DateOfBirth As Date, Gender As Enums.Gender,
                PermanentAddress As Address, ResidentalAddress As Address, Mobile As String, BloodGroup As BloodGroup,
                MaritalStatus As MaritalStatus, Religion As Religion, Community As Community, Photo As Drawing.Bitmap)
            Me.ID = ID
            Me.UserName = UserName
            Me.Password = Password
            Me.Info.FirstName = FirstName
            Me.Info.LastName = LastName
            Me.Info.FatherOrHusbandName = FatherOrHusbandName
            Me.Info.Department = Department
            Me.Info.Designation = Designation
            Me.Info.AdditionalRoles = AdditionalRoles
            Me.Info.Qualification = Qualification
            Me.Info.StaffID = StaffID
            Me.Info.DateOfJoining = DateOfJoining
            Me.Info.DateOfBirth = DateOfBirth
            Me.Info.Gender = Gender
            Me.Info.PermanentAddress = If(PermanentAddress Is Nothing, New Address, PermanentAddress)
            Me.Info.ResidentalAddress = If(ResidentalAddress Is Nothing, New Address, ResidentalAddress)
            Me.Info.Mobile = Mobile
            Me.Info.BloodGroup = BloodGroup
            Me.Info.MaritalStatus = MaritalStatus
            Me.Info.Religion = Religion
            Me.Info.Community = Community
            If Photo Is Nothing Then
                Me.Info.Photo = My.Resources.staff_128x128
            Else
                Me.Info.Photo = Photo
            End If
        End Sub

        Sub New(ID As Integer, UserName As String, Password As String, Info As StaffInfo)
            Me.ID = ID
            Me.UserName = UserName
            Me.Password = Password
            Me.Info = Info
        End Sub

    End Class

End Namespace
