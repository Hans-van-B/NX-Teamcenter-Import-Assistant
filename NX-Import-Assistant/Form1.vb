
Public Class Form1
    '==== Initialize application ==============================================

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ShowStatus("Initializing")
        Me.Text = AppName + " - " + AppVer
        xtrace_init()
        WriteInfo("Log file = " & LogFile)
        xtrace("Initializing")
        ReadDefaults()
        ShowStatus("Done")
        TextBoxUsrPrefix.Text = UsrPrefix
        ComboBoxUser.Text = Environment.UserName

        ' Excel
        OpenFileDialog1.Title = "Open clone data from Excel file"
        OpenFileDialog1.Filter = "Excel |*.xlsx|Excel Old |*.xls|All Files |*.*"

        SaveFileDialog1.Title = "Save clone data to Excel file"
        SaveFileDialog1.Filter = "Excel Documents|*.xlsx"
        SaveFileDialog1.FileName = "Import_Assisant.xlsx"

        ' Clone
        OpenFileDialog2.Title = "Open clone file"
        OpenFileDialog2.Filter = "Clone File|*.clone|Clone Log|*.log|All Files |*.*"
        OpenFileDialog2.FileName = "Import.clone"

        SaveFileDialog2.Title = "Save clone file"
        SaveFileDialog2.Filter = "Clone File|*.clone"
        SaveFileDialog2.FileName = "Import_Assisant.clone"

        ' File-2-Item Index
        OpenFileDialog3.Title = "Open Item ID Index from CSV"
        OpenFileDialog3.Filter = "Index|*.csv"
        OpenFileDialog3.FileName = "OS_File_Name_2_Item_ID_Index.csv"

        SaveFileDialog3.Filter = "Index|*.csv"
        SaveFileDialog3.FileName = "OS_File_Name_2_Item_ID_Index.csv"

        ' Dummy Part
        OpenFileDialog4.Title = "Select a template part file"
        OpenFileDialog4.Filter = "NX part|*.prt"
        OpenFileDialog4.FileName = "Dummy.prt"

        ' Check List
        OpenFileDialog5.Title = "Select a txt Item list file"
        OpenFileDialog5.Filter = "Text|*.txt"
        OpenFileDialog5.FileName = "Check_List.txt"

        ' Add Part to list
        ' Dummy Part
        OpenFileDialog6.Title = "Select a part file to add to the import list"
        OpenFileDialog6.Filter = "NX part|*.prt"
        'OpenFileDialog6.FileName = "Dummy.prt"
        OpenFileDialog6.Multiselect = True

        ResetDb()
        AppInitialized = True
    End Sub

    '==== Main Menu ===========================================================

    '---- File, Exit
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        xtrace_subs("Menu, File, Exit")
        Application.Exit()
        ' exit_program() is now initialized when the form is closing
    End Sub

    '---- Show settings
    Private Sub ShowSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowSettingsToolStripMenuItem.Click
        xtrace_subs("Menu, Settings, Show settings")
        If ShowSettingsToolStripMenuItem.Checked Then
            TextBoxInfo.Visible = True
            TextBoxInfo.Dock = DockStyle.Fill
            TextBoxInfo.BringToFront()
        Else
            TextBoxInfo.Visible = False
        End If
    End Sub

    '---- Show Log
    Private Sub ShowLogToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowLogToolStripMenuItem.Click
        xtrace_subs("Menu, Settings, Show log file")
        Process.Start(LogFile)
    End Sub

    '---- Help Help
    Private Sub HelpToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem1.Click
        xtrace_subs("Menu, Help, Help")
        ShowHelp()
    End Sub

    '---- Help About
    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        xtrace_subs("Menu, Help, About")
        ShowHelpAbout()
    End Sub

    '---- File, Import
    Private Sub ToolStripMenuImport_Click(sender As Object, e As EventArgs) Handles ToolStripMenuImport.Click
        xtrace_subs("Menu, File, Import")
        Import_From_Excel()
    End Sub

    '---- File Export Excel ---------------------------------------------------
    Private Sub ToolStripMenuExport_Click(sender As Object, e As EventArgs) Handles ToolStripMenuExport.Click
        xtrace_subs("Menu, File, Export")
        Export_to_Excel()
    End Sub

    '---- Read Clone file -----------------------------------------------------
    Private Sub ToolStripMenuRead_Click(sender As Object, e As EventArgs) Handles ToolStripMenuRead.Click
        Read_Clone_File()
    End Sub

    '---- Save Clone file -----------------------------------------------------
    Private Sub ToolStripMenuSave_Click(sender As Object, e As EventArgs) Handles ToolStripMenuSave.Click
        Save_Clone_File()
    End Sub

    '---- File, New (Reset)
    Private Sub ToolStripMenuNew_Click(sender As Object, e As EventArgs) Handles ToolStripMenuNew.Click
        WriteHistory("New Clone file (Reset)")
        ResetDb()
    End Sub

    '---- Form resizing
    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        SplitContainer1.SplitterDistance = Control_Panel_Width
    End Sub

    Private Sub SplitContainer1_Resize(sender As Object, e As EventArgs) Handles SplitContainer1.Resize
        'Prevent this value to overwite the default
        'If AppInitialized Then Control_Panel_Width = SplitContainer1.SplitterDistance
    End Sub

    '---- Button Fix
    Private Sub ButtonFix_Click(sender As Object, e As EventArgs) Handles ButtonFix.Click
        For Nr As Integer = 1 To NumericUpDown1.Value
            xtrace_subs("ButtonFix " + Nr.ToString)
            FixRec1()

        Next
    End Sub

    Private Sub TextBoxUsrPrefix_TextChanged(sender As Object, e As EventArgs) Handles TextBoxUsrPrefix.TextChanged
        If AppInitialized Then UsrPrefix = TextBoxUsrPrefix.Text
    End Sub

    Private Sub ToolStripMenuAddFiles_Click(sender As Object, e As EventArgs) Handles ToolStripMenuAddFiles.Click
        Add_Files()
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        exit_program()
    End Sub

    '---- ToDo Load Item ID Index -----------------------------------------------------------
    ' Here the File to Item-ID translations are remembered across different imports
    ' It is saved implicitly on exit
    Private Sub ToolStripMenuLoadItemIdIndex_Click(sender As Object, e As EventArgs) Handles ToolStripMenuLoadItemIdIndex.Click
        LoadFileToIdIndex()

    End Sub

    Private Sub ToolStripMenuCreateItemIdIndex_Click(sender As Object, e As EventArgs) Handles ToolStripMenuCreateItemIdIndex.Click
        CreateFileToIdIndex()
    End Sub

    Private Sub ToolStripMenuReserveItems_Click(sender As Object, e As EventArgs) Handles ToolStripMenuReserveItems.Click
        Reserve_TC_Items()
    End Sub

    Private Sub ToolStripMenuCheckIndex_Click(sender As Object, e As EventArgs) Handles ToolStripMenuCheckIndex.Click
        Check_Index_For_Missing_Items()
    End Sub

    '---- Mark Edited
    Private Sub ComboBoxGrp_Click(sender As Object, e As EventArgs) Handles ComboBoxGrp.Click
        ComboBoxGrp.BackColor = SystemColors.Window
    End Sub

    Private Sub ComboBoxFolder_Click(sender As Object, e As EventArgs) Handles ComboBoxFolder.Click
        ComboBoxFolder.BackColor = SystemColors.Window
    End Sub

    Private Sub ComboBoxDfltCloneAction_Click(sender As Object, e As EventArgs) Handles ComboBoxDfltCloneAction.Click
        ComboBoxDfltCloneAction.BackColor = SystemColors.Window
    End Sub

    Private Sub ToolStripMenuAddFilesFromList_Click(sender As Object, e As EventArgs) Handles ToolStripMenuAddFilesFromList.Click
        WriteHistory("Add Files From TXT List")
        Add_Files2()
    End Sub

    Private Sub QuickLoadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuickLoadToolStripMenuItem.Click
        QuickLoad = QuickLoadToolStripMenuItem.Checked
        UpdateWhileReading = Not QuickLoad
    End Sub

    Private Sub ToolStripMenuItemBreak_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemBreak.Click
        Break = True
    End Sub
End Class
