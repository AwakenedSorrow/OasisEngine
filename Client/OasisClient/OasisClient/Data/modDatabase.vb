Imports System.Xml
Imports System.IO.File
Imports System.Text

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
        HandleError("modDatabase, Function " & GetFuncName(), Err.Number.ToString, Err.Description)
        Exit Function
    End Function

    Public Sub LoadOptions(Optional ByVal Filename As String = CONFIG_FILE)
        Dim Reader As XmlTextReader, TempVal As String

        On Error GoTo errorhandler

        ' Check if the Config File exists, if it doesn't.. Well, we'll just use the default settings.
        'AddText("Looking for '" + App_Path() + Filename.Trim + "'..")
        If FileExists(Filename) Then
            'AddText("File Exists! Loading Config Data..")

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
            Options.MusicOn = CBool(Reader.ReadElementString("MusicOn"))
            Options.SoundOn = CBool(Reader.ReadElementString("SoundOn"))

            ' Close the Reader.
            Reader.Close()
        Else
            'AddText("File Doesn't Exist! Applying Default Config Data..")
            ' Set the Default Values.
            Options.MusicOn = True
            Options.SoundOn = True


            'Save These Options
            SaveOptions()
        End If
        'AddText("Config Loaded!")

        ' Error Handler
        Exit Sub
errorhandler:
        HandleError("modDatabase, Function " & GetFuncName(), Err.Number.ToString, Err.Description)
        Exit Sub
    End Sub

    Public Sub SaveOptions(Optional ByVal Filename As String = CONFIG_FILE)
        Dim Writer As XmlTextWriter

        On Error GoTo errorhandler

        ' Open a Text Writer instance
        Writer = New XmlTextWriter(App_Path() + Filename, Encoding.UTF8)

        'start writing!
        Writer.WriteStartDocument()
        Writer.WriteStartElement("options")

        ' Write all the settings.
        Writer.WriteElementString("MusicOn", Options.MusicOn)
        Writer.WriteElementString("SoundOn", Options.SoundOn)

        'close everything
        Writer.WriteEndElement()
        Writer.WriteEndDocument()
        Writer.Close()

        ' Error Handler
        Exit Sub
errorhandler:
        HandleError("modDatabase, Function " & GetFuncName(), Err.Number.ToString, Err.Description)
        Exit Sub
    End Sub

    Public Function App_Path() As String
        Return System.AppDomain.CurrentDomain.BaseDirectory()
    End Function

    Public Function GetFuncName()
        Return New System.Diagnostics.StackFrame().GetMethod().Name
    End Function
End Module