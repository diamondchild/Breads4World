
Partial Class HowItWorksManager
    Inherits System.Web.UI.Page


    Protected Sub btnStarter_Click(sender As Object, e As System.EventArgs) Handles btnStarter.Click
        Response.Redirect("HowItWorksStarter.aspx")
    End Sub

    Protected Sub btnDynasty_Click(sender As Object, e As System.EventArgs) Handles btnDynasty.Click
        Response.Redirect("HowItWorksDynasty.aspx")
    End Sub

    Protected Sub btnExecutive_Click(sender As Object, e As System.EventArgs) Handles btnExecutive.Click
        Response.Redirect("HowItWorksExecutive.aspx")
    End Sub

    Protected Sub btnMajesty_Click(sender As Object, e As System.EventArgs) Handles btnMajesty.Click
        Response.Redirect("HowItWorksMajesty.aspx")
    End Sub

    Protected Sub btnRoyal_Click(sender As Object, e As System.EventArgs) Handles btnRoyal.Click
        Response.Redirect("HowItWorksRoyal.aspx")
    End Sub

    Protected Sub btnManager_Click(sender As Object, e As System.EventArgs) Handles btnManager.Click
        Response.Redirect("HowItWorksManager.aspx")
    End Sub
End Class
