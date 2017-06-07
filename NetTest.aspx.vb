Public Class NetTest
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
        Me.Conn = New System.Data.SqlClient.SqlConnection
        '
        'Conn
        '
        Me.Conn.ConnectionString = CType(configurationAppSettings.GetValue("PMSIConn.ConnectionString", GetType(System.String)), String)

    End Sub
    Protected WithEvents Conn As System.Data.SqlClient.SqlConnection

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
        Try
            Conn.ConnectionString = "Server=CORTANA\SQLEXPRESS;Database=PMSI;Trusted_Connection=True;"
            Conn.Open()
        Catch ex As Exception
            Trace.Warn("Page_Load", ex.Message)
            Trace.Warn("Page_Load", Conn.ConnectionString)
        Finally
            If Conn.State <> ConnectionState.Open Then
                Conn.Close()
            End If
        End Try
    End Sub

End Class
