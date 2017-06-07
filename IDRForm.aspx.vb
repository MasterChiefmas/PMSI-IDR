Public Class IDRForm
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
        Me.PMSIConn = New System.Data.SqlClient.SqlConnection
        Me.GetItems = New System.Data.SqlClient.SqlCommand
        Me.GetContractMaterials = New System.Data.SqlClient.SqlCommand
        Me.dsItems = New System.Data.DataSet
        Me.InsertItem = New System.Data.SqlClient.SqlCommand
        Me.GetIDR = New System.Data.SqlClient.SqlCommand
        Me.InsertIDR = New System.Data.SqlClient.SqlCommand
        CType(Me.dsItems, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PMSIConn
        '
        Me.PMSIConn.ConnectionString = CType(configurationAppSettings.GetValue("PMSIConn.ConnectionString", GetType(System.String)), String)
        '
        'GetItems
        '
        Me.GetItems.CommandText = "SELECT dbo.Materials.Name AS [ Material ], dbo.IDRItems.Qty AS [ Quantity ] FROM " & _
        "dbo.IDRItems INNER JOIN dbo.Materials ON dbo.IDRItems.MaterialID = dbo.Materials" & _
        ".MaterialID WHERE (dbo.IDRItems.IDR_UID = @IDR_UID)"
        Me.GetItems.Connection = Me.PMSIConn
        Me.GetItems.Parameters.Add(New System.Data.SqlClient.SqlParameter("@IDR_UID", System.Data.SqlDbType.Int, 4, "IDR_UID"))
        '
        'GetContractMaterials
        '
        Me.GetContractMaterials.CommandText = "SELECT dbo.Materials.Name, dbo.ContractMaterials.MaterialID FROM dbo.ContractMate" & _
        "rials INNER JOIN dbo.Materials ON dbo.ContractMaterials.MaterialID = dbo.Materia" & _
        "ls.MaterialID WHERE (dbo.ContractMaterials.ContractUID = @ContractUID)"
        Me.GetContractMaterials.Connection = Me.PMSIConn
        Me.GetContractMaterials.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ContractUID", System.Data.SqlDbType.Int, 4, "ContractUID"))
        '
        'dsItems
        '
        Me.dsItems.DataSetName = "dsItems"
        Me.dsItems.Locale = New System.Globalization.CultureInfo("en-US")
        '
        'InsertItem
        '
        Me.InsertItem.Connection = Me.PMSIConn
        '
        'GetIDR
        '
        Me.GetIDR.CommandText = "SELECT IDR_UID, Milage, HoursCharged, TempHigh, TempLow, Weather, Comments, Appro" & _
        "vedBy, ApprovedOn FROM dbo.IDR WHERE (CustID = @CustID) AND (ContractUID = @Cont" & _
        "ractUID) AND (InspectorID = @InspectorID) AND (IDR_DATE = @IDR_DATE)"
        Me.GetIDR.Connection = Me.PMSIConn
        Me.GetIDR.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CustID", System.Data.SqlDbType.Int, 4, "CustID"))
        Me.GetIDR.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ContractUID", System.Data.SqlDbType.Int, 4, "ContractUID"))
        Me.GetIDR.Parameters.Add(New System.Data.SqlClient.SqlParameter("@InspectorID", System.Data.SqlDbType.Int, 4, "InspectorID"))
        Me.GetIDR.Parameters.Add(New System.Data.SqlClient.SqlParameter("@IDR_DATE", System.Data.SqlDbType.DateTime, 8, "IDR_DATE"))
        '
        'InsertIDR
        '
        Me.InsertIDR.Connection = Me.PMSIConn
        CType(Me.dsItems, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents lnkMainMenu As System.Web.UI.WebControls.HyperLink
    Protected WithEvents lblTempHigh As System.Web.UI.WebControls.Label
    Protected WithEvents lblTempLow As System.Web.UI.WebControls.Label
    Protected WithEvents txtTempHigh As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTempLow As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents PMSIConn As System.Data.SqlClient.SqlConnection
    Protected WithEvents lblTitle As System.Web.UI.WebControls.Label
    Protected WithEvents lblContract As System.Web.UI.WebControls.Label
    Protected WithEvents TextBox1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents lblCustomer As System.Web.UI.WebControls.Label
    Protected WithEvents GetItems As System.Data.SqlClient.SqlCommand
    Protected WithEvents lblMilage As System.Web.UI.WebControls.Label
    Protected WithEvents txtMilage As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblWeather As System.Web.UI.WebControls.Label
    Protected WithEvents lblHours As System.Web.UI.WebControls.Label
    Protected WithEvents txtHours As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtComments As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblComments As System.Web.UI.WebControls.Label
    Protected WithEvents txtWeather As System.Web.UI.WebControls.TextBox
    Protected WithEvents lstNewItem As System.Web.UI.WebControls.DropDownList
    Protected WithEvents GetContractMaterials As System.Data.SqlClient.SqlCommand
    Protected WithEvents lblCustomerVal As System.Web.UI.WebControls.Label
    Protected WithEvents lblContractVal As System.Web.UI.WebControls.Label
    Protected WithEvents dsItems As System.Data.DataSet
    Protected WithEvents InsertItem As System.Data.SqlClient.SqlCommand
    Protected WithEvents GetIDR As System.Data.SqlClient.SqlCommand
    Protected WithEvents lblIDRDate As System.Web.UI.WebControls.Label
    Protected WithEvents dgItems As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblItemList As System.Web.UI.WebControls.Label
    Protected WithEvents lblIDRUID As System.Web.UI.WebControls.Label
    Protected WithEvents InsertIDR As System.Data.SqlClient.SqlCommand

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Dim IDR_UID As Integer
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        Dim materials As SqlClient.SqlDataReader
        Dim DRItems As SqlClient.SqlDataReader

        PMSIConn.Open()
        If Not Page.IsPostBack Then
            ' First hit, has to load the existing IDR or create a new one.
            ' need to create a stored proc, insert with return @@identity.
            lblCustomerVal.Text = Cache("IDRCustName")
            lblContractVal.Text = Cache("IDRContractName")
            lblIDRDate.Text = Cache("IDRDate")
            Try
                GetContractMaterials.Parameters.Item("@ContractUID").Value = CInt(Cache("IDRContractID"))
                Trace.Write(GetContractMaterials.CommandText)
                Trace.Write("@ContractUID:" & CStr(GetContractMaterials.Parameters.Item("@ContractUID").Value))
                materials = GetContractMaterials.ExecuteReader
                If materials.HasRows Then
                    lstNewItem.DataSource = materials
                    lstNewItem.DataTextField = "Name"
                    lstNewItem.DataValueField = "MaterialID"
                    lstNewItem.DataBind()
                Else
                    lstNewItem.Items.Add("No materials")
                End If
                materials.Close()
            Catch ex As Exception
            End Try
            Try
                If Not LoadIDR(sender, e) Then
                    NewIDR(sender, e)
                End If
            Catch ex As Exception
                Trace.Write("Call LoadIDR:" & ex.Message)
            End Try

            GetItems.Parameters.Item("@IDR_UID").Value = IDR_UID
            DRItems = GetItems.ExecuteReader
            If DRItems.HasRows Then
                dgItems.DataSource = DRItems
                dgItems.DataBind()
            End If

            PMSIConn.Close()
        End If
    End Sub

    Private Function LoadIDR(ByVal sender As System.Object, ByVal e As System.EventArgs) As Boolean
        Dim IDR As SqlClient.SqlDataReader
        Try
            ' Load existing IDR
            GetIDR.Parameters.Item("@CustID").Value = Cache("IDRCustID")
            GetIDR.Parameters.Item("@ContractUID").Value = Cache("IDRContractID")
            GetIDR.Parameters.Item("@InspectorID").Value = Session("EmpID")
            GetIDR.Parameters.Item("@IDR_Date").Value = Cache("IDRDATE")
            Trace.Write("@CustID:" & GetIDR.Parameters.Item("@CustID").Value)
            Trace.Write("@ContractID:" & GetIDR.Parameters.Item("@ContractUID").Value)
            Trace.Write("@InspectorID:" & GetIDR.Parameters.Item("@InspectorID").Value)
            Trace.Write("@IDR_Date:" & GetIDR.Parameters.Item("@IDR_Date").Value)
            IDR = GetIDR.ExecuteReader
            If IDR.HasRows Then
                LoadIDR = True
                IDR.Read()
                IDR_UID = CInt(IDR.Item("IDR_UID"))
                txtWeather.Text = IDR.Item("Weather")
                txtTempHigh.Text = IDR.Item("TempHigh")
                txtTempLow.Text = IDR.Item("TempLow")
                txtComments.Text = IDR.Item("Comments")
                txtMilage.Text = IDR.Item("Milage")
                txtHours.Text = IDR.Item("HoursCharged")
            End If
            IDR.Close()
        Catch ex As Exception
            Trace.Write("LoadIDR():" & ex.Message)
        End Try
    End Function

    Private Function UpdateIDR(ByVal IDR_UID As Integer, ByVal sender As System.Object, ByVal e As System.EventArgs) As Boolean

    End Function

    Private Function NewIDR(ByVal sender As System.Object, ByVal e As System.EventArgs) As Boolean
        IDR_UID = 0
    End Function

End Class
