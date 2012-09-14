Module modStructs

    Public Options As New OptionsStruct
    Public Player() As PlayerStruct

    Structure OptionsStruct
        ' Game Options
        Dim GameName As String

        ' Server Options
        Dim IP As String
        Dim Port As Integer
        Dim MaxConn As Integer

        ' Debug
        Dim Logging As Boolean
        Dim Lock As Boolean
    End Structure

    Structure PlayerStruct
        ' Connection Data
        Dim ConnectionID As Integer
    End Structure

End Module
