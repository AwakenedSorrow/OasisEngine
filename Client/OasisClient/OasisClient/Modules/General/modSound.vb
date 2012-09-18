Imports SdlDotNet.Audio

Module modSound

    Public Sub InitSound()
        
    End Sub

    Public Sub CloseSound()
        If MusicStream Is Nothing Then Exit Sub

        If MusicStream.ToString <> Nothing Then
            MusicStream.Dispose()
        End If

        If SoundStream.ToString <> Nothing Then
            SoundStream.Dispose()
        End If

        MusicStream.Close()
        SoundStream.Close()
    End Sub

    Public Sub PlayMusic(ByVal filename As String)
        If Not Options.MusicOn = True Or Not FileExists(MUSIC_PATH & filename) Then Exit Sub

        If MusicStream.ToString = App_Path() & MUSIC_PATH & filename Then Exit Sub

        If MusicStream.ToString = Nothing Then
            MusicStream = New Music(App_Path() & MUSIC_PATH & filename)
            MusicStream.FadeIn(100, 500)
        Else
            MusicStream = New Music(App_Path() & MUSIC_PATH & filename)
            MusicStream.FadeIn(100, 500)
        End If
    End Sub

    Public Sub StopMusic()
        If MusicStream.ToString = Nothing Then Exit Sub

        If MusicStream.ToString <> Nothing Then
            MusicStream.Dispose()
        End If
    End Sub

    Public Sub PlaySound(ByVal filename As String)
        If Not Options.SoundOn = True Or Not FileExists(SOUND_PATH & filename) Then Exit Sub
        
        If SoundStream.ToString = Nothing Then
            SoundStream = New Music(App_Path() & SOUND_PATH & filename)
            SoundStream.Play()
        Else
            SoundStream = New Music(App_Path() & SOUND_PATH & filename)
            SoundStream.Play()
        End If
    End Sub

    Public Sub StopSound()
        If SoundStream.ToString = Nothing Then Exit Sub

        If SoundStream.ToString <> Nothing Then
            SoundStream.Dispose()
        End If
    End Sub
End Module
