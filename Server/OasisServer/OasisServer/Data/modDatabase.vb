﻿Imports System.Xml
Imports System.IO.File

Module modDatabase

    Public Function FileExists(ByVal Filename As String) As Boolean
        Dim ReturnVal As Boolean

        On Error GoTo errorhandler

        ' It's so much easier to do this in .NET, holy crap man!
        ' Really, one line to do what takes several in VB6. I quite like this.
        If FileIO.FileSystem.FileExists(Filename) = True Then ReturnVal = True
        Return ReturnVal

        ' Error Handler
        Exit Function
errorhandler:
        HandleError("modDatabase, Function FileExists()", Err.Number.ToString, Err.Description)
        Exit Function
    End Function

    Public Sub LoadOptions(Optional ByVal Filename As String = CONFIG_file)

        ' Check if the Config File exists, if it doesn't.. Well, we'll just use the default settings.
        AddText(">> Looking for '" + Filename.Trim + "'..")
        If FileExists(Filename) Then
            AddText(">>>> File Exists! Loading Config Data..")
        Else
            AddText(">>>> File Doesn't Exist! Applying Default Config Data..")
            Options.GameName = "Oasis Server"
            Options.IP = "0.0.0.0"
            Options.Port = "4000"
            Options.MaxConn = "32"
        End If
        AddText(">> Config Loaded!")
    End Sub

End Module
