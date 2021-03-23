Imports System.Data.OleDb

Module Import_Excel
    Sub Import_From_Excel()
        ShowStatus("Import from excel...")

        Dim Conn As OleDbConnection
        Dim dta As OleDbDataAdapter
        Dim dts As DataSet
        Dim excel As String
        Dim OpenFileDialog As New OpenFileDialog

        Try
            If Form1.OpenFileDialog1.ShowDialog(Form1) = System.Windows.Forms.DialogResult.OK Then
                WriteHistory("Import Excel file")

                xtrace_i("Reset")
                Form1.DataGridView1.Columns.Clear()

                xtrace_i("Import")
                Dim Filename As String = Form1.OpenFileDialog1.FileName
                xtrace_i("Open: """ + Filename + """")
                Dim fi As New IO.FileInfo(Filename)

                excel = fi.FullName
                Conn = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excel + ";Extended Properties='Excel 12.0;HDR=YES;'")
                dta = New OleDbDataAdapter("select * from [Sheet1$]", Conn)
                dts = New DataSet
                dta.Fill(dts, "[Sheet1$]")
                Form1.DataGridView1.DataSource = dts
                Form1.DataGridView1.DataMember = "[Sheet1$]"
                ShowStatus("Import done.")
                Conn.Close()

                Form1.DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            ShowStatus("Import failed.")
        End Try
    End Sub
End Module
