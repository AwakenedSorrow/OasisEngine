Module modGeneral
    Public Sub Main()
        ' Right, we're entering the program.. Load on brothers!

        ' First set the login menu to a proper location.. Would look kind of awkward near the side there would it not?
        frmMenu.picMenu.Location = New Point(frmMenu.Width / 2 - (frmMenu.picMenu.Width / 2), frmMenu.Height / 2 - (frmMenu.picMenu.Height / 2))

    End Sub

    Public Sub DestroyGame()
        frmMenu.Close()
        End
    End Sub
End Module
