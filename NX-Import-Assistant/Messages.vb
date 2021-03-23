Module Messages
    Sub WarningAtLine(Msg As String, LinNo As Integer)
        Dim Msg1 As String = Msg + " At line " + LinNo.ToString
        MessageBox.Show("Warning: " + Msg1, _
                        "Warning", MessageBoxButtons.OK, _
                        MessageBoxIcon.Exclamation, _
                        MessageBoxDefaultButton.Button1)

        xtrace("Warning Message: " + Msg1)
    End Sub
End Module
