Module modGeneral

    Sub Main()
        On Error GoTo errorhandler
        ' Load Server Options.
        LoadOptions()
        Console.Title = Options.GameName + " | Bind IP: " + Options.IP + " | Bind Port: " + Str(Options.Port).Trim

        ' Done Initializing.
        ' We should probably start getting on with it now.
        Console.Write(">> Done Initializing.. Starting Server Loop Thread Now..")
        SLoop.Start()

        ' Error Handler
        Exit Sub
errorhandler:
        HandleError("modGeneral, Sub Main()", Err.Number.ToString, Err.Description)
        Exit Sub
    End Sub

    Public Sub HandleError(ByVal Loc As String, ByVal Number As String, ByVal Desc As String)
        AddText("An error has occured in " + Loc.Trim)
        AddText("Error #" + Number.Trim + " : " + Desc.Trim)
        AddText("The server will attempt to continue running.")
    End Sub

    Public Sub AddText(ByVal Text As String)
        ' No error handler here.
        ' Why you ask? Well, if this line bugs out the HandleError sub won't work either.
        Console.WriteLine(Text)
    End Sub

End Module
