Module Defaults
    Sub ReadDefaults()
        Dim ReadFile

        If My.Computer.FileSystem.FileExists(IniFile1) Then
            WriteInfo("Read Defaults " & IniFile1)
            ReadFile = My.Computer.FileSystem.OpenTextFileReader(IniFile1)

        ElseIf My.Computer.FileSystem.FileExists(IniFile2) Then
            WriteInfo("Read Defaults " & IniFile2)
            ReadFile = My.Computer.FileSystem.OpenTextFileReader(IniFile2)

        Else
            WriteInfo("Failed to read:")
            WriteInfo("   " & IniFile1)
            WriteInfo("Or " & IniFile2)
            Exit Sub
        End If

        Dim Line As String
        Dim Group As String = ""
        Dim P1, P2 As Integer
        Dim DName, DVal As String

        While Not ReadFile.EndOfStream
            Try
                Line = ReadFile.ReadLine()

                '---- Remark lines ----
                If Left(Line, 1) = "#" Then
                    Continue While
                End If

                '---- Read Group ----------
                P1 = InStr(Line, "[")
                P2 = InStr(Line, "]")

                If P1 = 1 And P2 > 2 Then
                    Group = Mid(Line, 2, P2 - 2)
                    xtrace("Group = " & Group)
                    Continue While
                End If

                '---- Pick Lists ----
                ' Reset group (Optional)
                If Len(Line) < 2 Then
                    Group = ""
                    Continue While
                End If

                If Group = "COMBOBOX01" Then
                    'Form1.COMBOBOX01.Items.Add(Line)
                End If

                '---- Read Defaults
                P1 = InStr(Line, "=")
                DName = Left(Line, P1 - 1)
                DVal = Mid(Line, P1 + 1)
                xtrace("Default " & DName & "=" & DVal)

                If Group = "INIT" Then

                    If DName = "WindowState" Then
                        If UCase(DVal) = "MIN" Then
                            xtrace("Minimize form")
                            Form1.WindowState = FormWindowState.Minimized
                        End If
                    End If

                    '---- String Values
                    If DName = "LibExtension" Then
                        LibExtension = DVal
                        xtrace_i("LibExtension = " + LibExtension)
                    End If

                    If DName = "LibRev" Then
                        LibRev = DVal
                        xtrace_i("LibRev = " + LibRev)
                    End If

                    If DName = "UsrPrefix" Then
                        UsrPrefix = DVal
                        xtrace_i("UsrPrefix = " + UsrPrefix)
                    End If

                    '---- Integer values
                    If DName = "Control_Panel_Width" Then
                        Control_Panel_Width = Val(DVal)
                        xtrace_i("Control_Panel_Width = " + DVal)
                    End If

                    If DName = "MaxCol1Width" Then
                        MaxCol1Width = Val(DVal)
                        xtrace_i("MaxCol1Width = " + DVal)
                    End If

                    '---- Boolean Values
                    If DName = "AutoNextLine" Then
                        If DVal = "True" Then AutoNextLine = True
                        If DVal = "False" Then AutoNextLine = False
                        xtrace_i("AutoNextLine = " + AutoNextLine.ToString)
                    End If

                    If DName = "NumberBlocks" Then
                        If DVal = "True" Then NumberBlocks = True
                        If DVal = "False" Then NumberBlocks = False
                        xtrace_i("NumberBlocks = " + NumberBlocks.ToString)
                    End If

                    If DName = "UpdateWhileReading" Then
                        If DVal = "True" Then UpdateWhileReading = True
                        If DVal = "False" Then UpdateWhileReading = False
                        xtrace_i("UpdateWhileReading = " + UpdateWhileReading.ToString)
                    End If

                    If DName = "DelTemplateInDescr" Then
                        If DVal = "True" Then DelTemplateInDescr = True
                        If DVal = "False" Then DelTemplateInDescr = False
                        xtrace_i("DelTemplateInDescr = " + DelTemplateInDescr.ToString)
                    End If

                    If DName = "RemovePath" Then    ' Added 2020-07-17
                        If DVal = "True" Then Form1.RemovePathToolStripMenuItem.Checked = True
                        If DVal = "False" Then Form1.RemovePathToolStripMenuItem.Checked = False
                        xtrace_i("DelTemplateInDescr = " + DelTemplateInDescr.ToString)
                    End If


                End If

            Catch ex As Exception

            End Try
        End While
        ReadFile.Dispose()
    End Sub
End Module
