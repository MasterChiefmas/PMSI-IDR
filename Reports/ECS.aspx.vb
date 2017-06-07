Public Class ECS
    Inherits System.Web.UI.Page
    Dim IDR As New IDRData

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents ddlContract As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlCust As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnStartDate As System.Web.UI.WebControls.Button
    Protected WithEvents btnEndDate As System.Web.UI.WebControls.Button
    Protected WithEvents lblDateStart As System.Web.UI.WebControls.Label
    Protected WithEvents lblDateEnd As System.Web.UI.WebControls.Label
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents Calendar1 As System.Web.UI.WebControls.Calendar
    Protected WithEvents btnExecute As System.Web.UI.WebControls.Button
    Protected WithEvents dgReport As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblRptStatus As System.Web.UI.WebControls.Label
    Protected WithEvents lblTitle As System.Web.UI.WebControls.Label

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
            ' populate customer list
            Try
                IDR.OpenConn()
                IDR.GetClients()
                ddlCust.DataSource = IDR.drClients
                ddlCust.DataTextField = "Name"
                ddlCust.DataValueField = "CustID"
                ddlCust.DataBind()
                IDR.drClients.Close()
            Catch ex As Exception
                Trace.Warn(ex.Message)
            Finally
                If IDR.Conn.State <> ConnectionState.Closed Then
                    IDR.CloseConn()
                End If
            End Try
        End If
    End Sub

    Private Sub ddlCust_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlCust.SelectedIndexChanged
        ' On a change event, get update the list of contracts
        Try
            IDR.FillContractDDL(ddlCust.SelectedValue.ToString, True, ddlContract)
        Catch ex As Exception
            Trace.Warn(ex.Message)
        End Try
    End Sub

    Private Sub btnStartDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStartDate.Click
        lblDateStart.Text = Calendar1.SelectedDate.ToString
    End Sub

    Private Sub btnEndDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEndDate.Click
        lblDateEnd.Text = Calendar1.SelectedDate.ToString
    End Sub

    Private Sub btnExecute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExecute.Click
        Try
            IDR.OpenConn()
            IDR.GetEmpContractSummaryByDate(ddlContract.SelectedValue, lblDateStart.Text, lblDateEnd.Text)
            dgReport.DataSource = IDR.drECSBD
            dgReport.DataBind()
            If IDR.drECSBD.HasRows Then
                lblRptStatus.Text = ""
            Else
                lblRptStatus.Text = "No entries found."
            End If
            IDR.drECSBD.Close()

        Catch ex As Exception
            Trace.Warn(ex.Message)
        Finally
            If IDR.Conn.State <> ConnectionState.Closed Then
                IDR.CloseConn()
            End If
        End Try
    End Sub
End Class
