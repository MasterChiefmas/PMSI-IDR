Public Class IDR
    Inherits System.Web.UI.Page
    Dim IDRData As New IDRData
    Protected WithEvents btnAction As System.Web.UI.WebControls.Button
    Protected WithEvents txtQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnAddItem As System.Web.UI.WebControls.Button
    Protected WithEvents txtExpenses As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblStatus As System.Web.UI.WebControls.Label
    Dim IDRUID As String = ""
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lnkMainMenu As System.Web.UI.WebControls.HyperLink
    Protected WithEvents lnkAdminMain As System.Web.UI.WebControls.HyperLink
    Protected WithEvents lblTitle As System.Web.UI.WebControls.Label
    Protected WithEvents lstContracts As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblContract As System.Web.UI.WebControls.Label
    Protected WithEvents lstCustomers As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblCustomer As System.Web.UI.WebControls.Label
    Protected WithEvents txtTempLow As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblTempLow As System.Web.UI.WebControls.Label
    Protected WithEvents txtTempHigh As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblTempHigh As System.Web.UI.WebControls.Label
    Protected WithEvents txtWeather As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblWeather As System.Web.UI.WebControls.Label
    Protected WithEvents txtHours As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblHours As System.Web.UI.WebControls.Label
    Protected WithEvents txtMilage As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMilage As System.Web.UI.WebControls.Label
    Protected WithEvents txtComments As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblComments As System.Web.UI.WebControls.Label
    Protected WithEvents lblItemList As System.Web.UI.WebControls.Label
    Protected WithEvents dgItems As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lstNewItem As System.Web.UI.WebControls.DropDownList
    Protected WithEvents IDRDate As System.Web.UI.WebControls.Calendar

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
            Session("IDRUID") = ""
            HideDataEntry()
            IDRDate.SelectedDate = IDRDate.TodaysDate
            IDRData.FillClientsDDL(False, lstCustomers)
            'LoadCustomers()
            lstCustomers.Items.Insert(0, New ListItem("Select...", 0))
            lstContracts.Items.Insert(0, New ListItem("No Customer Selected", 0))
            If Session("IsApprover") Then
                lnkAdminMain.Visible = True
            End If
        End If
        lblStatus.Text = "" ' Clear the label stats on each page load.
        Trace.Write("Page_Load", IDRDate.SelectedDate)
    End Sub

    Private Sub lstCustomers_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstCustomers.SelectedIndexChanged
        Try
            ' Client changed, reload the list of contracts
            IDRData.FillContractDDL(lstCustomers.SelectedValue, False, lstContracts)
            If IsNumeric(lstCustomers.SelectedValue) And IsNumeric(lstContracts.SelectedValue) Then
                LoadIDR()
            End If
        Catch Ex As Exception
        End Try
    End Sub

    Private Sub lstContracts_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstContracts.SelectedIndexChanged
        Dim materials As SqlClient.SqlDataReader

        Try
            LoadIDR()
        Catch ex As Exception
            Trace.Write("lstContracts_SelectedIndexChanged", ex.Message)
        Finally
        End Try
    End Sub

    Private Sub LoadIDR()
        Try
            IDRData.OpenConn()
            IDRData.GetIDR(lstCustomers.SelectedValue, lstContracts.SelectedValue, IDRDate.SelectedDate, Session("EmpID"))
            Trace.Write("LoadIDR", lstCustomers.SelectedValue.ToString & "|" & lstContracts.SelectedValue.ToString & "|" & IDRDate.SelectedDate.ToString & "|" & Session("EmpID"))
            If IDRData.drIDR.HasRows Then
                IDRData.drIDR.Read()
                If IsDBNull(IDRData.drIDR("Weather")) Then txtWeather.Text = "" Else txtWeather.Text = IDRData.drIDR("Weather")
                If IsDBNull(IDRData.drIDR("TempHigh")) Then txtTempHigh.Text = "" Else txtTempHigh.Text = IDRData.drIDR("TempHigh")
                If IsDBNull(IDRData.drIDR("TempLOw")) Then txtTempLow.Text = "" Else txtTempLow.Text = IDRData.drIDR("TempLow")
                If IsDBNull(IDRData.drIDR("Milage")) Then txtMilage.Text = "" Else txtMilage.Text = IDRData.drIDR("Milage")
                If IsDBNull(IDRData.drIDR("HoursCharged")) Then txtHours.Text = "" Else txtHours.Text = IDRData.drIDR("HoursCharged")
                If IsDBNull(IDRData.drIDR("Expenses")) Then txtExpenses.Text = "" Else txtExpenses.Text = IDRData.drIDR("Expenses")
                If IsDBNull(IDRData.drIDR("Comments")) Then txtComments.Text = "" Else txtComments.Text = IDRData.drIDR("Comments")
                Session("IDRUID") = IDRData.drIDR("IDR_UID")
                IDRData.drIDR.Close()
                btnAction.Text = "Save IDR"
                btnAction.Visible = True
                IDRData.CloseConn()
                LoadIDRItems()
                btnAction.Text = "Save IDR"
                btnAction.Visible() = True
                ShowDataEntry()
            Else
                Trace.Write("LoadIDR", "No IDR Found, clearing")
                ClearIDR()
                HideDataEntry()
                btnAction.Text = "New IDR"
                btnAction.Visible = True
            End If
            IDRData.CloseConn()
        Catch ex As Exception
            Trace.Warn("LoadIDR", ex.Message)
        End Try
    End Sub

    Private Sub InsertIDR()
        Try
            IDRData.OpenConn()
            If IDRData.NewIDR(lstCustomers.SelectedValue, lstContracts.SelectedValue, IDRDate.SelectedDate, Session("EmpID")) Then
                Trace.Write("InsertIDR", "Called NewIDR successfully")
            End If
            IDRData.CloseConn()
        Catch ex As Exception
            Trace.Warn("InsertIDR", ex.Message)
        End Try
    End Sub

    Private Sub UpdateIDR()
        Try
            IDRData.OpenConn()
            If IDRData.UpdateIDR(txtWeather.Text, txtTempHigh.Text, txtTempLow.Text, txtMilage.Text, txtHours.Text, txtExpenses.Text, txtComments.Text, Session("IDRUID")) Then
                Trace.Write("UpdateIDR", "IDR Updated:" & Session("IDRUID"))
            End If
            IDRData.CloseConn()
        Catch ex As Exception
            Trace.Warn("UpdateIDR", ex.Message)
        Finally
            lblStatus.Text = "IDR Saved"
        End Try
    End Sub

    Private Sub ClearIDR()
        txtWeather.Text = ""
        txtTempHigh.Text = ""
        txtTempLow.Text = ""
        txtMilage.Text = ""
        txtHours.Text = ""
        txtComments.Text = ""
        Session("IDRUID") = ""
        dgItems.DataSource = Nothing
        dgItems.DataBind()
    End Sub

    Private Sub LoadIDRItems()
        ' Loads materials already reported on the selected IDR
        Try
            IDRData.OpenConn()
            IDRData.GetIDRItems(Session("IDRUID"))
            If IDRData.drIDRItems.HasRows Then
                dgItems.DataSource = IDRData.drIDRItems
                dgItems.DataBind()
            End If
            IDRData.drIDRItems.Close()
            ' Load the list of materials available to add for the current contract
            IDRData.GetAvailableMaterials(lstContracts.SelectedValue)
            If IDRData.drAvailableMaterials.HasRows Then
                With lstNewItem
                    .DataSource = IDRData.drAvailableMaterials
                    .DataTextField = "NAME"
                    .DataValueField = "MaterialID"
                    .DataBind()
                End With
            End If
            IDRData.drAvailableMaterials.Close()
            IDRData.CloseConn()
        Catch ex As Exception
            Trace.Warn("LoadIDRItems", ex.Message)
        End Try
    End Sub

    Private Sub IDRDate_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IDRDate.SelectionChanged
        If IsNumeric(lstCustomers.SelectedValue) And IsNumeric(lstContracts.SelectedValue) Then
            LoadIDR()
        End If
        Trace.Write("IDRDate_SelectionChanged", "Selected Date set to " & IDRDate.SelectedDate.ToShortDateString)
    End Sub

    Private Sub btnAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAction.Click
        Try
            Select Case btnAction.Text
                Case "New IDR"
                    InsertIDR()
                    LoadIDR()
                Case "Save IDR"
                    UpdateIDR()
            End Select
        Catch ex As Exception
            Trace.Warn("btnAction_Click", ex.Message)
        End Try
    End Sub

    Private Sub HideDataEntry()
        txtWeather.Visible = False
        txtHours.Visible = False
        txtComments.Visible = False
        txtMilage.Visible = False
        txtTempHigh.Visible = False
        txtTempLow.Visible = False
        txtExpenses.Visible = False
        txtQty.Visible = False
        lstNewItem.Visible = False
        btnAddItem.Visible = False
        dgItems.Visible = False
    End Sub

    Private Sub ShowDataEntry()
        txtWeather.Visible = True
        txtHours.Visible = True
        txtComments.Visible = True
        txtMilage.Visible = True
        txtTempHigh.Visible = True
        txtTempLow.Visible = True
        txtExpenses.Visible = True
        txtQty.Visible = True
        lstNewItem.Visible = True
        btnAddItem.Visible = True
        dgItems.Visible = True
    End Sub

    Private Sub btnAddItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddItem.Click
        Dim tmp As String ' cache the selected value before re-loading the IDR
        Try
            tmp = lstNewItem.SelectedValue
            UpdateIDR()
            LoadIDR()
            IDRData.OpenConn()
            If CInt(txtQty.Text) = 0 Then
                ' Erase
                If IDRData.RemoveIDRItem(Session("IDRUID"), tmp) Then
                    Trace.Write("btnAddItem_Click", "Successfully removed IDR ITem")
                    txtQty.Text = ""
                End If
            Else
                ' Insert
                If IDRData.AddIDRItem(Session("IDRUID"), tmp, txtQty.Text) Then
                    Trace.Write("btnAddItem_Click", "Sucessfully added IDR Item" & txtQty.Text)
                    txtQty.Text = ""
                End If
            End If
            LoadIDRItems()
        Catch ex As Exception
            Trace.Warn("btnAddItem_Click", ex.Message)
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        IDRData = Nothing
    End Sub

    Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
        If Not Page.IsPostBack Then
            Try
                lstCustomers.Items.RemoveAt(0)
                lstContracts.Items.RemoveAt(0)
            Catch ex As Exception
                Trace.Write("!PostBack Page_Unload", ex.Message)
            End Try
        End If
    End Sub
End Class
