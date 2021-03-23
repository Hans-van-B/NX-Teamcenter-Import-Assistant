Module Util
    '---- Wait ----------------------------------------------------------------
    Public Sub wait(ByVal interval As Integer)
        xtrace_i("Wait " & interval.ToString)
        interval = interval * 100

        Dim sw As New Stopwatch
        sw.Start()
        Do While sw.ElapsedMilliseconds < interval
            ' Allows UI to remain responsive
            Application.DoEvents()
        Loop
        sw.Stop()
    End Sub

    '---- Exit Program --------------------------------------------------------
    ' This routine is called explicitly and implicitly
    Sub exit_program()
        xtrace_i("exit_program")

        If Not ExistFinished Then
            ' Write Item ID Index/Hash
            SaveFileToIdIndex()

            xtrace(" ")
            If (ErrorCount > 0) Or (WarningCount > 0) Then
                xtrace("Found " & ErrorCount.ToString & " Errors", 2)
                xtrace("Found " & WarningCount.ToString & " Warnings", 2)
            Else
                xtrace("Exit Ok", 1)
            End If

            xtrace("")
            xtrace("================")
            xtrace("  Exit Program  ")
            xtrace("================")

            ExitProgram = True
            ExistFinished = True
        End If
    End Sub

    Sub Do_Events()
        If UpdateWhileReading Then Application.DoEvents()
    End Sub

    Sub Do_Break()
        Break = False

        MessageBox.Show("Operation canceled",
                        "Break", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation,
                        MessageBoxDefaultButton.Button1)

        xtrace("Operation canceled!")
    End Sub
End Module
