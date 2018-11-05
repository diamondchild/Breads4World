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
Partial Class Dashboard
    Inherits System.Web.UI.Page
    Dim thisConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("Bread4WorldConnectionString").ConnectionString)
    Dim dsworky As New DataTable()
    Dim cc As Code_Class = New Code_Class()
    Dim dadapt As New SqlDataAdapter()
    Private sqlcmd As SqlCommand
    Private da As New SqlDataAdapter
    Private dt As New DataTable
    Private ds As New DataSet
    Dim bonus As Integer
    Protected Sub getDashbaordInfo()

        Try
            thisConnection.Open()
            Dim into1 As String = String.Format("SELECT * FROM DashboardTable where REG_ID ='" + lblReg_Id.Text + "'")
            'passing the variable to the datatable
            Dim dsworky As DataTable = cc.SelectDataTableRecords(into1)

            'check if court its empty
            If dsworky.Rows.Count > 0 Then
                bonus = dsworky.Rows(0)("CURRENT_STAGE_ID")
                lblCurrentStage.Text = dsworky.Rows(0)("CURRENT_STAGE").ToString
                lbltotalbonusearnedusd.Text = dsworky.Rows(0)("TOTAL_BONUS_EARN_U").ToString
                lbltotalbonusearnedngn.Text = dsworky.Rows(0)("TOTAL_BONUS_EARN_N").ToString
                lbltotalbonuswithdrawnusd.Text = dsworky.Rows(0)("TOTAL_BONUS_WITHDRAWN_U").ToString
                lbltotalbonuswithdrawnedngn.Text = dsworky.Rows(0)("TOTAL_BONUS_WITHDRAWN_N").ToString
                lbltotalewalletbalanceusd.Text = dsworky.Rows(0)("TOTAL_EWALLET_BALANCE_U").ToString
                lbltotalewalletbalancengn.Text = dsworky.Rows(0)("TOTAL_EWALLET_BALANCE_N").ToString

                lbltotalfoodstuffbalanceusd.Text = dsworky.Rows(0)("TOTAL_FOODSTUFF_BALANCE_U").ToString
                lbltotalfoodstuffbalancengn.Text = dsworky.Rows(0)("TOTAL_FOODSTUFF_BALANCE_N").ToString
                lbltotalfoodstuffearnedusd.Text = dsworky.Rows(0)("TOTAL_FOODSTUFF_EARN_U").ToString
                lbltotalfoodstuffearnedngn.Text = dsworky.Rows(0)("TOTAL_FOODSTUFF_EARN_N").ToString
                lbltotalfoodstuffwithdrawnusd.Text = dsworky.Rows(0)("TOTAL_FOODSTUFF_WITHDRAWN_U").ToString
                lbltotalfoodstuffwithdrawngn.Text = dsworky.Rows(0)("TOTAL_FOODSTUFF_WITHDRAWN_N").ToString


                btnFundRequest.InnerText = dsworky.Rows(0)("REQUEST_TRANSFER").ToString
                btnFoodstuffRequest.InnerHtml = dsworky.Rows(0)("REQUEST_FOOD_TRANSFER").ToString

                ''Food items collection 
                'If dsworky.Rows(0)("FOOD_REQUEST").ToString = "TRUE" Then
                '    lblFoodItemStatus.Text = "CONGRATULATIONS, YOU ARE QUALIFIED FOR FOOD ITEMS WORTH "

                '    Select Case bonus
                '        Case 2
                '            lblFoodPoint.Text = "$18"
                '        Case 2
                '            lblFoodPoint.Text = "$75"
                '        Case 4
                '            lblFoodPoint.Text = "$250"
                '        Case 5
                '            lblFoodPoint.Text = "$500"
                '        Case 6
                '            lblFoodPoint.Text = "$1000"

                '    End Select
                'ElseIf dsworky.Rows(0)("FOOD_REQUEST").ToString = "FALSE" Then

                '    lblFoodItemStatus.Text = "FOOD ITEMS FOR THIS STAGE HAS BEEN COLLECTED"
                '    lblFoodPoint.Text = ""
                'Else

                '    lblFoodItemStatus.Text = ""
                '    lblFoodPoint.Text = ""
                'End If

            Else
                lblMessage.Visible = True
                lblMessage.ForeColor = Color.Red
                lblMessage.Text = "Dashboard Information Empty. Please contact admin"
            End If
        Catch ex As Exception

        End Try
        thisConnection.Close()
    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        If Session("sponsorphoneno") IsNot Nothing Then
            lblSponsorID.Text = Session("sponsorid").ToString
            lblSponsorName.Text = Session("sponsorname").ToString
            lblSponsorPhoneNo.Text = Session("sponsorphoneno").ToString
            lblReg_Id.Text = Session("userid").ToString
            lblUsername.Text = Session("username").ToString

            validatePage()
            getDashbaordInfo()
            LoadRepeater()
        Else
            Response.Redirect("~/Login.aspx")
        End If

    End Sub

    Protected Sub validatePage()

        Try
            thisConnection.Open()
            Dim into1 As String = String.Format("SELECT ONLINE_STATUS FROM RegTable where REG_ID ='" + lblReg_Id.Text + "'")
            'passing the variable to the datatable
            Dim dsworky As DataTable = cc.SelectDataTableRecords(into1)

            'check if court its empty
            If dsworky.Rows.Count > 0 Then


                If Session("ONLINE_STATUS").ToString = "ONLINE" Then
                    'do nothing
                Else
                    Response.Redirect("~/Login.aspx")
                End If

            Else
                Response.Redirect("~/Login.aspx")
            End If
        Catch ex As Exception

        End Try
        thisConnection.Close()
    End Sub

    Protected Sub Logout()
        thisConnection.Open()
        Try
            'insert into General table

            Using cmd As New SqlCommand("UPDATE RegTable SET ONLINE_STATUS = @ONLINE_STATUS where REG_ID  ='" + lblReg_Id.Text + "'", thisConnection)

                cmd.Parameters.AddWithValue("@ONLINE_STATUS", "OFFLINE")

                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                thisConnection.Close()
                Session.Clear()
                Response.Redirect("~/Login.aspx")
            End Using

        Catch ex As Exception

        End Try

    End Sub


    Protected Sub lnkLogout_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkLogout.ServerClick
        Logout()
    End Sub

    Protected Sub btnFundRequest_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFundRequest.ServerClick
        If btnFundRequest.InnerText = "PENDING" Then
            'Do nothing
        Else
            Session.Add("regID", lblReg_Id.Text)
            Session.Add("eWalletBalance", lbltotalewalletbalanceusd.Text)
            Response.Redirect("FundRequest.aspx")
        End If
    End Sub


   

    'Protected Sub Repeater2_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles Repeater2.ItemCommand
    '    If e.CommandName = "viewUsed" Then
    '        Dim ID As HiddenField = CType(e.Item.FindControl("systemHiddenID"), HiddenField)

    '        Dim userid = ID.Value

    '        Session.Add("userid", ID.Value)
    '        'Dim sScript As String = "window.open('PaymentDetails.aspx', '_blank','width=50,height=50,left=20,top=30,resizable=yes,titlebar=no,bar=yes');"
    '        'ScriptManager.RegisterStartupScript(Me, GetType(Page), "MyOpener34344", sScript, True)
    '        deleteUser(userid)
    '    End If
    'End Sub

    'Protected Sub deleteUser(ByVal value As String)

    '    Try
    '        thisConnection.Open()
    '        Dim into1 As String = String.Format("DELETE FROM SentPinsTable where UUID ='" + value + "'")
    '        'passing the variable to the datatable
    '        Dim dsworky As DataTable = cc.SelectDataTableRecords(into1)


    '    Catch ex As Exception

    '    End Try
    '    thisConnection.Close()
    '    LoadRepeater()
    'End Sub
    Private Sub LoadRepeater()
        dt.Rows.Clear()
        thisConnection.Open()
        sqlcmd = New SqlCommand("SELECT * from SentPinsTable WHERE usersname = '" + lblUsername.Text + "'", thisConnection)
        da = New SqlDataAdapter(sqlcmd)
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            Repeater2.Visible = True
            Repeater2.DataSource = dt
            Repeater2.DataBind()
        Else
            lblSentPIn.Visible = True
            lblSentPIn.ForeColor = Color.Red
            lblSentPIn.Text = "No PINS sent from Admin"
        End If
        thisConnection.Close()
    End Sub

    Protected Sub btnFoodstuffRequest_ServerClick1(sender As Object, e As System.EventArgs) Handles btnFoodstuffRequest.ServerClick

        If btnFundRequest.InnerText = "PENDING" Then
            'Do nothing
        Else
            Session.Add("regID", lblReg_Id.Text)
            Session.Add("foodStuffBalance", lbltotalfoodstuffbalanceusd.Text)
            Response.Redirect("FoodRequest.aspx")
        End If

    End Sub
End Class
