Public Class IDR_Setup
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.PMSIConn = New System.Data.SqlClient.SqlConnection
        Me.GetCustomers = New System.Data.SqlClient.SqlCommand
        Me.GetContracts = New System.Data.SqlClient.SqlCommand
        '
        'PMSIConn
        '
        Me.PMSIConn.ConnectionString = "workstation id=GHOST;packet size=4096;user id=PMSI;data source=""CORTANA\SQLEXPRES" & _
        "S"";persist security info=True;initial catalog=PMSI;password=asphalt"
        '
        'GetCustomers
        '
        Me.GetCustomers.CommandText = "SELECT CustID, Name FROM Customers ORDER BY Name"
        Me.GetCustomers.Connection = Me.PMSIConn
        '
        'GetContracts
        '
        Me.GetContracts.CommandText = "SELECT ContractUID, ContractID FROM dbo.Contract WHERE (CustID = @CustID)"
        Me.GetContracts.Connection = Me.PMSIConn
        Me.GetContracts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CustID", System.Data.SqlDbType.Int, 4, "CustID"))

    End Sub
    Protected WithEvents lstContracts As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblContract As System.Web.UI.WebControls.Label
    Protected WithEvents lstCustomers As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblCustomer As System.Web.UI.WebControls.Label
    Protected WithEvents lblTitle As System.Web.UI.WebControls.Label
    Protected WithEvents PMSIConn As System.Data.SqlClient.SqlConnection
    Protected WithEvents GetCustomers As System.Data.SqlClient.SqlCommand
    Protected WithEvents GetContracts As System.Data.SqlClient.SqlCommand
    Protected WithEvents btnContinue As System.Web.UI.WebControls.Button
    Protected WithEvents IDRDate As System.Web.UI.WebControls.Calendar
    Protected WithEvents lnkMainMenu As System.Web.UI.WebControls.HyperLink

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
            ' write form data to session
            btnContinue.Visible = True
        Else
            IDRDate.SelectedDate = IDRDate.TodaysDate
        End If
    End Sub

    Private Sub lstCustomers_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstCustomers.SelectedIndexChanged
        Dim Contracts As SqlClient.SqlDataReader

        PMSIConn.Open()
        Try
            ' Client changed, reload the list of contracts
            GetContracts.Parameters.Item("@CustID").Value = lstCustomers.SelectedValue
            Contracts = GetContracts.ExecuteReader
            lstContracts.DataSource = Contracts
            lstContracts.DataTextField = "ContractID" ' Admin assigned ID
            lstContracts.DataValueField = "ContractUID" ' DB Key
            lstContracts.DataBind()
            Contracts.Close()

            ' Update the current customer settings
            Cache("IDRCustID") = lstCustomers.SelectedValue
            Cache("IDRContractID") = ""
            Cache("IDRCustName") = lstCustomers.SelectedItem.Text
            Cache("IDRContractName") = lstContracts.SelectedItem.Text
        Finally
            PMSIConn.Close()
        End Try

    End Sub

    Private Sub lstCustomers_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstCustomers.Load
        Dim customers As SqlClient.SqlDataReader

        If Not Page.IsPostBack Then
            PMSIConn.Open()
            Try
                ' Populate the list of customers
                customers = GetCustomers.ExecuteReader
                lstCustomers.DataSource = customers
                lstCustomers.DataTextField = "Name"
                lstCustomers.DataValueField = "CustID"
                lstCustomers.DataBind()
                customers.Close()
            Finally
                lstCustomers.Items.Add("Select...")
                lstCustomers.SelectedValue = "Select..."
                PMSIConn.Close()
            End Try
        Else
            lstCustomers.Items.Remove("Select...")
        End If
    End Sub

    Private Sub lstContracts_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstContracts.Load
        If Not Page.IsPostBack Then
            lstContracts.Items.Add("Select Customer First...")
        End If
    End Sub

    Private Sub lstContracts_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstContracts.SelectedIndexChanged
        Dim materials As SqlClient.SqlDataReader

        PMSIConn.Open()
        Try
        Catch ex As Exception
        Finally
            PMSIConn.Close()
        End Try
    End Sub

    Private Sub btnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinue.Click
        Response.Redirect("IDRForm.aspx")
    End Sub

    Private Sub IDRDate_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IDRDate.SelectionChanged
        Cache("IDRDate") = IDRDate.SelectedDate
    End Sub
End Class
