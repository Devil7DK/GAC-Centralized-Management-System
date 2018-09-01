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

Namespace Modules
    Public Class SettingsManager

        Private Shared ConfigFilePath As String = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Devil7 Softwares", "GACMS", "Settings.config")
        Private Shared Settings_ As Objects.Settings

        Shared ReadOnly Property Settings As Objects.Settings
            Get
                If Settings_ Is Nothing Then
                    LoadSettings()
                End If
                Return Settings_
            End Get
        End Property

        Shared Sub SaveSettings()
            Objects.Serializer.ToFile(Settings, ConfigFilePath)
        End Sub

        Shared Sub LoadSettings()
            Settings_ = Objects.Serializer.FromFile(Of Objects.Settings)(ConfigFilePath)
        End Sub

    End Class
End Namespace