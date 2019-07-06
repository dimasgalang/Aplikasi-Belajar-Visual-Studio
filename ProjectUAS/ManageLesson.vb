Imports MySql.Data.MySqlClient
Public Class ManageLesson
    Dim ClickPath As String
    Dim ClickId As String
    Dim ClickName As String
    Public admin As String
    Public adminid As String
    Private Sub ManageMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        tampil()
        aturDGV()
        TextBox3.Enabled = False
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
            ClickName = Nothing
            ClickPath = Application.StartupPath + "\materi/" + ClickName

            DataGridView1.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
            DataGridView1.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
            DataGridView1.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
            DataGridView1.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Dim cek As String = ""
    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Me.Dispose()
        Login.Show()
    End Sub

    Private PathFile As String = Nothing

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
            str = "INSERT INTO materi VALUES ('', '" & TextBox1.Text & "', @path, '" & adminid & "')"
            cmd = New MySqlCommand(str, conn)
            cmd.Parameters.AddWithValue("@path", ClickPath)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Data Berhasil Ditambahkan")
            TextBox1.Text = Nothing
            TextBox3.Text = Nothing
            ClickName = Nothing
            ClickPath = Application.StartupPath + "\materi/" + ClickName
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
        da = New MySqlDataAdapter("SELECT materi.idmateri,materi.title,materi.path,admin.name FROM materi,admin WHERE materi.idadmin=admin.idadmin GROUP BY materi.idmateri", conn)
        ds = New DataSet
        da.Fill(ds, "materi")
        DataGridView1.DataSource = ds.Tables("materi")

    End Sub
    Sub aturDGV()
        Try
            DataGridView1.Columns(0).HeaderText = "ID"
            DataGridView1.Columns(1).HeaderText = "Title"
            DataGridView1.Columns(2).HeaderText = "Path"
            DataGridView1.Columns(3).HeaderText = "Author"
            DataGridView1.Columns(0).Width = 30
            DataGridView1.Columns(2).Width = 220
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DataGridView1_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        Try
            If DataGridView1.SelectedCells.Count > 0 Or DataGridView1.SelectedRows.Count > 0 Then
                TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
                TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
                ClickId = DataGridView1.Rows(e.RowIndex).Cells(0).Value
                ClickPath = DataGridView1.Rows(e.RowIndex).Cells(3).Value
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
                MessageBox.Show("Silahkan Pilih Item Terlebih Dahulu")
            Else
                conn.Open()
                str = "UPDATE materi SET title = '" & TextBox1.Text & "', path = @path, idadmin = '" & adminid & "' WHERE idmateri = '" & ClickId & "'"
                cmd = New MySqlCommand(str, conn)
                cmd.Parameters.AddWithValue("@path", ClickPath)
                cmd.ExecuteNonQuery()
                TextBox1.Text = Nothing
                TextBox3.Text = Nothing
                CheckBox1.Checked = False
                CheckBox1.Enabled = True
                ClickName = Nothing
                ClickPath = Application.StartupPath + "\materi/" + ClickName
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
                MessageBox.Show("Silahkan Pilih Item Terlebih Dahulu")
            Else
                conn.Open()
                str = "DELETE FROM materi WHERE idmateri = '" & ClickId & "'"
                cmd = New MySqlCommand(str, conn)
                cmd.ExecuteNonQuery()
                TextBox1.Text = Nothing
                TextBox3.Text = Nothing
                ClickName = Nothing
                ClickPath = Application.StartupPath + "\materi/" + ClickName
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
        TextBox1.Text = Nothing
        TextBox3.Text = Nothing
        ClickName = Nothing
        ClickPath = Application.StartupPath + "\materi/" + ClickName
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
        da = New MySqlDataAdapter("SELECT * FROM materi WHERE title LIKE '%" & TextBox2.Text & "%' OR path LIKE '%" & TextBox2.Text & "%' OR idadmin LIKE '%" & TextBox2.Text & "%'", conn)
        ds = New DataSet
        da.Fill(ds, "materi")
        DataGridView1.DataSource = ds.Tables("materi")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFileDialog1.Filter = "PDF Files(*.pdf)|*.pdf"
        OpenFileDialog1.FileName = ""
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PathFile = OpenFileDialog1.FileName
            ClickName = PathFile.Substring(PathFile.LastIndexOf("\") + 1)
            ClickPath = OpenFileDialog1.FileName
            TextBox3.Text = ClickPath
        End If
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Me.Dispose()
        ManageUser.Show()
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Me.Dispose()
        ManageQuiz.Show()
    End Sub

End Class