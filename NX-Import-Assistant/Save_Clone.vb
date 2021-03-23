Module Save_Clone

    Dim OSFN As String = " "
    Dim TopAs As String = "N"
    Dim FN As String
    Dim IType As String = " "
    Dim NC As String = " "
    Dim ID As String = " "
    Dim Rev As String = " "
    Dim Spec As String = " "
    Dim Name As String = " "
    Dim Desc As String = " "
    Dim CloneA As String = " "

    Dim RecordNr As Integer

    Sub Save_Clone_File()
        xtrace_subs("Save_Clone_File")

        If Form1.SaveFileDialog2.ShowDialog = DialogResult.OK Then
            WriteHistory("Save Clone file")
            Dim Filename As String
            Dim file As System.IO.StreamWriter
            Filename = Form1.SaveFileDialog2.FileName
            xtrace_i("Save to " + Filename)

            file = My.Computer.FileSystem.OpenTextFileWriter(Filename, False)

            xtrace("Write file header")
            file.WriteLine("===============================================")
            file.WriteLine("      TEAMCENTER INTEGRATION IMPORT LOG")
            file.WriteLine("        Date - " & DateTime.Now)
            file.WriteLine("===============================================")
            file.WriteLine(" " & AppName & " V" & AppVer)
            file.WriteLine("")
            file.WriteLine("-----------------------------------------------")
            file.WriteLine("Default Parameters")
            file.WriteLine("-----------------------------------------------")
            file.WriteLine("&LOG Operation_Type: IMPORT_OPERATION")
            file.WriteLine("&LOG Default_Cloning_Action: " + Form1.ComboBoxDfltCloneAction.Text)
            file.WriteLine("&LOG Default_Naming_Technique: OSFILE_NAME Default_Name_Rule_Type: AS_ID_REVISION")
            file.WriteLine("&LOG Default_Container: """ & Form1.ComboBoxFolder.Text & """")
            file.WriteLine("&LOG Default_Part_Type: Item")
            file.WriteLine("&LOG Default_Part_Name: ""${DB_PART_NAME}""")
            file.WriteLine("&LOG Default_Part_Description: ""${DB_PART_DESC}""")
            file.WriteLine("&LOG Default_Associated_Files_Directory: """"")
            file.WriteLine("&LOG Default_DB_Owner: " + Form1.ComboBoxUser.Text + " " + Form1.ComboBoxGrp.Text)
            file.WriteLine("&LOG Default_Validation_Mode: OFF")
            file.WriteLine("")

            xtrace("Write part info")
            file.WriteLine("-----------------------------------------------")
            file.WriteLine("Part Specific Information")
            file.WriteLine("-----------------------------------------------")

            Dim RowCount As Integer = Form1.DataGridView1.RowCount
            Dim RecordNr As Integer
            xtrace_i("RowCount = " + RowCount.ToString)
            For RecordNr = 0 To RowCount - 2
                If NumberBlocks Then
                    file.WriteLine("--- " + (RecordNr + 1).ToString + " ---")
                Else
                    file.WriteLine("&LOG ")
                End If

                OSFN = Form1.DataGridView1.Item(C_FN, RecordNr).Value
                FN = System.IO.Path.GetFileName(OSFN)
                Try
                    TopAs = Form1.DataGridView1.Item(C_TA, RecordNr).Value
                Catch ex As Exception
                    TopAs = "N"
                End Try
                IType = Form1.DataGridView1.Item(C_IT, RecordNr).Value
                NC = Form1.DataGridView1.Item(C_NC, RecordNr).Value
                ID = Form1.DataGridView1.Item(C_ID, RecordNr).Value
                Rev = Form1.DataGridView1.Item(C_RV, RecordNr).Value
                Try
                    Spec = Form1.DataGridView1.Item(C_SP, RecordNr).Value
                Catch ex As Exception
                    Spec = " "
                End Try
                Name = Form1.DataGridView1.Item(C_PN, RecordNr).Value
                Try
                    Desc = Form1.DataGridView1.Item(C_DE, RecordNr).Value
                Catch ex As Exception
                    Desc = ""
                    xtrace("Error while setting desc: " + ex.Message)
                End Try
                CloneA = Form1.DataGridView1.Item(C_CA, RecordNr).Value


                If TopAs = "Y" Then
                    file.WriteLine("&LOG TOP_ASSEMBLY Part: """ + OSFN + """")
                Else
                    file.WriteLine("&LOG Part: """ + OSFN + """")
                End If

                If Name = " " Then
                    xtrace("Dummy block")
                Else
                    file.WriteLine("&LOG Cloning_Action: " + CloneA + " ")
                End If

                If IType = "Specification" Then
                    file.WriteLine("&LOG Naming_Technique: USER_NAME Clone_Name: ""@DB/" + ID + "/" + Rev + "/specification/" + Spec + """")
                Else
                    file.WriteLine("&LOG Naming_Technique: USER_NAME Clone_Name: ""@DB/" + ID + "/" + Rev + """")
                End If

                ' If no name then dummy-block
                If Name = " " Then
                Else
                    file.WriteLine("&LOG Container: """"")
                    file.WriteLine("&LOG Part_Type: Item")
                    file.WriteLine("&LOG Part_Name: """ + Name + """")
                    file.WriteLine("&LOG Part_Description: """ + Desc + """")
                    file.WriteLine("&LOG Associated_Files_Directory: """"")
                End If

                UpdateFileToIdIndexRec(OSFN, ID, Rev)
            Next

            file.WriteLine("&LOG ")
            file.Close()
        End If
    End Sub
End Module
