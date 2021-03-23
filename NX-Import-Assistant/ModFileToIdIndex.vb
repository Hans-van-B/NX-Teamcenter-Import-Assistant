Imports System.IO

Module ModFileToIdIndex
    Dim Header As String = "OSFileName;ItemId;Rev"
    Dim file As System.IO.StreamWriter
    Dim FileSplitSize As Integer = 50

    Sub SaveFileToIdIndex()
        xtrace_subs("SaveFileToIdIndex")
        If FileToIdInitialized Then
            WriteHistory("Save Item ID Index")

            xtrace_i("Save index file to: " & FileToIdFName)
            ShowStatus("Save index file, please wait...  ")

            Dim FName, Record As String
            Dim WriteFile
            WriteFile = My.Computer.FileSystem.OpenTextFileWriter(FileToIdFName, False)
            WriteFile.WriteLine(Header)

            For Each FName In FileToIdIndex.Keys
                Record = FileToIdIndex(FName)
                Record = FName & Sep & Record
                WriteFile.WriteLine(Record, True)
            Next
            WriteFile.Close
            WriteFile.Dispose

            '---- Slow writing --------------------
            'My.Computer.FileSystem.WriteAllText(FileToIdFName, Header & vbNewLine, False)
            '
            'For Each FName In FileToIdIndex.Keys
            '   Record = FileToIdIndex(FName)
            '   Record = FName & Sep & Record
            '   My.Computer.FileSystem.WriteAllText(FileToIdFName, Record & vbNewLine, True)
            'Next
        Else
            ' No need for a warning, this save is implicit, never explicit
            xtrace_i("The Item Index is not loaded")
            ' MsgBox("The Item Index is not loaded", vbExclamation, "Warning:")
        End If
        xtrace_sube("SaveFileToIdIndex")
    End Sub

    Sub LoadFileToIdIndex()
        xtrace_subs("LoadFileToIdIndex")
        Dim Count As Integer = 0

        Try
            If Form1.OpenFileDialog3.ShowDialog(Form1) = System.Windows.Forms.DialogResult.OK Then
                WriteHistory("Load Item ID Index")

                FileToIdFName = Form1.OpenFileDialog3.FileName
                WriteInfo("Open Id Index: " + FileToIdFName)

                Dim ReadFile
                Dim Line As String
                Dim LData() As String
                Dim FName, Item, Rev As String
                ReadFile = My.Computer.FileSystem.OpenTextFileReader(FileToIdFName)

                While Not ReadFile.EndOfStream
                    Try
                        Line = ReadFile.ReadLine()
                        LData = Split(Line, Sep)

                        FName = LData(0)
                        Item = LData(1)
                        Rev = LData(2)

                        If FName = "OSFileName" Then Continue While
                        FileToIdIndex.Add(FName, Item & Sep & Rev)
                        Count = Count + 1
                    Catch ex As Exception
                        xtrace("Err1")
                        xtrace(ex.Message)
                    End Try
                End While

                ReadFile.Dispose()

                ActivateIdIndex()
            End If
        Catch ex As Exception
            xtrace("Err2")
            xtrace(ex.Message)
            If (InStr(ex.Message, "being used by another process") > 1) Then MsgBox("This file is locked by another process", vbExclamation, "Warning")
        End Try
        ' xtrace_i(Count.ToString & " Records read")
        ShowStatus(Count.ToString & " Records read")

        xtrace_i("ActivateIdIndex = " & FileToIdInitialized.ToString)
        xtrace_sube("LoadFileToIdIndex")
    End Sub

    Sub UpdateFileToIdIndexRec(FName As String,
                               Item As String,
                               Rev As String)
        If FileToIdInitialized Then
            If FileToIdIndex.ContainsKey(FName) Then
                xtrace_i("Update FileToIdIndex Rec")
                FileToIdIndex.Item(FName) = Item & Sep & Rev
            Else
                xtrace_i("Add FileToIdIndex Rec")
                FileToIdIndex.Add(FName, Item & Sep & Rev)
            End If
        End If
    End Sub

    Sub CreateFileToIdIndex()
        If Form1.SaveFileDialog3.ShowDialog = DialogResult.OK Then
            FileToIdFName = Form1.SaveFileDialog3.FileName
            xtrace_i("Create: """ + FileToIdFName + """")

            My.Computer.FileSystem.WriteAllText(FileToIdFName, Header & vbNewLine, False)
            ActivateIdIndex()
        End If
    End Sub

    Sub ActivateIdIndex()
        xtrace_subs("ActivateIdIndex")
        FileToIdInitialized = True
        Form1.ToolStripStatusLabel2.Text = "Item ID Index = Active"
        Form1.ToolStripStatusLabel2.BackColor = Color.LightGreen
    End Sub

    ' Add file without path
    Function CheckFileToIdIndex(FName As String) As String
        Dim FName2 As String = Path.GetFileName(FName)

        xtrace_i("CheckFileToIdIndex for " & FName)

        If Not FileToIdInitialized Then
            xtrace_i("Index not initialized")

        ElseIf FileToIdIndex.ContainsKey(FName) Then
            xtrace_i("Found (1)")
            CheckFileToIdIndex = FileToIdIndex.Item(FName)

        ElseIf FileToIdIndex.ContainsKey(FName2) Then
            xtrace_i("Found (2)")
            CheckFileToIdIndex = FileToIdIndex.Item(FName2)

        Else
            xtrace_i("Not found")
            CheckFileToIdIndex = ""
        End If

    End Function

    '===== Create Dummy Import / Reserve Item ID's ======================================

    Sub Reserve_TC_Items()
        xtrace_subs("Reserve_TC_Items")
        If FileToIdInitialized Then
            ShowStatus("Save index file")

            xtrace_i("Check target dir")
            Dim DDir = Path.GetDirectoryName(FileToIdFName) & "\DummyImport"
            If Not My.Computer.FileSystem.DirectoryExists(DDir) Then
                xtrace_i("Create " & DDir)
                My.Computer.FileSystem.CreateDirectory(DDir)
            End If

            xtrace_i("Select template part")
            If Form1.OpenFileDialog4.ShowDialog(Form1) = System.Windows.Forms.DialogResult.OK Then

                Dim DummyPart As String = Form1.OpenFileDialog4.FileName
                Dim DummyCopy As String = DDir & "\Dummy.prt"
                Dim Target As String
                xtrace_i("Template part = " & DummyPart)


                If DummyPart <> DummyCopy Then
                    Try
                        xtrace_i("Create copy " & DummyCopy)
                        FileCopy(DummyPart, DummyCopy)
                    Catch ex As Exception
                        xtrace(ex.Message)
                    End Try
                Else
                    xtrace("Copy " & DummyCopy & " already exists")
                End If
                xtrace_i("DummyPart: """ + DummyPart + """")

                ShowStatus("Creating dummy parts:")
                Dim Cnt As Integer = 0

                For Each FName In FileToIdIndex.Keys
                    xtrace_i("Create " & FName)
                    Target = DDir & "\" & Path.GetFileName(FName)

                    If Not My.Computer.FileSystem.FileExists(Target) Then
                        Try
                            Cnt = Cnt + 1
                            ShowStatus("Creating dummy part " & Cnt.ToString)
                            FileCopy(DummyPart, Target)
                        Catch ex As Exception
                            xtrace(ex.Message)
                        End Try
                    End If
                Next
                xtrace_i("Done.")

                ShowStatus("Create clone file:")
                If Form1.SaveFileDialog2.ShowDialog = DialogResult.OK Then

                    Dim Filename As String
                    Filename = Form1.SaveFileDialog2.FileName

                    If Form1.ReserveItensSplitToolStripMenuItem.Checked Then
                        Write_Split_Clone_File(Filename, DDir)
                    Else
                        Write_One_Clone_File(Filename, DDir)
                    End If

                End If

            Else
                xtrace_i("Warning: The Item Index is not loaded")
                MsgBox("The Item Index is not loaded", vbExclamation, "Warning:")
            End If
        End If

        xtrace_sube("Reserve_TC_Items")
    End Sub

    '---- Write Header -------------------------------------------------------------
    Private Sub Write_Clone_File_Header()
        xtrace_i("Write file header")
        file.WriteLine("===============================================")
        file.WriteLine("      TEAMCENTER INTEGRATION IMPORT LOG")
        file.WriteLine("        Date - " & DateTime.Now)
        file.WriteLine("===============================================")
        file.WriteLine("")
        file.WriteLine("-----------------------------------------------")
        file.WriteLine("Default Parameters")
        file.WriteLine("-----------------------------------------------")
        file.WriteLine("&LOG Operation_Type: IMPORT_OPERATION")
        file.WriteLine("&LOG Default_Cloning_Action: USE_EXISTING")  ' Reserve Items should never overwrite
        file.WriteLine("&LOG Default_Naming_Technique: OSFILE_NAME Default_Name_Rule_Type: AS_ID_REVISION")
        file.WriteLine("&LOG Default_Container: """ & Form1.ComboBoxFolder.Text & """")
        file.WriteLine("&LOG Default_Part_Type: Item")
        file.WriteLine("&LOG Default_Part_Name: ""${DB_PART_NAME}""")
        file.WriteLine("&LOG Default_Part_Description: ""${DB_PART_DESC}""")
        file.WriteLine("&LOG Default_Associated_Files_Directory: """"")
        file.WriteLine("&LOG Default_DB_Owner: " + Form1.ComboBoxUser.Text + " " + Form1.ComboBoxGrp.Text)
        file.WriteLine("&LOG Default_Validation_Mode: OFF")
        file.WriteLine("")

        xtrace_i("Write part info")
        file.WriteLine("-----------------------------------------------")
        file.WriteLine("Part Specific Information")
        file.WriteLine("-----------------------------------------------")
    End Sub

    '---- Write One Clone File -----------------------------------------------------
    Private Sub Write_One_Clone_File(Filename As String,
                                     DDir As String)
        ShowStatus("Creating clone file...")

        xtrace_i("Save to " + Filename)
        file = My.Computer.FileSystem.OpenTextFileWriter(Filename, False)
        Write_Clone_File_Header()

        Dim Record As String
        Dim Data() As String
        Dim OSFN As String
        Dim FName As String
        Dim ID As String
        Dim Rev As String
        Dim FName_List As New Hashtable
        Dim ID_List As New Hashtable
        Dim CountDuplicateFN As Integer = 0
        Dim CountDuplicateID As Integer = 0
        Dim Cnt As Integer = 0

        For Each FName In FileToIdIndex.Keys
            Record = FileToIdIndex(FName)
            Data = Split(Record, Sep)

            OSFN = Path.GetFileName(FName)
            ID = Data(0)
            Rev = Data(1)
            If FName_List.ContainsKey(OSFN) Then
                CountDuplicateFN = CountDuplicateFN + 1
                Continue For
            End If

            If ID_List.ContainsKey(ID) Then
                CountDuplicateID = CountDuplicateID + 1
                Continue For
            End If
            Cnt = Cnt + 1
            ShowStatus("Creating clone ID " & Cnt.ToString)

            FName_List.Add(OSFN, "X")
            ID_List.Add(ID, "X")

            file.WriteLine("--- " & Cnt.ToString)
            file.WriteLine("&LOG Part: """ + OSFN + """")
            file.WriteLine("&LOG Cloning_Action: DEFAULT_DISP")
            file.WriteLine("&LOG Naming_Technique: USER_NAME Clone_Name: ""@DB/" + ID + "/" + Rev + """")
            file.WriteLine("&LOG Container: """"")
            file.WriteLine("&LOG Part_Type: Item")
            file.WriteLine("&LOG Part_Name: """ + ID + """")
            file.WriteLine("&LOG Part_Description: ""Dummy Item " & Cnt.ToString & """")
            file.WriteLine("&LOG Associated_Files_Directory: """"")

        Next
        file.WriteLine("&LOG ")
        file.Close()
        file.Dispose()
        ShowStatus("Done.")
        If CountDuplicateID > 0 Then MsgBox(CountDuplicateID.ToString & " Duplicate ID's skipped.", vbExclamation, "Warning:")
        If CountDuplicateFN > 0 Then MsgBox(CountDuplicateFN.ToString & " Duplicate OS File names skipped.", vbExclamation, "Warning:")
        MsgBox("Now use " & Filename & "To import the dummy files", vbInformation, "Tip:")

    End Sub


    '---- Write Split Clone File ---------------------------------------------------
    Private Sub Write_Split_Clone_File(Filename As String,
                                       DDir As String)
        ShowStatus("Creating split clone file...")

        Dim Record As String
        Dim Data() As String
        Dim OSFN As String
        Dim FName As String
        Dim ID As String
        Dim Rev As String
        Dim FName_List As New Hashtable
        Dim ID_List As New Hashtable
        Dim CountDuplicateFN As Integer = 0
        Dim CountDuplicateID As Integer = 0
        Dim Cnt As Integer = 0
        Dim FICnt As Integer = 0    ' File Item Count
        Dim FNCnt As Integer = 0    ' Fine Nr Count
        Dim FileName1 As String = Path.GetFileNameWithoutExtension(Filename)
        Dim FileName2 As String

        For Each FName In FileToIdIndex.Keys
            FICnt = FICnt + 1
            If FICnt = 1 Then
                FNCnt = FNCnt + 1
                FileName2 = DDir & "\" & FileName1 & "_" & FNCnt.ToString & ".clone"
                xtrace_i("Save to " + FileName2)
                file = My.Computer.FileSystem.OpenTextFileWriter(FileName2, False)
                Write_Clone_File_Header()
            End If

            Record = FileToIdIndex(FName)
            Data = Split(Record, Sep)

            OSFN = Path.GetFileName(FName)
            ID = Data(0)
            Rev = Data(1)
            If FName_List.ContainsKey(OSFN) Then
                CountDuplicateFN = CountDuplicateFN + 1
                Continue For
            End If

            If ID_List.ContainsKey(ID) Then
                CountDuplicateID = CountDuplicateID + 1
                Continue For
            End If
            Cnt = Cnt + 1
            ShowStatus("Creating clone ID " & Cnt.ToString)

            FName_List.Add(OSFN, "X")
            ID_List.Add(ID, "X")

            file.WriteLine("--- " & Cnt.ToString)
            file.WriteLine("&LOG Part: """ + OSFN + """")
            file.WriteLine("&LOG Cloning_Action: DEFAULT_DISP")
            file.WriteLine("&LOG Naming_Technique: USER_NAME Clone_Name: ""@DB/" + ID + "/" + Rev + """")
            file.WriteLine("&LOG Container: """"")
            file.WriteLine("&LOG Part_Type: Item")
            file.WriteLine("&LOG Part_Name: """ + ID + """")
            file.WriteLine("&LOG Part_Description: ""Dummy Item " & Cnt.ToString & """")
            file.WriteLine("&LOG Associated_Files_Directory: """"")

            If FICnt >= FileSplitSize Then
                file.WriteLine("&LOG ")
                file.Close()

                FICnt = 0
            End If
        Next

        file.WriteLine("&LOG ")
        file.Close()
        file.Dispose()

        ShowStatus("Done.")
        If CountDuplicateID > 0 Then MsgBox(CountDuplicateID.ToString & " Duplicate ID's skipped.", vbExclamation, "Warning:")
        If CountDuplicateFN > 0 Then MsgBox(CountDuplicateFN.ToString & " Duplicate OS File names skipped.", vbExclamation, "Warning:")
        MsgBox("Now use " & Filename & "To import the dummy files", vbInformation, "Tip:")

    End Sub

    '==== Check For missing Items =======================================================

    Sub Check_Index_For_Missing_Items()
        xtrace_subs("Check_Index_For_Missing_Items")
        If Form1.OpenFileDialog5.ShowDialog(Form1) = System.Windows.Forms.DialogResult.OK Then
            Dim ChkName As String = Form1.OpenFileDialog5.FileName
            xtrace_i("Open: " & ChkName)
            Dim ReadFile
            Dim Line As String
            ReadFile = My.Computer.FileSystem.OpenTextFileReader(ChkName)

            While Not ReadFile.EndOfStream
                Line = ReadFile.ReadLine()
                Line = Line.Trim

                If FileToIdIndex.ContainsKey(Line) Then
                    xtrace_i("Exists")
                Else
                    xtrace_i("Add: " & Line)
                    FileToIdIndex.Add(Line, "ZZ_ToDo")
                End If
            End While

            ReadFile.Close()
            ReadFile.Dispose()
        Else

        End If
        xtrace_sube("Check_Index_For_Missing_Items")
    End Sub
End Module
