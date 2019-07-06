Imports MySql.Data.MySqlClient
Public Class LoginUser

    Private Sub LoginUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If MessageBox.Show("Yakin Ingin Membatalkan Login?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
            Me.Dispose()
            Login.Show()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MsgBox("Masukkan Username", MsgBoxStyle.Critical, "Pesan")
        ElseIf TextBox2.Text = "" Then
            MsgBox("Masukkan Password", MsgBoxStyle.Critical, "Pesan")
            Exit Sub

        Else
            koneksi()
            cmd = New MySqlCommand
            cmd.Connection = conn
            str = " SELECT username,password FROM user WHERE username= '" & TextBox1.Text & "' AND password = '" & TextBox2.Text & "'"
            cmd.CommandText = str

            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows Then
                MessageBox.Show("Login Sukses!")
                DashboardUser.Show()
                Me.Close()
                TextBox1.Text = Nothing
                TextBox2.Text = Nothing
                conn.Close()

            Else
                MessageBox.Show("Username atau Password Salah")
                TextBox2.Text = Nothing
            End If
        End If
    End Sub

End Class