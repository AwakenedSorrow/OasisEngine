Imports System.Net.Sockets

Module modServerTCP

    Public Sub MainTCP()
        ' The following determines if we still need to loop this.
        Dim isRunning As Boolean
        ' Our core listener, we'll be getting clients on this before we hand them over to our actual system. Our entry point so to speak.
        Dim CoreSocket As New TcpListener(System.Net.IPAddress.Parse(Options.IP), Options.Port)
        ' The actual client handler(s).
        Dim ClientSocket(Options.MaxConn) As TcpClient

        ' Redim the Player() array.
        AddText("Assigning Connection Settings..")
        ReDim Player(Options.MaxConn)

        ' Launch the core socket so we can start listening!
        AddText("Launching Core Socket..")
        CoreSocket.Start()

        Do While isRunning

        Loop

    End Sub

End Module
