Public Class AudioFile

    ' This class is a wrapper for the Windows API calls to play wave, midi or mp3 files. 

    ' Windows API Declarations 
    Private Declare Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" (ByVal lpstrCommand As String, ByVal lpstrReturnString As String, ByVal uReturnLength As Int32, ByVal hwndCallback As Int32) As Int32

    'Constructor:  Location is the filename of the media to play.  Wave files and Mp3 files are the supported formats. 

    Public Sub New(ByVal location As String)
        Me.Filename = location
    End Sub

    'Plays the file that is specified as the filename. 
    Public Sub Play()

        If _filename = "" Or Filename.Length <= 4 Then Exit Sub

        Select Case Right(Filename, 3).ToLower
            Case "mp3"
                mciSendString("open """ & _filename & """ type mpegvideo alias audiofile", Nothing, 0, IntPtr.Zero)
                mciSendString("play audiofile from 0 repeat", Nothing, 0, IntPtr.Zero)

            Case "wav"
                mciSendString("open """ & _filename & """ type waveaudio alias audiofile", Nothing, 0, IntPtr.Zero)
                mciSendString("play audiofile from 0 repeat", Nothing, 0, IntPtr.Zero)

            Case "mid", "idi"
                mciSendString("stop midi", "", 0, 0)
                mciSendString("close midi", "", 0, 0)
                mciSendString("open sequencer!" & _filename & " alias midi repeat", "", 0, 0)
                mciSendString("play midi", "", 0, 0)

            Case Else
                Throw New Exception("File type not supported.")
                Call Close()
        End Select

        IsPaused = False

    End Sub

    'Pause the current play back. 
    Public Sub Pause()
        mciSendString("pause audiofile", Nothing, 0, IntPtr.Zero)
        IsPaused = True
    End Sub

    'Resume the current play back if it is currently paused. 
    Public Sub [Resume]()
        mciSendString("resume audiofile", Nothing, 0, IntPtr.Zero)
        IsPaused = False
    End Sub

    'Stop the current file if it's playing. 
    Public Sub [Stop]()
        mciSendString("stop audiofile", Nothing, 0, IntPtr.Zero)
    End Sub

    'Close the file. 
    Public Sub Close()
        mciSendString("close audiofile", Nothing, 0, IntPtr.Zero)
    End Sub

    'Sets the audio file's time format via the mciSendString API. 
    ReadOnly Property Milleseconds() As Integer
        Get
            Dim buf As String = Space(255)
            mciSendString("set audiofile time format milliseconds", Nothing, 0, IntPtr.Zero)
            mciSendString("status audiofile length", buf, 255, IntPtr.Zero)

            buf = Replace(buf, Chr(0), "") ' Get rid of the nulls, they fuck things up 

            If buf = "" Then
                Return 0
            Else
                Return CInt(buf)
            End If
        End Get
    End Property

    'Gets the status of the current playback file via the mciSendString API. 
    ReadOnly Property Status() As String
        Get
            Dim buf As String = Space(255)
            mciSendString("status audiofile mode", buf, 255, IntPtr.Zero)
            buf = Replace(buf, Chr(0), "")  ' Get rid of the nulls, they fuck things up 
            Return buf
        End Get
    End Property

    'Gets the file size of the current audio file. 
    ReadOnly Property FileSize() As Integer
        Get
            Try
                Return My.Computer.FileSystem.GetFileInfo(_filename).Length
            Catch ex As Exception
                Return 0
            End Try
        End Get
    End Property

    'Gets the channels of the file via the mciSendString API. 
    ReadOnly Property Channels() As Integer
        Get
            Dim buf As String = Space(255)
            mciSendString("status audiofile channels", buf, 255, IntPtr.Zero)

            If IsNumeric(buf) = True Then
                Return CInt(buf)
            Else
                Return -1
            End If
        End Get
    End Property

    'Used for debugging purposes. 
    ReadOnly Property Debug() As String
        Get
            Dim buf As String = Space(255)
            mciSendString("status audiofile channels", buf, 255, IntPtr.Zero)

            Return Str(buf)
        End Get
    End Property

    Private _isPaused As Boolean = False
    'Whether or not the current playback is paused. 
    Public Property IsPaused() As Boolean
        Get
            Return _isPaused
        End Get
        Set(ByVal value As Boolean)
            _isPaused = value
        End Set
    End Property

    Private _filename As String
    'The current filename of the file that is to be played back. 
    Public Property Filename() As String
        Get
            Return _filename
        End Get
        Set(ByVal value As String)

            If My.Computer.FileSystem.FileExists(value) = False Then
                Throw New System.IO.FileNotFoundException
                Exit Property
            End If

            _filename = value
        End Set
    End Property

End Class
