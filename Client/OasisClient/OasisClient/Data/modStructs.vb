Module modStructs
    Public Options As New OptionsStruct
    Public Player() As PlayerStruct

    Structure OptionsStruct
        'log errors on/off
        Dim Logging As Boolean

        ' Sound Options
        Dim MusicOn As Boolean
        Dim SoundOn As Integer

    End Structure

    Structure PlayerStruct
        ' Connection Data
        'Dim ConnectionID As Integer
    End Structure
End Module
