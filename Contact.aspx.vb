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
Partial Class Contact
    Inherits System.Web.UI.Page
    Dim thisConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("Bread4WorldConnectionString").ConnectionString)




    Public Sub sendmail()
        Try

            Dim imgpath2 As String = MapPath("~/images/logostransparent.png")

            Dim msg As MailMessage
            Dim cmd As New SqlCommand()
            Dim ActivationUrl As String = String.Empty
            Dim email As String = String.Empty
            'Sending activation link in the email
            msg = New MailMessage()
            Dim fullname As String = txtFirstname.Text & " " & txtLastName.Text
            email = txtEmail.Text
            'sender email address
            msg.From = New MailAddress("info@breadsforworld.com", fullname)
            'Receiver email address
            msg.[To].Add(New MailAddress("info@breadsforworld.com", "BREAD FOR WORLD INC"))
            msg.Subject = "BREAD FOR WORLD SUGGESTIONS/COMPLAINTS"

            Dim body As String = "<b>NAME</b>: " & fullname & "<br/><br/>" & "<br/>EMAIL: <br/>" & txtEmail.Text & "<br/><br/>" & txtPhoneNo.Text & " <br/><br/><b>MESSAGE: <b/>" & txtMessage.Text.ToString


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




            Dim smtp As New SmtpClient()

            smtp.Credentials = New NetworkCredential("info@breadsforworld.com", "info@b4w")


            'SmtpMail.Host = "mail.breadsforworld.com"
            'SmtpMail.UseDefaultCredentials = False
            'SmtpMail.Credentials = basicAuthenticationInfo



            ''for local
            'SmtpMail.Port = 587
            'SmtpMail.Host = "smtp.gmail.com"

            'for server
            smtp.Port = 25
            smtp.Host = "mail.breadsforworld.com"

            smtp.EnableSsl = False

            smtp.Send(msg)

            lblMessage.Text = "Your MESSAGE has been sent to BREADFORWORLD INC"
            lblMessage.ForeColor = Color.Green
        Catch ex As Exception

            lblMessage.Text = "Sending failed! please confirm your internet connection and try again"
            lblMessage.ForeColor = Color.Red
        End Try
    End Sub


    Protected Sub btnsubmit_Click(sender As Object, e As System.EventArgs) Handles btnsubmit.Click
        If txtEmail.Text = "" Or txtFirstname.Text = "" Or txtLastName.Text = "" Or txtPhoneNo.Text = "" Or txtMessage.Text = "" Then
            lblMessage.Text = "Sending failed! Please endeavour to fill in all required textboxes and try again"
            lblMessage.ForeColor = Color.Red
        Else
            sendmail()
        End If

    End Sub
End Class
