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

Partial Class Login
    Inherits System.Web.UI.Page
    Dim thisConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("Bread4WorldConnectionString").ConnectionString)
    Dim dsworky As New DataTable()

    Dim cc As Code_Class = New Code_Class()

    Dim g_username, g_password As String

    Protected Sub getFields()

        Try
            thisConnection.Open()
            Dim into1 As String = String.Format("SELECT * FROM RegTable where USERSNAME ='" + txtUserName.Value + "' and CONFIRM_PASSWORD = '" + txtPassword.Value + "'")
            'passing the variable to the datatable
            Dim dsworky As DataTable = cc.SelectDataTableRecords(into1)

            'check if court its empty
            If dsworky.Rows.Count > 0 Then

                Session.Add("username", dsworky.Rows(0)("USERSNAME"))
                Session.Add("userid", dsworky.Rows(0)("REG_ID"))
                Session.Add("sponsorid", dsworky.Rows(0)("SPONSOR_ID"))
                Session.Add("sponsorname", dsworky.Rows(0)("SPONSOR_NAME"))
                Session.Add("sponsorphoneno", dsworky.Rows(0)("SPONSOR_PHONE_NO"))

                UpdateStatus()
                Response.Redirect("Dashboard.aspx")
            Else
                adminPass()
                lblMessage.Visible = True
                lblMessage.ForeColor = Color.Red
                lblMessage.Text = "Login failed, Check Credentials or Join Now"
                Page.RegisterStartupScript("FAILED", "<script type=""text/javascript"">alert('Login' Login failed, Check Credentials or Join Now');</script>")
            End If
        Catch ex As Exception

        End Try
        thisConnection.Close()
    End Sub

    Protected Sub adminPass()
        Try

            Dim into1 As String = String.Format("SELECT * FROM AdminTable where username ='" + txtUserName.Value + "' and password = '" + txtPassword.Value + "'")
            'passing the variable to the datatable
            Dim dsworky As DataTable = cc.SelectDataTableRecords(into1)

            'check if court its empty
            If dsworky.Rows.Count > 0 Then

                Session.Add("username", dsworky.Rows(0)("username"))
                Session.Add("userid", dsworky.Rows(0)("reg_id"))
                updateAdminStatus()
                Response.Redirect("Admin.aspx")
            Else
                lblMessage.Visible = True
                lblMessage.ForeColor = Color.Red
                lblMessage.Text = "Login failed, Check Credentials"
                Page.RegisterStartupScript("FAILED", "<script type=""text/javascript"">alert('Login' Login failed, Check Credentials');</script>")
            End If
        Catch ex As Exception

        End Try

    End Sub


    Protected Sub updateStatus()

        Try
            'insert into General table

            Using cmd As New SqlCommand("UPDATE RegTable SET ONLINE_STATUS = @ONLINE_STATUS where USERSNAME ='" + txtUserName.Value + "' and CONFIRM_PASSWORD = '" + txtPassword.Value + "'", thisConnection)

                cmd.Parameters.AddWithValue("@ONLINE_STATUS", "ONLINE")

                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

            End Using

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub updateAdminStatus()

        Try
            'insert into General table

            Using cmd As New SqlCommand("UPDATE AdminTable SET online_status = @ONLINE_STATUS ", thisConnection)

                cmd.Parameters.AddWithValue("@ONLINE_STATUS", "ONLINE")

                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

            End Using

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub btnSignIn_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSignIn.ServerClick
        getFields()
    End Sub

    Protected Sub btnJoinNow_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnJoinNow.ServerClick
        Response.Redirect("SignUp.aspx")
    End Sub

    Public Sub sendmail()
        Try

            Dim imgpath2 As String = MapPath("~/images/logostransparent.png")

            Dim msg As MailMessage
            Dim cmd As New SqlCommand()
            Dim ActivationUrl As String = String.Empty
            Dim email As String = String.Empty
            'Sending activation link in the email
            msg = New MailMessage()
            Dim fullname As String = g_username
            email = txtUserName.Value
            'sender email address
            msg.From = New MailAddress("info@breadsforworld.com", "BREAD FOR WORLD INC.")
            'Receiver email address
            msg.[To].Add(New MailAddress(txtUserName.Value, g_username))
            msg.Subject = "BREAD FOR WORLD PASSWORD RECOVERY"
            Dim codee As String = g_password
            Dim body As String = "<b>NAME</b>: " & fullname & "<br/><br/>" & "<br/><br/>" & "<b>PASSWORD: <b/>" & codee


            msg.Body = body


            'first we create the Plain Text part
            Dim plainView As AlternateView = AlternateView.CreateAlternateViewFromString(body, Nothing, "text/plain")

            'then we create the Html part
            'to embed images, we need to use the prefix 'cid' in the img src value
            'the cid value will map to the Content-Id of a Linked resource.
            'thus <img src='cid:companylogo'> will map to a LinkedResource with a ContentId of 'companylogo'
            Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString("<img src=cid:companylogo> <br/><br/> " & vbLf & vbLf + body + "", Nothing, "text/html")

            'create the LinkedResource (embedded image)
            Dim logo As New LinkedResource(imgpath2)
            logo.ContentId = "companylogo"
            'add the LinkedResource to the appropriate view
            htmlView.LinkedResources.Add(logo)

            'add the views
            msg.AlternateViews.Add(plainView)
            msg.AlternateViews.Add(htmlView)


            msg.IsBodyHtml = True




            'Dim smtp As New SmtpClient()
       
            Dim SmtpMail As New SmtpClient
            Dim basicAuthenticationInfo As New System.Net.NetworkCredential("info@breadsforworld.com", "info@breadsforworld")

            SmtpMail.Host = "mail.breadsforworld.com"
            SmtpMail.UseDefaultCredentials = False
            SmtpMail.Credentials = basicAuthenticationInfo



            'for local
            ' smtp.Port = 587
            ' smtp.Host = "smtp.gmail.com"

            'for server
            SmtpMail.Port = 25
            'smtp.Host = "mail.breadsforworld.com"

            SmtpMail.EnableSsl = False

            SmtpMail.Send(msg)

            lblMessage.Text = "Your PASSWORD has been sent to your email"
            lblMessage.ForeColor = Color.Green
        Catch ex As Exception

            lblMessage.Text = "Sending failed! please confirm your internet connection and try again"
            lblMessage.ForeColor = Color.Red
        End Try
    End Sub

    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        If txtUserName.Value = "" Then
            lblMessage.Visible = True
            lblMessage.ForeColor = Color.Red
            lblMessage.Text = "Please enter your mail in the UserName textbox provided then click the link again"
        Else
            Try
                Dim into1 As String = String.Format("SELECT * FROM RegTable where email ='" + txtUserName.Value + "'")
                'passing the variable to the datatable
                Dim dsworky As DataTable = cc.SelectDataTableRecords(into1)

                'check if court its empty
                If dsworky.Rows.Count > 0 Then
                    g_username = dsworky.Rows(0)("USERSNAME").ToString
                    g_password = dsworky.Rows(0)("CONFIRM_PASSWORD").ToString
                    sendmail()
                Else
                    lblMessage.Visible = True
                    lblMessage.ForeColor = Color.Red
                    lblMessage.Text = "This email has not been registered"
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub
End Class
