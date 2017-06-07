Imports System.Web
Imports System.Web.Services
Imports IDR.IDRData

' No DISCO file, probably can't do services discovery?
<System.Web.Services.WebService(Namespace:="http://pmsi-web.dyndns.org/idr/ContractStatus1")> _
Public Class ContractStatus1
    Inherits System.Web.Services.WebService

#Region " Web Services Designer Generated Code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Web Services Designer.
        InitializeComponent()

        'Add your own initialization code after the InitializeComponent() call

    End Sub

    'Required by the Web Services Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Web Services Designer
    'It can be modified using the Web Services Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        'CODEGEN: This procedure is required by the Web Services Designer
        'Do not modify it using the code editor.
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

#End Region

    ' WEB SERVICE EXAMPLE
    ' The HelloWorld() example service returns the string Hello World.
    ' To build, uncomment the following lines then save and build the project.
    ' To test this web service, ensure that the .asmx file is the start page
    ' and press F5.
    '
    <WebMethod()> _
    Public Function HelloWorld() As String
        Return "Hello World"
    End Function

    <WebMethod()> _
    Public Function ContractStatus() As System.Xml.XmlDocument
        Dim IDR As New IDRData
        Dim xmlStr As String
        Dim xmlReturn As New System.Xml.XmlDocument
        Try
            ' Gets the data to return
            IDR.OpenConn()
            IDR.GetContractSummary("3", True)
            If IDR.drContractSummary.HasRows Then
                IDR.drContractSummary.Read()
                xmlStr = IDR.drContractSummary(0)
                xmlReturn.LoadXml(xmlStr)
            End If
            IDR.drContractSummary.Close()
            IDR.CloseConn()
        Catch ex As Exception

        End Try
    End Function


End Class
