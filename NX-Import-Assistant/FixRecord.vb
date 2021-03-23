Imports System.IO

Module FixRecord

    Dim OSFN As String = " "
    Dim FN As String           ' File name
    Dim FName As String        ' File name without .prt
    Dim IType As String = " "
    Dim NC As String = " "
    Dim ID As String = " "
    Dim Rev As String = " "
    Dim Spec As String = " "
    Dim Name As String = " "
    Dim Desc As String = " "
    Dim CloneA As String = " "

    Dim RecordNr As Integer
    Dim Is11nc As Boolean
    Dim IsVC As Boolean
    Dim IsSpec As Boolean
    Dim P1 As Integer

    Dim IndexData As String
    Dim IData() As String
    Dim TmpIdSeq As Long


    Sub FixRec1()
        xtrace_subs("FixRec1")

        RecordNr = Form1.DataGridView1.CurrentCell.RowIndex
        xtrace_i("01 RecordNr = " + RecordNr.ToString)

        'Dim Record As System.Windows.Forms.DataGridViewRow
        'Record = DataGridView1.CurrentRow
        'xtrace_i("Row = " + RecNr.ToString)

        OSFN = Form1.DataGridView1.Item(C_FN, RecordNr).Value
        FN = System.IO.Path.GetFileName(OSFN)
        FName = System.IO.Path.GetFileNameWithoutExtension(OSFN)

        ' Fix error 003, Try Added. Checking for "Is Nothing" does not seem to catch DbNull
        Try
            IType = Form1.DataGridView1.Item(C_IT, RecordNr).Value
        Catch ex As Exception
            IType = ""
        End Try
        Try
            NC = Form1.DataGridView1.Item(C_NC, RecordNr).Value
        Catch ex As Exception
            NC = ""
        End Try
        Try
            ID = Form1.DataGridView1.Item(C_ID, RecordNr).Value
        Catch ex As Exception
            ID = ""
        End Try
        Try
            Rev = Form1.DataGridView1.Item(C_RV, RecordNr).Value
        Catch ex As Exception
            Rev = ""
        End Try
        Try
            Spec = Form1.DataGridView1.Item(C_SP, RecordNr).Value
        Catch ex As Exception
            Spec = ""
        End Try
        Try
            Name = Form1.DataGridView1.Item(C_PN, RecordNr).Value
        Catch ex As Exception
            Name = ""
        End Try
        Try
            Desc = Form1.DataGridView1.Item(C_DE, RecordNr).Value
        Catch ex As Exception
            Desc = ""
        End Try
        Try
            CloneA = Form1.DataGridView1.Item(C_CA, RecordNr).Value
        Catch ex As Exception
            CloneA = ""
        End Try

        xtrace_i("02 OSFN     = " + OSFN)
        xtrace_i("03 FileN    = " + FN)
        xtrace_i("04 FileName = " + FName)
        xtrace_i("05 IType    = " + IType)
        xtrace_i("06 NC       = " + NC)
        xtrace_i("07 ID       = " + ID)
        xtrace_i("08 Rev      = " + Rev)
        xtrace_i("09 Spec     = " + Spec)
        xtrace_i("10 Name     = " + Name)
        xtrace_i("11 Desc     = " + Desc)

        If Form1.RemovePathToolStripMenuItem.Checked Then
            OSFN = Path.GetFileName(OSFN)
            xtrace_i("12 OSFN     = " + OSFN)
        Else
            xtrace_i("12 Remove Path Disabeled")
        End If

        xtrace_i("13 Check the description")
        If DelTemplateInDescr Then
            If Desc = Nothing Then
                xtrace_i("Descr undefined")
                Desc = ""
            Else
                P1 = Desc.IndexOf("template", StringComparison.OrdinalIgnoreCase)
            End If
        End If

        xtrace_i("14 Check the ID Index")
        IndexData = CheckFileToIdIndex(OSFN)
        If IndexData <> "" Then
            xtrace_i("Use Index Data")
            IData = Split(IndexData, Sep)
            ID = IData(0)
            Rev = IData(1)

            xtrace_i("Use existing translation")
            Fix_Existing_Translation()

            ' If the translation is missing, and "Use TMP ID" Is enabled
            If (Len(ID) < 2) And (Form1.ComboBoxFixMethod.Text = "Use TMP ID") Then
                Fix_Rec_Use_TmpID()
            End If

        Else
            xtrace_i("15 Check if OS Filename has 11nc")
            Is11nc = RegExpr(FName, "^\d{4}\-\d{3}\-\d{4}")

            If Not Is11nc And (Len(ID) = 13) Then
                xtrace_i("16: Check if Item ID has 11nc")
                If RegExpr(ID, "^\d{4}\-\d{3}\-\d{4}") Then
                    xtrace_i("16  11nc found in Item ID")
                    Is11nc = True
                    NC = ID
                    xtrace_i("16  11nc = " & NC)
                End If
            End If
            xtrace_i("17: Check if VC")
            IsVC = RegExpr(FName, "^[0-2]\d{3}\-\d{3}\-\d{5}")

            If Form1.ComboBoxFixMethod.Text = "Default" Then
                Fix_Rec_Default()
            ElseIf Form1.ComboBoxFixMethod.Text = "Use TMP ID" Then
                Fix_Rec_Use_TmpID()
            End If
        End If



        '---- Write back to database
        xtrace_i("Write back")
        Form1.DataGridView1.Item(C_FN, RecordNr).Value = OSFN
        Form1.DataGridView1.Item(C_IT, RecordNr).Value = IType
        Form1.DataGridView1.Item(C_NC, RecordNr).Value = NC
        Form1.DataGridView1.Item(C_ID, RecordNr).Value = ID
        Form1.DataGridView1.Item(C_RV, RecordNr).Value = Rev
        Form1.DataGridView1.Item(C_SP, RecordNr).Value = Spec
        Form1.DataGridView1.Item(C_PN, RecordNr).Value = Name
        Form1.DataGridView1.Item(C_DE, RecordNr).Value = Desc
        Form1.DataGridView1.Item(C_CA, RecordNr).Value = CloneA

        If AutoNextLine Then Set_Selected_Row_One_Down()
        Do_Events()
        xtrace_sube("FixRec1")
        xtrace_border()
    End Sub

    '---- Fix Existing Translation ------------------------------------------------------

    Sub Fix_Existing_Translation()
        xtrace_subs("Fix_Existing_Translation")
        ' ID
        ' Use existing (from index)

        '---- Specification
        IsSpec = RegExSym(FName, "^(.*)(\-\d{3}\-\d{2})$", "Free naming spec")
        If IsSpec Then
            Dim FN_Item = RegEx_Results(1)
            Dim FN_Sheet = RegEx_Results(2)
            xtrace_i("FN_Item = " & FN_Item)
            xtrace_i("FN_Sheet = " & FN_Sheet)

            Spec = ID & "_" & FN_Sheet

            IType = "Specification"
            Name = Spec
        Else
            IType = "11NC"
            Name = ID
        End If

        '---- Description
        FixDescription()
    End Sub

    '---- Fix Default -------------------------------------------------------------------

    Sub Fix_Rec_Default()
        xtrace_subs("Fix_Rec_Default")

        '---- Use NC
        If Len(NC) = 13 Then
            IType = "11NC"
            ID = NC
            If Len(Rev) < 1 Then Rev = "1A"
            Name = ID
            '---- Is11nc
        ElseIf (Is11nc) And (Not IsVC) Then
            IType = "11NC"
            NC = Left(FName, 13)
            ID = NC
            Rev = Mid(FName, 14, 2)
            Name = ID
        Else
            IType = "Free naming"
            If Len(NC) = 13 Then
                ID = NC
            Else
                ID = Left(UsrPrefix + FName, MaxIdLength)
            End If
            Rev = "1A"
            Name = ID
        End If

        '---- IsVC
        If IsVC Then
            IType = "Std.art."
            NC = Left(FName, 14)
            ID = NC + LibExtension
            Rev = LibRev
            Name = ID
        Else

        End If

        '---- Specification 2020-04-30
        If IType = "Free naming" Then
            IsSpec = RegExSym(FName, "^(.*)(\-\d{3}\-\d{2})$", "Free naming spec")
            If IsSpec Then
                Dim FN_Item = RegEx_Results(1)
                Dim FN_Sheet = RegEx_Results(2)
                xtrace_i("FN_Item = " & FN_Item)
                xtrace_i("FN_Sheet = " & FN_Sheet)

                IType = "Specification"
                If Len(NC) = 13 Then
                    ID = NC
                    Spec = NC + Rev + FN_Sheet
                Else
                    ' Redo Item
                    ID = Left(UsrPrefix + FN_Item, MaxIdLength)
                    Spec = ID + Rev + FN_Sheet
                End If

                If Len(Desc) < 4 Then Desc = FN_Item
            End If
        Else
            IsSpec = RegExpr(FName, "^\d{4}\-\d{3}\-\d{5}\w\-\d{3}\-\d{2}")
            If IsSpec Then
                IType = "Specification"
                Spec = Left(FName, 22)
                Name = Spec
            End If
        End If

        '---- Description
        FixDescription()

        '---- Cloning Action
        CloneA = Check_CA(CloneA)

    End Sub

    '---- Use Free Naming Tmp -----------------------------------------------------------

    Sub Fix_Rec_Use_TmpID()
        xtrace_subs("Fix_Rec_Use_TmpID")
        Dim TestID As Long

        '---- Is11nc
        If (Is11nc) And (Not IsVC) Then
            IType = "11NC"
            NC = Left(FName, 13)
            ID = NC
            Rev = Mid(FName, 14, 2)
            Name = ID
        Else
            IType = "Free naming"
            ID = DateTime.Today.Year.ToString +
                 DateTime.Today.Month.ToString +
                 DateTime.Today.Day.ToString +
                 DateTime.Now.Hour.ToString +
                 DateTime.Now.Minute.ToString +
                 DateTime.Now.Second.ToString +
                 Left(DateTime.Now.Millisecond.ToString, 1)     ' Added 2020-07-17
            xtrace_i("Assign " & ID)

            ' Check Added 2020-07-21
            TestID = Val(ID)
            If TestID <= TmpIdSeq Then
                TestID = TmpIdSeq + 1
                ID = TestID.ToString
                xtrace_i("Inc to " + ID)
            End If
            TmpIdSeq = TestID

            ID = "IMP-" + ID
            Rev = "1A"
            Name = ID
        End If

        '---- IsVC
        If IsVC Then
            IType = "Std.art."
            NC = Left(FName, 14)
            ID = NC + LibExtension
            Rev = LibRev
            Name = ID
        Else

        End If

        '---- Specification
        IsSpec = RegExpr(FName, "^\d{4}\-\d{3}\-\d{5}\w\-\d{3}\-\d{2}")
        If IsSpec Then
            IType = "Specification"
            Spec = Left(FName, 22)
            Name = Spec
        End If

        '---- Description
        FixDescription()

        '---- Cloning Action
        CloneA = Check_CA(CloneA)

    End Sub

    Sub FixDescription()
        xtrace_subs("FixDescription")
        xtrace_i("Desc In : """ & Desc & """")

        If Desc = Nothing Then Desc = ""
        Desc = Desc.Trim

        ' Remove 12nc
        If Len(Desc) > 9 Then

            If RegExpr(Desc, "^\d{4}\-\d{3}\-\d{5} \- ") Then
                Desc = Mid(Desc, 18)
            End If

            If RegExpr(Desc, "^\d{4}\-\d{3}\-\d{5}") Then
                Desc = Mid(Desc, 15)
            End If

            If RegExpr(Desc, "^\d{4}\-\d{3}\-\d{4}") Then
                Desc = Mid(Desc, 14)
            End If

            Desc = Desc.Trim
        End If

        If Len(Desc) < 4 Then
            Desc = Path.GetFileNameWithoutExtension(FName)
            Desc = Replace(Desc, "_", " ")
        End If

        xtrace_i("Description = """ & Desc & """")
        xtrace_sube("FixDescription")
    End Sub

    '==== Selected Row one down =========================================================

    Sub Set_Selected_Row_One_Down()
        Dim NewRecNr = RecordNr + 1
        xtrace_subs("Set_Selected_Row_One_Down")
        xtrace_i("RecordNr = " + RecordNr.ToString)
        xtrace_i("RowCount = " + Form1.DataGridView1.RowCount.ToString)

        If NewRecNr < Form1.DataGridView1.RowCount - 1 Then
            Form1.DataGridView1.ClearSelection()
            Form1.DataGridView1.CurrentCell = Form1.DataGridView1.Rows(NewRecNr).Cells(0)
            Form1.DataGridView1.Rows(NewRecNr).Selected = True
        End If

    End Sub

    '==== Chech the Cloning Action Value ===============================================

    Function Check_CA(Val As String) As String
        xtrace_i("Check Cloning Action Value")
        Dim Valid As Boolean = False

        Val = UCase(Val)
        If Val = "USE EXISTING" Then Val = "USE_EXISTING"

        For Each Str As String In CA_Range
            If Str = Val Then Valid = True
        Next

        If Not Valid Then Val = CA_Default

        Check_CA = Val
    End Function

End Module
