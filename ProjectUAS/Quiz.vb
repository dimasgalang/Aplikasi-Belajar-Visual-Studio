Imports MySql.Data.MySqlClient
Public Class Quiz
    Public userid As String
    Public user As String
    Private Sub Quiz_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Quiz()
        Try
            koneksi()
            user = DashboardUser.LabelParsing.Text
            LabelParsing.Visible = False
            LabelParsing.Text = user
            cmd = New MySqlCommand
            cmd.Connection = conn
            str = "SELECT * FROM user WHERE username = '" + user + "'"
            cmd.CommandText = str

            rd = cmd.ExecuteReader
            rd.Read()
            PictureBox1.ImageLocation = rd.Item("photo")
            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
            Label1.Text = UCase(rd.Item("name"))
            PictureBox2.ImageLocation = rd.Item("photo")
            PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
            Label2.Text = UCase(rd.Item("name"))
            userid = rd.Item("iduser")
            conn.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Dim jawaban As String
    Sub Quiz()
        Try
            Button1.Enabled = False
            Button2.Enabled = True
            RadioButton1.Enabled = True
            RadioButton2.Enabled = True
            RadioButton3.Enabled = True
            status.Visible = False
            koneksi()
            Dim totquiz As Integer
            cmd = New MySqlCommand
            cmd.Connection = conn
            str = "SELECT COUNT(idquiz) FROM quiz"
            cmd.CommandText = str
            rd = cmd.ExecuteReader
            rd.Read()
            totquiz = rd.Item("COUNT(idquiz)")
            conn.Close()

            conn.Open()
            Dim randomquiz As New Random
            cmd = New MySqlCommand
            cmd.Connection = conn
            qid.Text = randomquiz.Next(1, totquiz)
            str = "SELECT * FROM quiz WHERE idquiz = '" + qid.Text + "'"
            cmd.CommandText = str

            rd = cmd.ExecuteReader
            rd.Read()
            RadioButton1.Text = rd.Item("option1")
            RadioButton2.Text = rd.Item("option2")
            RadioButton3.Text = rd.Item("option3")
            soal.Text = UCase(rd.Item("soal"))
            jawaban = rd.Item("answer")
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

    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Me.Dispose()
        Profil.Show()
    End Sub

    Dim pilih As String
    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        pilih = RadioButton1.Text
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        pilih = RadioButton2.Text
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        pilih = RadioButton3.Text
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            If String.Compare(pilih, jawaban, True) = 0 Then
                status.Text = "Benar"
                status.Visible = True
                status.ForeColor = Color.Green
            Else
                status.Text = "Salah"
                status.Visible = True
                status.ForeColor = Color.Red
            End If
            koneksi()
            str = "INSERT INTO user_quiz VALUES('" + userid + "','" + qid.Text + "', '" + status.Text + "', '" + jawaban + "', '" + pilih + "')"
            cmd = New MySqlCommand(str, conn)
            cmd.CommandText = str
            cmd.ExecuteNonQuery()
            Button2.Enabled = False
            Button1.Enabled = True
            RadioButton1.Checked = False
            RadioButton2.Checked = False
            RadioButton3.Checked = False
            pilih = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Quiz()
    End Sub
End Class