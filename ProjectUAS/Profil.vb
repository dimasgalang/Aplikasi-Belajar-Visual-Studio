Imports MySql.Data.MySqlClient
Public Class Profil
    Private Sub Profil_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        Try
            Dim user As String
            user = DashboardUser.LabelParsing.Text
            LabelParsing.Visible = False
            LabelParsing.Text = user
            cmd = New MySqlCommand
            cmd.Connection = conn
            str = "SELECT * FROM user WHERE username= '" + user + "'"
            cmd.CommandText = str

            rd = cmd.ExecuteReader
            rd.Read()
            PictureBox1.ImageLocation = rd.Item("photo")
            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
            Label1.Text = UCase(rd.Item("name"))
            PictureBox2.ImageLocation = rd.Item("photo")
            PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
            Label2.Text = UCase(rd.Item("name"))
            Picture.ImageLocation = rd.Item("photo")
            Picture.SizeMode = PictureBoxSizeMode.StretchImage
            uid.Text = UCase(rd.Item("iduser"))
            nama.Text = UCase(rd.Item("name"))
            nohp.Text = UCase(rd.Item("nohp"))
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Me.Dispose()
        DashboardUser.Dispose()
        Login.Show()
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Me.Dispose()
        Lesson.Show()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Dispose()
        DashboardUser.Show()
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Me.Dispose()
        Quiz.Show()
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked

    End Sub
End Class