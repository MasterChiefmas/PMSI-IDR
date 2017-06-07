Public Class ContractStatus
    Inherits System.Web.UI.Page
    Dim IDRData As New IDRData

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lnkMainMenu As System.Web.UI.WebControls.HyperLink
    Protected WithEvents lnkAdminMain As System.Web.UI.WebControls.HyperLink
    Protected WithEvents lblCustomer As System.Web.UI.WebControls.Label
    Protected WithEvents lstCustomers As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lstContracts As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnGetReport As System.Web.UI.WebControls.Button
    Protected WithEvents lblLastIDR As System.Web.UI.WebControls.Label
    Protected WithEvents lblStatus As System.Web.UI.WebControls.Label
    Protected WithEvents lblContract As System.Web.UI.WebControls.Label
    Protected WithEvents dgReport As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblTCV As System.Web.UI.WebControls.Label
    Protected WithEvents lblCTD As System.Web.UI.WebControls.Label
    Protected WithEvents lblRCV As System.Web.UI.WebControls.Label

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
        If Page.IsPostBack Then
            lstCustomers.Items.Remove("Select...")
            lstContracts.Items.Remove("No Customer Selected")
        Else
            IDRData.FillClientsDDL(True, lstCustomers)
            lstCustomers.Items.Insert(0, "Select...")
            lstContracts.Items.Insert(0, "No Customer Selected")
            If Session("IsApprover") Then
                lnkAdminMain.Visible = True
            End If
        End If
    End Sub

    Private Sub lstCustomers_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstCustomers.SelectedIndexChanged
        Try
            ' Client changed, reload the list of contracts
            IDRData.FillContractDDL(lstCustomers.SelectedValue, True, lstContracts)
            btnGetReport.Visible = True
        Catch Ex As Exception
            Trace.Warn("lstCustomers_SelectedIndexChanged", Ex.Message)
        End Try
    End Sub

    Private Sub DoReport()
        Try
            IDRData.OpenConn()
            ' Get the list of materials and quantities available in the contract
            'IDRData.GetContractMaterialsSummary(lstContracts.SelectedValue)
            'If IDRData.drCMS.HasRows Then
            '    dgSummary.DataSource = IDRData.drCMS
            '    dgSummary.DataBind()
            'Else
            '    dgSummary.DataSource = Nothing
            '    dgSummary.DataBind()
            'End If
            'IDRData.drCMS.Close()

            ' Get the current quantities of used materials for the contract

            IDRData.GetContractSummary(lstContracts.SelectedValue, False)
            Trace.Write("DoReport", "Retrieved summary report data")

            ' Set the TCV and CTD
            lblTCV.Text = CStr(IDRData.TCV)
            lblCTD.Text = CStr(IDRData.CTD)
            lblRCV.Text = IDRData.TCV - IDRData.CTD
            If CDec(lblRCV.Text) < 0 Then
                lblRCV.ForeColor = System.Drawing.Color.Red
            End If

            If IDRData.drContractSummary.HasRows Then
                Trace.Write("Do Report", "Attempting to bind data")
                dgReport.DataSource = IDRData.drContractSummary
                dgReport.DataBind()
                Trace.Write("Do Report", "Bind complete")
                lblStatus.Text = ""
                IDRData.drContractSummary.Close()
                ' Get the date of the most recent IDR
                lblLastIDR.Text = IDRData.GetMostRecentIDR(lstContracts.SelectedValue)
            Else
                dgReport.DataSource = Nothing
                dgReport.DataBind()
                lblStatus.Text = "No IDRs found."
                IDRData.drContractSummary.Close()
            End If
            IDRData.CloseConn()
        Catch ex As Exception
            Trace.Warn("DoReport", ex.Message)
            Trace.Warn("IDRData ExMsg:", IDRData.ExMsg)
        Finally
        End Try
    End Sub

    Private Sub btnGetReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetReport.Click
        Try
            Trace.Write("btnGetReport_Click", "Call DoReport()")
            DoReport()
            Trace.Write("btnGetReport_Click", "DoReport() call complete")
        Catch ex As Exception
            Trace.Warn("btnGetReport_Click", ex.Message)
        End Try

    End Sub
End Class
