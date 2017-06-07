Public Class TimeReport
    Inherits System.Web.UI.Page
    Dim IDRData As New IDRData

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lnkMainMenu As System.Web.UI.WebControls.HyperLink
    Protected WithEvents lnkAdminMain As System.Web.UI.WebControls.HyperLink
    Protected WithEvents btnDateBegin As System.Web.UI.WebControls.Button
    Protected WithEvents btnDateEnd As System.Web.UI.WebControls.Button
    Protected WithEvents btnGetRpt As System.Web.UI.WebControls.Button
    Protected WithEvents lblDateBegin As System.Web.UI.WebControls.Label
    Protected WithEvents lblDateEnd As System.Web.UI.WebControls.Label
    Protected WithEvents ctlCalendar As System.Web.UI.WebControls.Calendar
    Protected WithEvents ddlInspectors As System.Web.UI.WebControls.DropDownList
    Protected WithEvents dgRpt As System.Web.UI.WebControls.DataGrid

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        If Not Page.IsPostBack Then
            ' init calendar and start/end date range
            ctlCalendar.SelectedDate = ctlCalendar.TodaysDate
            lblDateBegin.Text = DateAdd(DateInterval.Day, -14, ctlCalendar.TodaysDate).ToShortDateString.ToString
            lblDateEnd.Text = ctlCalendar.TodaysDate.ToShortDateString.ToString

            ' init inspector list
            Try
                IDRData.OpenConn()
                IDRData.GetUsers(False)
                ddlInspectors.DataSource = IDRData.drUsers
                ddlInspectors.DataTextField = "NAME"
                ddlInspectors.DataValueField = "EmpID"
                ddlInspectors.DataBind()
                IDRData.drUsers.Close()
                IDRData.CloseConn()
            Catch ex As Exception
                Trace.Write("Page Load:" & ex.Message)
            End Try

        End If
    End Sub

    Private Sub btnDateBegin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDateBegin.Click
        lblDateBegin.Text = ctlCalendar.SelectedDate.ToShortDateString.ToString
    End Sub

    Private Sub btnDateEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDateEnd.Click
        lblDateEnd.Text = ctlCalendar.SelectedDate.ToShortDateString.ToString
    End Sub


    Private Sub btnGetRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetRpt.Click
        Try
            'If dgRpt.Items.Count <> 0 Then
            '    dgRpt.DataSource = Nothing
            '    dgRpt.DataBind()
            'End If
            Try
                IDRData.OpenConn()
            Catch ex As Exception
                Trace.Write("OpenConn:" & ex.Message)
            End Try
            Trace.Write("Getting Time Report...")
            Trace.Write("Inspector ID is " & CStr(ddlInspectors.SelectedValue))
            IDRData.GetTimeReport(CDate(lblDateBegin.Text), CDate(lblDateEnd.Text), CInt(ddlInspectors.SelectedValue))
            Trace.Write("Time Report Retrieved!")
            If IDRData.drRpt.HasRows Then
                dgRpt.Visible = True
                dgRpt.DataSource = IDRData.drRpt
                dgRpt.DataBind()
                IDRData.drRpt.Close()
            End If
        Catch ex As Exception
            Trace.Write("btnGetRpt_Click:" & ex.Message)
            Trace.Warn(IDRData.ExMsg)
        Finally
            IDRData.CloseConn()
        End Try
    End Sub

    Private Sub ddlInspectors_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlInspectors.SelectedIndexChanged
        dgRpt.Visible = False
    End Sub

End Class
