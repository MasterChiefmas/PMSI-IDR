Imports System.Xml
Imports System.Xml.Xsl
Imports System.Xml.XPath
Imports System.Web.UI.WebControls

Public Class IDRDump
    Inherits System.Web.UI.Page


#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents btnSetBegin As System.Web.UI.WebControls.Button
    Protected WithEvents btnSetEnd As System.Web.UI.WebControls.Button
    Protected WithEvents lblBegin As System.Web.UI.WebControls.Label
    Protected WithEvents lblEnd As System.Web.UI.WebControls.Label
    Protected WithEvents dBegin As System.Web.UI.WebControls.Label
    Protected WithEvents dEnd As System.Web.UI.WebControls.Label
    Protected WithEvents lblClient As System.Web.UI.WebControls.Label
    Protected WithEvents lblJob As System.Web.UI.WebControls.Label
    Protected WithEvents btnExecute As System.Web.UI.WebControls.Button
    Protected WithEvents ddlContracts As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlClients As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Xml1 As System.Web.UI.WebControls.Xml
    Protected WithEvents txtDateBegin As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDateEnd As System.Web.UI.WebControls.TextBox
    Protected WithEvents lnkAdminMain As System.Web.UI.WebControls.HyperLink
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

    Private IDRData As New IDRData
    Private CommandClick As String

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not Page.IsPostBack Then
            ' Get client list
            IDRData.FillClientsDDL(False, ddlClients)
            ddlClients.Items.Insert(0, "Select Client")

            ddlContracts.Items.Insert(0, "Select Contract")

            dBegin.Text = CStr(DateAdd(DateInterval.Day, -7, Now))

            dEnd.Text = CStr(Now())
        End If
    End Sub


    Private Sub Command_Button_Click(ByVal sender As System.Object, ByVal e As CommandEventArgs)
        CommandClick = e.CommandName
    End Sub

    Private Sub HideAll()
        ' Hides all visible Controls
        txtDateBegin.Visible = False
        txtDateEnd.Visible = False
        ddlClients.Visible = False
        ddlContracts.Visible = False
        lblBegin.Visible = False
        lblEnd.Visible = False
        lblClient.Visible = False
        lblJob.Visible = False
        dBegin.Visible = False
        dEnd.Visible = False
        btnSetBegin.Visible = False
        btnSetEnd.Visible = False
        btnExecute.Visible = False
    End Sub

    Private Sub ddlClients_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlClients.SelectedIndexChanged
        If ddlClients.SelectedValue = "All" Then
            ddlContracts.Items.Clear()
            ddlContracts.Items.Insert(0, "All")
        Else
            IDRData.FillContractDDL(ddlClients.SelectedValue, True, ddlContracts)
        End If
    End Sub

    Private Sub btnSetBegin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetBegin.Click
        dBegin.Text = txtDateBegin.Text
    End Sub

    Private Sub btnSetEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetEnd.Click
        dEnd.Text = txtDateEnd.Text
    End Sub

    Private Sub btnExecute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExecute.Click
        Dim XMLDoc As New XmlDocument
        Dim XSLDoc As New XslTransform
        Dim str As String

        XSLDoc.Load(Server.MapPath("/IDR/Reports/IDRDump.xsl"))

        HideAll()
        'Response.Write("<?xml-stylesheet type='text/xsl' href='IDRDump.xsl'?>")
        Try
            Response.Clear()
            IDRData.OpenConn()
            IDRData.GetIDRDump(dBegin.Text, dEnd.Text, ddlClients.SelectedValue, ddlContracts.SelectedValue)
            XMLDoc.Load(IDRData.XMLRdr)
            IDRData.XMLRdr.Close()
            IDRData.CloseConn()
            Xml1.Document = XMLDoc
            Xml1.Transform = XSLDoc
            lnkAdminMain.Visible = False
            lnkMainMenu.Visible = False
        Catch ex As Exception
            Response.Write("spRptIDRDump '" & dBegin.Text & "', '" & dEnd.Text & "', " & ddlClients.SelectedValue & ", " & ddlContracts.SelectedValue & "<br>")
            Response.Write(ex.Message & "<br>" & vbCrLf)
            Response.Write(str)
            lnkAdminMain.Visible = True
            lnkMainMenu.Visible = True
        End Try

    End Sub

    Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
    End Sub
End Class
