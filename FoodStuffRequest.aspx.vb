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
Partial Class FoodStuffRequest
     Inherits System.Web.UI.Page
    Dim dsworky As New DataTable
    Dim dbCall As New Code_Class()
    Dim userID, requestedAmount As String
    Dim thisConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("Bread4WorldConnectionString").ConnectionString)


    Private Sub displayRepeater()

        lblMessage.Text = Nothing
        dsworky.Clear()
        dsworky = dbCall.SelectDataTableRecords(String.Format("SELECT REG_ID, CURRENT_STAGE, TOTAL_FOODSTUFF_EARN_U, TOTAL_FOODSTUFF_WITHDRAWN_U, TOTAL_FOODSTUFF_BALANCE_U, REQUESTED_FOOD_AMOUNT, REQUEST_FOOD_TRANSFER FROM DashboardTable where REQUEST_FOOD_TRANSFER = 'PENDING'"))
        If dsworky.Rows.Count > 0 Then
            Repeater2.Visible = True
            Repeater2.DataSource = dsworky
            Repeater2.DataBind()
        Else
            lblMessage.ForeColor = Color.Blue
            lblmessage.Text = "No request has been made"
            Repeater2.Visible = False
            Repeater2.Visible = False
        End If

    End Sub

    Protected Sub Repeater2_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles Repeater2.ItemCommand
        If e.CommandName = "viewDetails" Then
            Dim ID As HiddenField = CType(e.Item.FindControl("systemHiddenID"), HiddenField)
            Dim amount As HiddenField = CType(e.Item.FindControl("requestedAmount"), HiddenField)
            userID = ID.Value
            requestedAmount = amount.Value
            updateDashboard()
        End If
    End Sub

    Private Sub updateDashboard()
        thisConnection.Open()
        Dim sql = "update DashboardTable set  REQUESTED_FOOD_AMOUNT = @REQUESTED_FOOD_AMOUNT, REQUEST_FOOD_TRANSFER = @REQUEST_FOOD_TRANSFER  where REG_ID = @REG_ID"
        Using cmd As New SqlCommand(sql, thisConnection)
            cmd.CommandType = CommandType.Text

            cmd.Parameters.AddWithValue("@REQUESTED_FOOD_AMOUNT", 0)
            cmd.Parameters.AddWithValue("@REQUEST_FOOD_TRANSFER", "Food Stuff Request")
            cmd.Parameters.AddWithValue("@REG_ID", userID)


            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
            setTransactionDetails()
            displayRepeater()
        End Using
        thisConnection.Close()
    End Sub

    Private Sub setTransactionDetails()
        Dim sql = "insert into TransactionTable(UUID, REG_ID, AMOUNT, TRANSACTION_TYPE, DESCRIPTION, _DATE) Values(@UUID, @REG_ID, @AMOUNT, @TRANSACTION_TYPE, @DESCRIPTION, @_DATE)"
        Using cmd As New SqlCommand(sql, thisConnection)
            cmd.CommandType = CommandType.Text

            cmd.Parameters.AddWithValue("@UUID", Guid.NewGuid().ToString)
            cmd.Parameters.AddWithValue("@REG_ID", userID)
            cmd.Parameters.AddWithValue("@AMOUNT", requestedAmount)
            cmd.Parameters.AddWithValue("@TRANSACTION_TYPE", "FOOD ITEM TRANSFER")
            cmd.Parameters.AddWithValue("@DESCRIPTION", "The equivalent amount of Food Item has been sent to user")
            cmd.Parameters.AddWithValue("@_DATE", Date.Now.Date)

            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

        End Using

    End Sub


 Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If Session("userid") IsNot Nothing Then
            lblReg_Id.Text = Session("userid").ToString
            displayRepeater()
        Else
            Response.Redirect("Login.aspx")
        End If

    End Sub


    Protected Sub lnkLogout_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkLogout.ServerClick
        Session.Clear()
        Response.Redirect("Login.aspx")
    End Sub
End Class
