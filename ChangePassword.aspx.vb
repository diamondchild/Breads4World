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
Partial Class ChangePassword
    Inherits System.Web.UI.Page
    Dim thisConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("Bread4WorldConnectionString").ConnectionString)
    Dim dsworky As New DataTable()
    Dim cc As Code_Class = New Code_Class()
    Dim g_username, g_password As String


    Protected Sub getFields()
        If txtNewPassword.Value = txtConfirmNewPassword.Value Then

            Try
                thisConnection.Open()
                Dim into1 As String = String.Format("SELECT * FROM RegTable where REG_ID = '" + txtRegID.Value + "'")
                'passing the variable to the datatable
                Dim dsworky As DataTable = cc.SelectDataTableRecords(into1)

                'check if court its empty
                If dsworky.Rows.Count > 0 Then
                    If txtPassword.Value = dsworky.Rows(0)("CONFIRM_PASSWORD").ToString Then
                        updateStatus()

                    Else
                        lblMessage.Visible = True
                        lblMessage.ForeColor = Color.Red
                        lblMessage.Text = "Incorrect Password entered!"
                    End If
                Else
                    lblMessage.Visible = True
                    lblMessage.ForeColor = Color.Red
                    lblMessage.Text = "Incorrect RegID entered!"
                End If
            Catch ex As Exception

            End Try
            thisConnection.Close()
        Else
            lblMessage.Visible = True
            lblMessage.ForeColor = Color.Red
            lblMessage.Text = "Password MisMatch!"
        End If
    End Sub

    Protected Sub updateStatus()

        Try
            'insert into General table

            Using cmd As New SqlCommand("UPDATE RegTable SET PASSWORD = @PASSWORD, CONFIRM_PASSWORD = @CONFIRM_PASSWORD where REG_ID ='" + txtRegID.Value + "'", thisConnection)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@PASSWORD", txtConfirmNewPassword.Value)

                cmd.Parameters.AddWithValue("@CONFIRM_PASSWORD", txtConfirmNewPassword.Value)

                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

            End Using
            lblMessage.Visible = True
            lblMessage.ForeColor = Color.Yellow
            lblMessage.Text = "Password Successfully Changed"
        Catch ex As Exception

        End Try

    End Sub


    Protected Sub btnChange_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChange.ServerClick
        getFields()
    End Sub

    Protected Sub btnCancel_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.ServerClick
        Response.Redirect("~/ViewProfile.aspx")
    End Sub
End Class
