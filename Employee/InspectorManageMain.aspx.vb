Public Class InspectorManageMain
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.connPMSI = New System.Data.SqlClient.SqlConnection
        Me.GetEmployees = New System.Data.SqlClient.SqlCommand
        Me.GetEmp = New System.Data.SqlClient.SqlCommand
        Me.myDS = New System.Data.DataSet
        CType(Me.myDS, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'connPMSI
        '
        Me.connPMSI.ConnectionString = "workstation id=GHOST;packet size=4096;user id=PMSI;data source=""CORTANA\SQLEXPRES" & _
        "S"";persist security info=True;initial catalog=PMSI;password=asphalt"
        '
        'GetEmployees
        '
        Me.GetEmployees.CommandText = "SELECT EmpID, LastName + ', ' + FirstName AS FullName FROM dbo.Employee ORDER BY " & _
        "LastName, FirstName"
        Me.GetEmployees.Connection = Me.connPMSI
        '
        'GetEmp
        '
        Me.GetEmp.CommandText = "SELECT FirstName, LastName, EmpID FROM dbo.Employee WHERE (EmpID = ?)"
        Me.GetEmp.Connection = Me.connPMSI
        Me.GetEmp.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Param1", System.Data.SqlDbType.Int, 4, "EmpID"))
        '
        'myDS
        '
        Me.myDS.DataSetName = "NewDataSet"
        Me.myDS.Locale = New System.Globalization.CultureInfo("en-US")
        CType(Me.myDS, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents connPMSI As System.Data.SqlClient.SqlConnection
    Protected WithEvents GetEmployees As System.Data.SqlClient.SqlCommand
    Protected WithEvents EmpList As System.Web.UI.WebControls.ListBox
    Protected WithEvents LblMsg As System.Web.UI.WebControls.Label
    Protected WithEvents lnkMainMenu As System.Web.UI.WebControls.HyperLink
    Protected WithEvents FirstName As System.Web.UI.WebControls.TextBox
    Protected WithEvents LastName As System.Web.UI.WebControls.TextBox
    Protected WithEvents GetEmp As System.Data.SqlClient.SqlCommand
    Protected WithEvents myDS As System.Data.DataSet
    Protected WithEvents dbug As System.Web.UI.WebControls.TextBox

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
        Dim mySqlAdapter As New SqlClient.SqlDataAdapter
        Dim myCmd As New SqlClient.SqlCommand
        Dim cName As DataColumn

        Try
            connPMSI.Open()
            Try
                myCmd.CommandText = GetEmployees.CommandText
                myCmd.Connection = connPMSI
                mySqlAdapter.SelectCommand = myCmd
                mySqlAdapter.Fill(myDS)
                EmpList.DataSource = myDS.Tables(0)
                EmpList.DataTextField = "FullName"
                EmpList.DataValueField = "EmpID"
                EmpList.DataBind()
                dbug.Text = Global.ConnString
            Finally
                FirstName.Visible = True
                LastName.Visible = True
                FirstName.Text = CStr(myDS.Tables.Count)
                LastName.Text = CStr(myDS.Tables(0).Rows.Item(0).Item(1))
                LblMsg.Text = "All Employees Shown"
            End Try
        Finally
            connPMSI.Close()
        End Try
    End Sub

    Private Sub EmpList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmpList.SelectedIndexChanged
        Dim mySqlReader As SqlClient.SqlDataReader

        FirstName.Visible = True
        LastName.Visible = True

    End Sub

    Private Sub connPMSI_InfoMessage(ByVal sender As System.Object, ByVal e As System.Data.SqlClient.SqlInfoMessageEventArgs) Handles connPMSI.InfoMessage

    End Sub

    Private Sub dbug_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dbug.TextChanged

    End Sub
End Class
