Imports MySql.Data.MySqlClient
Public Class DashboardAdmin
    Private Sub DashboardAdmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        Try
            Dim admin As String
            admin = LoginAdmin.TextBox1.Text
            LabelParsing.Visible = False
            LabelParsing.Text = admin
            cmd = New MySqlCommand
            cmd.Connection = conn
            str = "SELECT * FROM admin WHERE username= '" + admin + "'"

            cmd.CommandText = str

            rd = cmd.ExecuteReader
            rd.Read()
            PictureBox1.ImageLocation = rd.Item("photo")
            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
            Label1.Text = UCase(rd.Item("name"))
            PictureBox2.ImageLocation = rd.Item("photo")
            PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
            Label2.Text = UCase(rd.Item("name"))
            conn.Close()

            conn.Open()
            cnt = "SELECT COUNT(iduser) FROM user"
            cmd.CommandText = cnt

            rd = cmd.ExecuteReader
            rd.Read()
            CountUser.Text = UCase(rd.Item("COUNT(iduser)"))
            conn.Close()

            conn.Open()
            cnt = "SELECT COUNT(idquiz) FROM quiz"
            cmd.CommandText = cnt

            rd = cmd.ExecuteReader
            rd.Read()
            CountQuiz.Text = UCase(rd.Item("COUNT(idquiz)"))
            conn.Close()

            conn.Open()
            cnt = "SELECT COUNT(idmateri) FROM materi"
            cmd.CommandText = cnt

            rd = cmd.ExecuteReader
            rd.Read()
            Dim CountMateri As Integer
            CountMateri = rd.Item("COUNT(idmateri)")
            conn.Close()

            CountLesson.Text = CountMateri

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Me.Dispose()
        Login.Show()
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Me.Hide()
        ManageUser.Show()
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        ManageLesson.Show()
        Me.Hide()
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Me.Hide()
        ManageQuiz.Show()
    End Sub
End Class