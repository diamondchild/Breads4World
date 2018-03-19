Imports System.Data.SqlClient
Imports System.IO
Imports System.Data.SqlClient.SqlCommand
Imports System.Drawing
Imports System.Configuration
Imports System.Data
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Partial Class ViewAll
    Inherits System.Web.UI.Page
    Dim thisConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("Bread4WorldConnectionString").ConnectionString)
    Dim cc As Code_Class = New Code_Class()
    Dim dadapt As New SqlDataAdapter()
    Private sqlcmd As SqlCommand
    Private da As New SqlDataAdapter
    Private dt As New DataTable
    Private ds As New DataSet

    Private Sub LoadRepeater()
        dt.Rows.Clear()
        thisConnection.Open()
        sqlcmd = New SqlCommand("SELECT ID, REG_ID, USERSNAME, MOBILE, SPONSOR_NAME, PASSWORD, CURRENT_STAGE_ID, DATE from RegTable WHERE USERSNAME IS NOT NULL  ORDER BY DATE ", thisConnection)
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
        If Session("userid") IsNot Nothing Then
            Try
                thisConnection.Open()
                Dim into1 As String = String.Format("SELECT online_status FROM AdminTable where REG_ID ='" + Session("userid") + "'")
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
        Else
            Response.Redirect("Login.aspx")
        End If

    End Sub

End Class
