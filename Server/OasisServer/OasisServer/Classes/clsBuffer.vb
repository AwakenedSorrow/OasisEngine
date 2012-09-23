Imports System.Text

Public Class clsBuffer
    ' ********************
    ' ** Main Variables **
    ' ********************
    Private Buffer() As Byte
    Private BufferSize As Integer
    Private WriteHead As Integer
    Private ReadHead As Integer
    ' *****************
    ' ** Constructor **
    ' *****************
    Public Sub New()

        Flush()

    End Sub

    Public Sub PreAllocate(ByVal Length As Integer)

        WriteHead = 0
        ReadHead = 0
        BufferSize = Length - 1
        ReDim Buffer(0 To BufferSize)

    End Sub

    Public Sub Allocate(ByVal Length As Integer)

        If BufferSize = 0 And Length > 1 Then Length -= 1
        BufferSize += Length
        ReDim Preserve Buffer(0 To BufferSize)

    End Sub

    Public Sub Flush()

        ReDim Buffer(0)
        BufferSize = 0
        WriteHead = 0
        ReadHead = 0

    End Sub

    Public Sub Trim()

        If ReadHead >= Count() Then
            Flush()
        End If

    End Sub

    Public Sub WriteByte(ByVal nByte As Byte)

        If WriteHead >= BufferSize Then Allocate(1)
        Buffer(WriteHead) = nByte
        WriteHead += 1

    End Sub

    Public Sub WriteBytes(ByVal nBytes() As Byte)

        Dim nLength As Integer = nBytes.Length
        If WriteHead + nLength - 1 > BufferSize Then Allocate(nLength)

        For i As Integer = WriteHead To nLength - 1
            Buffer(i) = nBytes(i)
        Next

        WriteHead += nLength

    End Sub

    Public Sub WriteShort(ByVal nShort As Short)

        If WriteHead + 1 > BufferSize Then Allocate(2)

        BitConverter.GetBytes(nShort).CopyTo(Buffer, WriteHead)
        WriteHead += 2

    End Sub

    Public Sub WriteInteger(ByVal nInt As Integer)

        If WriteHead + 3 > BufferSize Then Allocate(4)

        BitConverter.GetBytes(nInt).CopyTo(Buffer, WriteHead)
        WriteHead += 4

    End Sub

    Public Sub WriteLong(ByVal nLong As Long)

        If WriteHead + 7 > BufferSize Then Allocate(8)

        BitConverter.GetBytes(nLong).CopyTo(Buffer, WriteHead)
        WriteHead += 8

    End Sub

    Public Sub WriteString(ByVal nString As String)

        WriteInteger(nString.Length)

        If WriteHead + nString.Length - 1 > BufferSize Then Allocate(nString.Length)

        Encoding.ASCII.GetBytes(nString).CopyTo(Buffer, WriteHead)
        WriteHead += nString.Length

    End Sub

    Public Function ReadByte(Optional ByVal MoveReadHead As Boolean = True) As Byte

        If ReadHead > BufferSize Then Return 0

        Dim val As Byte = Buffer(ReadHead)

        If MoveReadHead Then ReadHead += 1

        Return val

    End Function

    Public Function ReadBytes(ByVal nLength As Integer, Optional ByVal MoveReadHead As Boolean = True) As Byte()

        Dim Data() As Byte

        If nLength = 0 Then Return Nothing

        If ReadHead + nLength > BufferSize Then Return Nothing

        ReDim Data(nLength)

        For i As Integer = 0 To ReadHead + nLength - 1
            Data(i) = Buffer(i)
        Next

        If MoveReadHead Then ReadHead += nLength

        Return Data

    End Function

    Public Function ReadShort(Optional ByVal MoveReadHead As Boolean = True) As Short

        If ReadHead + 1 > BufferSize Then Return 0

        Dim val As Short = BitConverter.ToInt16(Buffer, ReadHead)

        If MoveReadHead Then ReadHead += 2

        Return val

    End Function

    Public Function ReadInteger(Optional ByVal MoveReadHead As Boolean = True) As Integer

        If ReadHead + 3 > BufferSize Then Return 0

        Dim val As Integer = BitConverter.ToInt32(Buffer, ReadHead)

        If MoveReadHead Then ReadHead += 4

        Return val

    End Function

    Public Function ReadLong(Optional ByVal MoveReadHead As Boolean = True) As Long

        If ReadHead + 7 > BufferSize Then Return 0

        Dim val As Long = BitConverter.ToInt64(Buffer, ReadHead)

        If MoveReadHead Then ReadHead += 8

        Return val

    End Function

    Public Function ReadString(Optional ByVal MoveReadHead As Boolean = True) As String

        Dim sLength As Integer = ReadInteger()

        If sLength <= 0 Then Return vbNullString

        Dim val As String = Encoding.ASCII.GetString(Buffer, ReadHead, sLength)

        If MoveReadHead Then ReadHead += sLength

        Return val

    End Function

    Public Function Count() As Integer

        Return Buffer.Length

    End Function

    Public Function Length() As Integer

        Return Count() - ReadHead

    End Function

    Public Function ToArray() As Byte()

        Return Buffer

    End Function

    Public Overrides Function ToString() As String

        Return Buffer.ToString()

    End Function

End Class
