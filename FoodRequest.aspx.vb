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
Partial Class FoodRequest
    Inherits System.Web.UI.Page
    Dim thisConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("Bread4WorldConnectionString").ConnectionString)
    Dim cc As Code_Class = New Code_Class()


    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If Session("foodStuffBalance") IsNot Nothing And Session("regID") IsNot Nothing Then
            txtFoodItemBalance.Value = Session("foodStuffBalance")

        End If
    End Sub


    Protected Sub btnCancelRequest_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelRequest.ServerClick
        Response.Redirect("Dashboard.aspx")
    End Sub


    Protected Sub btnRequest_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRequest.ServerClick
        If txtAmountWithdrawn.Value.Trim = "" Then
            lblMessage.Visible = True
            lblMessage.ForeColor = Color.Red
            lblMessage.Text = "Pleae enter an amount to withdraw"
        Else
            Dim checkAmount = Val(txtFoodItemBalance.Value.Trim) - Val(txtAmountWithdrawn.Value.Trim)
            If checkAmount < 0 Or txtFoodItemBalance.Value.Trim = "0" Then
                lblMessage.Visible = True
                lblMessage.ForeColor = Color.Red
                lblMessage.Text = " Sorry, insufficient Food Item Balance"
            Else

                updateDashboard(Session("regID"), checkAmount, txtAmountWithdrawn.Value.Trim)
            End If


        End If

    End Sub

    Private Sub updateDashboard(ByVal regId As String, ByVal foodItemBal As Object, ByVal amountToWithdrawn As Object)
        thisConnection.Open()
        Dim sql = "update DashboardTable set TOTAL_FOODSTUFF_BALANCE_U = @TOTAL_FOODSTUFF_BALANCE_U, TOTAL_FOODSTUFF_BALANCE_N = @TOTAL_FOODSTUFF_BALANCE_N, TOTAL_FOODSTUFF_WITHDRAWN_U = TOTAL_FOODSTUFF_WITHDRAWN_U + @TOTAL_FOODSTUFF_WITHDRAWN_U, TOTAL_FOODSTUFF_WITHDRAWN_N = TOTAL_FOODSTUFF_WITHDRAWN_N + @TOTAL_FOODSTUFF_WITHDRAWN_N, REQUEST_FOOD_TRANSFER = @REQUEST_FOOD_TRANSFER, REQUESTED_FOOD_AMOUNT = @REQUESTED_FOOD_AMOUNT where REG_ID = @REG_ID"
        Using cmd As New SqlCommand(sql, thisConnection)
            cmd.CommandType = CommandType.Text

            cmd.Parameters.AddWithValue("@TOTAL_FOODSTUFF_BALANCE_U", foodItemBal)
            cmd.Parameters.AddWithValue("@TOTAL_FOODSTUFF_BALANCE_N", foodItemBal * 200)

            cmd.Parameters.AddWithValue("@TOTAL_FOODSTUFF_WITHDRAWN_U", amountToWithdrawn)
            cmd.Parameters.AddWithValue("@TOTAL_FOODSTUFF_WITHDRAWN_N", amountToWithdrawn * 200)

            cmd.Parameters.AddWithValue("@REQUESTED_FOOD_AMOUNT", amountToWithdrawn)
            cmd.Parameters.AddWithValue("@REQUEST_FOOD_TRANSFER", "PENDING")
            cmd.Parameters.AddWithValue("@REG_ID", regId)


            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
            setTransactionDetails()

            Response.Redirect("Dashboard.aspx")
        End Using
        thisConnection.Close()
    End Sub

    Private Sub setTransactionDetails()
        Dim sql = "insert into TransactionTable(UUID, REG_ID, AMOUNT, TRANSACTION_TYPE, DESCRIPTION, _DATE) Values(@UUID, @REG_ID, @AMOUNT, @TRANSACTION_TYPE, @DESCRIPTION, @_DATE)"
        Using cmd As New SqlCommand(sql, thisConnection)
            cmd.CommandType = CommandType.Text

            cmd.Parameters.AddWithValue("@UUID", Guid.NewGuid().ToString)
            cmd.Parameters.AddWithValue("@REG_ID", Session("regID"))
            cmd.Parameters.AddWithValue("@AMOUNT", txtAmountWithdrawn.Value)
            cmd.Parameters.AddWithValue("@TRANSACTION_TYPE", "REQUESTING FOR FOOD STUFF")
            cmd.Parameters.AddWithValue("@DESCRIPTION", "Request made by user")
            cmd.Parameters.AddWithValue("@_DATE", Date.Now.Date)

            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

        End Using

    End Sub

End Class
