Module Glob
    Public AppName As String = "NX-Import-Assistant"
    Public AppVer As String = "0.04.013"
    Public AppRoot As String = Application.StartupPath
    Public CD As String = My.Computer.FileSystem.CurrentDirectory
    Public Temp As String = Environment.GetEnvironmentVariable("TEMP")
    Public LogFile As String = Temp & "\" & AppName & ".log"
    Public IniFile1 As String = AppRoot & "\" & AppName & ".ini"
    Public IniFile2 As String = AppRoot & "\Data\" & AppName & ".ini"

    Public ErrorCount As Integer = 0
    Public WarningCount As Integer = 0

    Public EndDelay As Integer = 2
    Public EndPause As Boolean = False
    Public ShowGui As Boolean = False
    Public ExitProgram As Boolean = False
    Public AppInitialized As Boolean = False

    '---- File to ItemID index
    Public ExistFinished As Boolean = False
    Public FileToIdIndex As New Hashtable
    Public FileToIdInitialized As Boolean = False
    Public FileToIdFName As String = ""
    Public Sep As String = ";"

    '---- Columns
    Public C_FN As Integer = 0  ' File Name
    Public C_TA As Integer = 1  ' Top Assembly
    Public C_IT As Integer = 2  ' Item Type
    Public C_NC As Integer = 3  ' 11NC / 12NC
    Public C_ID As Integer = 4  ' TC Iten ID
    Public C_RV As Integer = 5  ' TC Revision
    Public C_SP As Integer = 6  ' TC Specification
    Public C_PN As Integer = 7  ' TC Part Name
    Public C_DE As Integer = 8  ' TC Decription
    Public C_CA As Integer = 9 ' Cloning Action: DEFAULT_DISP|Use Existing|OVERWRITE

    Public CA_Range As String() = {"DEFAULT_DISP", "USE_EXISTING", "OVERWRITE", "NEW_REVISION"}
    Public CA_Default As String = "DEFAULT_DISP"

    '---- Defaults
    Public Control_Panel_Width As Integer = 200
    Public G_TL_RE As Integer = 4
    Public CTrace As Integer = 2
    Public LibExtension As String = "-EMT"
    Public LibRev As String = "VC"
    Public UsrPrefix As String = "IMP-"
    Public MaxIdLength As Integer = 23
    Public MaxCol1Width As Integer = 300


    Public AutoNextLine As Boolean = False
    Public NumberBlocks As Boolean = False
    Public UpdateWhileReading As Boolean = True
    Public QuickLoad As Boolean = False
    Public Break As Boolean = False
    Public DelTemplateInDescr As Boolean = True
    Public Undefined As String = "<Undefined>"
End Module
