Imports MySql.Data.MySqlClient
Public Class ManageUser
    Dim ClickPath As String
    Dim ClickId As String
    Dim ClickName As String
    Public admin As String
    Public adminid As String
    Private Sub ManageUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            ClickName = "user.png"
            ClickPath = Application.StartupPath + "\img/" + ClickName

            DataGridView1.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
            DataGridView1.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
            DataGridView1.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
            DataGridView1.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
            DataGridView1.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
            DataGridView1.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable

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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFileDialog1.Filter = "JPG Files(*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|GIF Files(*.gif)|*.gif|PNG Files(*.png)|*.png|BMP Files(*.bmp)|*.bmp|TIFF Files(*.tiff)|*.tiff"
        OpenFileDialog1.FileName = ""
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage
            PictureBox3.Image = New Bitmap(OpenFileDialog1.FileName)
            PathFile = OpenFileDialog1.FileName
            ClickName = PathFile.Substring(PathFile.LastIndexOf("\") + 1)
            ClickPath = OpenFileDialog1.FileName
            PictureBox3.Image = Image.FromFile(ClickPath)
        End If
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
            str = "INSERT INTO user VALUES ('', '" & TextBox1.Text & "','" & TextBox2.Text & "', '" & TextBox3.Text & "', '" & TextBox4.Text & "', @photo, '" & adminid & "')"
            cmd = New MySqlCommand(str, conn)
            cmd.Parameters.AddWithValue("@photo", ClickPath)
            cmd.ExecuteNonQuery()
            MessageBox.Show("User Berhasil Dibuat")
            TextBox1.Text = Nothing
            TextBox2.Text = Nothing
            TextBox3.Text = Nothing
            TextBox4.Text = Nothing
            ClickName = "user.png"
            ClickPath = Application.StartupPath + "\img/" + ClickName
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
        da = New MySqlDataAdapter("SELECT user.iduser,user.username,user.password,user.name,user.nohp,user.photo,admin.name FROM user,admin WHERE user.idadmin=admin.idadmin GROUP BY user.iduser", conn)
        ds = New DataSet
        da.Fill(ds, "user")
        DataGridView1.DataSource = ds.Tables("user")

    End Sub
    Sub aturDGV()
        Try
            DataGridView1.Columns(0).HeaderText = "ID"
            DataGridView1.Columns(1).HeaderText = "Username"
            DataGridView1.Columns(2).HeaderText = "Password"
            DataGridView1.Columns(3).HeaderText = "Nama"
            DataGridView1.Columns(4).HeaderText = "No HP"
            DataGridView1.Columns(5).HeaderText = "Foto"
            DataGridView1.Columns(6).HeaderText = "Admin"
            DataGridView1.Columns(0).Width = 30
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DataGridView1_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        Try
            If DataGridView1.SelectedCells.Count > 0 Or DataGridView1.SelectedRows.Count > 0 Then
                TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
                TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
                TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
                TextBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value
                ClickPath = DataGridView1.Rows(e.RowIndex).Cells(5).Value
                ClickId = DataGridView1.Rows(e.RowIndex).Cells(0).Value
                PictureBox3.Image = Image.FromFile(ClickPath)
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
                MessageBox.Show("Silahkan Pilih User Terlebih Dahulu")
            Else
                conn.Open()
                str = "UPDATE user SET username = '" & TextBox1.Text & "', password = '" & TextBox2.Text & "', name = '" & TextBox3.Text & "', nohp = '" & TextBox4.Text & "', photo = @photo WHERE iduser = '" & ClickId & "'"
                cmd = New MySqlCommand(str, conn)
                cmd.Parameters.AddWithValue("@photo", ClickPath)
                cmd.ExecuteNonQuery()
                TextBox1.Text = Nothing
                TextBox2.Text = Nothing
                TextBox3.Text = Nothing
                TextBox4.Text = Nothing
                ClickName = "user.png"
                ClickPath = Application.StartupPath + "\img/" + ClickName
                PictureBox3.Image = Image.FromFile(ClickPath)
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
                MessageBox.Show("Silahkan Pilih User Terlebih Dahulu")
            Else
                conn.Open()
                str = "DELETE FROM user WHERE iduser = '" & ClickId & "'"
                cmd = New MySqlCommand(str, conn)
                cmd.ExecuteNonQuery()
                TextBox1.Text = Nothing
                TextBox2.Text = Nothing
                TextBox3.Text = Nothing
                TextBox4.Text = Nothing
                ClickName = "user.png"
                ClickPath = Application.StartupPath + "\img/" + ClickName
                PictureBox3.Image = Image.FromFile(ClickPath)
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
        TextBox2.Text = Nothing
        TextBox3.Text = Nothing
        TextBox4.Text = Nothing
        ClickName = "user.png"
        ClickPath = Application.StartupPath + "\img/" + ClickName
        PictureBox3.Image = Image.FromFile(ClickPath)
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
        da = New MySqlDataAdapter("SELECT * FROM user WHERE username LIKE '%" & TextBox7.Text & "%' OR password LIKE '%" & TextBox7.Text & "%' OR name LIKE '%" & TextBox7.Text & "%' OR nohp LIKE '%" & TextBox7.Text & "%' OR photo LIKE '%" & TextBox7.Text & "%'", conn)
        ds = New DataSet
        da.Fill(ds, "user")
        DataGridView1.DataSource = ds.Tables("user")
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        ManageQuiz.Show()
        Me.Dispose()
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Me.Dispose()
        ManageLesson.Show()
    End Sub

End Class