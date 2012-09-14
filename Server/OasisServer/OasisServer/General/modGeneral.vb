Module modGeneral

    Sub Main()
        On Error GoTo errorhandler

        ' Set the Console Title to state we're loading the server.
        Console.Title = "Loading..."        
        AddText("Initializing Server..")

        ' Load Server Options.
        LoadOptions()

        ' We've loaded all these options, time to apply them to the WINDOW_TITLE variable.
        WINDOW_TITLE = Options.GameName + " | Bind IP: " + Options.IP + " | Bind Port: " + Str(Options.Port).Trim

        ' Set up the TCP stuff and get it all running.
        MainTCPThread.Start()

        ' Done Initializing.
        ' We should probably start getting on with it now.
        AddText("Done Initializing!")
        SLoop.Start()

        ' Error Handler
        Exit Sub
errorhandler:
        HandleError("modGeneral, Sub Main()", Err.Number.ToString, Err.Description)
        Exit Sub
    End Sub

    Public Sub HandleError(ByVal Loc As String, ByVal Number As String, ByVal Desc As String)
        Dim objWriter As New System.IO.StreamWriter(App_Path() + ERROR_LOG, True)

        AddText("!!! --- !!!", True)
        AddText("An error has occured in " + Loc.Trim, True)
        AddText("Error #" + Number.Trim + " : " + Desc.Trim, True)
        AddText("The server will attempt to continue running.", True)
        AddText("!!! --- !!!", True)

        If Options.Logging Then
            objWriter.WriteLine("---")
            objWriter.WriteLine("An error has occured in " + Loc.Trim)
            objWriter.WriteLine("Error #" + Number.Trim + " : " + Desc.Trim)
            objWriter.WriteLine("---")
        End If

        objWriter.Close()
    End Sub

    Public Sub AddText(ByVal Text As String, Optional ByVal Ignore As Boolean = False)

        ' Write the Console Line
        Console.WriteLine("[" + DateTime.Now.ToLongTimeString() + "] " + Text)

        ' If not an error message, write it to the serverlog.
        If Not Ignore And Options.Logging Then
            ' Open the writer.
            Dim objWriter As New System.IO.StreamWriter(App_Path() + SERVER_LOG, True)

            ' Write the data.
            objWriter.WriteLine("[" + DateTime.Now.ToString + "] " + Text)

            ' Close the writer again.
            objWriter.Close()
        End If
    End Sub

End Module
