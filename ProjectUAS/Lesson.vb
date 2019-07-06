Imports MySql.Data.MySqlClient
Public Class Lesson
    Public ClickId As String
    Public userid As String
    Public user As String
    Private Sub Lesson_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        tampil()
        aturDGV()
        Try
            user = DashboardUser.LabelParsing.Text
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
            userid = rd.Item("iduser")
            conn.Close()
            DataGridView1.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
            DataGridView1.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
            
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Dim cek As String = ""
    Sub tampil()
        koneksi()
        da = New MySqlDataAdapter("SELECT materi.idmateri,materi.title,admin.name FROM materi,admin WHERE materi.idadmin=admin.idadmin GROUP BY materi.idmateri", conn)
        ds = New DataSet
        da.Fill(ds, "materi")
        DataGridView1.DataSource = ds.Tables("materi")
    End Sub
    Sub aturDGV()
        Try
            DataGridView1.Columns(0).HeaderText = "ID"
            DataGridView1.Columns(1).HeaderText = "Title"
            DataGridView1.Columns(2).HeaderText = "Author"
            DataGridView1.Columns(0).Width = 30
            DataGridView1.Columns(1).Width = 680
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DataGridView1_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        Try
            If DataGridView1.SelectedCells.Count > 0 Or DataGridView1.SelectedRows.Count > 0 Then
                ClickId = DataGridView1.Rows(e.RowIndex).Cells(0).Value
                ButtonOpen.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show("Header Tidak Bisa Dipilih")
        End Try
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Me.Dispose()
        DashboardUser.Dispose()
        Login.Show()
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked

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

    Private Sub ButtonOpen_Click(sender As Object, e As EventArgs) Handles ButtonOpen.Click
        If String.Compare(cek, ClickId, True) = 0 Then
            MessageBox.Show("Silahkan Pilih Materi Terlebih Dahulu")
        Else
            koneksi()
            str = "INSERT INTO user_materi VALUES('" + userid + "','" + ClickId + "', 'Mempelajari')"
            cmd = New MySqlCommand(str, conn)
            cmd.CommandText = str
            cmd.ExecuteNonQuery()
            conn.Close()
            Me.Hide()
            LessonView.Show()
        End If
    End Sub

    Private Sub ButtonCari_Click(sender As Object, e As EventArgs) Handles ButtonCari.Click
        koneksi()
        da = New MySqlDataAdapter("SELECT * FROM materi WHERE title LIKE '%" & TextBoxCari.Text & "%'", conn)
        ds = New DataSet
        da.Fill(ds, "materi")
        DataGridView1.DataSource = ds.Tables("materi")
    End Sub
End Class