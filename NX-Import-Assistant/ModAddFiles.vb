Imports System.IO
Module ModAddFiles
    Dim OSFN As String = ""
    Dim TopAs As String = ""
    Dim IType As String = ""
    Dim NC As String = ""
    Dim ID As String = Undefined
    Dim Rev As String = ""
    Dim Spec As String = ""
    Dim Name As String = ""
    Dim Desc As String = ""
    Dim CloneA As String = ""

    Dim CountAdd As Integer = 0

    Sub Add_Files()
        xtrace_subs("Add Files")

        Dim files As String()
        Dim file As String

        If Form1.OpenFileDialog6.ShowDialog(Form1) = System.Windows.Forms.DialogResult.OK Then
            WriteHistory("Add OS Files")

            files = Form1.OpenFileDialog6.FileNames
            xtrace_i("Selected " & files.Length.ToString & " part files")

            For Each file In files
                Add_Rec_If_Not_Exist(file)
            Next
        End If
        '---- Select OS File Names

        '---- Add Records With OS Filename

    End Sub

    Private Sub Add_Rec_If_Not_Exist(OSFN As String)
        xtrace_subs("Add_Rec_If_Not_Exist")

        If IfPartFileExist(OSFN) Then
            xtrace_i("Exists : " & OSFN)
        Else
            xtrace_i("Add    : " & OSFN)
            CountAdd = CountAdd + 1

            Rev = "1A"
            Desc = Path.GetFileNameWithoutExtension(OSFN)
            FixDescription()
            CloneA = CA_Default
            Add_Record(OSFN, TopAs, IType, NC, ID, Rev, Spec, Name, Desc, CloneA)
        End If

        xtrace_sube("Add_Rec_If_Not_Exist")
    End Sub

    Sub Add_Files2()
        xtrace_subs("Add Files From TXT List (Add_Files2)")
        CountAdd = 0

        If Form1.OpenFileDialog5.ShowDialog(Form1) = System.Windows.Forms.DialogResult.OK Then
            xtrace_subs("Add_Files2")
            ShowStatus("Adding OS Files...")

            Dim ChkName As String = Form1.OpenFileDialog5.FileName
            WriteInfo("Add OS Files from TXT list: " & ChkName)

            xtrace_i("Open: " & ChkName)
            Dim ReadFile
            Dim Line As String
            ReadFile = My.Computer.FileSystem.OpenTextFileReader(ChkName)

            While Not ReadFile.EndOfStream
                If Break Then
                    Do_Break()
                    Exit While
                End If

                Line = ReadFile.ReadLine()
                Line = Line.Trim

                Add_Rec_If_Not_Exist(Line)
            End While

            ReadFile.Close()
            ReadFile.Dispose()
        Else

        End If

        ShowStatus("Done. (" & CountAdd.ToString & " Added)")
        xtrace_sube("Add_Files2")
    End Sub

End Module
