Module ModHelp
    Dim HelpPage As String = Temp & "\help.html"
    Dim HelpPageHtm As String = AppRoot & "\" & AppName & ".html"
    Dim HelpPagePdf As String = AppRoot & "\" & AppName & ".pdf"

    Sub WriteHelp(Line As String)
        My.Computer.FileSystem.WriteAllText(HelpPage, Line & vbNewLine, True)
    End Sub

    Sub ShowHelp()
        xtrace("Show Help")

        If (System.IO.File.Exists(HelpPageHtm)) Then
            HelpPage = HelpPageHtm
        ElseIf (System.IO.File.Exists(HelpPagePdf)) Then
            HelpPage = HelpPagePdf
        Else
            xtrace("Did not find " & HelpPageHtm)
            xtrace("Did not find " & HelpPagePdf)

            xtrace("Create page")
            My.Computer.FileSystem.WriteAllText(HelpPage, "<html>" & vbNewLine, False)
            WriteHelp("<head>")
            WriteHelp("")
            WriteHelp("</head>")
            WriteHelp("<H2>" & AppName & " V" & AppVer & " Help Page</H2>")
            WriteHelp("<br>")
            WriteHelp("<br>")
            WriteHelp("<br>")
            WriteHelp("<br>")
            WriteHelp("<br>")
            WriteHelp("The " & AppName & " log can be found here: " & Glob.LogFile & "<br>")
            WriteHelp("See Help, About for maitenance info.<br>")
            WriteHelp("</body>")
            WriteHelp("</html")
        End If

        Process.Start(HelpPage, "")
    End Sub

    Sub ShowHelpAbout()
        xtrace("Show Help, about")

        xtrace("Create page")
        My.Computer.FileSystem.WriteAllText(HelpPage, "<html>" & vbNewLine, False)
        WriteHelp("<head>")
        WriteHelp("")
        WriteHelp("</head>")
        WriteHelp("<H2>" & AppName & " V" & AppVer & " Help About</H2>")
        WriteHelp("<br>")
        WriteHelp("<br>")
        WriteHelp("<br>")
        WriteHelp("<br>")
        WriteHelp("<br>")
        WriteHelp("<font size=""-1"">")
        WriteHelp(" Created by: Hans van Buitenen / hans.van.buitenen@xs4all.nl<br>")
        WriteHelp(" Dev: C:\Users\nly10677\OneDrive - Philips\VS_Projects\??<br>")
        WriteHelp(" Maint: P:\Dev\Template\vb.net\ZZ_Template_Windows_Forms<br>")
        WriteHelp(" log: " & Glob.LogFile & "<br>")
        WriteHelp("</font>")
        WriteHelp("</body>")
        WriteHelp("</html")

        Process.Start(HelpPage, "")
    End Sub
End Module
