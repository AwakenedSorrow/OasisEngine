Imports System.Net.Sockets

Public Class clsHandleClient
    Dim clientSocket As TcpClient
    Dim clientNumber As String

    Public Sub startClient(ByVal inClientSocket As TcpClient, ByVal CNumber As String)
        ' Set up the values we'll be using for this instance of the thread.
        Me.clientSocket = inClientSocket
        Me.clientNumber = CNumber

        ' Notify the console we accepted someone.
        AddText("Accepted a client under: " + CNumber)
        AddText("Starting a new thread for client: " + CNumber)

        ' Add the CNumber to the player array so we don't use this ID again until he/she disconnects.
        ' May seem a little nonsensical. But whatever.
        Player(Convert.ToInt32(CNumber)).ConnectionID = Convert.ToInt32(CNumber)

        ' Start the new thread!
        Dim ctThread As Threading.Thread = New Threading.Thread(AddressOf DoClientLogic)
        ctThread.Start()
    End Sub

    Public Sub DoClientLogic()

        Do While (True)

        Loop

    End Sub

End Class