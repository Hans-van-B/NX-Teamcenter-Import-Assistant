Module Log
    Sub xtrace_init()
        My.Computer.FileSystem.WriteAllText(LogFile, "" & vbNewLine, False)
        WriteInfo(AppName & " V" & AppVer)
        xtrace("AppRoot = " & AppRoot)
        xtrace("CD      = " & CD)
    End Sub

    '---- xtrace
    Sub xtrace(Msg As String)
        My.Computer.FileSystem.WriteAllText(LogFile, Msg & vbNewLine, True)
    End Sub

    Sub xtrace(Msg As String, TV As Integer)
        If TV <= CTrace Then
            Console.Write(Msg & vbNewLine)
        End If

        xtrace(Msg)
    End Sub

    Sub xtrace_i(Msg As String)
        xtrace(" * " & Msg)
    End Sub

    Sub xtrace_i(Msg As String, TV As Integer)
        xtrace(" * " & Msg, TV)
    End Sub

    '---- xtrace sub start
    Sub xtrace_subs(Msg As String)
        xtrace("## " & Msg)
    End Sub

    '---- xtrace sub exit
    Sub xtrace_sube()

    End Sub

    Sub xtrace_sube(Msg As String)
        'xtrace("## " & Msg)
    End Sub

    Sub xtrace_border()
        xtrace("###############################################################################")
    End Sub

    Sub xtrace_err(Msg As String)
        xtrace("ERROR: " & Msg)
    End Sub
    '---- Show Status ----
    Sub ShowStatus(Msg As String)
        Form1.ToolStripStatusLabel1.Text = Msg
        Application.DoEvents()
        xtrace(" S " & Msg)
    End Sub

    Sub ShowStatus(Msg As String, Loading As Boolean) ' Support QuickLoad

        If Loading And QuickLoad Then

        Else
            Form1.ToolStripStatusLabel1.Text = Msg
            Application.DoEvents()
        End If
        xtrace(" S " & Msg)
    End Sub

    '---- Write to Info TextBox ----
    Public Sub WriteInfo(Msg)
        Form1.TextBoxInfo.AppendText(Msg & vbNewLine)
        xtrace(Msg)
    End Sub
    '---- Write to the History TextBox
    Public Sub WriteHistory(Msg)
        Form1.TextBoxHistory.AppendText(Msg & vbNewLine)
    End Sub
End Module
