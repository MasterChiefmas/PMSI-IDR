Imports System.Data.SqlClient

Public Class ManageContracts
    Inherits System.Web.UI.Page
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lnkAdminMain As System.Web.UI.WebControls.HyperLink
    Protected WithEvents lnkMainMenu As System.Web.UI.WebControls.HyperLink
    Protected WithEvents lstClients As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnAddMaterial As System.Web.UI.WebControls.Button
    Protected WithEvents lstMaterials As System.Web.UI.WebControls.DropDownList
    Protected WithEvents RFVContractQty As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtContractQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtUnitPrice As System.Web.UI.WebControls.TextBox
    Protected WithEvents RFVUnitPrice As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents lblDebug As System.Web.UI.WebControls.Label
    Protected WithEvents lstContractMaterials As System.Web.UI.WebControls.ListBox
    Protected WithEvents RFVAddContract As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents btnAddContract As System.Web.UI.WebControls.Button
    Protected WithEvents ddlEngineers As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtNewContract As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnRemove As System.Web.UI.WebControls.Button
    Protected WithEvents btnContractNameChange As System.Web.UI.WebControls.Button
    Protected WithEvents TBNameChange As System.Web.UI.WebControls.TextBox
    Protected WithEvents lstContracts As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnArchive As System.Web.UI.WebControls.Button

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private IDRData As New IDRData

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If IsPostBack Then
            lstContracts.Items.Remove("Select Client")
            lstContractMaterials.Items.Remove("Select Contract")
        Else
            IDRData.FillClientsDDL(True, lstClients)
            IDRData.FillMaterialsDDL(lstMaterials)
            IDRData.FillUserDDL(True, False, ddlEngineers)
            lstContractMaterials.Items.Add("Select Contract")
            lstContracts.Items.Add("Select Client")
        End If
    End Sub

    Private Sub lstClients_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstClients.SelectedIndexChanged
        If lstClients.SelectedValue <> "Selected..." Then
            lstContracts.Items.Clear()
            IDRData.FillContractDDL(lstClients.SelectedItem.Value, False, lstContracts)
            Trace.Warn(IDRData.ExMsg)
        End If
        lstContractMaterials.Items.Clear()
        btnAddContract.Visible = True
    End Sub

    Private Sub lstContracts_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstContracts.SelectedIndexChanged
        IDRData.FillContractMaterialsLstBox(lstContracts.SelectedValue, lstContractMaterials)
        TBNameChange.Visible = True
        btnContractNameChange.Visible = True
        TBNameChange.Text = lstContracts.SelectedItem.Text
    End Sub

    Private Sub btnAddContract_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddContract.Click
        Dim Success As Boolean = False
        IDRData.OpenConn()
        Success = IDRData.AddContract(lstClients.SelectedValue, txtNewContract.Text, ddlEngineers.SelectedValue)
        IDRData.CloseConn()
        ' Repopulate the contract list regardless...
        txtNewContract.Text = ""
        IDRData.FillContractDDL(lstClients.SelectedItem.Value, True, lstContracts)
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        Dim Success As Boolean
        IDRData.OpenConn()
        Success = IDRData.RemoveMaterial(lstContracts.SelectedValue, lstContractMaterials.SelectedValue)
        IDRData.CloseConn()
        If Success Then
            IDRData.FillContractMaterialsLstBox(lstContracts.SelectedValue, lstContractMaterials)
        End If
    End Sub

    Private Sub btnAddMaterial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddMaterial.Click
        Dim Success As Boolean = False
        IDRData.OpenConn()
        Success = IDRData.AddContractMaterial(lstContracts.SelectedValue, lstMaterials.SelectedValue, txtContractQty.Text, txtUnitPrice.Text)
        IDRData.CloseConn()
        If Success Then
            txtContractQty.Text() = ""
            txtUnitPrice.Text() = ""
            IDRData.FillContractMaterialsLstBox(lstContracts.SelectedValue, lstContractMaterials)
        End If
    End Sub

    Private Sub lstContractMaterials_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstContractMaterials.SelectedIndexChanged

    End Sub

    Private Sub btnContractNameChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContractNameChange.Click
        IDRData.OpenConn()
        IDRData.UpdateContractName(lstContracts.SelectedValue, TBNameChange.Text)
        IDRData.CloseConn()
        IDRData.FillContractDDL(lstClients.SelectedItem.Value, True, lstContracts)
    End Sub

    Private Sub btnArchive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArchive.Click
        If IDRData.ArchiveContract(lstContracts.SelectedValue) Then
            IDRData.FillContractDDL(lstClients.SelectedItem.Value, False, lstContracts)
            Trace.Warn("Archive successful!")
        Else
            Trace.Warn("Archive failed")
        End If
    End Sub
End Class
