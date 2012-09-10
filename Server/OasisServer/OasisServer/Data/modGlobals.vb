Module modGlobals
    ' ***
    ' Server Threads
    ' ***
    Public SLoop As Threading.Thread = New Threading.Thread(AddressOf ServerLoop) ' Main Server Thread

    ' ***
    ' General Server Information
    ' ***
    Public IsRunning As Boolean = False
End Module
