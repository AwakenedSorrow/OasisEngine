Module modGlobals
    ' Server Threads
    Public SLoop As Threading.Thread = New Threading.Thread(AddressOf ServerLoop) ' Main Server Thread
    Public MainTCPThread As Threading.Thread = New Threading.Thread(AddressOf MainTCP) ' Main TCP Thread

    ' General Server Information
    Public WINDOW_TITLE As String

End Module
