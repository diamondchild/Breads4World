Imports System.Data.SqlClient
Imports System.IO
Imports System.Data.SqlClient.SqlCommand
Imports System.Drawing
Imports System.Configuration
Imports System.Data
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Partial Class Admin
    Inherits System.Web.UI.Page
    Dim thisConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("Bread4WorldConnectionString").ConnectionString)
    Dim cc As Code_Class = New Code_Class()
    Dim dadapt As New SqlDataAdapter()
    Private sqlcmd As SqlCommand
    Private da As New SqlDataAdapter
    Private dt As New DataTable
    Private ds As New DataSet
    Dim K As Integer
    Dim num, NBA, bigSN As String

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        If Session("userid") IsNot Nothing Then
            lblRegID.Text = Session("userid").ToString
            validatePage()
            LoadRepeater()
        Else
            Response.Redirect("Login.aspx")
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        btngenerate.Attributes.Add("onclick", "return confirm('Are you sure you want to generate and send this code(s) to the user with this PIN?')")
    End Sub

    Private Sub LoadRepeater()
        dt.Rows.Clear()
        thisConnection.Open()
        sqlcmd = New SqlCommand("SELECT ID, REG_ID from RegTable  where USERSNAME  IS NULL ORDER BY ID", thisConnection)
        da = New SqlDataAdapter(sqlcmd)
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            Repeater2.Visible = True
            Repeater2.DataSource = dt
            Repeater2.DataBind()
        End If
        thisConnection.Close()
    End Sub

    Private Sub generate_codes()
      
            Try

                'loop code generation
                For codes = 1 To Val(txtcodeNo.Text.Trim)


                    'generate a random number 

                    Dim runInsert As New Code_Class

                    Dim str As String()

                    Dim pin = Guid.NewGuid.ToString().Substring(0, 10).ToUpper

                str = New String() {"INSERT INTO RegTable (REG_ID) VALUES ('" + pin + "')", "INSERT INTO SentPinsTable (uuid, usersname, Pins, date) VALUES ('" + Guid.NewGuid.ToString().Substring(0, 5) + "', '" + txtUsersname.Text.Trim + "', '" + pin + "', '" + Date.Now + "')"}
                    Try
                        Code_Class.SaveRecord(str)

                    Catch ex As Exception
                        Page.RegisterStartupScript("FAILED", "<script type=""text/javascript"">alert('Login' codes failed to generate');</script>")
                    End Try

            Next codes
            txtcodeNo.Text = Nothing
            txtUsersname.Text = Nothing

                LoadRepeater()
                Page.RegisterStartupScript("success", "<script type=""text/javascript"">alert('Login' codes were successfully generated');</script>")
            Catch ex As Exception
                Page.RegisterStartupScript("FAILED", "<script type=""text/javascript"">alert('Login' codes failed to generate');</script>")
            End Try

       
    End Sub

    Protected Sub btngenerate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btngenerate.Click
        lblmsg.Text = Nothing

        Repeater2.Visible = False
        If txtcodeNo.Text = "" Or txtUsersname.Text = "" Then
            lblmsg.ForeColor = Color.Red
            lblmsg.Text = "Please ensure you fill in the textboxes"
        Else
            If txtcodeNo.Text = Nothing Then
                lblmsg.Text = "Please enter the number of codes you want to generate"
                Page.RegisterStartupScript("FAILhEDw", "<script type=""text/javascript"">alert('Please enter the number of codes you want to generate');</script>")
            Else
                generate_codes()
            End If
        End If


    End Sub

    Protected Sub validatePage()

        Try
            thisConnection.Open()
            Dim into1 As String = String.Format("SELECT online_status FROM AdminTable where REG_ID ='" + lblRegID.Text + "'")
            'passing the variable to the datatable
            Dim dsworky As DataTable = cc.SelectDataTableRecords(into1)

            'check if court its empty
            If dsworky.Rows.Count > 0 Then


                If Session("online_status").ToString = "ONLINE" Then
                    'do nothing
                Else
                    Response.Redirect("~/Login.aspx")
                End If

            Else
                Response.Redirect("~/Login.aspx")
            End If
        Catch ex As Exception

        End Try
        thisConnection.Close()
    End Sub

    Protected Sub Logout()
        thisConnection.Open()
        Try
            'insert into General table

            Using cmd As New SqlCommand("UPDATE AdminTable SET online_status = @ONLINE_STATUS where REG_ID  ='" + lblRegID.Text + "'", thisConnection)

                cmd.Parameters.AddWithValue("@ONLINE_STATUS", "OFFLINE")

                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                thisConnection.Close()
                Session.Clear()
                Response.Redirect("~/Login.aspx")
            End Using

        Catch ex As Exception

        End Try

    End Sub



    Protected Sub lnkLogout_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkLogout.ServerClick
        Logout()
    End Sub
End Class
