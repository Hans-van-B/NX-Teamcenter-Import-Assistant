Imports System.IO
Module CheckIfExist
    Function IfPartFileExist(OSFN As String) As Boolean
        Dim Found As Boolean = False
        Dim RemovPath As Boolean = Form1.RemovePathToolStripMenuItem.Checked
        Dim RowCount As Integer = Form1.DataGridView1.RowCount
        Dim FN As String

        If RemovPath Then OSFN = Path.GetFileName(OSFN)

        For RecordNr = 0 To RowCount - 2
            FN = Form1.DataGridView1.Item(C_FN, RecordNr).Value
            If RemovPath Then FN = Path.GetFileName(FN)
            If UCase(OSFN) = UCase(FN) Then
                Found = True
                Exit For
            End If
        Next

        xtrace_i("IfPartFileExist = " & Found.ToString)
        IfPartFileExist = Found
    End Function

    Function IfIDExist(ID As String) As Boolean
        Dim Found As Boolean = False
        Dim RowCount As Integer = Form1.DataGridView1.RowCount
        Dim RID As String

        For RecordNr = 0 To RowCount - 2
            RID = Form1.DataGridView1.Item(C_ID, RecordNr).Value
            If UCase(ID) = UCase(RID) Then
                Found = True
                Exit For
            End If
        Next

        xtrace_i("IfIDExist = " & Found.ToString)
        IfIDExist = Found
    End Function
End Module
