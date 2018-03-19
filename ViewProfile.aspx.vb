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
Partial Class ViewProfile
    Inherits System.Web.UI.Page
    Dim thisConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("Bread4WorldConnectionString").ConnectionString)
    Dim dsworky As New DataTable()
    Dim cc As Code_Class = New Code_Class()


    Protected Sub getFields()
        If Session("userid") IsNot Nothing Then
            Try
                Dim into1 As String = String.Format("SELECT * FROM RegTable where REG_ID ='" + Session("userid") + "'")
                'passing the variable to the datatable
                Dim dsworky As DataTable = cc.SelectDataTableRecords(into1)

                'check if court its empty
                If dsworky.Rows.Count > 0 Then

                    lblfirstname.Text = dsworky.Rows(0)("FIRST_NAME")
                    lbllastname.Text = dsworky.Rows(0)("LAST_NAME")
                    lblCountry.Text = dsworky.Rows(0)("COUNTRY")
                    lblState.Text = dsworky.Rows(0)("STATE")
                    lblCity.Text = dsworky.Rows(0)("CITY")
                    lblEmail.Text = dsworky.Rows(0)("EMAIL")
                    lblMobile.Text = dsworky.Rows(0)("MOBILE")
                    lblGender.Text = dsworky.Rows(0)("GENDER")
                    lblAddress.Text = dsworky.Rows(0)("ADDRESS")
                    lblDOB.Text = dsworky.Rows(0)("DOB")
                    lblUsername.Text = dsworky.Rows(0)("USERSNAME")
                    lblBankName.Text = dsworky.Rows(0)("BANK_NAME")
                    lblAccountName.Text = dsworky.Rows(0)("ACCOUNT_NAME")
                    lblAccountNumber.Text = dsworky.Rows(0)("ACCOUNT_NUMBER")


                End If
            Catch ex As Exception

            End Try

        End If
    End Sub


    Protected Sub btnEdit_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.ServerClick
        If Session("userid") IsNot Nothing Then
            Response.Redirect("~/EditProfile.aspx")
        Else
            lblMessage.Visible = True
            lblMessage.ForeColor = Color.Red
            lblMessage.Text = "Session expires. Pls re-Login to access this feature"
            ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "HideLabel();", True)
        End If

    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        getFields()
    End Sub

    Protected Sub btnChangePassword_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChangePassword.ServerClick
        Response.Redirect("~/ChangePassword.aspx")
    End Sub
End Class
