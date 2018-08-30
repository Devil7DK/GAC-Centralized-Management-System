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

Imports Devil7.GACMS.Utils.Objects

<ServiceContract>
Public Interface IDatabaseService

    <OperationContract>
    Function GetStaff(ByVal Username As String, ByVal Password As String) As Staff

End Interface
