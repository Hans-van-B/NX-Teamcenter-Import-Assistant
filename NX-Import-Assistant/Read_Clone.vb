
Module Read_Clone
    ' https://visualstudiocodes.blogspot.com/2019/11/datagridview-data-export-to-excel-in.html
    ' https://www.youtube.com/watch?v=5i1q6Qy2M5w

    Dim OSFN As String
    Dim TopAs As String
    Dim IType As String
    Dim NC As String
    Dim ID As String
    Dim Rev As String
    Dim Spec As String
    Dim Name As String
    Dim Desc As String
    Dim CloneA As String

    Dim EOB As Boolean
    Dim EV As String = "<Empty>"    ' Empty Value

    Sub RC_Record_Reset()
        xtrace_i("Record reset")
        OSFN = " "
        TopAs = "N"
        IType = "11NC"
        NC = " "
        ID = " "
        Rev = " "
        Spec = " "
        Name = " "
        Desc = " "
        CloneA = "DEFAULT_DISP"

        EOB = False
    End Sub


    Sub ResetDb()
        xtrace_i("Reset DB")
        Form1.DataGridView1.Columns.Clear()
        Application.DoEvents()

        Dim ColTA As New DataGridViewComboBoxColumn
        ColTA.Name = "TopAssy"
        ColTA.HeaderText = "Top Assy"
        ColTA.Items.Add("Y")
        ColTA.Items.Add("N")

        Dim ColType As New DataGridViewComboBoxColumn
        ColType.Name = "ItemType"
        ColType.HeaderText = "Item Type"
        ColType.Items.Add("11NC")
        ColType.Items.Add("Std.art.")
        ColType.Items.Add("Specification")
        ColType.Items.Add("Free naming")

        Dim ColCA As New DataGridViewComboBoxColumn
        ColCA.Name = "CloneAction"
        ColCA.HeaderText = "Cloning Action"
        For Each Str As String In CA_Range
            ColCA.Items.Add(Str)
        Next

        Form1.DataGridView1.Columns.Add("OsFileName", "OS FILE NAME")   ' 0
        Form1.DataGridView1.Columns.Add(ColTA)                          ' 1
        Form1.DataGridView1.Columns.Add(ColType)                        ' 2
        Form1.DataGridView1.Columns.Add("Nc", "11/12 NC")               ' 3
        Form1.DataGridView1.Columns.Add("ItemID", "TC Item ID")         ' 4
        Form1.DataGridView1.Columns.Add("Rev", "TC Rev")                ' 5
        Form1.DataGridView1.Columns.Add("Spec", "Specification")        ' 6
        Form1.DataGridView1.Columns.Add("PartName", "Part Name")        ' 7
        Form1.DataGridView1.Columns.Add("Description", "Description")   ' 8
        Form1.DataGridView1.Columns.Add(ColCA)                          ' 9

        'Form1.DataGridView1.Columns(C_TA).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Form1.DataGridView1.Columns(C_FN).Width = 200
        Form1.DataGridView1.Columns(C_TA).Width = 40
        Form1.DataGridView1.Columns(C_IT).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Form1.DataGridView1.Columns(C_ID).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Form1.DataGridView1.Columns(C_SP).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Form1.DataGridView1.Columns(C_CA).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        Form1.DataGridView1.Columns(C_RV).Width = 35

        Application.DoEvents()
    End Sub


    '---- Read clone file ---------------------------------------------------------------

    Sub Read_Clone_File()
        xtrace(" ")
        xtrace_border()
        xtrace_subs("Read_Clone_File")
        xtrace_border()

        Dim CFLN As Integer = 0  ' Clone file line number
        Dim CFLNS As String
        Dim Count As Integer
        Dim FileName As String


        If Form1.OpenFileDialog2.ShowDialog(Form1) = System.Windows.Forms.DialogResult.OK Then
            WriteHistory("Open Clone file")

            ResetDb()
            ' AutoSize While loading
            Form1.DataGridView1.Columns(C_NC).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            Form1.DataGridView1.Columns(C_PN).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            Form1.DataGridView1.Columns(C_DE).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

            FileName = Form1.OpenFileDialog2.FileName
            WriteInfo("Read Clone File: " + FileName)

            Dim ReadFile = My.Computer.FileSystem.OpenTextFileReader(Form1.OpenFileDialog2.FileName)
            Dim Line As String
            Dim P1, P2, P3, PA As Integer   ' PA = Pos Alternative
            Dim Str1 As String
            Dim Header As Boolean = True

            '---- Reset record
            RC_Record_Reset()

            If QuickLoad Then
                xtrace_i("Hide the datagrid to load faster")
                Form1.DataGridView1.Visible = False
            End If

            While Not ReadFile.EndOfStream
                If Break Then
                    Do_Break()
                    Exit While
                End If

                Line = ReadFile.ReadLine()
                CFLN = CFLN + 1
                '---- Create heading Clone File Line Number String
                CFLNS = CFLN.ToString
                While Len(CFLNS) < 3
                    CFLNS = "0" + CFLNS
                End While

                xtrace(CFLNS + " " + Line)

                '---- Read Header -----------------------------------

                If Header Then
                    If Left(Line, 29) = "&LOG Default_Cloning_Action: " Then
                        Form1.ComboBoxDfltCloneAction.Text = Mid(Line, 30)
                    End If
                End If

                '---- Check EOB -------------------------------------
                Line = Line.TrimEnd

                If (Len(Line) < 8) Or (Left(Line, 5) <> "&LOG ") Then
                    xtrace_i("EOB", 3)

                    '---- Write Record
                    If (ID <> " ") And (Rev <> " ") Then
                        Add_Record(OSFN, TopAs, IType, NC, ID, Rev, Spec, Name, Desc, CloneA)
                        Count = Count + 1
                    End If

                    '---- Reset record
                    RC_Record_Reset()
                    Continue While
                End If

                '---- Read item block -------------------------------
                If Left(Line, 5) = "&LOG " Then

                    '---- Part
                    P1 = InStr(1, Line, " Part: """)
                    If P1 > 1 Then
                        Header = False
                        P1 = P1 + 8
                        P2 = InStr(P1, Line, """")
                        xtrace(" 1 : Part " + P1.ToString + "," + P2.ToString)
                        If P2 > P1 Then
                            OSFN = Mid(Line, P1, P2 - P1)
                            xtrace("     Part = " + OSFN)
                        Else
                            WarningAtLine("Quote mismatch", CFLN)
                        End If

                    ElseIf InStr(1, Line, " Part: ") > 0 Then
                        WarningAtLine("Part without quotes", CFLN)
                    End If

                    '---- Cloning Action
                    P1 = InStr(1, Line, " Cloning_Action: ")
                    If P1 > 1 Then
                        P1 = P1 + 17
                        xtrace(" 1 : Part " + P1.ToString)
                        CloneA = Mid(Line, P1).Trim
                        xtrace("     CloneA = " + CloneA)

                        CloneA = Check_CA(CloneA)
                    End If

                    '---- Top Assembly
                    P1 = InStr(1, Line, " TOP_ASSEMBLY Part")
                    If P1 > 1 Then
                        TopAs = "Y"
                    End If

                    '---- Clone Name
                    P1 = InStr(1, Line, "Clone_Name: ""@DB")
                    If P1 > 1 Then
                        P1 = P1 + 17
                        P2 = InStr(P1, Line, "/")
                        xtrace(" 2 : Item " + P1.ToString + "," + P2.ToString)
                        If P2 > P1 Then
                            ID = Mid(Line, P1, P2 - P1).Trim
                            xtrace("     Item = " + ID)
                        Else
                            WarningAtLine("Separator 1 missing", CFLN)
                        End If


                        P1 = P2 + 1
                        P2 = InStr(P1, Line, """")
                        P3 = InStr(P1, Line, "/")

                        ' Item Rev
                        If P3 = 0 Then
                            P2 = P2
                            xtrace(" 3a: Rev " + P1.ToString + "," + P2.ToString)
                            Rev = Mid(Line, P1, P2 - P1).Trim
                            xtrace("     Rev = " + Rev)

                        Else  ' Specification Rev
                            P2 = P3
                            xtrace(" 3b: Rev " + P1.ToString + "," + P2.ToString)
                            Rev = Mid(Line, P1, P2 - P1).Trim
                            xtrace("     Rev = " + Rev)

                            ' Specification
                            P1 = P2 + 1
                            Str1 = Mid(Line, P1, 13)
                            xtrace_i("Str1 = " + Str1)
                            If Str1 = "specification" Then
                                P1 = P1 + 14
                                xtrace(" 4b: Spec " + P1.ToString)
                                P2 = InStr(P1, Line, """")
                                Spec = Mid(Line, P1, P2 - P1)
                                xtrace("     Spec = " + Spec)
                                IType = "Specification"
                            End If
                        End If
                    End If

                    '---- Empty Clone Name
                    P1 = InStr(1, Line, "Clone_Name: """"")
                    If P1 > 1 Then
                        ID = EV
                        Rev = EV
                    End If


                    '---- Part Name
                    P1 = InStr(1, Line, "Part_Name: """)
                    PA = InStr(1, Line, "Part_Name: ")
                    If P1 > 1 Then
                        P1 = P1 + 12
                        P2 = InStr(P1, Line, """")
                        xtrace(" 5 : Name " + P1.ToString + "," + P2.ToString)
                        Name = Mid(Line, P1, P2 - P1).Trim
                        xtrace("     Name = " + Name)

                    ElseIf PA > 1 Then  ' No Quotes
                        P1 = PA + 11
                        Name = Mid(Line, P1).Trim
                        xtrace("     Name = " + Name)
                    End If

                    '---- Description
                    P1 = InStr(1, Line, "Part_Description: """)
                    PA = InStr(1, Line, "Part_Description: ")
                    If P1 > 1 Then
                        P1 = P1 + 19
                        P2 = InStr(P1, Line, """")
                        xtrace(" 6 : Desc " + P1.ToString + "," + P2.ToString)
                        Desc = Mid(Line, P1, P2 - P1)
                        xtrace("     Desc = " + Desc)

                    ElseIf PA > 1 Then  ' No Quotes
                        P1 = PA + 18
                        Desc = Mid(Line, P1).Trim
                        xtrace("     Desc = " + Desc)
                    End If

                End If

                xtrace("")
            End While
        Else
            xtrace_i("Read Clone Canceled")
        End If

        ' Enable resize after loading
        Dim W As Integer
        W = Form1.DataGridView1.Columns(C_ID).Width
        Form1.DataGridView1.Columns(C_ID).AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
        Form1.DataGridView1.Columns(C_ID).Width = W

        W = Form1.DataGridView1.Columns(C_PN).Width
        Form1.DataGridView1.Columns(C_PN).AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
        Form1.DataGridView1.Columns(C_PN).Width = W

        W = Form1.DataGridView1.Columns(C_ID).Width
        Form1.DataGridView1.Columns(C_DE).AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
        Form1.DataGridView1.Columns(C_DE).Width = W

        Form1.DataGridView1.Visible = True
        ShowStatus(Count.ToString & " Items loaded.")
        xtrace_border()
    End Sub

    '---- Add Record --------------------------------------------------------------------

    Sub Add_Record(OSFN As String,
                   TopAs As String,
                   IType As String,
                   NC As String,
                   ID As String,
                   Rev As String,
                   Spec As String,
                   Name As String,
                   Desc As String,
                   CloneA As String)

        xtrace_subs("Add Record")
        Dim RC As Integer   ' Record count
        Dim CC As Integer
        Dim CR As Integer   ' Current record

        CC = Form1.DataGridView1.ColumnCount
        xtrace_i("Column Count = " + CC.ToString)

        RC = Form1.DataGridView1.Rows.Count
        xtrace_i("Record Count = " + RC.ToString)
        CR = RC - 1
        xtrace_i("Current Record = " + CR.ToString)

        If IfIDExist(ID) Then WarningAtLine("ID " & ID & "Already exists", RC)
        If IfPartFileExist(OSFN) Then WarningAtLine("OS File Name " & OSFN & "Already exists", RC)

        ShowStatus("Read record " + CR.ToString + " : " + ID, True)
        Do_Events()

        Form1.DataGridView1.Rows.Add()

        xtrace("   Add OSFN", 3)
        Form1.DataGridView1.Item(C_FN, CR).Value = OSFN

        xtrace("   Add Top Assy = '" + TopAs + "'", 3)
        Try
            Form1.DataGridView1.Item(C_TA, CR).Value = TopAs
        Catch ex As Exception
            xtrace("Error while setting 'Top Assy' in line " + CR.ToString + ": " + ex.Message)
        End Try

        xtrace("   Add Item Type = '" + IType + "'", 3)
        Try
            Form1.DataGridView1.Item(C_IT, CR).Value = IType
        Catch ex As Exception
            xtrace("Error while setting 'Item Type' in line " + CR.ToString + ": " + ex.Message)
        End Try

        xtrace("   Add NC = '" + NC + "'", 3)
        Form1.DataGridView1.Item(C_NC, CR).Value = NC
        Form1.DataGridView1.Item(C_ID, CR).Value = ID
        Form1.DataGridView1.Item(C_RV, CR).Value = Rev
        Form1.DataGridView1.Item(C_SP, CR).Value = Spec
        Form1.DataGridView1.Item(C_PN, CR).Value = Name
        Form1.DataGridView1.Item(C_DE, CR).Value = Desc

        xtrace("   Add Clone Action = '" + CloneA + "'", 3)
        Try
            Form1.DataGridView1.Item(C_CA, CR).Value = CloneA
        Catch ex As Exception
            xtrace("Error while setting 'Clone Action' in line " + CR.ToString + ": " + ex.Message)
        End Try


    End Sub


End Module
