Module modStructs

    Public Options As New OptionsStruct

    Public Structure OptionsStruct
        ' Game Options
        Dim GameName As String

        ' Server Options
        Dim IP As String
        Dim Port As Integer
        Dim MaxConn As Integer
    End Structure

End Module
