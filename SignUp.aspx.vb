Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing
Imports System.Configuration
Imports System.Data
Imports System
Imports System.Management
Imports System.Management.Instrumentation
Imports System.Security.Cryptography
Imports System.Text
Imports System.Security.Policy
Imports System.Globalization
Imports System.Net.Mail
Imports System.Net
Imports System.ComponentModel

Partial Class SignUp
    Inherits System.Web.UI.Page
    Dim thisConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("Bread4WorldConnectionString").ConnectionString)
    Dim cc As Code_Class = New Code_Class()

    Dim validatedParent, validatedSponsor, validatedReg As String


    Protected Sub insert()
        thisConnection.Open()

        If lblValidateStatus.Text = "SPONSORID VERIFIED REGID VERIFIED " Then



            'validating the textboxes
            If txtSponsorID.Value = "" Or txtSponsorName.Value = "" Or txtSponsorPhoneNo.Value = "" Or txtFirstName.Value = "" Or _
            txtLastName.Value = "" Or txtCountry.Value = "" Or txtState.Value = "" Or txtCity.Value = "" Or txtEmail.Value = "" _
            Or txtPhone.Value = "" Or txtGender.Value = "" Or txtAddress.Value = "" Or txtDOB.Value = "" Or txtUsersName.Value = "" Or _
            txtPassword.Value = "" Or txtConfirmPassword.Value = "" Or txtBankName.Value = "" Or txtAccountName.Value = "" Or txtAccountNumber.Value = "" Then
                lblMessage.Visible = True
                lblMessage.ForeColor = Color.Red
                lblMessage.Text = "Submission failed! Ensure all textboxes are filled"
                ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "HideLabel();", True)
            Else


                'avoid dublicate username
                Try

                    Dim into1 As String = String.Format("SELECT REG_ID, SPONSOR_ID, PARENT_ID FROM RegTable where USERSNAME ='" + txtUsersName.Value + "' or  EMAIL = '" + txtEmail.Value + "'")
                    'passing the variable to the datatable
                    Dim dsworky As DataTable = cc.SelectDataTableRecords(into1)

                    'check if court its empty
                    If dsworky.Rows.Count > 0 Then
                        lblMessage.Visible = True
                        lblMessage.ForeColor = Color.Red
                        lblMessage.Text = "UserName or Email already Exist, Please choose another"
                        ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "HideLabel();", True)
                    Else

                        'validate password and confirmed password
                        If txtPassword.Value = txtConfirmPassword.Value Then

                            'code for registration
                            Using cmd As New SqlCommand("UPDATE RegTable SET SPONSOR_ID = @SPONSOR_ID, PARENT_ID = @PARENT_ID, SPONSOR_NAME = @SPONSOR_NAME, SPONSOR_PHONE_NO = @SPONSOR_PHONE_NO, FIRST_NAME = @FIRST_NAME, LAST_NAME = @LAST_NAME, COUNTRY = @COUNTRY, STATE = @STATE, CITY = @CITY, EMAIL = @EMAIL, MOBILE = @MOBILE, GENDER = @GENDER, ADDRESS = @ADDRESS, DOB = @DOB, USERSNAME = @USERSNAME, PASSWORD = @PASSWORD, CONFIRM_PASSWORD = @CONFIRM_PASSWORD, BANK_NAME = @BANK_NAME, ACCOUNT_NAME = @ACCOUNT_NAME, ACCOUNT_NUMBER = @ACCOUNT_NUMBER, ONLINE_STATUS = @ONLINE_STATUS, CURRENT_STAGE_ID = @CURRENT_STAGE_ID, DATE = @DATE WHERE  REG_ID = '" + txtRegId.Value + "'", thisConnection)

                                cmd.CommandType = CommandType.Text
                                'cmd.Parameters.AddWithValue("@REG\_ID", txtRegId.Value)

                                cmd.Parameters.AddWithValue("@SPONSOR_ID", txtSponsorID.Value)

                                cmd.Parameters.AddWithValue("@PARENT_ID", txtSponsorID.Value)
                                cmd.Parameters.AddWithValue("@SPONSOR_NAME", txtSponsorName.Value)
                                cmd.Parameters.AddWithValue("@SPONSOR_PHONE_NO", txtSponsorPhoneNo.Value)
                                cmd.Parameters.AddWithValue("@FIRST_NAME", txtFirstName.Value.ToUpper)
                                cmd.Parameters.AddWithValue("@LAST_NAME", txtLastName.Value.ToUpper)
                                cmd.Parameters.AddWithValue("@COUNTRY", txtCountry.Value)
                                cmd.Parameters.AddWithValue("@STATE", txtState.Value)
                                cmd.Parameters.AddWithValue("@CITY", txtCity.Value.ToUpper)
                                cmd.Parameters.AddWithValue("@EMAIL", txtEmail.Value.ToLower)
                                cmd.Parameters.AddWithValue("@MOBILE", txtPhone.Value)

                                cmd.Parameters.AddWithValue("@GENDER", txtGender.Value)
                                cmd.Parameters.AddWithValue("@ADDRESS", txtAddress.Value.ToUpper)
                                cmd.Parameters.AddWithValue("@DOB", txtDOB.Value)
                                cmd.Parameters.AddWithValue("@USERSNAME", txtUsersName.Value.ToUpper)
                                cmd.Parameters.AddWithValue("@PASSWORD", txtPassword.Value)
                                cmd.Parameters.AddWithValue("@CONFIRM_PASSWORD", txtConfirmPassword.Value)
                                cmd.Parameters.AddWithValue("@ONLINE_STATUS", "ONLINE")

                                cmd.Parameters.AddWithValue("@BANK_NAME", txtBankName.Value.ToUpper)
                                cmd.Parameters.AddWithValue("@ACCOUNT_NAME", txtAccountName.Value.ToUpper)
                                cmd.Parameters.AddWithValue("@ACCOUNT_NUMBER", txtAccountNumber.Value)
                                cmd.Parameters.AddWithValue("@CURRENT_STAGE_ID", 1)
                                cmd.Parameters.AddWithValue("@DATE", Date.Now.Date)

                                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                                UpdateNode(txtRegId.Value, txtSponsorID.Value)


                            End Using

                            lblMessage.Visible = True
                            lblMessage.ForeColor = Color.Blue
                            lblMessage.Text = "Registration was successful!"

                            ' insertEntryLevel()
                            Session.Add("username", txtUsersName.Value)
                            Session.Add("userid", txtRegId.Value)
                            Session.Add("sponsorid", txtSponsorID.Value)
                            Session.Add("sponsorname", txtSponsorName.Value)
                            Session.Add("sponsorphoneno", txtSponsorPhoneNo.Value)
                            deleteUserGeneratedPin()
                            Response.Redirect("Dashboard.aspx")

                        Else
                            lblMessage.Visible = True
                            lblMessage.ForeColor = Color.Red
                            lblMessage.Text = "Sorry! Password Mismatch"


                        End If
                    End If
                Catch ex As Exception
                    lblMessage.Visible = True
                    lblMessage.ForeColor = Color.Red
                    lblMessage.Text = "Sorry! Your registration wasn't seccessful"

                End Try

            End If
        Else
            lblValidateStatus.Visible = False
            lblMessage.Visible = True
            lblMessage.ForeColor = Color.Red
            lblMessage.Text = "Please click on Validate ID's to validate ID before sumbitting"
            lblValidateStatus.Visible = True



        End If

    End Sub

    Protected Sub UpdateNode(ByVal RegID As String, ByVal ParentID As String)
        Dim into1 As String = String.Format("SELECT MATRIX_LEFT, MATRIX_RIGHT FROM RegTable where REG_ID ='" + ParentID + "'")
        'passing the variable to the datatable
        Dim dsworky As DataTable = cc.SelectDataTableRecords(into1)

        'check if court its empty
        If dsworky.Rows.Count > 0 Then
            Dim parentLeft As Integer = dsworky.Rows(0)("MATRIX_LEFT")
            Dim parentRight As Integer = dsworky.Rows(0)("MATRIX_RIGHT")

            Dim left, right As Integer
            If parentRight - parentLeft = 1 Then
                left = parentLeft + 1
            Else
                left = getDownlineCount(parentLeft, parentRight) * 2 + 1 + parentLeft
            End If

            right = left + 1

            'code for registration
            Using cmd As New SqlCommand("UPDATE RegTable SET MATRIX_LEFT = MATRIX_LEFT + 2 WHERE " + _
                                        "MATRIX_LEFT >= @P_LEFT; UPDATE RegTable SET MATRIX_RIGHT = MATRIX_RIGHT + 2 WHERE " + _
                                        "MATRIX_RIGHT >= @P_RIGHT; ", thisConnection)

                cmd.CommandType = CommandType.Text
                'cmd.Parameters.AddWithValue("@REG\_ID", txtRegId.Value)

                cmd.Parameters.AddWithValue("@P_LEFT", left.ToString)
                cmd.Parameters.AddWithValue("@P_RIGHT", right.ToString)

                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

            End Using

            'code for registration
            Using cmd As New SqlCommand("UPDATE RegTable SET MATRIX_LEFT = @M_LEFT, MATRIX_RIGHT = @M_RIGHT WHERE  REG_ID = '" + RegID + "'", thisConnection)

                cmd.CommandType = CommandType.Text
                'cmd.Parameters.AddWithValue("@REG\_ID", txtRegId.Value)

                cmd.Parameters.AddWithValue("@M_LEFT", left)

                cmd.Parameters.AddWithValue("@M_RIGHT", right)

                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

            End Using




            'code for registration
            Using cmd As New SqlCommand("UPDATE RegTable SET MATRIX_RIGHT = MATRIX_RIGHT + 2 WHERE " + _
                                        "REG_ID = @P_ID", thisConnection)

                cmd.CommandType = CommandType.Text
                'cmd.Parameters.AddWithValue("@REG\_ID", txtRegId.Value)

                cmd.Parameters.AddWithValue("@P_ID", ParentID)

                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()



                '*****************************************************************************************************************
            End Using

            insertDashboard()

            Dim bgWork As New BackgroundWorker

            AddHandler bgWork.DoWork, AddressOf bgWork_doWork
            Dim args As New ArrayList
            args.Add(left)
            args.Add(right)
            'bgWork.RunWorkerAsync(args)
            updateParentLevels(left, right)

        End If

    End Sub

    Protected Function getDownlineCount(ByVal left As Integer, ByVal right As Integer) As Integer
        Dim into1 As String = String.Format("SELECT count(*) as Number  FROM RegTable where MATRIX_LEFT > " + left.ToString + " and MATRIX_RIGHT < " + right.ToString)
        'passing the variable to the datatable
        Dim dsworky As DataTable = cc.SelectDataTableRecords(into1)

        'check if court its empty
        If dsworky.Rows.Count > 0 Then
            Dim parentLeft As Integer = dsworky.Rows(0)("Number")
            Return parentLeft
        End If

        Return 0
    End Function

    Protected Function getDownlineCount(ByVal left As Integer, ByVal right As Integer, ByVal level As Integer) As Integer
        Dim into1 As String = String.Format("SELECT count(*) as Number  FROM RegTable where MATRIX_LEFT > " + _
                                            left.ToString + " and MATRIX_RIGHT < " + right.ToString + " and CURRENT_STAGE_ID = " + level.ToString)
        'passing the variable to the datatable
        Dim dsworky As DataTable = cc.SelectDataTableRecords(into1)

        'check if court its empty
        If dsworky.Rows.Count > 0 Then
            Dim parentLeft As Integer = dsworky.Rows(0)("Number")
            Return parentLeft
        End If

        Return 0
    End Function



    Protected Sub btnsubmit_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsubmit.ServerClick
        clearText()
    End Sub


    Protected Sub clearText()
        txtAccountName.Value = ""
        txtAccountNumber.Value = ""
        txtAddress.Value = ""
        txtBankName.Value = ""
        txtCity.Value = ""
        txtConfirmPassword.Value = ""
        txtCountry.Value = ""
        txtDOB.Value = ""
        txtEmail.Value = ""
        txtFirstName.Value = ""
        txtGender.Value = ""
        txtLastName.Value = ""
        txtPassword.Value = ""
        txtPhone.Value = ""
        txtRegId.Value = ""
        txtSponsorID.Value = ""
        txtSponsorName.Value = ""
        txtSponsorPhoneNo.Value = ""
        txtState.Value = ""
        txtUsersName.Value = ""
    End Sub

    Protected Sub insertDashboard()
        Try

            'INSERT INTO Dashboard table
            Using cmd As New SqlCommand("insert into DashboardTable (REQUEST_TRANSFER, UUID, REG_ID, SPONSOR_ID, CURRENT_STAGE, CURRENT_STAGE_ID, TOTAL_BONUS_EARN_U, TOTAL_BONUS_EARN_N, TOTAL_BONUS_WITHDRAWN_U, TOTAL_BONUS_WITHDRAWN_N, TOTAL_EWALLET_BALANCE_U, TOTAL_EWALLET_BALANCE_N)values (@REQUEST_TRANSFER, @UUID, @REG_ID, @SPONSOR_ID, @CURRENT_STAGE, @CURRENT_STAGE_ID, @TOTAL_BONUS_EARN_U, @TOTAL_BONUS_EARN_N, @TOTAL_BONUS_WITHDRAWN_U, @TOTAL_BONUS_WITHDRAWN_N, @TOTAL_EWALLET_BALANCE_U, @TOTAL_EWALLET_BALANCE_N)", thisConnection)
                cmd.CommandType = CommandType.Text

                cmd.Parameters.AddWithValue("@REQUEST_TRANSFER", "Fund Request")
                cmd.Parameters.AddWithValue("@UUID", "" + Guid.NewGuid().ToString)
                cmd.Parameters.AddWithValue("@REG_ID", txtRegId.Value)
                cmd.Parameters.AddWithValue("@SPONSOR_ID", txtSponsorID.Value)
                cmd.Parameters.AddWithValue("@CURRENT_STAGE", "STARTER")
                cmd.Parameters.AddWithValue("@TOTAL_BONUS_EARN_U", 0)
                cmd.Parameters.AddWithValue("@TOTAL_BONUS_EARN_N", 0)
                cmd.Parameters.AddWithValue("@TOTAL_BONUS_WITHDRAWN_U", 0)
                cmd.Parameters.AddWithValue("@TOTAL_BONUS_WITHDRAWN_N", 0)
                cmd.Parameters.AddWithValue("@TOTAL_EWALLET_BALANCE_U", 0)
                cmd.Parameters.AddWithValue("@TOTAL_EWALLET_BALANCE_N", 0)
                cmd.Parameters.AddWithValue("@CURRENT_STAGE_ID", 1)


                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

            End Using
        Catch ex As Exception
        End Try

    End Sub

    Protected Sub insertEntryLevel()
        Try

            'INSERT INTO Dashboard table
            Using cmd As New SqlCommand("insert into EntryLevelTable (UUID, REG_ID, SPONSOR_ID, USERSNAME)values (@UUID, @REG_ID, @SPONSOR_ID, @USERSNAME)", thisConnection)
                cmd.CommandType = CommandType.Text

                cmd.Parameters.AddWithValue("@UUID", "" + Guid.NewGuid().ToString)
                cmd.Parameters.AddWithValue("@REG_ID", txtRegId.Value)
                cmd.Parameters.AddWithValue("@SPONSOR_ID", txtSponsorID.Value)
                cmd.Parameters.AddWithValue("@USERSNAME", txtUsersName.Value)


                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

            End Using
        Catch ex As Exception
        End Try
    End Sub


    Protected Sub btnClear_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.ServerClick
        insert()
    End Sub

    Private Sub updateParentLevels(ByVal left As Integer, ByVal right As Integer)
        Dim into1 As String = String.Format("SELECT REG_ID FROM RegTable where MATRIX_LEFT < " + left.ToString + " and MATRIX_RIGHT > " + right.ToString + " ORDER BY MATRIX_RIGHT ASC")
        'passing the variable to the datatable
        Dim dsworky As DataTable = cc.SelectDataTableRecords(into1)

        'check if court its empty
        If dsworky.Rows.Count > 0 Then
            For index As Integer = 0 To dsworky.Rows.Count - 1
                Dim regId As String = dsworky.Rows(index)("REG_ID").ToString()
                Dim currentLevel As Integer = getCurrentLevel(regId)
                If memberHasCompletedLevel(regId, currentLevel) = True Then
                    Dim bonus = getLevelBonus(currentLevel)
                    creditMember(regId, bonus)
                    Dim nextLevel = currentLevel + 1
                    addMemberLevel(regId, nextLevel)
                End If
            Next
        End If
    End Sub

    Private Function getCurrentLevel(ByVal regId As String) As Integer
        Dim into1 As String = String.Format("SELECT CURRENT_STAGE_ID  FROM DashboardTable where REG_ID = '" + regId + "'")
        'passing the variable to the datatable
        Dim dsworky As DataTable = cc.SelectDataTableRecords(into1)

        'check if court its empty
        If dsworky.Rows.Count > 0 Then
            Return dsworky.Rows(0)("CURRENT_STAGE_ID")
        End If
        Return 0
    End Function

    Private Function memberHasCompletedLevel(ByVal regId As String, ByVal currentLevel As Integer) As Boolean
        If currentLevel = 1 Then
            Return memberHasCompletedEntryLevel(regId)
        Else
            'check that the current level matrix is balance
            Dim tree As Tree
            tree = getCurrentLevelTree(regId)
            Return tree.IsBalance(4)

            'Dim sql = "select REG_ID from RegTable where PARENT_ID = '" + regId + "'"
            'Dim dsworky As DataTable = cc.SelectDataTableRecords(sql)
            'If dsworky.Rows.Count > 0 Then
            '    For index As Integer = 0 To dsworky.Rows.Count - 1
            '        Dim downlineRegId = dsworky.Rows(0)("REG_ID").ToString
            '        If levelDownlineCount(downlineRegId, currentLevel) < 7 Then
            '            Return False
            '        End If
            '    Next
            '    Return True
            'End If
            'Return False

        End If
    End Function

    

    Private Function getLevelBonus(ByVal levelId As Integer) As Object
        Dim sql = "select BONUS from LevelTable where ID = '" + levelId.ToString + "'"
        Dim dsworky As DataTable = cc.SelectDataTableRecords(sql)
        If dsworky.Rows.Count > 0 Then
            Return dsworky.Rows(0)("BONUS")
        End If
        Return 0
    End Function

    Private Sub creditMember(ByVal regId As String, ByVal bonus As Object)
        Dim sql = "update DashboardTable set TOTAL_EWALLET_BALANCE_U = TOTAL_EWALLET_BALANCE_U + @TOTAL_EWALLET_BALANCE_U, TOTAL_EWALLET_BALANCE_N = TOTAL_EWALLET_BALANCE_N + @TOTAL_EWALLET_BALANCE_N, TOTAL_BONUS_EARN_U = TOTAL_BONUS_EARN_U + @TOTAL_BONUS_EARN_U, TOTAL_BONUS_EARN_N = TOTAL_BONUS_EARN_N + @TOTAL_BONUS_EARN_N where REG_ID = @REG_ID"
        Using cmd As New SqlCommand(sql, thisConnection)
            cmd.CommandType = CommandType.Text

            cmd.Parameters.AddWithValue("@TOTAL_BONUS_EARN_U", bonus)
            cmd.Parameters.AddWithValue("@TOTAL_BONUS_EARN_N", bonus * 200)

            cmd.Parameters.AddWithValue("@TOTAL_EWALLET_BALANCE_U", bonus)
            cmd.Parameters.AddWithValue("@TOTAL_EWALLET_BALANCE_N", bonus * 200)


            cmd.Parameters.AddWithValue("@REG_ID", regId)


            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

        End Using
    End Sub

    Private Sub addMemberLevel(ByVal regId As String, ByVal levelId As Integer)
        Dim sql = "insert into MatrixLevel(REG_ID, LEVEL_ID, ENTRY_DATE) Values(@REG_ID, @LEVEL_ID, @DATE)"
        Using cmd As New SqlCommand(sql, thisConnection)
            cmd.CommandType = CommandType.Text

            cmd.Parameters.AddWithValue("@REG_ID", regId)
            cmd.Parameters.AddWithValue("@LEVEL_ID", levelId)
            cmd.Parameters.AddWithValue("@DATE", Date.Now.Date)


            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

        End Using
        sql = "UPDATE RegTable SET CURRENT_STAGE_ID = @CURRENT_STAGE_ID WHERE REG_ID = @REG_ID;"
        sql += "UPDATE d SET d.CURRENT_STAGE_ID = @CURRENT_STAGE_ID, d.CURRENT_STAGE = L.NAME FROM DashboardTable d JOIN LevelTable L ON L.ID = @CURRENT_STAGE_ID WHERE REG_ID = @REG_ID"
        Using cmd As New SqlCommand(sql, thisConnection)
            cmd.CommandType = CommandType.Text

            cmd.Parameters.AddWithValue("@REG_ID", regId)
            cmd.Parameters.AddWithValue("@CURRENT_STAGE_ID", levelId)


            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

        End Using
    End Sub

    Private Function memberHasCompletedEntryLevel(ByVal regId As String) As Boolean
        Dim sql = "select REG_ID from RegTable where PARENT_ID = '" + regId + "'"
        Dim dsworky As DataTable = cc.SelectDataTableRecords(sql)
        If dsworky.Rows.Count > 0 Then
            For index As Integer = 0 To dsworky.Rows.Count - 1
                sql = "select REG_ID from RegTable where PARENT_ID = '" + dsworky.Rows(index)("REG_ID") + "'"
                Dim dsworky2 As DataTable = cc.SelectDataTableRecords(sql)
                If dsworky2.Rows.Count < 2 Then
                    Return False
                End If
            Next
            Return True
        End If
        Return False
    End Function


    Private Function levelDownlineCount(ByVal regId As String, ByVal currentLevel As Integer) As Integer
        Dim sql = "select MATRIX_LEFT, MATRIX_RIGHT from RegTable where REG_ID = '" + regId + "'"
        Dim dsworky As DataTable = cc.SelectDataTableRecords(sql)
        If dsworky.Rows.Count > 0 Then
            Return getDownlineCount(dsworky.Rows(0)("MATRIX_LEFT"), dsworky.Rows(0)("MATRIX_RIGHT"), currentLevel)
        End If
        Return 0
    End Function

    Private Sub bgWork_doWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        Dim args As ArrayList = CType(e.Argument, ArrayList)
        updateParentLevels(args(0), args(1))
    End Sub

    Protected Sub LnkValidateID_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkValidateID.Click
        lblMessage.Text = ""
        lblValidateStatus.Text = ""
        If txtSponsorID.Value = "" Or txtRegId.Value = "" Then
            lblValidateStatus.Visible = True
            lblValidateStatus.ForeColor = Color.Red
            lblValidateStatus.Text = "Please enter ID's to validate"
        Else

            Dim into5 As String = String.Format("SELECT * FROM RegTable where PARENT_ID = '" + txtSponsorID.Value + "'")
            'passing the variable to the datatable
            Dim dsworky5 As DataTable = cc.SelectDataTableRecords(into5)

            'check if court its empty
            If dsworky5.Rows.Count = 2 Then
                lblMessage.Visible = True
                lblMessage.ForeColor = Color.Yellow
                lblMessage.Text = "CHOOSE ANOTHER SPONSOR  "
            Else

                Try

                    Dim into2 As String = String.Format("SELECT USERSNAME, MOBILE FROM RegTable where REG_ID = '" + txtSponsorID.Value + "'")
                    'passing the variable to the datatable
                    Dim dsworky2 As DataTable = cc.SelectDataTableRecords(into2)

                    'check if court its empty
                    If dsworky2.Rows.Count > 0 Then
                        txtSponsorName.Value = dsworky2.Rows(0)("USERSNAME").ToString
                        txtSponsorPhoneNo.Value = dsworky2.Rows(0)("MOBILE").ToString
                        lblValidateStatus.Visible = True
                        lblValidateStatus.ForeColor = Color.Yellow
                        validatedSponsor = "SPONSORID VERIFIED "
                    Else
                        lblValidateStatus.Visible = True
                        lblValidateStatus.ForeColor = Color.Red
                        validatedSponsor = "SPONSORID NOT VERIFIED "
                    End If



                    Dim into3 As String = String.Format("SELECT REG_ID, USERSNAME FROM RegTable where REG_ID = '" + txtRegId.Value + "'")
                    'passing the variable to the datatable
                    Dim dsworky3 As DataTable = cc.SelectDataTableRecords(into3)

                    'check if court its empty
                    If dsworky3.Rows.Count > 0 Then
                        If dsworky3.Rows(0)("USERSNAME").ToString = "" Then
                            lblValidateStatus.Visible = True
                            lblValidateStatus.ForeColor = Color.Yellow
                            validatedReg = "REGID VERIFIED "
                        Else
                            lblValidateStatus.Visible = True
                            lblValidateStatus.ForeColor = Color.Red
                            validatedReg = "REGID HAS BEEN USED"
                        End If
                    Else
                        lblValidateStatus.Visible = True
                        lblValidateStatus.ForeColor = Color.Red
                        validatedReg = "REGID NOT VERIFIED"
                    End If


                    lblValidateStatus.Visible = True
                    lblValidateStatus.ForeColor = Color.Yellow
                    lblValidateStatus.Text = validatedSponsor + validatedReg

                Catch ex As Exception

                    lblValidateStatus.Visible = True
                    lblValidateStatus.ForeColor = Color.Red
                    lblValidateStatus.Text = validatedSponsor + validatedReg
                    lblValidateStatus.Visible = True

                End Try
            End If
        End If
    End Sub

    Protected Sub deleteUserGeneratedPin()

        Try
            thisConnection.Open()
            Dim into1 As String = String.Format("DELETE FROM SentPinsTable where PINS ='" + txtRegId.Value + "'")
            'passing the variable to the datatable
            Dim dsworky As DataTable = cc.SelectDataTableRecords(into1)


        Catch ex As Exception

        End Try
        thisConnection.Close()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        btnsubmit.Attributes.Add("onclick", "return confirm('Please ensure you go through the information you provided before clicking on OK, else click on Cancel?')")
    End Sub

    Private Function getCurrentLevelTree(regId As String) As Tree
        thisConnection.Open()
        Dim into1 As String = String.Format("SELECT  MATRIX_LEFT, MATRIX_RIGHT, USERSNAME, REG_ID, CURRENT_STAGE_ID FROM RegTable where REG_ID ='" + regId + "'")
        'passing the variable to the datatable
        Dim dsworky As DataTable = cc.SelectDataTableRecords(into1)

        If dsworky.Rows.Count > 0 Then
            Dim rootMember As New Member

            rootMember.Left = dsworky.Rows(0)("MATRIX_LEFT")
            rootMember.Right = dsworky.Rows(0)("MATRIX_RIGHT")
            rootMember.Stage = dsworky.Rows(0)("CURRENT_STAGE_ID")

            rootMember.RegId = dsworky.Rows(0)("REG_ID")
            rootMember.Name = dsworky.Rows(0)("USERSNAME")
            'lblStage.Text = dsworky.Rows(0)("CURRENT_STAGE")




            Dim selectedLevel As Integer = rootMember.Stage
            'fetch the downlines

            Dim sql = "SELECT MATRIX_LEFT, MATRIX_RIGHT, USERSNAME, REG_ID, CURRENT_STAGE_ID FROM RegTable where MATRIX_LEFT between " + rootMember.Left.ToString + " and " + rootMember.Right.ToString + " and  CURRENT_STAGE_ID = " + selectedLevel.ToString + " order by MATRIX_LEFT asc"
            dsworky = cc.SelectDataTableRecords(sql)

            'check if court its empty
            If dsworky.Rows.Count > 0 Then
                Dim members As New System.Collections.Generic.List(Of Member)
                For index As Integer = 0 To dsworky.Rows.Count - 1
                    Dim member As New Member

                    member.Left = dsworky.Rows(index)("MATRIX_LEFT")
                    member.Right = dsworky.Rows(index)("MATRIX_RIGHT")
                    member.Stage = dsworky.Rows(index)("CURRENT_STAGE_ID")
                    member.RegId = dsworky.Rows(index)("REG_ID")
                    member.Name = dsworky.Rows(index)("USERSNAME")

                    members.Add(member)
                Next

                Dim tree As Tree = New Tree(rootMember, members, 1)

                Return tree

            End If
        Else

        End If
        Return Nothing

    End Function

End Class
