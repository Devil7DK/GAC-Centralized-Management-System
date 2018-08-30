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

    <XmlRoot("Staff"), Serializable>
    Public Class Staff

        <DisplayName("ID"), Browsable(False)>
        Property ID As Integer
        <DisplayName("Username")>
        Property UserName As String
        <DisplayName("Password"), Browsable(False)>
        Property Password As String
        <DisplayName("First Name")>
        Property FirstName As String
        <DisplayName("Last Name")>
        Property LastName As String
        <DisplayName("Father/Husband Name")>
        Property FatherOrHusbandName As String
        <DisplayName("Department")>
        Property Department As String
        <DisplayName("Designation")>
        Property Designation As String
        <DisplayName("Additional Roles")>
        Property AdditionalRoles As String
        <DisplayName("Qualification")>
        Property Qualification As String
        <DisplayName("Staff ID")>
        Property StaffID As String
        <DisplayName("Date Of Joining")>
        Property DateOfJoining As Date
        <DisplayName("Date Of Birth")>
        Property DateOfBirth As Date
        <DisplayName("Gender")>
        Property Gender As Enums.Gender
        <DisplayName("Permanent Address")>
        Property PermanentAddress As Address
        <DisplayName("Residental Address")>
        Property ResidentalAddress As Address
        <DisplayName("Mobile Number")>
        Property Mobile As String
        <DisplayName("Blood Group")>
        Property BloodGroup As String
        <DisplayName("Marital Status")>
        Property MaritalStatus As String
        <DisplayName("Religion")>
        Property Religion As String
        <DisplayName("Community")>
        Property Community As String

        Private m_Image As Drawing.Bitmap
        <Xml.Serialization.XmlIgnore()>
        Property Photo() As Drawing.Bitmap
            Get
                Return m_Image
            End Get
            Set(ByVal value As Drawing.Bitmap)
                m_Image = value
            End Set
        End Property

        <XmlElement("pImage"), Browsable(False)>
        Public Property PhotoByteArray() As Byte()
            Get
                If Not m_Image Is Nothing Then
                    Dim bitmapConverter As System.ComponentModel.TypeConverter = System.ComponentModel.TypeDescriptor.GetConverter(m_Image.GetType)
                    Return CType(bitmapConverter.ConvertTo(m_Image, GetType(Byte())), Byte())
                Else
                    Return Nothing
                End If
            End Get
            Set(ByVal value As Byte())

                If Not value Is Nothing Then
                    m_Image = New Drawing.Bitmap(New System.IO.MemoryStream(value))
                Else
                    m_Image = Nothing
                End If

            End Set
        End Property

        Sub New()
            Me.Gender = Enums.Gender.Male
            Me.PermanentAddress = New Address
            Me.ResidentalAddress = New Address
            Me.m_Image = My.Resources.staff_128x128
        End Sub

        Sub New(ID As Integer, UserName As String, Password As String, FirstName As String, LastName As String,
                FatherOrHusbandName As String, Department As String, Designation As String, AdditionalRoles As String,
                Qualification As String, StaffID As String, DateOfJoining As Date, DateOfBirth As Date, Gender As Enums.Gender,
                PermanentAddress As Address, ResidentalAddress As Address, Mobile As String, BloodGroup As String,
                MaritalStatus As String, Religion As String, Community As String, Photo As Drawing.Bitmap)
            Me.ID = ID
            Me.UserName = UserName
            Me.Password = Password
            Me.FirstName = FirstName
            Me.LastName = LastName
            Me.FatherOrHusbandName = FatherOrHusbandName
            Me.Department = Department
            Me.Designation = Designation
            Me.AdditionalRoles = AdditionalRoles
            Me.Qualification = Qualification
            Me.StaffID = StaffID
            Me.DateOfJoining = DateOfJoining
            Me.DateOfBirth = DateOfBirth
            Me.Gender = Gender
            Me.PermanentAddress = If(PermanentAddress Is Nothing, New Address, PermanentAddress)
            Me.ResidentalAddress = If(ResidentalAddress Is Nothing, New Address, ResidentalAddress)
            Me.Mobile = Mobile
            Me.BloodGroup = BloodGroup
            Me.MaritalStatus = MaritalStatus
            Me.Religion = Religion
            Me.Community = Community
            Me.Photo = Photo
        End Sub

    End Class

End Namespace
