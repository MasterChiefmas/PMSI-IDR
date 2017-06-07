Public Class EmployeeSummary
    Inherits System.Web.UI.Page
    Dim IDRData As New IDRData

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lnkMainMenu As System.Web.UI.WebControls.HyperLink
    Protected WithEvents lnkAdminMain As System.Web.UI.WebControls.HyperLink
    Protected WithEvents lblCustomer As System.Web.UI.WebControls.Label
    Protected WithEvents Calendar1 As System.Web.UI.WebControls.Calendar
    Protected WithEvents btnSetStart As System.Web.UI.WebControls.Button
    Protected WithEvents btnSetEnd As System.Web.UI.WebControls.Button
    Protected WithEvents lblStart As System.Web.UI.WebControls.Label
    Protected WithEvents lblEnd As System.Web.UI.WebControls.Label
    Protected WithEvents btnGetReport As System.Web.UI.WebControls.Button
    Protected WithEvents lblMsg As System.Web.UI.WebControls.Label
    Protected WithEvents lblErrMsg As System.Web.UI.WebControls.Label
    Protected WithEvents ddlCust As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlContract As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblIDRErr As System.Web.UI.WebControls.Label
    Protected WithEvents dgECS As System.Web.UI.WebControls.DataGrid

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
        Try
            IDRData.FillClientsDDL(True, ddlCust)
        Catch ex As Exception
            lblErrMsg.Text = IDRData.ExMsg
        End Try

    End Sub


    Private Sub btnSetStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetStart.Click
        lblStart.Text = Calendar1.SelectedDate.ToShortDateString
    End Sub

    Private Sub btnSetEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetEnd.Click
        lblEnd.Text = Calendar1.SelectedDate.ToShortDateString
    End Sub

    Private Sub btnGetReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetReport.Click
        IDRData.OpenConn()
        Try
            dgECS.DataSource = IDRData.drECSBD
            IDRData.GetEmpContractSummaryByDate(ddlContract.SelectedValue, lblStart.Text, lblEnd.Text)
            If IDRData.drECSBD.HasRows Then
                dgECS.DataBind()
            End If
            IDRData.drECSBD.Close()
        Catch ex As Exception
            lblErrMsg.Text = ex.Message
            lblIDRErr.Text = IDRData.ExMsg
        End Try
        IDRData.CloseConn()
    End Sub


    Private Sub ddlCust_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlCust.SelectedIndexChanged
        IDRData.FillContractDDL(ddlCust.SelectedValue, True, ddlContract)
    End Sub

End Class
