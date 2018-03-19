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
Partial Class EditProfile
    Inherits System.Web.UI.Page
    Dim thisConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("Bread4WorldConnectionString").ConnectionString)
    Dim dsworky As New DataTable()
    Dim cc As Code_Class = New Code_Class()



    Protected Sub getProfileDetails()

        Try
            thisConnection.Open()
            Dim into1 As String = String.Format("SELECT * FROM RegTable where REG_ID ='" + Session("userid") + "'")
            'passing the variable to the datatable
            Dim dsworky As DataTable = cc.SelectDataTableRecords(into1)

            'check if court its empty
            If dsworky.Rows.Count > 0 Then

                txtFirstName.Value = dsworky.Rows(0)("FIRST_NAME")
                txtLastName.Value = dsworky.Rows(0)("LAST_NAME")
                txtCountry.Value = dsworky.Rows(0)("COUNTRY")
                txtState.Value = dsworky.Rows(0)("STATE")
                txtCity.Value = dsworky.Rows(0)("CITY")
                txtEmail.Value = dsworky.Rows(0)("EMAIL")
                txtPhone.Value = dsworky.Rows(0)("MOBILE")
                txtAddress.Value = dsworky.Rows(0)("ADDRESS")
                txtDOB.Value = dsworky.Rows(0)("DOB")
                txtRegId.Value = dsworky.Rows(0)("REG_ID")
                txtBankName.Value = dsworky.Rows(0)("BANK_NAME")
                txtAccountName.Value = dsworky.Rows(0)("ACCOUNT_NAME")
                txtAccountNumber.Value = dsworky.Rows(0)("ACCOUNT_NUMBER")

            Else
                lblMessage.Visible = True
                lblMessage.ForeColor = Color.Red
                lblMessage.Text = "Error in retrieving your information. Please contact admin"
            End If
        Catch ex As Exception

        End Try
        thisConnection.Close()
    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        getProfileDetails()
    End Sub


    Protected Sub insert()
        thisConnection.Open()

        'validating the textboxes
        If txtFirstName.Value = "" Or _
        txtLastName.Value = "" Or txtCountry.Value = "" Or txtState.Value = "" Or txtCity.Value = "" Or txtEmail.Value = "" _
        Or txtPhone.Value = "" Or txtAddress.Value = "" Or txtDOB.Value = "" Or _
       txtBankName.Value = "" Or txtAccountName.Value = "" Or txtAccountNumber.Value = "" Then
            lblMessage.Visible = True
            lblMessage.ForeColor = Color.Red
            lblMessage.Text = "Submission failed! Ensure all textboxes are filled"
            ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "HideLabel();", True)
        Else


            'avoid dublicate username
            Try


                'code for registration
                Using cmd As New SqlCommand("UPDATE RegTable SET FIRST_NAME = @FIRST_NAME, LAST_NAME = @LAST_NAME, COUNTRY = @COUNTRY, STATE = @STATE, CITY = @CITY, EMAIL = @EMAIL, MOBILE = @MOBILE, ADDRESS = @ADDRESS, DOB = @DOB, BANK_NAME = @BANK_NAME, ACCOUNT_NAME = @ACCOUNT_NAME, ACCOUNT_NUMBER = @ACCOUNT_NUMBER WHERE  REG_ID = '" + txtRegId.Value + "'", thisConnection)

                    cmd.CommandType = CommandType.Text
                    'cmd.Parameters.AddWithValue("@REG\_ID", txtRegId.Value)


                    cmd.Parameters.AddWithValue("@FIRST_NAME", txtFirstName.Value)
                    cmd.Parameters.AddWithValue("@LAST_NAME", txtLastName.Value)
                    cmd.Parameters.AddWithValue("@COUNTRY", txtCountry.Value)
                    cmd.Parameters.AddWithValue("@STATE", txtState.Value)
                    cmd.Parameters.AddWithValue("@CITY", txtCity.Value)
                    cmd.Parameters.AddWithValue("@EMAIL", txtEmail.Value)
                    cmd.Parameters.AddWithValue("@MOBILE", txtPhone.Value)

                    cmd.Parameters.AddWithValue("@ADDRESS", txtAddress.Value)
                    cmd.Parameters.AddWithValue("@DOB", txtDOB.Value)

                    cmd.Parameters.AddWithValue("@BANK_NAME", txtBankName.Value)
                    cmd.Parameters.AddWithValue("@ACCOUNT_NAME", txtAccountName.Value)
                    cmd.Parameters.AddWithValue("@ACCOUNT_NUMBER", txtAccountNumber.Value)

                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                End Using

                lblMessage.Visible = True
                lblMessage.ForeColor = Color.Yellow
                lblMessage.Text = "Profile edit was successful!"
                ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "HideLabel();", True)



            Catch ex As Exception
                lblMessage.Visible = True
                lblMessage.ForeColor = Color.Red
                lblMessage.Text = "Sorry! Your Profile editing wasn't unseccessful"
                ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "HideLabel();", True)
            End Try

        End If
    End Sub



    Protected Sub btnsubmit_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsubmit.ServerClick
        insert()
    End Sub

    Protected Sub btnBack_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.ServerClick
        Response.Redirect("~/ViewProfile.aspx")
    End Sub
End Class
