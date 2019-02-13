Imports System.IO
Imports System.Text
Public Class Form1
    Const WM_NCHITTEST As Integer = &H84
    Const HTCLIENT As Integer = &H1
    Const HTCAPTION As Integer = &H2
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Select Case m.Msg
            Case WM_NCHITTEST
                MyBase.WndProc(m)
                If m.Result = HTCLIENT Then m.Result = HTCAPTION
            Case Else
                MyBase.WndProc(m)
        End Select
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Create Update folder if not found
        If (Not System.IO.Directory.Exists(IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Spotify\Update"))) Then
            System.IO.Directory.CreateDirectory(IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Spotify\Update"))
        End If

        'Remove downloaded update
        Dim fuckupdates As String = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Spotify\Update\spotify_installer-1.1.0.237.g378f6f25-15.exe")
        If System.IO.File.Exists(fuckupdates) Then
            File.SetAttributes(fuckupdates, FileAttributes.Normal)
            My.Computer.FileSystem.DeleteFile(fuckupdates)
        Else

        End If
        'Remove update.json
        Dim fuckjson As String = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Spotify\Update\update.json")
        If System.IO.File.Exists(fuckjson) Then
            File.SetAttributes(fuckjson, FileAttributes.Normal)
            My.Computer.FileSystem.DeleteFile(fuckjson)
        Else

        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        'Create update.json
        Dim filepath As String =
    IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Spotify\Update\update.json")
        If System.IO.File.Exists(filepath) Then
            My.Computer.FileSystem.DeleteFile(filepath)
        Else
            Dim fs As FileStream = File.Create(filepath)
        End If
        File.SetAttributes(filepath, FileAttributes.ReadOnly)
        'Create fake update
        Dim updatepath As String =
    IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Spotify\Update\spotify_installer-1.1.0.237.g378f6f25-15.exe")
        If System.IO.File.Exists(updatepath) Then
            My.Computer.FileSystem.DeleteFile(updatepath)
        Else
            Dim fs As FileStream = File.Create(updatepath)
        End If
        File.SetAttributes(updatepath, FileAttributes.ReadOnly)
        PictureBox1.Image = My.Resources.patchbuttondisabled
        BackgroundImage = My.Resources.GnomeDialogCool
        Button1.Enabled = False
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        End
    End Sub
End Class
