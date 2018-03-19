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
Partial Class Transfer
    Inherits System.Web.UI.Page
    Dim dsworky As New DataTable
    Dim dbCall As New Code_Class()
    Dim thisConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("Bread4WorldConnectionString").ConnectionString)


    Private Sub displayRepeater()

        lblMessage.Text = Nothing
        dsworky.Clear()
        dsworky = dbCall.SelectDataTableRecords(String.Format("SELECT REG_ID, CURRENT_STAGE, TOTAL_BONUS_EARN_U, TOTAL_EWALLET_BALANCE_U, REQUESTED_AMOUNT, REQUEST_TRANSFER FROM DashboardTable where REQUEST_TRANSFER = 'PENDING'"))
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
            Session.Add("userid", ID.Value)
            Session.Add("amount", amount.Value)
            'Dim sScript As String = "window.open('PaymentDetails.aspx', '_blank','width=50,height=50,left=20,top=30,resizable=yes,titlebar=no,bar=yes');"
            'ScriptManager.RegisterStartupScript(Me, GetType(Page), "MyOpener34344", sScript, True)
            Response.Redirect("PaymentDetails.aspx")
        End If
    End Sub

    'Private Sub updateDashboard(ByVal regId As String)
    '    thisConnection.Open()
    '    Dim sql = "update DashboardTable set  REQUESTED_AMOUNT = @REQUESTED_AMOUNT, REQUEST_TRANSFER = @REQUEST_TRANSFER  where REG_ID = @REG_ID"
    '    Using cmd As New SqlCommand(sql, thisConnection)
    '        cmd.CommandType = CommandType.Text


    '        cmd.Parameters.AddWithValue("@REQUESTED_AMOUNT", 0)
    '        cmd.Parameters.AddWithValue("@REQUEST_TRANSFER", "Fund Request")
    '        cmd.Parameters.AddWithValue("@REG_ID", regId)


    '        Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

    '    End Using
    '    thisConnection.Close()
    'End Sub

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
