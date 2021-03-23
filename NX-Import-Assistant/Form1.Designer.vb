<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.TextBoxInfo = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuRead = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuImport = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuExport = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuAddFiles = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuAddFilesFromList = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuCreateItemIdIndex = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuLoadItemIdIndex = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuCheckIndex = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuReserveItems = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowLogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UtilToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReserveItensSplitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemovePathToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBoxHistory = New System.Windows.Forms.TextBox()
        Me.ComboBoxFolder = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ComboBoxFixMethod = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ComboBoxGrp = New System.Windows.Forms.ComboBox()
        Me.ComboBoxUser = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBoxDfltCloneAction = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxUsrPrefix = New System.Windows.Forms.TextBox()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.ButtonFix = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.OS_File_Name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Item_Type = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.NC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Rev = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Spec = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog2 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog2 = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog3 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog3 = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog4 = New System.Windows.Forms.OpenFileDialog()
        Me.OpenFileDialog5 = New System.Windows.Forms.OpenFileDialog()
        Me.OpenFileDialog6 = New System.Windows.Forms.OpenFileDialog()
        Me.QuickLoadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemBreak = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBoxInfo
        '
        Me.TextBoxInfo.AcceptsReturn = True
        Me.TextBoxInfo.Font = New System.Drawing.Font("Liberation Mono", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxInfo.Location = New System.Drawing.Point(395, 201)
        Me.TextBoxInfo.Multiline = True
        Me.TextBoxInfo.Name = "TextBoxInfo"
        Me.TextBoxInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxInfo.Size = New System.Drawing.Size(123, 64)
        Me.TextBoxInfo.TabIndex = 1
        Me.TextBoxInfo.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.TextBoxInfo.Visible = False
        Me.TextBoxInfo.WordWrap = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.SettingsToolStripMenuItem, Me.ToolStripMenuItemBreak, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1001, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuRead, Me.ToolStripMenuSave, Me.ToolStripMenuNew, Me.ToolStripMenuImport, Me.ToolStripMenuExport, Me.ToolStripMenuAddFiles, Me.ToolStripMenuAddFilesFromList, Me.ToolStripSeparator1, Me.ToolStripMenuCreateItemIdIndex, Me.ToolStripMenuLoadItemIdIndex, Me.ToolStripMenuCheckIndex, Me.ToolStripMenuReserveItems, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'ToolStripMenuRead
        '
        Me.ToolStripMenuRead.Name = "ToolStripMenuRead"
        Me.ToolStripMenuRead.Size = New System.Drawing.Size(232, 22)
        Me.ToolStripMenuRead.Text = "&Open Clone File"
        '
        'ToolStripMenuSave
        '
        Me.ToolStripMenuSave.Name = "ToolStripMenuSave"
        Me.ToolStripMenuSave.Size = New System.Drawing.Size(232, 22)
        Me.ToolStripMenuSave.Text = "&Save Clone file"
        '
        'ToolStripMenuNew
        '
        Me.ToolStripMenuNew.Name = "ToolStripMenuNew"
        Me.ToolStripMenuNew.Size = New System.Drawing.Size(232, 22)
        Me.ToolStripMenuNew.Text = "&New"
        '
        'ToolStripMenuImport
        '
        Me.ToolStripMenuImport.Name = "ToolStripMenuImport"
        Me.ToolStripMenuImport.Size = New System.Drawing.Size(232, 22)
        Me.ToolStripMenuImport.Text = "&Import Excel"
        '
        'ToolStripMenuExport
        '
        Me.ToolStripMenuExport.Name = "ToolStripMenuExport"
        Me.ToolStripMenuExport.Size = New System.Drawing.Size(232, 22)
        Me.ToolStripMenuExport.Text = "E&xport Excel"
        '
        'ToolStripMenuAddFiles
        '
        Me.ToolStripMenuAddFiles.Name = "ToolStripMenuAddFiles"
        Me.ToolStripMenuAddFiles.Size = New System.Drawing.Size(232, 22)
        Me.ToolStripMenuAddFiles.Text = "&Add NX Files"
        '
        'ToolStripMenuAddFilesFromList
        '
        Me.ToolStripMenuAddFilesFromList.Name = "ToolStripMenuAddFilesFromList"
        Me.ToolStripMenuAddFilesFromList.Size = New System.Drawing.Size(232, 22)
        Me.ToolStripMenuAddFilesFromList.Text = "A&dd NX Files From TXT List"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(229, 6)
        '
        'ToolStripMenuCreateItemIdIndex
        '
        Me.ToolStripMenuCreateItemIdIndex.Name = "ToolStripMenuCreateItemIdIndex"
        Me.ToolStripMenuCreateItemIdIndex.Size = New System.Drawing.Size(232, 22)
        Me.ToolStripMenuCreateItemIdIndex.Text = "&Create Item ID Index"
        '
        'ToolStripMenuLoadItemIdIndex
        '
        Me.ToolStripMenuLoadItemIdIndex.Name = "ToolStripMenuLoadItemIdIndex"
        Me.ToolStripMenuLoadItemIdIndex.Size = New System.Drawing.Size(232, 22)
        Me.ToolStripMenuLoadItemIdIndex.Text = "&Load Item ID Index"
        '
        'ToolStripMenuCheckIndex
        '
        Me.ToolStripMenuCheckIndex.Name = "ToolStripMenuCheckIndex"
        Me.ToolStripMenuCheckIndex.Size = New System.Drawing.Size(232, 22)
        Me.ToolStripMenuCheckIndex.Text = "C&heck Index for missing Items"
        '
        'ToolStripMenuReserveItems
        '
        Me.ToolStripMenuReserveItems.Name = "ToolStripMenuReserveItems"
        Me.ToolStripMenuReserveItems.Size = New System.Drawing.Size(232, 22)
        Me.ToolStripMenuReserveItems.Text = "&Reserve Items"
        Me.ToolStripMenuReserveItems.ToolTipText = "Creates a dummy import that reserves the items in teamcenter" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "so that you don't h" &
    "ave to worry your items get stolen while" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "you are debugging the Import Assembly"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.ExitToolStripMenuItem.Text = "&Exit"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowSettingsToolStripMenuItem, Me.ShowLogToolStripMenuItem, Me.UtilToolStripMenuItem, Me.RemovePathToolStripMenuItem, Me.QuickLoadToolStripMenuItem})
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.SettingsToolStripMenuItem.Text = "&Settings"
        '
        'ShowSettingsToolStripMenuItem
        '
        Me.ShowSettingsToolStripMenuItem.CheckOnClick = True
        Me.ShowSettingsToolStripMenuItem.Name = "ShowSettingsToolStripMenuItem"
        Me.ShowSettingsToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ShowSettingsToolStripMenuItem.Text = "&Show settings"
        '
        'ShowLogToolStripMenuItem
        '
        Me.ShowLogToolStripMenuItem.Name = "ShowLogToolStripMenuItem"
        Me.ShowLogToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ShowLogToolStripMenuItem.Text = "Show &Log"
        '
        'UtilToolStripMenuItem
        '
        Me.UtilToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReserveItensSplitToolStripMenuItem})
        Me.UtilToolStripMenuItem.Name = "UtilToolStripMenuItem"
        Me.UtilToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.UtilToolStripMenuItem.Text = "&Util"
        '
        'ReserveItensSplitToolStripMenuItem
        '
        Me.ReserveItensSplitToolStripMenuItem.CheckOnClick = True
        Me.ReserveItensSplitToolStripMenuItem.Name = "ReserveItensSplitToolStripMenuItem"
        Me.ReserveItensSplitToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.ReserveItensSplitToolStripMenuItem.Text = "&Reserve Items, Split"
        '
        'RemovePathToolStripMenuItem
        '
        Me.RemovePathToolStripMenuItem.CheckOnClick = True
        Me.RemovePathToolStripMenuItem.Name = "RemovePathToolStripMenuItem"
        Me.RemovePathToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.RemovePathToolStripMenuItem.Text = "&Remove Path"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HelpToolStripMenuItem1, Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'HelpToolStripMenuItem1
        '
        Me.HelpToolStripMenuItem1.Name = "HelpToolStripMenuItem1"
        Me.HelpToolStripMenuItem1.Size = New System.Drawing.Size(107, 22)
        Me.HelpToolStripMenuItem1.Text = "&Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.AboutToolStripMenuItem.Text = "&About"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 462)
        Me.StatusStrip1.Margin = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1001, 22)
        Me.StatusStrip1.TabIndex = 5
        Me.StatusStrip1.TabStop = True
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(12, 17)
        Me.ToolStripStatusLabel1.Text = "-"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.BackColor = System.Drawing.Color.NavajoWhite
        Me.ToolStripStatusLabel2.Margin = New System.Windows.Forms.Padding(10, 3, 0, 2)
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(131, 17)
        Me.ToolStripStatusLabel2.Text = "Item ID Index = Inactive"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 24)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBoxHistory)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBoxFolder)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBoxFixMethod)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBoxGrp)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBoxUser)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBoxDfltCloneAction)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBoxUsrPrefix)
        Me.SplitContainer1.Panel1.Controls.Add(Me.NumericUpDown1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ButtonFix)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DataGridView1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1001, 438)
        Me.SplitContainer1.SplitterDistance = 247
        Me.SplitContainer1.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 232)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "History"
        '
        'TextBoxHistory
        '
        Me.TextBoxHistory.Location = New System.Drawing.Point(6, 248)
        Me.TextBoxHistory.Multiline = True
        Me.TextBoxHistory.Name = "TextBoxHistory"
        Me.TextBoxHistory.ReadOnly = True
        Me.TextBoxHistory.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxHistory.Size = New System.Drawing.Size(196, 187)
        Me.TextBoxHistory.TabIndex = 13
        '
        'ComboBoxFolder
        '
        Me.ComboBoxFolder.BackColor = System.Drawing.Color.Yellow
        Me.ComboBoxFolder.FormattingEnabled = True
        Me.ComboBoxFolder.Items.AddRange(New Object() {":Import", ":Current Projects:Mechatronics:0000100059 : NXP 5G Antenna"})
        Me.ComboBoxFolder.Location = New System.Drawing.Point(45, 208)
        Me.ComboBoxFolder.Name = "ComboBoxFolder"
        Me.ComboBoxFolder.Size = New System.Drawing.Size(121, 21)
        Me.ComboBoxFolder.TabIndex = 12
        Me.ComboBoxFolder.Text = ":Import"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 211)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Folder"
        '
        'ComboBoxFixMethod
        '
        Me.ComboBoxFixMethod.FormattingEnabled = True
        Me.ComboBoxFixMethod.Items.AddRange(New Object() {"Default", "Use TMP ID"})
        Me.ComboBoxFixMethod.Location = New System.Drawing.Point(68, 51)
        Me.ComboBoxFixMethod.Name = "ComboBoxFixMethod"
        Me.ComboBoxFixMethod.Size = New System.Drawing.Size(98, 21)
        Me.ComboBoxFixMethod.TabIndex = 10
        Me.ComboBoxFixMethod.Text = "Default"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Fix Method"
        '
        'ComboBoxGrp
        '
        Me.ComboBoxGrp.BackColor = System.Drawing.Color.Yellow
        Me.ComboBoxGrp.FormattingEnabled = True
        Me.ComboBoxGrp.Items.AddRange(New Object() {"dba", "0000100059"})
        Me.ComboBoxGrp.Location = New System.Drawing.Point(45, 181)
        Me.ComboBoxGrp.Name = "ComboBoxGrp"
        Me.ComboBoxGrp.Size = New System.Drawing.Size(121, 21)
        Me.ComboBoxGrp.TabIndex = 8
        Me.ComboBoxGrp.Text = "dba"
        '
        'ComboBoxUser
        '
        Me.ComboBoxUser.FormattingEnabled = True
        Me.ComboBoxUser.Location = New System.Drawing.Point(45, 154)
        Me.ComboBoxUser.Name = "ComboBoxUser"
        Me.ComboBoxUser.Size = New System.Drawing.Size(121, 21)
        Me.ComboBoxUser.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 184)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Group"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 157)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "User"
        '
        'ComboBoxDfltCloneAction
        '
        Me.ComboBoxDfltCloneAction.BackColor = System.Drawing.Color.Yellow
        Me.ComboBoxDfltCloneAction.FormattingEnabled = True
        Me.ComboBoxDfltCloneAction.Items.AddRange(New Object() {"USE_EXISTING", "OVERWRITE"})
        Me.ComboBoxDfltCloneAction.Location = New System.Drawing.Point(45, 127)
        Me.ComboBoxDfltCloneAction.Name = "ComboBoxDfltCloneAction"
        Me.ComboBoxDfltCloneAction.Size = New System.Drawing.Size(121, 21)
        Me.ComboBoxDfltCloneAction.TabIndex = 4
        Me.ComboBoxDfltCloneAction.Text = "USE_EXISTING"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 81)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Usr Prefix"
        '
        'TextBoxUsrPrefix
        '
        Me.TextBoxUsrPrefix.Location = New System.Drawing.Point(68, 78)
        Me.TextBoxUsrPrefix.Name = "TextBoxUsrPrefix"
        Me.TextBoxUsrPrefix.Size = New System.Drawing.Size(43, 20)
        Me.TextBoxUsrPrefix.TabIndex = 2
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumericUpDown1.Location = New System.Drawing.Point(90, 15)
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(44, 26)
        Me.NumericUpDown1.TabIndex = 1
        Me.NumericUpDown1.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'ButtonFix
        '
        Me.ButtonFix.Location = New System.Drawing.Point(14, 15)
        Me.ButtonFix.Name = "ButtonFix"
        Me.ButtonFix.Size = New System.Drawing.Size(70, 26)
        Me.ButtonFix.TabIndex = 0
        Me.ButtonFix.Text = "Fix"
        Me.ButtonFix.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.OS_File_Name, Me.Item_Type, Me.NC, Me.Item, Me.Rev, Me.Spec, Me.PName, Me.Descr})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(2)
        Me.DataGridView1.MinimumSize = New System.Drawing.Size(30, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(750, 438)
        Me.DataGridView1.TabIndex = 7
        '
        'OS_File_Name
        '
        Me.OS_File_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.OS_File_Name.HeaderText = "OS File Name"
        Me.OS_File_Name.MaxInputLength = 200
        Me.OS_File_Name.Name = "OS_File_Name"
        Me.OS_File_Name.Width = 97
        '
        'Item_Type
        '
        Me.Item_Type.HeaderText = "Item Type"
        Me.Item_Type.Items.AddRange(New Object() {"11NC", "Std_Art", "Specification", "Free naming"})
        Me.Item_Type.Name = "Item_Type"
        Me.Item_Type.Width = 60
        '
        'NC
        '
        Me.NC.HeaderText = "11/12 NC"
        Me.NC.MaxInputLength = 14
        Me.NC.Name = "NC"
        Me.NC.Width = 79
        '
        'Item
        '
        Me.Item.HeaderText = "TC Item ID"
        Me.Item.MaxInputLength = 24
        Me.Item.Name = "Item"
        Me.Item.Width = 83
        '
        'Rev
        '
        Me.Rev.HeaderText = "TC Rev"
        Me.Rev.MaxInputLength = 2
        Me.Rev.Name = "Rev"
        Me.Rev.Width = 69
        '
        'Spec
        '
        Me.Spec.HeaderText = "Specification"
        Me.Spec.Name = "Spec"
        Me.Spec.Width = 93
        '
        'PName
        '
        Me.PName.HeaderText = "Part Name"
        Me.PName.MaxInputLength = 200
        Me.PName.Name = "PName"
        Me.PName.Width = 82
        '
        'Descr
        '
        Me.Descr.HeaderText = "Description"
        Me.Descr.MaxInputLength = 200
        Me.Descr.Name = "Descr"
        Me.Descr.Width = 85
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'OpenFileDialog2
        '
        Me.OpenFileDialog2.FileName = "OpenFileDialog2"
        '
        'OpenFileDialog3
        '
        Me.OpenFileDialog3.FileName = "OpenFileDialog3"
        '
        'OpenFileDialog4
        '
        Me.OpenFileDialog4.FileName = "OpenFileDialog4"
        '
        'OpenFileDialog5
        '
        Me.OpenFileDialog5.FileName = "OpenFileDialog5"
        '
        'OpenFileDialog6
        '
        Me.OpenFileDialog6.FileName = "OpenFileDialog6"
        '
        'QuickLoadToolStripMenuItem
        '
        Me.QuickLoadToolStripMenuItem.CheckOnClick = True
        Me.QuickLoadToolStripMenuItem.Name = "QuickLoadToolStripMenuItem"
        Me.QuickLoadToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.QuickLoadToolStripMenuItem.Text = "Quick Load"
        '
        'ToolStripMenuItemBreak
        '
        Me.ToolStripMenuItemBreak.Name = "ToolStripMenuItemBreak"
        Me.ToolStripMenuItemBreak.Size = New System.Drawing.Size(48, 20)
        Me.ToolStripMenuItemBreak.Text = "Break"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1001, 484)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.TextBoxInfo)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBoxInfo As System.Windows.Forms.TextBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowSettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowLogToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuImport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripMenuRead As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripMenuExport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents OpenFileDialog2 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog2 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents OS_File_Name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Item_Type As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents NC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Item As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Rev As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Spec As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ButtonFix As System.Windows.Forms.Button
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBoxUsrPrefix As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxDfltCloneAction As System.Windows.Forms.ComboBox
    Friend WithEvents ToolStripMenuNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ComboBoxGrp As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxUser As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxFixMethod As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ToolStripMenuAddFiles As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFileDialog3 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ToolStripMenuLoadItemIdIndex As ToolStripMenuItem
    Friend WithEvents ToolStripMenuCreateItemIdIndex As ToolStripMenuItem
    Friend WithEvents SaveFileDialog3 As SaveFileDialog
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents ToolStripMenuReserveItems As ToolStripMenuItem
    Friend WithEvents OpenFileDialog4 As OpenFileDialog
    Friend WithEvents UtilToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReserveItensSplitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label5 As Label
    Friend WithEvents ComboBoxFolder As ComboBox
    Friend WithEvents RemovePathToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripMenuCheckIndex As ToolStripMenuItem
    Friend WithEvents OpenFileDialog5 As OpenFileDialog
    Friend WithEvents OpenFileDialog6 As OpenFileDialog
    Friend WithEvents ToolStripMenuAddFilesFromList As ToolStripMenuItem
    Friend WithEvents Label6 As Label
    Friend WithEvents TextBoxHistory As TextBox
    Friend WithEvents QuickLoadToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemBreak As ToolStripMenuItem
End Class
