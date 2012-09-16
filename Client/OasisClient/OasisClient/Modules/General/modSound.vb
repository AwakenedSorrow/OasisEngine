Imports Microsoft.DirectX.AudioVideoPlayback

Module modSound
    Public Sub PlayMusic(ByVal filename As String)
        'If Not Options.Music = 1 Or Not FileExist(Application.StartupPath & MUSIC_PATH & filename) Then Exit Sub
        If MusicPlayer Is Nothing Then
            MusicPlayer = New Audio(Application.StartupPath & MUSIC_PATH & filename, True)
        Else
            MusicPlayer.Dispose()
            MusicPlayer = Nothing
            MusicPlayer = New Audio(Application.StartupPath & MUSIC_PATH & filename, True)
        End If
    End Sub

    Public Sub StopMusic()
        If MusicPlayer Is Nothing Then Exit Sub
        MusicPlayer.Dispose()
        MusicPlayer = Nothing
    End Sub

    Public Sub PlaySound(ByVal filename As String)
        'If Not Options.Sound = 1 Or Not FileExist(Application.StartupPath & SOUND_PATH & filename) Then Exit Sub
        If SoundPlayer Is Nothing Then
            SoundPlayer = New Audio(Application.StartupPath & SOUND_PATH & filename, True)
        Else
            SoundPlayer.Dispose()
            SoundPlayer = Nothing
            SoundPlayer = New Audio(Application.StartupPath & SOUND_PATH & filename, True)
        End If
    End Sub

    Public Sub StopSound()
        If SoundPlayer Is Nothing Then Exit Sub
        SoundPlayer.Dispose()
        SoundPlayer = Nothing
    End Sub
End Module
