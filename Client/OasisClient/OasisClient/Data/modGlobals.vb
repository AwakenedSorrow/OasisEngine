Imports System.Net.Sockets

Module modGlobals
    'Music + Sound Players
    Public SoundStream As AudioFile
    Public SoundFile As String

    Public MusicStream As AudioFile
    Public MusicFile As String

    'Network
    Public clientSocket As New System.Net.Sockets.TcpClient()
    Public serverStream As NetworkStream
End Module
