Imports System
Imports System.Web
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text
Imports System.Web.TraceContext
Imports System.Web.UI.WebControls

Public Class IDRData
    Public drMaterials As SqlDataReader
    Public drClients As SqlDataReader
    Public drContracts As SqlDataReader
    Public drContractMaterials As SqlDataReader
    Public drUsers As SqlDataReader
    Public drIDR As SqlDataReader
    Public drIDRItems As SqlDataReader
    Public drAvailableMaterials As SqlDataReader
    Public drContractSummary As SqlDataReader
    Public drCMS As SqlDataReader ' CMS = Contract Materias Summary
    Public drECS As SqlDataReader ' ECS = Employee/Contract Summary
    Public drECSBD As SqlDataReader ' EmpContractSummaryByDate
    Public drAuth As SqlDataReader
    Public drRpt As SqlDataReader ' Generic handle for holding results of report generation calls
    Public TCV As Decimal ' Total Contract Value
    Public CTD As Decimal ' Contract (Value) To Date
    Public ExMsg As String = ""
    Public XMLRdr As System.Xml.XmlReader
    Public Conn As New SqlConnection
    Private cmd As New SqlCommand

    Public Sub FillClientsDDL(ByVal ShowAll As Boolean, ByRef ddl As DropDownList)
        ' ShowAll True displays inactive as well
        Me.OpenConn()
        Me.GetClients()
        ddl.DataSource = Me.drClients
        ddl.DataTextField = "NAME"
        ddl.DataValueField = "CustID"
        ddl.DataBind()
        Me.drClients.Close()
        Me.CloseConn()
    End Sub

    Public Overloads Sub GetClients()
        If Conn.State = ConnectionState.Open Then
            cmd.CommandText = "SELECT CustID, Name FROM CUSTOMERS ORDER BY Name"
            cmd.Connection = Conn
            drClients = cmd.ExecuteReader
        End If
    End Sub

    Public Overloads Sub GetClients(ByVal EmpID As String)
        ' Gets a list of clients that the passed ID has IDRs on
        Dim param As SqlParameter
        If Conn.State = ConnectionState.Open Then
            cmd.CommandText = "SELECT Distinct(c.Name) As [Customer], c.CustID FROM IDR As I Inner Join Customers As C ON " & _
                "(I.CustID = C.CustID) WHERE I.InspectorID=@EmpID"
            param = cmd.CreateParameter
            param.ParameterName = "@EmpID"
            param.Value = EmpID
            cmd.Parameters.Add(param)
            cmd.Connection = Conn
            drClients = cmd.ExecuteReader
        End If
        cmd.Parameters.Clear()
    End Sub

    Public Overloads Sub GetClients(ByVal oConn As SqlConnection)
        If Not oConn.State = ConnectionState.Open Then
            cmd.CommandText = "SELECT CustID, Name FROM CUSTOMERS ORDER BY Name"
            cmd.Connection = oConn
            drClients = cmd.ExecuteReader
        End If
    End Sub

    Public Sub FillMaterialsDDL(ByRef ddl As DropDownList)
        Me.OpenConn()
        Me.GetMaterials()
        ddl.DataSource = Me.drMaterials
        ddl.DataTextField = "COMPOSITE"
        ddl.DataValueField = "MaterialID"
        ddl.DataBind()
        Me.drMaterials.Close()
        Me.CloseConn()
    End Sub

    Public Overloads Sub GetMaterials()
        If Conn.State = ConnectionState.Open Then
            cmd.CommandText = "SELECT MaterialID, Name, UnitType, Name + '(' + UnitType + ')' AS Composite FROM Materials Order By Name"
            cmd.Connection = Conn
            drMaterials = cmd.ExecuteReader
        End If
    End Sub

    Public Sub FillContractDDL(ByVal ClientId As String, ByVal ShowAll As Boolean, ByRef ddl As DropDownList)
        Me.OpenConn()
        Me.GetContracts(ClientId, ShowAll)
        If Me.drContracts.HasRows Then
            ddl.DataSource = Me.drContracts
            ddl.DataTextField = "ContractID"
            ddl.DataValueField = "ContractUID"
            ddl.DataBind()
        Else
            ddl.Items.Clear()
            ddl.Items.Add("No contracts found")
        End If
        Me.drContracts.Close()
        Me.CloseConn()
    End Sub

    Public Sub GetContracts(ByVal ClientID As String, ByVal ShowAll As Boolean)
        Dim param As SqlParameter
        If Conn.State = ConnectionState.Open Then
            If ShowAll = True Then
                cmd.CommandText = "SELECT ContractUID, ContractID, CustID FROM Contract WHERE CustID=@ClientID Order By ContractID"
            Else
                cmd.CommandText = "SELECT ContractUID, ContractID, CustID FROM Contract WHERE CustID=@ClientID AND Archived Is Null Order By ContractID"
            End If

            param = cmd.CreateParameter
            param.ParameterName = "@clientID"
            param.Value = ClientID
            cmd.Parameters.Add(param)
            cmd.Connection = Conn
            drContracts = cmd.ExecuteReader
            cmd.Parameters.Clear()
        End If
    End Sub

    Public Sub GetIDRItems(ByVal IDR_UID As String)
        Dim param As SqlParameter
        If Conn.State = ConnectionState.Open Then
            cmd.CommandText = "SELECT m.Name AS [Item],  i.Qty AS [Quantity], m.UnitType As [Unit] FROM IDRItems As i INNER JOIN Materials AS m ON (i.MaterialID=m.MaterialID) " & _
                "WHERE i.IDR_UID=@IDR_UID"
            param = cmd.CreateParameter
            param.ParameterName = "@IDR_UID"
            param.Value = IDR_UID
            cmd.Parameters.Add(param)
            cmd.Connection = Conn
            Try
                drIDRItems = cmd.ExecuteReader
            Catch ex As Exception
                ExMsg = ex.Message
            End Try
            cmd.Parameters.Clear()
        End If
    End Sub

    Public Sub GetAvailableMaterials(ByVal ContractUID As String)
        Dim param As SqlParameter
        If Conn.State = ConnectionState.Open Then
            cmd.CommandText = "SELECT M.Name + '(' + M.UnitType + ')' AS [Name], M.MaterialID, M.UnitType " & _
            "FROM ContractMaterials AS CM INNER JOIN Materials As M ON (CM.MaterialID = M.MaterialID) " & _
            "WHERE CM.ContractUID = @ContractUID ORDER BY M.NAME"
            param = cmd.CreateParameter
            param.ParameterName = "@ContractUID"
            param.Value = ContractUID
            cmd.Parameters.Add(param)
            cmd.Connection = Conn
            Try
                drAvailableMaterials = cmd.ExecuteReader
            Catch ex As Exception
                ExMsg = ex.Message
            End Try
            cmd.Parameters.Clear()
        End If
    End Sub

    Public Sub FillContractMaterialsLstBox(ByVal ContractUID As String, ByRef lb As ListBox)
        Me.OpenConn()
        Try
            Me.GetContractMaterials(ContractUID)
            If Me.drContractMaterials.HasRows Then
                lb.DataSource = Me.drContractMaterials
                lb.DataTextField = "INFO"
                lb.DataValueField = "MaterialID"
                lb.DataBind()
            Else
                lb.Items.Clear()
                lb.Items.Add("No materials on this contract.")
            End If
            Me.drContractMaterials.Close()
        Catch ex As Exception
            ExMsg = ex.Message
        End Try
        Me.CloseConn()
    End Sub

    Public Sub GetContractMaterials(ByVal ContractUID As String)
        Dim param As SqlParameter
        If Conn.State = ConnectionState.Open Then
            cmd.CommandText = "SELECT M.Name, M.Name + '(' + Cast(CM.BidQuantity As VarChar(7)) + '/' + Cast(CM.UnitPrice As Varchar(7)) + ')' AS [Info], CM.MaterialID " & _
            "FROM ContractMaterials AS CM INNER JOIN Materials As M ON (CM.MaterialID = M.MaterialID) " & _
            "WHERE CM.ContractUID = @ContractUID ORDER BY M.NAME"
            param = cmd.CreateParameter
            param.ParameterName = "@ContractUID"
            param.Value = ContractUID
            cmd.Parameters.Add(param)
            cmd.Connection = Conn
            Try
                drContractMaterials = cmd.ExecuteReader
            Catch ex As Exception
                ExMsg = ex.Message
            End Try
            cmd.Parameters.Clear()
        End If
    End Sub

    Public Sub FillUserDDL(ByVal ApproversOnly As Boolean, ByVal ShowAll As Boolean, ByVal ddl As DropDownList)
        Me.OpenConn()
        Me.GetUsers(ApproversOnly)
        ddl.DataSource = Me.drUsers
        ddl.DataTextField = "NAME"
        ddl.DataValueField = "EmpID"
        ddl.DataBind()
        Me.drUsers.Close()
        Me.CloseConn()
    End Sub

    Public Sub GetUsers(ByVal ApproversOnly As Boolean)
        Dim param As SqlParameter
        Dim SQL As String
        If Conn.State = ConnectionState.Open Then
            SQL = "SELECT EmpID, Lastname + ', ' + FirstName As [Name] FROM Employee "
            If ApproversOnly Then
                SQL = SQL & "WHERE IsApprover = 1 "
            End If
            SQL = SQL & "ORDER BY LastName, FirstName"
            cmd.CommandText = SQL
            cmd.Connection = Conn
            Try
                drUsers = cmd.ExecuteReader
            Catch ex As Exception
                ExMsg = ex.Message
            End Try
            cmd.Parameters.Clear()
        End If
    End Sub

    Public Function GetIDR(ByVal CustID As String, ByVal ContractUID As String, ByVal IDR_DATE As String, ByVal InspectorID As String)
        Dim param As SqlParameter
        If Conn.State = ConnectionState.Open Then
            cmd.CommandText = "SELECT IDR_UID, CustID, ContractUID, InspectorID, IDR_DATE, Milage, HoursCharged, TempHigh, TempLow, Expenses, Weather, Comments, ApprovedBy, ApprovedOn " & _
                "FROM IDR WHERE CustID=@CustID AND ContractUID=@ContractUID AND IDR_DATE=@IDR_DATE AND InspectorID=@InspectorID"

            param = cmd.CreateParameter
            param.ParameterName = "@CustID"
            param.Value = CustID
            cmd.Parameters.Add(param)

            param = cmd.CreateParameter
            param.ParameterName = "@ContractUID"
            param.Value = ContractUID
            cmd.Parameters.Add(param)

            param = cmd.CreateParameter
            param.ParameterName = "@IDR_DATE"
            param.Value = IDR_DATE
            cmd.Parameters.Add(param)

            param = cmd.CreateParameter
            param.ParameterName = "@InspectorID"
            param.Value = InspectorID
            cmd.Parameters.Add(param)

            cmd.Connection = Conn
            drIDR = cmd.ExecuteReader
            cmd.Parameters.Clear()
        End If
    End Function

    'Public Function GetEmpContractSummary(ByVal ContractUID As String, ByVal InspectorID As String, Optional ByVal dStart As String = "", Optional ByVal dEnd As String = "")
    '    Dim param As SqlParameter
    '    If Conn.State = ConnectionState.Open Then
    '        cmd.CommandText = "SELECT SUM(hourscharged) AS [HoursCharged], Sum(Milage) AS [Milage] FROM IDR WHERE ContractUID=@ContractUID AND InspectorID=@InspectorID "
    '        If dStart <> "" Then
    '            cmd.CommandText &= "AND IDR_DATE >= @dStart "
    '            param = cmd.CreateParameter
    '            param.ParameterName = "@dStart"
    '            param.Value = dStart
    '            cmd.Parameters.Add(param)
    '        End If
    '        If dEnd <> "" Then
    '            cmd.CommandText &= "AND IDR_DATE <= @dEnd"
    '            param = cmd.CreateParameter
    '            param.ParameterName = "@dEnd"
    '            param.Value = dEnd
    '            cmd.Parameters.Add(param)
    '        End If
    '        ExMsg = cmd.CommandText
    '        param = cmd.CreateParameter
    '        param.ParameterName = "@ContractUID"
    '        param.Value = ContractUID
    '        cmd.Parameters.Add(param)

    '        param = cmd.CreateParameter
    '        param.ParameterName = "@InspectorID"
    '        param.Value = InspectorID
    '        cmd.Parameters.Add(param)
    '        cmd.Connection = Conn
    '        drECS = cmd.ExecuteReader
    '    End If
    '    cmd.Parameters.Clear()
    'End Function

    Public Function GetEmpContractSummaryByDate(ByVal ContractUID As String, ByVal dStart As String, ByVal dEnd As String)
        Dim param As SqlParameter
        If Conn.State = ConnectionState.Open Then
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "spRptEmpSummary"

            ExMsg = cmd.CommandText

            param = cmd.CreateParameter
            param.ParameterName = "@CUID"
            param.Value = ContractUID
            cmd.Parameters.Add(param)

            param = cmd.CreateParameter
            param.ParameterName = "@StartDate"
            param.Value = dStart
            cmd.Parameters.Add(param)

            param = cmd.CreateParameter
            param.ParameterName = "@EndDate"
            param.Value = dEnd
            cmd.Parameters.Add(param)

            cmd.Connection = Conn
            drECSBD = cmd.ExecuteReader
        End If
        cmd.Parameters.Clear()
    End Function

    Public Function GetContractSummary(ByVal ContractUID As String, ByVal IsXML As Boolean)
        ' 2006-03-03 modified stored procedure to return XML
        ' 2006-06-27 modified function to also set the TCV and CTD values

        Dim param As SqlParameter
        Dim sb As New StringBuilder
        If Conn.State = ConnectionState.Open Then
            ' TCV
            Try
                cmd.CommandText = "spTotalContractValue"
                cmd.CommandType = CommandType.StoredProcedure

                param = cmd.CreateParameter
                With param
                    .ParameterName = "@ContractUID"
                    .SqlDbType = SqlDbType.Int
                    .Value = CInt(ContractUID)
                End With
                cmd.Parameters.Add(param)
                cmd.Connection = Conn
                TCV = cmd.ExecuteScalar
            Catch ex As Exception
                ExMsg = ex.Message
            Finally
                ' I wonder if I can get away with not clearing the parameters collection here since the same parameter is used each time...
                cmd.Parameters.Clear()
                cmd.CommandType = CommandType.Text
            End Try
            ' CTD
            Try
                cmd.CommandText = "spContractCTD"
                cmd.CommandType = CommandType.StoredProcedure

                param = cmd.CreateParameter
                With param
                    .ParameterName = "@ContractUID"
                    .SqlDbType = SqlDbType.Int
                    .Value = CInt(ContractUID)
                End With
                cmd.Parameters.Add(param)
                cmd.Connection = Conn
                CTD = cmd.ExecuteScalar
            Catch ex As Exception
                ExMsg = ex.Message
            Finally
                ' I wonder if I can get away with not clearing the parameters collection here since the same parameter is used each time...
                cmd.Parameters.Clear()
                cmd.CommandType = CommandType.Text
            End Try
            Try
                cmd.CommandText = "spRptContractSummary"
                cmd.CommandType = CommandType.StoredProcedure

                param = cmd.CreateParameter
                With param
                    .ParameterName = "@ContractUID"
                    .SqlDbType = SqlDbType.Int
                    .Value = CInt(ContractUID)
                End With
                cmd.Parameters.Add(param)

                param = cmd.CreateParameter
                With param
                    .ParameterName = "@AsXML"
                    .SqlDbType = SqlDbType.Bit
                    If IsXML Then
                        .Value = 1
                    Else
                        .Value = 0
                    End If
                End With
                cmd.Parameters.Add(param)

                cmd.Connection = Conn

                drContractSummary = cmd.ExecuteReader
            Catch ex As Exception
                ExMsg = ex.Message
            Finally
                cmd.Parameters.Clear()
                cmd.CommandType = CommandType.Text
            End Try
        End If
    End Function

    Public Function GetContractMaterialsSummary(ByVal ContractUID As String)
        Dim param As SqlParameter
        If Conn.State = ConnectionState.Open Then
            cmd.CommandText = "SELECT M.Name As [Material Type], CM.BidQuantity As [Bid Qty], CM.UnitPrice As [Unit Price] " & _
            "FROM ContractMaterials AS CM INNER JOIN Materials As M ON (CM.MaterialID = M.MaterialID) " & _
            "WHERE CM.ContractUID = @ContractUID ORDER BY M.NAME"
            param = cmd.CreateParameter
            param.ParameterName = "@ContractUID"
            param.Value = ContractUID
            cmd.Parameters.Add(param)
            cmd.Connection = Conn
            Try
                drCMS = cmd.ExecuteReader
            Catch ex As Exception
                ExMsg = ex.Message
            End Try
            cmd.Parameters.Clear()
        End If
    End Function

    Public Function GetMostRecentIDR(ByVal Contract_UID As String) As String
        Dim param As SqlParameter
        If Conn.State = ConnectionState.Open Then
            cmd.CommandText = "SELECT MAX(IDR_DATE) AS [IDR_DATE] FROM IDR WHERE ContractUID=@Contract_UID"
            param = cmd.CreateParameter
            param.ParameterName = "@Contract_UID"
            param.Value = Contract_UID
            cmd.Parameters.Add(param)
            GetMostRecentIDR = cmd.ExecuteScalar
            cmd.Parameters.Clear()
        End If
    End Function

    Public Function GetIDRDump(ByVal StartDate As String, ByVal EndDate As String, ByVal CustomerID As Integer, ByVal ContractID As Integer) As String
        Dim param As SqlParameter
        Dim tmp As String
        GetIDRDump = False
        If Conn.State = ConnectionState.Open Then
            Try
                cmd.CommandText = "spRptIDRDump"
                cmd.CommandType = CommandType.StoredProcedure

                param = cmd.CreateParameter
                param.ParameterName = "@StartDate"
                param.Value = StartDate
                cmd.Parameters.Add(param)

                param = cmd.CreateParameter
                param.ParameterName = "@EndDate"
                param.Value = EndDate
                cmd.Parameters.Add(param)

                param = cmd.CreateParameter
                param.ParameterName = "@CustomerID"
                param.Value = CustomerID
                cmd.Parameters.Add(param)

                param = cmd.CreateParameter
                param.ParameterName = "@ContractID"
                param.Value = ContractID
                cmd.Parameters.Add(param)

                cmd.Connection = Conn

                XMLRdr = cmd.ExecuteXmlReader
                'GetIDRDump = tmp.ToString
            Catch ex As Exception
                ExMsg = ex.Message
            Finally
                cmd.Parameters.Clear()
            End Try
        End If


    End Function

    Public Function GetTimeReport(ByVal StartDate As Date, ByVal EndDate As Date, ByVal EmpID As Integer) As Boolean
        Dim param As SqlParameter
        GetTimeReport = False
        If Conn.State = ConnectionState.Open Then
            Try
                cmd.CommandText = "spTimeReport"
                cmd.CommandType = CommandType.StoredProcedure
                param = cmd.CreateParameter
                param.ParameterName = "@sDate"
                param.Value = StartDate
                cmd.Parameters.Add(param)

                param = cmd.CreateParameter
                param.ParameterName = "@eDate"
                param.Value = EndDate
                cmd.Parameters.Add(param)

                param = cmd.CreateParameter
                param.ParameterName = "@InspectorID"
                param.Value = EmpID
                cmd.Parameters.Add(param)
                cmd.Connection = Conn

                drRpt = cmd.ExecuteReader

            Catch ex As Exception
                ExMsg = ex.Message
            Finally
                cmd.Parameters.Clear()
            End Try
        End If

    End Function

    Public Function NewIDR(ByVal CustID As String, ByVal ContractUID As String, ByVal IDR_DATE As String, ByVal InspectorID As String) As Boolean
        Dim Param As SqlParameter
        Dim result As Integer
        If Conn.State = ConnectionState.Open Then
            cmd.CommandText = "INSERT INTO IDR (CustID, ContractUID, IDR_DATE, InspectorID) VALUES (@CustID, @ContractUID, @IDR_DATE, @InspectorID)"
            Param = cmd.CreateParameter
            Param.ParameterName = "@CustID"
            Param.Value = CustID
            cmd.Parameters.Add(Param)

            Param = cmd.CreateParameter
            Param.ParameterName = "@ContractUID"
            Param.Value = ContractUID
            cmd.Parameters.Add(Param)

            Param = cmd.CreateParameter
            Param.ParameterName = "@IDR_DATE"
            Param.Value = IDR_DATE
            cmd.Parameters.Add(Param)

            Param = cmd.CreateParameter
            Param.ParameterName = "@InspectorID"
            Param.Value = InspectorID
            cmd.Parameters.Add(Param)

            cmd.Connection = Conn

            result = cmd.ExecuteNonQuery
            If result <> 1 Then
                NewIDR = False
            Else
                NewIDR = True
            End If
            cmd.Parameters.Clear()
        End If
    End Function

    Public Function UpdateIDR(ByVal Weather As String, ByVal TempHigh As String, ByVal TempLow As String, ByVal Milage As String, ByVal HoursCharged As String, _
        ByVal Expenses As String, ByVal Comments As String, ByVal IDR_UID As String) As Boolean
        Dim param As SqlParameter
        Dim iResult As Integer
        If Conn.State = ConnectionState.Open Then
            cmd.CommandText = "Update IDR SET Weather=@Weather, TempHigh=@TempHigh, TempLow=@TempLow, Milage=@Milage, HoursCharged=@HoursCharged, " & _
                "Expenses=@Expenses, Comments=@Comments WHERE IDR_UID=@IDR_UID"

            param = cmd.CreateParameter
            param.ParameterName = "@Weather"
            param.Value = Weather
            cmd.Parameters.Add(param)

            param = cmd.CreateParameter
            param.ParameterName = "@TempHigh"
            param.Value = TempHigh
            cmd.Parameters.Add(param)

            param = cmd.CreateParameter
            param.ParameterName = "@TempLow"
            param.Value = TempLow
            cmd.Parameters.Add(param)

            param = cmd.CreateParameter
            param.ParameterName = "@Milage"
            param.Value = Milage
            cmd.Parameters.Add(param)

            param = cmd.CreateParameter
            param.ParameterName = "@HoursCharged"
            param.Value = HoursCharged
            cmd.Parameters.Add(param)

            param = cmd.CreateParameter
            param.ParameterName = "@Expenses"
            param.Value = Expenses
            cmd.Parameters.Add(param)

            param = cmd.CreateParameter
            param.ParameterName = "@Comments"
            param.Value = Comments
            cmd.Parameters.Add(param)

            param = cmd.CreateParameter
            param.ParameterName = "@IDR_UID"
            param.Value = IDR_UID
            cmd.Parameters.Add(param)

            cmd.Connection = Conn
            iResult = cmd.ExecuteNonQuery
            If iResult = 1 Then
                UpdateIDR = True
            Else
                UpdateIDR = False
            End If
            cmd.Parameters.Clear()
        End If
    End Function

    Public Function UpdateContractName(ByVal ContractUID As Integer, ByVal NewContractID As String) As Boolean
        Dim param As SqlParameter
        Dim iResult As Integer
        If Conn.State = ConnectionState.Open Then
            cmd.CommandText = "UPDATE Contract Set ContractID=@NewContractID WHERE ContractUID=@ContractUID"

            param = cmd.CreateParameter
            param.ParameterName = "@newContractID"
            param.Value = NewContractID
            cmd.Parameters.Add(param)

            param = cmd.CreateParameter
            param.ParameterName = "@ContractUID"
            param.Value = ContractUID
            cmd.Parameters.Add(param)
            cmd.Connection = Conn
            iResult = cmd.ExecuteNonQuery
            If iResult = 1 Then
                UpdateContractName = True
            Else
                UpdateContractName = False
            End If
            cmd.Parameters.Clear()
        End If
    End Function

    Public Function AddContract(ByVal ClientID As String, ByVal ContractName As String, ByVal EngineerID As String) As Boolean
        Dim param As SqlParameter
        Dim iResult As Integer
        If Conn.State = ConnectionState.Open Then
            cmd.CommandText = "INSERT INTO Contract (ContractID, CustID, ProjectEngineerID) VALUES (@ContractName, @ClientID, @EngineerID)"
            ' @ContractName
            param = cmd.CreateParameter
            param.ParameterName = "@ContractName"
            param.Value = ContractName
            cmd.Parameters.Add(param)
            ' @ClientID
            param = cmd.CreateParameter
            param.ParameterName = "@ClientID"
            param.Value = ClientID
            cmd.Parameters.Add(param)
            ' @Engineer
            param = cmd.CreateParameter
            param.ParameterName = "@EngineerID"
            param.Value = EngineerID
            cmd.Parameters.Add(param)

            cmd.Connection = Conn
            iResult = cmd.ExecuteNonQuery
            If iResult = 1 Then
                AddContract = True
            Else
                AddContract = False
            End If
            cmd.Parameters.Clear()
        End If
    End Function

    Public Function ArchiveContract(ByVal ContractUID As String)
        Dim param As SqlParameter
        Dim iResult As Integer
        Me.OpenConn()
        If Conn.State = ConnectionState.Open Then
            cmd.CommandText = "Update Contract Set Archived=GetDate() Where ContractUID=@ContractUID"
            param = cmd.CreateParameter
            param.ParameterName = "@ContractUID"
            param.Value = ContractUID
            cmd.Parameters.Add(param)
            cmd.Connection = Conn
            iResult = cmd.ExecuteNonQuery
            If iResult = 1 Then
                ArchiveContract = True
            Else
                ArchiveContract = False
            End If
            cmd.Parameters.Clear()
        End If
        Me.CloseConn()
    End Function

    Public Function AddContractMaterial(ByVal ClientUID As String, ByVal MaterialID As String, ByVal BidQty As String, ByVal UnitPrice As String) As Boolean
        Dim param As SqlParameter
        Dim iResult As Integer
        If Conn.State = ConnectionState.Open Then
            cmd.CommandText = "INSERT INTO ContractMaterials (ContractUID, MaterialID, BidQuantity, UnitPrice) VALUES (@ContractUID, @MaterialID, @BidQuantity, @UnitPrice)"
            ' @ContractUID
            param = cmd.CreateParameter
            param.ParameterName = "@ContractUID"
            param.Value = ClientUID
            cmd.Parameters.Add(param)
            ' @MaterialID
            param = cmd.CreateParameter
            param.ParameterName = "@MaterialID"
            param.Value = MaterialID
            cmd.Parameters.Add(param)
            ' @BidQuantity
            param = cmd.CreateParameter
            param.ParameterName = "@BidQuantity"
            param.Value = BidQty
            cmd.Parameters.Add(param)
            ' @UnitPrice
            param = cmd.CreateParameter
            param.ParameterName = "@UnitPrice"
            param.Value = UnitPrice
            cmd.Parameters.Add(param)

            cmd.Connection = Conn
            Try
                iResult = cmd.ExecuteNonQuery
            Catch ex As Exception
                ExMsg = ex.Message
            End Try
            If iResult = 1 Then
                AddContractMaterial = True
            Else
                AddContractMaterial = False
            End If
            cmd.Parameters.Clear()
        End If
    End Function

    Public Function AddIDRItem(ByVal IDR_UID As String, ByVal MaterialID As String, ByVal Qty As String) As Boolean
        Dim param As SqlParameter
        Dim iResult As Integer
        If Conn.State = ConnectionState.Open Then
            cmd.CommandText = "INSERT INTO IDRItems (IDR_UID, MaterialID, Qty) VALUES(@IDR_UID, @MaterialID, @Qty)"

            param = cmd.CreateParameter
            param.ParameterName = "@IDR_UID"
            param.Value = IDR_UID
            cmd.Parameters.Add(param)

            param = cmd.CreateParameter
            param.ParameterName = "@MaterialID"
            param.Value = MaterialID
            cmd.Parameters.Add(param)

            param = cmd.CreateParameter
            param.ParameterName = "@Qty"
            param.DbType = DbType.Decimal
            param.Value = Qty
            cmd.Parameters.Add(param)

            cmd.Connection = Conn
            iResult = cmd.ExecuteNonQuery
            If iResult = 1 Then
                AddIDRItem = True
            Else
                AddIDRItem = False
            End If
            cmd.Parameters.Clear()
        End If
    End Function

    Public Function RemoveIDRItem(ByVal IDR_UID As String, ByVal MaterialID As String) As Boolean
        Dim param As SqlParameter
        Dim iResult As Integer
        If Conn.State = ConnectionState.Open Then
            cmd.CommandText = "DELETE FROM IDRItems WHERE IDR_UID=@IDR_UID AND MaterialID=@MaterialID"

            param = cmd.CreateParameter
            param.ParameterName = "@IDR_UID"
            param.Value = IDR_UID
            cmd.Parameters.Add(param)

            param = cmd.CreateParameter
            param.ParameterName = "@MaterialID"
            param.Value = MaterialID
            cmd.Parameters.Add(param)

            cmd.Connection = Conn
            iResult = cmd.ExecuteNonQuery
            If iResult = 1 Then
                RemoveIDRItem = True
            Else
                RemoveIDRItem = False
            End If
            cmd.Parameters.Clear()
        End If
    End Function

    Public Function RemoveMaterial(ByVal ContractUID As String, ByVal MaterialID As String) As Boolean
        Dim param As SqlParameter
        Dim result As Integer
        If Conn.State = ConnectionState.Open Then
            cmd.CommandText = "DELETE FROM ContractMaterials WHERE ContractUID=@ContractUID AND MaterialID=@MaterialID"

            param = cmd.CreateParameter
            param.ParameterName = "@ContractUID"
            param.Value = ContractUID
            cmd.Parameters.Add(param)

            param = cmd.CreateParameter
            param.ParameterName = "@MaterialID"
            param.Value = MaterialID
            cmd.Parameters.Add(param)

            cmd.Connection = Conn
            result = cmd.ExecuteNonQuery
            If result = 1 Then
                RemoveMaterial = True
            Else
                RemoveMaterial = False
            End If
            cmd.Parameters.Clear()
        End If
    End Function

    Public Sub AuthUser(ByVal UserName As String, ByVal Password As String)
        Dim param As SqlParameter
        Dim result As Integer

        If Conn.State = ConnectionState.Open Then
            cmd.CommandText = "SELECT EmpID, UserName, Password, IsApprover FROM dbo.Employee WHERE (UserName = @UserName) AND (Password = @Password)"

            param = cmd.CreateParameter
            With param
                .ParameterName = "@UserName"
                .Value = UserName
            End With
            cmd.Parameters.Add(param)

            param = cmd.CreateParameter
            With param
                .ParameterName = "@Password"
                .Value = Password
            End With
            cmd.Parameters.Add(param)

            cmd.Connection = Conn
            drAuth = cmd.ExecuteReader
            cmd.Parameters.Clear()
        End If

    End Sub

    Public Sub OpenConn()
        Try
            Conn.Open()
        Catch ex As Exception
            ExMsg = ex.Message
        End Try
    End Sub

    Public Sub CloseConn()
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub

    Sub New()
        Conn.ConnectionString = ConfigurationSettings.AppSettings("PMSIConn.ConnectionString")
    End Sub

    Sub Dispose()
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
        Conn = Nothing
    End Sub

End Class
