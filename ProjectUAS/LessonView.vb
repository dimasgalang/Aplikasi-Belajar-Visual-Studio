Imports MySql.Data.MySqlClient
Public Class LessonView
    Private Sub LessonMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Menuu()
        Try
            koneksi()
            Dim user As String
            user = DashboardUser.LabelParsing.Text
            cmd = New MySqlCommand
            cmd.Connection = conn
            str = "SELECT * FROM user WHERE username= '" + user + "'"
            cmd.CommandText = str
            LabelParsing.Text = user
            LabelParsing.Visible = False
            rd = cmd.ExecuteReader
            rd.Read()
            PictureBox1.ImageLocation = rd.Item("photo")
            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
            Label1.Text = UCase(rd.Item("name"))
            PictureBox2.ImageLocation = rd.Item("photo")
            PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
            Label2.Text = UCase(rd.Item("name"))
            conn.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub Menuu()
        Try
            koneksi()
            cmd = New MySqlCommand
            cmd.Connection = conn
            Dim Id As String
            Id = Lesson.ClickId
            str = "SELECT * FROM materi WHERE idmateri = '" + Id + "'"
            cmd.CommandText = str

            rd = cmd.ExecuteReader
            rd.Read()
            nama.Text = UCase(rd.Item("title"))
            AxAcroPDF1.src = rd.Item("path")
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

    Private Sub ButtonOpen2_Click(sender As Object, e As EventArgs) Handles ButtonOpen2.Click
        Me.Dispose()
        Lesson.Show()
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Me.Dispose()
        Profil.Show()
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Me.Dispose()
        Quiz.Show()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Dispose()
        DashboardUser.Show()
    End Sub
End Class