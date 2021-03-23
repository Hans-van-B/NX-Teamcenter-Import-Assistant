Imports System.Text.RegularExpressions

Module RegExpression

    '---- RegEx Results
    Public RegEx_Succeeded As Boolean
    Public RegEx_Results(20) As String
    Public RegEx_ResultCount As Integer

    Function RegExpr(Line As String, expr As String) As Boolean
        xtrace_subs("RegExpr")
        xtrace("  Line = " & Line, G_TL_RE)
        xtrace("  Expr = " & expr, G_TL_RE)

        Dim MatchColl As MatchCollection
        Dim Match1 As Match
        Dim Result As GroupCollection

        If Len(Line) < 1 Then   ' 2020-07-20
            xtrace_i("Empty line")
            RegEx_Succeeded = False
        Else

            MatchColl = Regex.Matches(Line, expr, RegexOptions.IgnoreCase)
            Try
                Match1 = MatchColl.Item(0)
                RegEx_Succeeded = Match1.Success
            Catch ex As Exception
                xtrace(ex.Message)
                RegEx_Succeeded = False
            End Try
            xtrace("  Match Succeeded = " & RegEx_Succeeded.ToString, 3)

            If RegEx_Succeeded Then
                Result = Match1.Groups
                RegEx_ResultCount = Result.Count - 1
                xtrace("  Group Length = " & RegEx_ResultCount.ToString, G_TL_RE)

                ' Write all results
                Dim RNr As Integer = -1
                Dim RT As String
                For Each R As Group In Result
                    RNr = RNr + 1
                    RT = R.ToString
                    RegEx_Results(RNr) = RT
                    xtrace("  Data " & RNr & " = " & RT, G_TL_RE)
                Next
            Else
                RegEx_ResultCount = 0
            End If
        End If
        RegExpr = RegEx_Succeeded
ExitL:  xtrace_sube()
    End Function

    '---- Simulate Perl Expressions -------------------------------------------
    ' The much more readable: (.*?)(\%\d)(.*)
    ' Is translated into    : (?'A'.*?)(?'B'\%\d)(?'C'.*)
    ' Which is needed for VB

    Function RegExSym(Line As String, Expr As String, Remark As String) As Boolean
        xtrace_subs("RegExSym " + Remark)
        xtrace("Prepare Regular expression", G_TL_RE)
        xtrace("  Line = " & Line, G_TL_RE)
        xtrace("  Expr = " & Expr, G_TL_RE)

        Dim LT As Integer = 4   ' Determine the detail log level
        Dim ProcStr As String = Expr
        Dim Result As String = ""
        Dim P1, P2, L1 As Integer
        Dim NNr As Integer = 64  ' Name Nr
        Dim NC As Char

        While InStr(ProcStr, "(") > 0
            P1 = InStr(ProcStr, "(")
            P2 = InStr(ProcStr, "\(")
            ' Give location of bracket, not the "\"
            If P2 > 0 Then P2 = P2 + 1
            L1 = Len(ProcStr)
            xtrace("  P1=" & P1 & ", P2=" & P2 & ", L1=" & L1, G_TL_RE + 1)

            If (P1 = P2) Then ' Skip This one
                Result = Result & Left(ProcStr, P2)

            Else ' Update
                NNr = NNr + 1
                NC = Chr(NNr)
                xtrace("  NNr=" & NNr & ", NC=" & NC, G_TL_RE + 1)
                Result = Result & Left(ProcStr, P1)
                Result = Result & "?'" & NC & "'"
            End If

            ' Rest
            If P1 < L1 Then
                ProcStr = Mid(ProcStr, P1 + 1)
            Else
                ProcStr = ""
            End If

            xtrace("  Expr = " & Result, G_TL_RE + 1)
            xtrace("  Rest = " & ProcStr, G_TL_RE + 1)
        End While

        If Len(ProcStr) > 0 Then
            Result = Result & ProcStr
            xtrace("  Expr = " & Result, G_TL_RE + 1)
        End If

        RegExpr(Line, Result)
        RegExSym = RegEx_Succeeded
ExitL:  xtrace_sube()
    End Function

    '---- Example Call -------------------------------------------------

    Sub TryRegExpr()
        ' Group in Brackets                                    (
        ' Starts with an unique name                            ?'b'
        ' Followed by the sub-expression and a closing bracket      .*)
        RegExpr("Set Var=Value", "Set (?'a'\w+?)=(?'b'.*)")

        ' Or
        RegExSym("Set Var=Value", "Set (\w+?)=(.*)", "")

        ' Templates
        RegExpr("line", "expr")
        RegExSym("line", "expr", "Remark")
    End Sub

End Module
