Imports System.Data.SqlClient
Public Class ManageUsers
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.PMSIConn = New System.Data.SqlClient.SqlConnection
        Me.GetUsers = New System.Data.SqlClient.SqlCommand
        '
        'PMSIConn
        '
        Me.PMSIConn.ConnectionString = "workstation id=SCORPION;packet size=4096;user id=pmsi;data source=""CORTANA\SQLEXP" & _
        "RESS"";persist security info=True;initial catalog=PMSI;password=asphalt"
        '
        'GetUsers
        '
        Me.GetUsers.CommandText = "SELECT EmpID, LastName, FirstName, UserName FROM dbo.Employee ORDER BY LastName, " & _
        "FirstName DESC"
        Me.GetUsers.Connection = Me.PMSIConn

    End Sub
    Protected WithEvents PMSIConn As System.Data.SqlClient.SqlConnection
    Protected WithEvents lstUSers As System.Web.UI.WebControls.ListBox
    Protected WithEvents GetUsers As System.Data.SqlClient.SqlCommand
    Protected WithEvents TextBox1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents TextBox2 As System.Web.UI.WebControls.TextBox

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
        Dim drUsers As SqlDataReader
        'Put user code to initialize the page here
        If Not Page.IsPostBack Then
            PMSIConn.Open()
            drUsers = GetUsers.ExecuteReader()
            If drUsers.HasRows Then
                lstUSers.DataSource = drUsers
                lstUSers.DataTextField = "UserName"
                lstUSers.DataValueField = "EmpID"
                lstUSers.DataBind()
            End If
            drUsers.Close()
            PMSIConn.Close()
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class
