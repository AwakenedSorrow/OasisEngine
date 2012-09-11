Module modServerLoop

    Public Sub ServerLoop()
        ' We just entered this sub.
        ' Should probably set the loop to actually be ON.
        IsRunning = True

        ' Main Server Loop
        Do While IsRunning

        Loop

        ' Close the Server Loop Thread
        SLoop.Abort()
    End Sub

End Module
