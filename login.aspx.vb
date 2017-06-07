Imports System.Web.Security
Imports System.Security.Principal
Public Class login
    Inherits System.Web.UI.Page
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
        Me.PMSIConn = New System.Data.SqlClient.SqlConnection
        Me.AuthUser = New System.Data.SqlClient.SqlCommand
        '
        'PMSIConn
        '
        Me.PMSIConn.ConnectionString = CType(configurationAppSettings.GetValue("PMSIConn.ConnectionString", GetType(System.String)), String)
        '
        'AuthUser
        '
        Me.AuthUser.CommandText = "SELECT EmpID, UserName, Password, IsApprover FROM dbo.Employee WHERE (UserName = " & _
        "@UserName) AND (Password = @Password)"
        Me.AuthUser.Connection = Me.PMSIConn
        Me.AuthUser.Parameters.Add(New System.Data.SqlClient.SqlParameter("@UserName", System.Data.SqlDbType.NVarChar, 20, "UserName"))
        Me.AuthUser.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Password", System.Data.SqlDbType.NVarChar, 50, "Password"))

    End Sub
    Protected WithEvents lblLogin As System.Web.UI.WebControls.Label
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents txtUserName As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPassword As System.Web.UI.WebControls.TextBox
    Protected WithEvents PMSIConn As System.Data.SqlClient.SqlConnection
    Protected WithEvents AuthUser As System.Data.SqlClient.SqlCommand
    Protected WithEvents txtMsg As System.Web.UI.WebControls.Label

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
        ' User already has credentials
        If Page.User.Identity.IsAuthenticated Then
            Response.Redirect("default.aspx")
        Else
            txtMsg.Text = "Please Login"
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim IDRData As New IDRData
        Dim SqlDR As SqlClient.SqlDataReader
        Dim ds As DataSet
        Dim UserName As String

        If Page.IsPostBack Then
            Try
                IDRData.OpenConn()
                IDRData.AuthUser(txtUserName.Text, txtPassword.Text)
                    If IDRData.drAuth.HasRows Then
                    IDRData.drAuth.Read()
                    Session("EmpID") = IDRData.drAuth("EmpID")
                    Session("UserName") = txtUserName.Text
                        If IDRData.drAuth("IsApprover") = 1 Then
                        Session("IsApprover") = True
                    Else
                        Session("IsApprover") = False
                    End If
                    IDRData.drAuth.Close()
                    FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, False) ' the boolean controls persistance of the cookie(disk cache or memory)
                Else
                    Trace.Write("login", "User lookup did not return a row")
                    End If
                    IDRData.CloseConn()
            Catch Ex As Exception
                Trace.Write("login", Ex.Message)
            Finally
                Trace.Write("Login", "Finally...")
            End Try
        End If
    End Sub

End Class
