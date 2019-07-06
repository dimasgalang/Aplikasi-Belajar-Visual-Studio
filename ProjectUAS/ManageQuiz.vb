Imports MySql.Data.MySqlClient
Public Class ManageQuiz
    Dim ClickId As String
    Public admin As String
    Public adminid As String
    Private Sub ManageQuiz_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        tampil()
        aturDGV()
        Try
            admin = DashboardAdmin.LabelParsing.Text
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
            adminid = rd.Item("idadmin")
            conn.Close()
            Button2.Enabled = False
            DataGridView1.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
            DataGridView1.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
            DataGridView1.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
            DataGridView1.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
            DataGridView1.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
            DataGridView1.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
            DataGridView1.Columns(6).SortMode = DataGridViewColumnSortMode.NotSortable

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Dim cek As String = ""
    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Me.Dispose()
        Login.Show()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            Button2.Enabled = True
        Else
            Button2.Enabled = False
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            conn.Open()
            str = "INSERT INTO quiz VALUES ('', '" & RichTextBox1.Text & "','" & RichTextBox2.Text & "', '" & RichTextBox3.Text & "', '" & RichTextBox4.Text & "', '" & RichTextBox5.Text & "', '" & adminid & "')"
            cmd = New MySqlCommand(str, conn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Quiz Berhasil Ditambahkan")
            RichTextBox1.Text = Nothing
            RichTextBox2.Text = Nothing
            RichTextBox3.Text = Nothing
            RichTextBox4.Text = Nothing
            RichTextBox5.Text = Nothing
            CheckBox1.Checked = False
            ClickId = Nothing
            tampil()

        Catch ex As Exception
            MessageBox.Show("Gagal")
        End Try
        conn.Close()
    End Sub
    Sub tampil()
        koneksi()
        da = New MySqlDataAdapter("SELECT quiz.idquiz,quiz.soal,quiz.option1,quiz.option2,quiz.option3,quiz.answer,admin.name FROM quiz,admin WHERE quiz.idadmin=admin.idadmin GROUP BY quiz.idquiz", conn)
        ds = New DataSet
        da.Fill(ds, "quiz")
        DataGridView1.DataSource = ds.Tables("quiz")

    End Sub
    Sub aturDGV()
        Try
            DataGridView1.Columns(0).HeaderText = "ID"
            DataGridView1.Columns(1).HeaderText = "Soal"
            DataGridView1.Columns(2).HeaderText = "Option 1"
            DataGridView1.Columns(3).HeaderText = "Option 2"
            DataGridView1.Columns(4).HeaderText = "Option 3"
            DataGridView1.Columns(5).HeaderText = "Answer"
            DataGridView1.Columns(6).HeaderText = "Admin"
            DataGridView1.Columns(0).Width = 30
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DataGridView1_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        Try
            If DataGridView1.SelectedCells.Count > 0 Or DataGridView1.SelectedRows.Count > 0 Then
                RichTextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
                RichTextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
                RichTextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
                RichTextBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value
                RichTextBox5.Text = DataGridView1.Rows(e.RowIndex).Cells(5).Value
                ClickId = DataGridView1.Rows(e.RowIndex).Cells(0).Value
                CheckBox1.Enabled = False
                Button2.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show("Header Tidak Bisa Dipilih")
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            If String.Compare(cek, ClickId, True) = 0 Then
                MessageBox.Show("Silahkan Pilih Quiz Terlebih Dahulu")
            Else
                conn.Open()
                str = "UPDATE quiz SET soal = '" & RichTextBox1.Text & "', option1 = '" & RichTextBox2.Text & "', option2 = '" & RichTextBox3.Text & "', option3 = '" & RichTextBox4.Text & "', answer = '" & RichTextBox5.Text & "', idadmin = '" & adminid & "' WHERE idquiz = '" & ClickId & "'"
                cmd = New MySqlCommand(str, conn)
                cmd.ExecuteNonQuery()
                RichTextBox1.Text = Nothing
                RichTextBox2.Text = Nothing
                RichTextBox3.Text = Nothing
                RichTextBox4.Text = Nothing
                RichTextBox5.Text = Nothing
                CheckBox1.Checked = False
                CheckBox1.Enabled = True
                ClickId = Nothing
                MessageBox.Show("Update Data Berhasil")
                tampil()
            End If
        Catch ex As Exception
            MessageBox.Show("Update Data Gagal")
        End Try
        conn.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            If String.Compare(cek, ClickId, True) = 0 Then
                MessageBox.Show("Silahkan Pilih Quiz Terlebih Dahulu")
            Else
                conn.Open()
                str = "DELETE FROM quiz WHERE idquiz = '" & ClickId & "'"
                cmd = New MySqlCommand(str, conn)
                cmd.ExecuteNonQuery()
                RichTextBox1.Text = Nothing
                RichTextBox2.Text = Nothing
                RichTextBox3.Text = Nothing
                RichTextBox4.Text = Nothing
                RichTextBox5.Text = Nothing
                CheckBox1.Checked = False
                CheckBox1.Enabled = True
                ClickId = Nothing
                MessageBox.Show("Delete Data Berhasil")
                tampil()
            End If
        Catch ex As Exception
            MessageBox.Show("Delete Data Gagal")
        End Try
        conn.Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        RichTextBox1.Text = Nothing
        RichTextBox2.Text = Nothing
        RichTextBox3.Text = Nothing
        RichTextBox4.Text = Nothing
        RichTextBox5.Text = Nothing
        CheckBox1.Checked = False
        CheckBox1.Enabled = True
        ClickId = Nothing
        tampil()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Dispose()
        DashboardAdmin.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        koneksi()
        da = New MySqlDataAdapter("SELECT * FROM quiz WHERE soal LIKE '%" & TextBox2.Text & "%' OR option1 LIKE '%" & TextBox2.Text & "%' OR option2 LIKE '%" & TextBox2.Text & "%' OR option3 LIKE '%" & TextBox2.Text & "%' OR answer LIKE '%" & TextBox2.Text & "%'", conn)
        ds = New DataSet
        da.Fill(ds, "quiz")
        DataGridView1.DataSource = ds.Tables("quiz")
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        ManageUser.Show()
        Me.Dispose()
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        ManageLesson.Show()
        Me.Dispose()
    End Sub
End Class