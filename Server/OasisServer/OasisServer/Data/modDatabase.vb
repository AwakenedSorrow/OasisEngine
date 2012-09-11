Imports System.Xml
Imports System.IO.File

Module modDatabase

    Public Function FileExists(ByVal Filename As String) As Boolean
        Dim ReturnVal As Boolean

        On Error GoTo errorhandler

        ' It's so much easier to do this in .NET, holy crap man!
        ' Really, one line to do what takes several in VB6. I quite like this.
        If FileIO.FileSystem.FileExists(App_Path() + Filename) = True Then ReturnVal = True
        Return ReturnVal

        ' Error Handler
        Exit Function
errorhandler:
        HandleError("modDatabase, Function FileExists()", Err.Number.ToString, Err.Description)
        Exit Function
    End Function

    Public Sub LoadOptions(Optional ByVal Filename As String = CONFIG_FILE)
        Dim Reader As XmlTextReader, TempVal As String

        ' Check if the Config File exists, if it doesn't.. Well, we'll just use the default settings.
        AddText("Looking for '" + App_Path() + Filename.Trim + "'..")
        If FileExists(Filename) Then
            AddText("File Exists! Loading Config Data..")

            ' Open the Text Reader
            Reader = New XmlTextReader(App_Path() + Filename)

            'Disable whitespace so that we don't have to read over whitespaces
            Reader.WhitespaceHandling = WhitespaceHandling.None

            ' Read past the stuff we're not using to actually retrieve data from.
            ' I know there's more efficient and dynamic ways to load data from an XML file.
            ' But frankly, I don't care. I only need a linear list of data anyhow.
            Reader.Read()
            Reader.Read()
            Reader.Read()

            ' Read all the settings.
            Options.GameName = Reader.ReadElementString("gamename")
            Options.IP = Reader.ReadElementString("bindip")
            Options.Port = Val(Reader.ReadElementString("bindport"))
            Options.MaxConn = Val(Reader.ReadElementString("maxconn"))
            TempVal = Reader.ReadElementString("log")
            If TempVal.ToLower = "true" Then Options.Logging = True
            TempVal = Reader.ReadElementString("lock")
            If TempVal.ToLower = "true" Then Options.Lock = True

            ' Close the Reader.
            Reader.Close()
        Else
            AddText("File Doesn't Exist! Applying Default Config Data..")
            ' Set the Default Values.
            Options.GameName = "Oasis Server"
            Options.IP = "0.0.0.0"
            Options.Port = "4000"
            Options.MaxConn = "32"
            Options.Logging = True
            Options.Lock = False
        End If
        AddText("Config Loaded!")
    End Sub

    Public Function App_Path() As String
        Return System.AppDomain.CurrentDomain.BaseDirectory()
    End Function
End Module
