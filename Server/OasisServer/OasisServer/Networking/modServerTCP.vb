Imports System.Net.Sockets

Module modServerTCP

    Public Sub MainTCP()
        ' The player ID counter.
        Dim TempSlot As Integer
        ' The following determines if we still need to loop this.
        Dim isRunning As Boolean
        ' Our core listener, we'll be getting clients on this before we hand them over to our actual system. Our entry point so to speak.
        Dim CoreSocket As New TcpListener(System.Net.IPAddress.Parse(Options.IP), Options.Port)
        ' The actual client handler(s).
        Dim ClientSocket As TcpClient

        ' Redim the Player() array.
        AddText("Assigning Connection Settings..")
        ReDim Player(Options.MaxConn)

        ' Launch the core socket so we can start listening!
        AddText("Launching Core Socket..")
        CoreSocket.Start()

        Do While isRunning
            If CoreSocket.Pending Then
                ' Accept our client into a temporary slot.
                ClientSocket = CoreSocket.AcceptTcpClient

                ' See if we have any open slots.. If we do not, kick them and notify them.
                TempSlot = GetOpenSlot()
                If TempSlot <> -1 Then
                    ClientHandler.startClient(ClientSocket, TempSlot)
                Else
                    AddText("Refused connection from " + CoreSocket.Server.RemoteEndPoint.AddressFamily.ToString + ", the server is currently full.")
                    ClientSocket.Close()
                End If

            End If
        Loop
    End Sub

    Private Function GetOpenSlot() As Integer
        Dim i As Integer

        ' If we can find an empty slot, use it!
        For i = 1 To Options.MaxConn
            If Player(i).ConnectionID = 0 Then Return i
        Next

        ' No empty slots, let's return a -1.
        Return -1
    End Function

End Module
