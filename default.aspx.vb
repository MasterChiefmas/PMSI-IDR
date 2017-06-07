Imports System.Web.Security

Public Class MainMenu
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents IDRSubmit As System.Web.UI.WebControls.HyperLink
    Protected WithEvents lnkReportsMenu As System.Web.UI.WebControls.HyperLink
    Protected WithEvents lnkManageCust As System.Web.UI.WebControls.HyperLink
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents HyperLink3 As System.Web.UI.WebControls.HyperLink

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
        If Session("IsApprover") Then
            lnkManageCust.Visible = True
        End If
        If Not Page.User.Identity.IsAuthenticated Then
            Response.Redirect("login.aspx")
        Else
            Trace.Write("Page_Load:Page.User.Identity.Name", Page.User.Identity.Name)
        End If
    End Sub

End Class

