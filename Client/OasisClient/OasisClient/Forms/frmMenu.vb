Public Class frmMenu

    Private Sub frmMenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set up Parent Properties
        btn_Exit.Parent = picMenu
        btn_Login.Parent = picMenu
        btn_Register.Parent = picMenu

        txtUsername.Parent = picMenu
        txtPassword.Parent = picMenu
        txtRPassword.Parent = picMenu

        Label1.Parent = picMenu
        Label2.Parent = picMenu
        Label3.Parent = picMenu
        lblConnectionStatus.Parent = picMenu

        ' Start up the game's system and load everything.
        Main()
    End Sub

    Private Sub btn_Exit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Exit.Click
        ' We're killing the game.. Poor us :[
        DestroyGame()
    End Sub
End Class
