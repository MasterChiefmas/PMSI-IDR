Public Class ManageCust
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
        Me.PMSIConn = New System.Data.SqlClient.SqlConnection
        Me.GetClients = New System.Data.SqlClient.SqlCommand
        Me.UpdateClient = New System.Data.SqlClient.SqlCommand
        Me.InsertClient = New System.Data.SqlClient.SqlCommand
        '
        'PMSIConn
        '
        Me.PMSIConn.ConnectionString = CType(configurationAppSettings.GetValue("PMSIConn.ConnectionString", GetType(System.String)), String)
        '
        'GetClients
        '
        Me.GetClients.CommandText = "SELECT CustID, Name FROM dbo.Customers ORDER BY Name"
        Me.GetClients.Connection = Me.PMSIConn
        '
        'UpdateClient
        '
        Me.UpdateClient.CommandText = "UPDATE dbo.Customers SET Name = @Name WHERE (CustID = @CustID)"
        Me.UpdateClient.Connection = Me.PMSIConn
        Me.UpdateClient.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Name", System.Data.SqlDbType.NVarChar, 0, "Name"))
        Me.UpdateClient.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CustID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CustID", System.Data.DataRowVersion.Original, Nothing))
        '
        'InsertClient
        '
        Me.InsertClient.CommandText = "INSERT INTO dbo.Customers (Name) VALUES (@Name)"
        Me.InsertClient.Connection = Me.PMSIConn
        Me.InsertClient.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Name", System.Data.SqlDbType.NVarChar, 0, "Name"))

    End Sub
    Protected WithEvents lblNew As System.Web.UI.WebControls.Label
    Protected WithEvents txtNewClient As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnAddClient As System.Web.UI.WebControls.Button
    Protected WithEvents lnkAdminMain As System.Web.UI.WebControls.HyperLink
    Protected WithEvents lnkMainMenu As System.Web.UI.WebControls.HyperLink
    Protected WithEvents PMSIConn As System.Data.SqlClient.SqlConnection
    Public WithEvents GetClients As System.Data.SqlClient.SqlCommand
    Protected WithEvents lboxClients As System.Web.UI.WebControls.ListBox
    Protected WithEvents EditLBL As System.Web.UI.WebControls.Label
    Protected WithEvents EditTxtBox As System.Web.UI.WebControls.TextBox
    Protected WithEvents EditBTN As System.Web.UI.WebControls.Button
    Protected WithEvents HidCustID As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents UpdateClient As System.Data.SqlClient.SqlCommand
    Protected WithEvents InsertClient As System.Data.SqlClient.SqlCommand
    Protected WithEvents RFVNewClient As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RFVEditClient As System.Web.UI.WebControls.RequiredFieldValidator

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region
    Dim drClients As SqlClient.SqlDataReader
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not IsPostBack() Then
            RefreshClientListBox()
        End If
    End Sub

    Private Sub RefreshClientListBox()
        lboxClients.Items.Clear()
        PMSIConn.Open()
        ' Should do this as a Try-Catch
        drClients = GetClients.ExecuteReader
        If drClients.HasRows Then
            lboxClients.DataSource = drClients
            lboxClients.DataTextField = "Name"
            lboxClients.DataValueField = "CustID"
            lboxClients.DataBind()
        End If
        drClients.Close()
        PMSIConn.Close()
    End Sub

    Private Sub lboxClients_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lboxClients.SelectedIndexChanged
        ' Make Edit options visible
        EditBTN.Visible = True
        EditLBL.Visible = True
        EditTxtBox.Visible = True

        ' Populate the text box and hidden value
        HidCustID.Value = lboxClients.SelectedValue
        EditTxtBox.Text = lboxClients.Items(lboxClients.SelectedIndex).Text
    End Sub

    Private Sub EditBTN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditBTN.Click
        Dim iResult As Integer
        RFVNewClient.Enabled = False
        If RFVEditClient.IsValid Then
            PMSIConn.Open()
            UpdateClient.Parameters.Item("@CustID").Value = HidCustID.Value
            UpdateClient.Parameters.Item("@Name").Value = EditTxtBox.Text
            iResult = UpdateClient.ExecuteScalar()
            PMSIConn.Close()
            RefreshClientListBox()
        End If
    End Sub

    Private Sub btnAddClient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddClient.Click
        Dim iResult As Integer
        If RFVNewClient.IsValid Then
            PMSIConn.Open()
            InsertClient.Parameters.Item("@Name").Value = txtNewClient.Text
            iResult = InsertClient.ExecuteNonQuery
            PMSIConn.Close()
            RefreshClientListBox()
        End If
    End Sub
End Class
