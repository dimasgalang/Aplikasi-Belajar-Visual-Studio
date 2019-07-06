Imports MySql.Data.MySqlClient

Module Connection
    Public conn As MySqlConnection
    Public cmd As MySqlCommand
    Public rd As MySqlDataReader
    Public rd2 As MySqlDataReader
    Public da As MySqlDataAdapter
    Public ds As DataSet
    Public str As String
    Public cnt As String
    Public re As DataTableReader
    Public cari As DataTable

    Sub koneksi()
        conn = New MySqlConnection

        conn.ConnectionString = "server=localhost;user id=root;database=pemdesk;password="
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
        Catch ex As Exception
            MsgBox("Koneksi Gagal" & Err.Description)
        End Try
    End Sub

End Module