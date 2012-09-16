﻿Module modGeneral
    Public Sub Main()
        ' Right, we're entering the program.. Load on brothers!

        ' First set the login menu to a proper location.. Would look kind of awkward near the side there would it not?
        frmMenu.picMenu.Location = New Point(frmMenu.Width / 2 - (frmMenu.picMenu.Width / 2), frmMenu.Height / 2 - (frmMenu.picMenu.Height / 2))

    End Sub

    Public Sub DestroyGame()
        frmMenu.Close()
        End
    End Sub

    Public Sub HandleError(ByVal Loc As String, ByVal Number As String, ByVal Desc As String)
        Dim objWriter As New System.IO.StreamWriter(App_Path() + ERROR_LOG, True)

        If Options.Logging Then
            objWriter.WriteLine("---")
            objWriter.WriteLine("An error has occured in " + Loc.Trim)
            objWriter.WriteLine("Error #" + Number.Trim + " : " + Desc.Trim)
            objWriter.WriteLine("---")
        End If

        objWriter.Close()
    End Sub
End Module
