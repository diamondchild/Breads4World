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
Partial Class TransactionDetails
    Inherits System.Web.UI.Page
    Dim dsworky As New DataTable
    Dim dbCall As New Code_Class()
    Dim thisConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("Bread4WorldConnectionString").ConnectionString)


    Private Sub displayRepeater()

        lblMessage.Text = Nothing
        dsworky.Clear()
        dsworky = dbCall.SelectDataTableRecords(String.Format("SELECT REG_ID, AMOUNT, TRANSACTION_TYPE, DESCRIPTION, _DATE FROM TransactionTable where REG_ID = '" + lblReg_Id.Text + "'"))
        If dsworky.Rows.Count > 0 Then
            Repeater2.Visible = True
            Repeater2.DataSource = dsworky
            Repeater2.DataBind()
        Else
            lblMessage.ForeColor = Color.Blue
            lblmessage.Text = "No Transaction has been made on this account"
            Repeater2.Visible = False
            Repeater2.Visible = False
        End If

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
