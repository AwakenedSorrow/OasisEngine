
Module modSound

    Public Sub InitSound()
        
    End Sub

    Public Sub CloseSound()

        If Not MusicStream Is Nothing Then
            MusicStream.Stop()
            MusicStream = Nothing
        End If

        If Not SoundStream Is Nothing Then
            SoundStream.Stop()
            SoundStream = Nothing
        End If

    End Sub

    Public Sub PlayMusic(ByVal filename As String)

        If Not Options.MusicOn = True Or Not FileExists(MUSIC_PATH & filename) Then Exit Sub

        If MusicFile = App_Path() & MUSIC_PATH & filename Then
            Exit Sub
        Else
            MusicFile = App_Path() & MUSIC_PATH & filename
        End If

        If MusicStream Is Nothing Then
            MusicStream = New AudioFile(MusicFile)
            MusicStream.Play()
        Else
            MusicStream.Stop()
            MusicStream = New AudioFile(MusicFile)
            MusicStream.Play()
        End If

    End Sub

    Public Sub StopMusic()
        If MusicStream Is Nothing Then Exit Sub

        MusicStream.Stop()
        MusicStream = Nothing
    End Sub

    Public Sub PlaySound(ByVal filename As String)
        If Not Options.SoundOn = True Or Not FileExists(SOUND_PATH & filename) Then Exit Sub
        
        If SoundFile = App_Path() & SOUND_PATH & filename Then
            Exit Sub
        Else
            SoundFile = App_Path() & SOUND_PATH & filename
        End If

        If SoundStream Is Nothing Then
            SoundStream = New AudioFile(SoundFile)
            SoundStream.Play()
        Else
            SoundStream.Stop()
            SoundStream = New AudioFile(SoundFile)
            SoundStream.Play()
        End If

    End Sub

    Public Sub StopSound()
        If SoundStream Is Nothing Then Exit Sub

        SoundStream.Stop()
        SoundStream = Nothing
    End Sub
End Module
