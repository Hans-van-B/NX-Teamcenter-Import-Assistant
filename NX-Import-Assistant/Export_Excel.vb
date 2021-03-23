Imports System.IO
Imports Excel = Microsoft.Office.Interop.Excel

Module Export_Excel
    Sub Export_to_Excel()
        xtrace_subs("Export_to_Excel")

        If Form1.SaveFileDialog1.ShowDialog = DialogResult.OK Then
            WriteHistory("Export Excel file")

            Dim sheetIndex As Integer
            Dim Ex As Object
            Dim Wb As Object
            Dim Ws As Object
            ShowStatus("Exporting...")

            Ex = CreateObject("Excel.Application")
            Wb = Ex.workbooks.add
            Dim col, row As Integer
            Dim rawData(Form1.DataGridView1.Rows.Count, Form1.DataGridView1.Columns.Count - 1) As Object
            For col = 0 To Form1.DataGridView1.Columns.Count - 1
                rawData(0, col) = Form1.DataGridView1.Columns(col).HeaderText.ToUpper
            Next
            For col = 0 To Form1.DataGridView1.Columns.Count - 1
                For row = 0 To Form1.DataGridView1.Rows.Count - 1
                    rawData(row + 1, col) = Form1.DataGridView1.Rows(row).Cells(col).Value
                Next
            Next
            Dim finalColLetter As String = String.Empty
            finalColLetter = ExcelColName(Form1.DataGridView1.Columns.Count)
            sheetIndex += 1
            Ws = Wb.Worksheets(sheetIndex)
            Dim excelRange As String = String.Format("A1:{0}{1}", finalColLetter, Form1.DataGridView1.Rows.Count + 1)
            Ws.Range(excelRange, Type.Missing).Value2 = rawData
            Ws = Nothing
            Try
                Wb.SaveAs(Form1.SaveFileDialog1.FileName, Type.Missing, Type.Missing,
                     Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                     Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing)
                Wb.Close(True, Type.Missing, Type.Missing)
            Catch ex1 As Exception
                MessageBox.Show(ex1.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                 MessageBoxDefaultButton.Button1)
            End Try
            Wb = Nothing
            ' Release the Application object
            Ex.Quit()
            Ex = Nothing
            ' Collect the unreferenced objects
            GC.Collect()
            ShowStatus("Export finished.")
            MsgBox("Exported Successfully.", MsgBoxStyle.Information)
        End If
    End Sub

    Function ExcelColName(ByVal Col As Integer) As String
        If Col < 0 And Col > 256 Then
            MsgBox("Invalid Argument", MsgBoxStyle.Critical)
            Return Nothing
            Exit Function
        End If
        Dim i As Int16
        Dim r As Int16
        Dim S As String
        If Col <= 26 Then
            S = Chr(Col + 64)
        Else
            r = Col Mod 26
            i = System.Math.Floor(Col / 26)
            If r = 0 Then
                r = 26
                i = i - 1
            End If
            S = Chr(i + 64) & Chr(r + 64)
        End If
        ExcelColName = S
    End Function
End Module
