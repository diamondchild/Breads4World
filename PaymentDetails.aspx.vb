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
Partial Class PaymentDetails
    Inherits System.Web.UI.Page
    Dim dsworky As New DataTable
    Dim dbCall As New Code_Class()
    Dim thisConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("Bread4WorldConnectionString").ConnectionString)
    Dim cc As Code_Class = New Code_Class()

    Protected Sub getBankDetails()

        Dim into1 As String = String.Format("SELECT USERSNAME, BANK_NAME, ACCOUNT_NAME, ACCOUNT_NUMBER FROM RegTable where REG_ID ='" + lblID.Text + "'")
        'passing the variable to the datatable
        Dim dsworky As DataTable = cc.SelectDataTableRecords(into1)

        'check if court its empty
        If dsworky.Rows.Count > 0 Then
            lblUserName.Text = dsworky.Rows(0)("USERSNAME").ToString
            lblAccountName.Text = dsworky.Rows(0)("ACCOUNT_NAME").ToString
            lblBankName.Text = dsworky.Rows(0)("BANK_NAME").ToString
            lblAccountNumber.Text = dsworky.Rows(0)("ACCOUNT_NUMBER").ToString

        End If
    End Sub



    Private Sub updateDashboard()
        thisConnection.Open()
        Dim sql = "update DashboardTable set  REQUESTED_AMOUNT = @REQUESTED_AMOUNT, REQUEST_TRANSFER = @REQUEST_TRANSFER  where REG_ID = @REG_ID"
        Using cmd As New SqlCommand(sql, thisConnection)
            cmd.CommandType = CommandType.Text

            cmd.Parameters.AddWithValue("@REQUESTED_AMOUNT", 0)
            cmd.Parameters.AddWithValue("@REQUEST_TRANSFER", "Fund Request")
            cmd.Parameters.AddWithValue("@REG_ID", lblID.Text)


            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
            setTransactionDetails()
            Response.Redirect("Transfer.aspx")
        End Using
        thisConnection.Close()
    End Sub

    Protected Sub btnDone_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDone.Click
        lblMessage.Text = ""
        If txtDescription.Text = "" Then
            lblMessage.Visible = True
            lblMessage.ForeColor = Color.Red
            lblMessage.Text = "Please add a description to before you click on the Done button"
        Else
            updateDashboard()
        End If
    End Sub

    Protected Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init
        If Session("userid") IsNot Nothing Then
            lblID.Text = Session("userid").ToString
            lblAmount.Text = Session("amount").ToString
            getBankDetails()
        Else
            Response.Redirect("Login.aspx")
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        btnDone.Attributes.Add("onclick", "return confirm('Please ensure you paid this User before you click on OK, else click on Cancel?')")
    End Sub

    Private Sub setTransactionDetails()
        Dim sql = "insert into TransactionTable(UUID, REG_ID, AMOUNT, TRANSACTION_TYPE, DESCRIPTION, _DATE) Values(@UUID, @REG_ID, @AMOUNT, @TRANSACTION_TYPE, @DESCRIPTION, @_DATE)"
        Using cmd As New SqlCommand(sql, thisConnection)
            cmd.CommandType = CommandType.Text

            cmd.Parameters.AddWithValue("@UUID", Guid.NewGuid().ToString)
            cmd.Parameters.AddWithValue("@REG_ID", lblID.Text)
            cmd.Parameters.AddWithValue("@AMOUNT", Val(lblAmount.Text))
            cmd.Parameters.AddWithValue("@TRANSACTION_TYPE", "FUND TRANSFER TO USER")
            cmd.Parameters.AddWithValue("@DESCRIPTION", txtDescription.Text)
            cmd.Parameters.AddWithValue("@_DATE", Date.Now.Date)

            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

        End Using

    End Sub

End Class
