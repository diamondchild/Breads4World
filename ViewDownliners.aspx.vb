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
Partial Class ViewDownliners
    Inherits System.Web.UI.Page
    Dim thisConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("Bread4WorldConnectionString").ConnectionString)
    Dim cc As Code_Class = New Code_Class()
    Dim dadapt As New SqlDataAdapter()
    Private sqlcmd As SqlCommand
    Private da As New SqlDataAdapter
    Private dt As New DataTable
    Private ds As New DataSet
    Dim Mleft, Mright As Integer

    Private Sub LoadRepeater()
        dt.Rows.Clear()
        thisConnection.Open()
        sqlcmd = New SqlCommand("SELECT ID, REG_ID, USERSNAME, FIRST_NAME, LAST_NAME, MOBILE, SPONSOR_NAME, CURRENT_STAGE_ID, DATE from RegTable where MATRIX_LEFT between " + Mleft.ToString + " and " + Mright.ToString + " order by MATRIX_LEFT asc ", thisConnection)
        da = New SqlDataAdapter(sqlcmd)
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            Repeater2.Visible = True
            Repeater2.DataSource = dt
            Repeater2.DataBind()
            lblCount.Text = dt.Rows.Count
        End If
        thisConnection.Close()


    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        validatePage()
        LoadRepeater()
    End Sub

    Protected Sub validatePage()

       
        Try
            If Session("mright") IsNot Nothing Then
                Mright = Val(Session("mright"))
                Mleft = Val(Session("mleft"))
                'do nothing
            Else
                Response.Redirect("~/Login.aspx")
            End If
        Catch ex As Exception
            Response.Redirect("~/Login.aspx")
        End Try




    End Sub

End Class
