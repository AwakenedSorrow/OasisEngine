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

        AddText("!!! --- !!!")
        AddText("An error has occured in " + Loc.Trim)
        AddText("Error #" + Number.Trim + " : " + Desc.Trim)
        AddText("The server will attempt to continue running.")
        AddText("!!! --- !!!")

        objWriter.WriteLine("---")
        objWriter.WriteLine("An error has occured in " + Loc.Trim)
        objWriter.WriteLine("Error #" + Number.Trim + " : " + Desc.Trim)
        objWriter.WriteLine("---")

        objWriter.Close()
    End Sub

    Public Sub AddText(ByVal Text As String)
        Console.WriteLine("[" + DateTime.Now.ToLongTimeString() + "]>> " + Text)
    End Sub

End Module
