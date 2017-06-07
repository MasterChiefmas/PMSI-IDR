<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ECS.aspx.vb" Inherits="IDR.ECS" Trace="false"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>ECS</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/nav4-0" name="vs_targetSchema">
		<LINK href="../Stylesheets/Reports.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<DIV align="center">
			<form id="Form1" method="post" runat="server">
				<P align="center">&nbsp;</P>
				<P>&nbsp;</P>
				<P>
					<asp:Label id="lblTitle" runat="server" Font-Size="Large">Inspector-Contract Summary</asp:Label></P>
				<P>
					<TABLE id="Table1" cellSpacing="1" cellPadding="1" border="1">
						<TR>
							<TD width="473" height="24"></TD>
							<TD align="center" height="24"><asp:button id="btnExecute" runat="server" Text="Get Report"></asp:button></TD>
						</TR>
						<TR>
							<TD width="473" height="62">
								<P style="TEXT-ALIGN: left">Customer:
									<asp:dropdownlist id="ddlCust" runat="server" AutoPostBack="True"></asp:dropdownlist></P>
								<P style="TEXT-ALIGN: left">Contract:
									<asp:dropdownlist id="ddlContract" runat="server"></asp:dropdownlist></P>
							</TD>
							<TD rowSpan="2">
								<P><asp:datagrid id="dgReport" runat="server" Width="400px" HorizontalAlign="Left">
										<AlternatingItemStyle BackColor="#E0E0E0"></AlternatingItemStyle>
										<HeaderStyle ForeColor="White" BackColor="Navy"></HeaderStyle>
									</asp:datagrid></P>
								<asp:label id="lblRptStatus" runat="server"></asp:label></TD>
						</TR>
						<TR>
							<TD align="left" width="473">
								<P style="TEXT-ALIGN: left"><asp:calendar id="Calendar1" runat="server" BackColor="Transparent">
										<DayStyle ForeColor="Black" BackColor="White"></DayStyle>
										<NextPrevStyle ForeColor="White" BackColor="Navy"></NextPrevStyle>
										<DayHeaderStyle ForeColor="Black" BackColor="White"></DayHeaderStyle>
										<SelectedDayStyle ForeColor="Black" BorderColor="Transparent" BackColor="Yellow"></SelectedDayStyle>
										<TitleStyle Font-Bold="True" ForeColor="White" BackColor="Navy"></TitleStyle>
										<WeekendDayStyle ForeColor="Black" BackColor="White"></WeekendDayStyle>
										<OtherMonthDayStyle BackColor="#E0E0E0"></OtherMonthDayStyle>
									</asp:calendar></P>
								<P style="TEXT-ALIGN: left"><asp:button id="btnStartDate" runat="server" Text="Range Start"></asp:button><asp:label id="lblDateStart" runat="server"></asp:label></P>
								<P style="TEXT-ALIGN: left"><asp:button id="btnEndDate" runat="server" Text="Range End"></asp:button>
									<asp:Label id="lblDateEnd" runat="server"></asp:Label></P>
							</TD>
						</TR>
					</TABLE>
				</P>
			</form>
		</DIV> <!--#include file="../Common/footer.htm"-->
	</body>
</HTML>
