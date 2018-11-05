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

Partial Class Genealogy
    Inherits System.Web.UI.Page
    Dim thisConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("Bread4WorldConnectionString").ConnectionString)
    Dim dsworky As New DataTable()
    Dim cc As Code_Class = New Code_Class()
    Dim g_username, g_password As String
    Dim Mleft, Mright As Integer

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        getTreeInfo()
        populateCombo()
    End Sub






    Protected Sub getTreeInfo()
        If Session("userid") IsNot Nothing Then
            Try
                Dim userId = Session("userId")
                If Request("userId") IsNot Nothing Then
                    userId = Request("userId")
                End If
                thisConnection.Open()
                Dim into1 As String = String.Format("SELECT  MATRIX_LEFT, MATRIX_RIGHT, USERSNAME, REG_ID, CURRENT_STAGE_ID FROM RegTable where REG_ID ='" + userId + "'")
                'passing the variable to the datatable
                Dim dsworky As DataTable = cc.SelectDataTableRecords(into1)

                'check if court its empty
                If dsworky.Rows.Count > 0 Then
                    Dim rootMember As New Member

                    rootMember.Left = dsworky.Rows(0)("MATRIX_LEFT")
                    Mleft = dsworky.Rows(0)("MATRIX_LEFT")
                    rootMember.Right = dsworky.Rows(0)("MATRIX_RIGHT")
                    MRight = dsworky.Rows(0)("MATRIX_RIGHT")
                    rootMember.Stage = dsworky.Rows(0)("CURRENT_STAGE_ID")

                    Session.Add(Mleft, "mleft")
                    Session.Add("mright", Mright)
                    Session.Add("mleft", Mleft)

                    Select rootMember.Stage
                        Case 1
                            lblStageName.Text = "Starter"
                        Case 2
                            lblStageName.Text = "Manager"
                        Case 3
                            lblStageName.Text = "Executive"
                        Case 4
                            lblStageName.Text = "Royal"
                        Case 5
                            lblStageName.Text = "Majesty"
                        Case 6
                            lblStageName.Text = "Dynasty"
                    End Select



                    rootMember.RegId = dsworky.Rows(0)("REG_ID")
                    rootMember.Name = dsworky.Rows(0)("USERSNAME")
                    'lblStage.Text = dsworky.Rows(0)("CURRENT_STAGE")


                    Dim selectedLevel As Integer = rootMember.Stage
                    If Request("selectedLevel") IsNot Nothing Then
                        selectedLevel = Request("selectedLevel")
                    End If
                    'fetch the downlines

                    Dim sql = "SELECT MATRIX_LEFT, MATRIX_RIGHT, USERSNAME, REG_ID, CURRENT_STAGE_ID FROM RegTable where MATRIX_LEFT > " + rootMember.Left.ToString + " and MATRIX_RIGHT < " + rootMember.Right.ToString + " and  CURRENT_STAGE_ID >= " + selectedLevel.ToString + " order by MATRIX_LEFT asc"

                    'Dim sql = "SELECT MATRIX_LEFT, MATRIX_RIGHT, USERSNAME, REG_ID, CURRENT_STAGE_ID FROM RegTable where MATRIX_LEFT > " + rootMember.Left.ToString + " and MATRIX_RIGHT < " + rootMember.Right.ToString + " and  CURRENT_STAGE_ID >= " + selectedLevel.ToString + " order by MATRIX_LEFT asc"
                    dsworky = cc.SelectDataTableRecords(sql)

                    'check if court its empty
                    Dim members As New System.Collections.Generic.List(Of Member)
                    If dsworky.Rows.Count > 0 Then
                        For index As Integer = 0 To dsworky.Rows.Count - 1
                            Dim member As New Member

                            member.Left = dsworky.Rows(index)("MATRIX_LEFT")
                            member.Right = dsworky.Rows(index)("MATRIX_RIGHT")
                            member.Stage = dsworky.Rows(index)("CURRENT_STAGE_ID")
                            member.RegId = dsworky.Rows(index)("REG_ID")
                            member.Name = dsworky.Rows(index)("USERSNAME")

                            members.Add(member)
                        Next

                    End If
                    Dim tree As Tree = New Tree(rootMember, members, 1)
                    genealogyDiv.InnerHtml = tree.Display()
                Else

                End If
            Catch ex As Exception

            End Try
            thisConnection.Close()
        Else
            Response.Redirect("~/Login.aspx")
        End If

    End Sub

    Protected Sub Logout()
        thisConnection.Open()
        If Session("userid") IsNot Nothing Then
            Try
                Dim userId = Session("userId")
                If Request("userId") IsNot Nothing Then
                    userId = Request("userId")
                End If

                'insert into General table

                Using cmd As New SqlCommand("UPDATE RegTable SET ONLINE_STATUS = @ONLINE_STATUS where REG_ID  ='" + userId + "'", thisConnection)

                    cmd.Parameters.AddWithValue("@ONLINE_STATUS", "OFFLINE")

                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                    Session.Clear()
                End Using
                Response.Redirect("~/Login.aspx")
            Catch ex As Exception

            End Try
        End If
        thisConnection.Close()

    End Sub

    Protected Sub populateCombo()

        If Not Me.IsPostBack Then
            Dim constr As String = ConfigurationManager.ConnectionStrings("Bread4WorldConnectionString").ConnectionString
            Using con As New SqlConnection(constr)
                Using cmd As New SqlCommand("SELECT USERSNAME, REG_ID FROM RegTable where MATRIX_LEFT between " + Mleft.ToString + " and " + Mright.ToString + " order by MATRIX_LEFT asc ")
                    cmd.CommandType = CommandType.Text
                    cmd.Connection = con
                    con.Open()
                    ddlUsersname.DataSource = cmd.ExecuteReader()
                    ddlUsersname.DataTextField = "UsersName"
                    ddlUsersname.DataValueField = "UsersName"
                    ddlUsersname.DataBind()
                    con.Close()
                End Using
            End Using
            ddlUsersname.Items.Insert(0, New ListItem("--Select User--", "0"))
        End If
    End Sub

    Protected Sub lnkLogout_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkLogout.ServerClick
        Logout()
    End Sub

    Protected Sub ddlUsersname_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlUsersname.SelectedIndexChanged
        Dim sql = "select REG_ID from RegTable where USERSNAME = '" + ddlUsersname.SelectedItem.ToString + "'"
        Dim dsworky As DataTable = cc.SelectDataTableRecords(sql)

        If dsworky.Rows.Count > 0 Then
            Response.Redirect("Genealogy.aspx?userid=" + dsworky.Rows(0)("REG_ID").ToString)
        End If

    End Sub
End Class
