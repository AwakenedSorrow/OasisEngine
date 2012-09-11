Module modServerLoop

    ' halts thread of execution
    Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Integer)
    Private Declare Function GetTickCount Lib "kernel32" () As Integer

    Public Sub ServerLoop()
        Dim Tick As Integer, TickCPS As Integer, CPS As Integer, FrameTime As Integer, ElapsedTime As Integer
        Dim IsRunning As Boolean = False
        ' We just entered this sub.
        ' Should probably set the loop to actually be ON.
        IsRunning = True

        ' Notify the user we're entering the main loop.
        AddText("Starting Server Loop Thread Now..")

        ' Main Server Loop
        Do While IsRunning
            ' Starting section of the Cycles Per Second system (CPS)
            Tick = GetTickCount
            ElapsedTime = Tick - FrameTime
            FrameTime = Tick

            ' If we have it locked, sleep so we don't use a crapload of system resources.
            If Options.Lock Then Sleep(1)

            ' Calculate the CPS we're currently running at.
            If TickCPS < Tick Then
                ' Reset the Timer.
                TickCPS = GetTickCount + 1000

                ' Update the Console Title.
                Console.Title = WINDOW_TITLE + " | CPS: " + Format(CPS, "#,###,###,###")

                ' Reset the value
                CPS = 0
            Else
                ' Add to it! We're counting!
                CPS = CPS + 1
            End If
        Loop

        ' Close the Server Loop Thread
        SLoop.Abort()
    End Sub

End Module
