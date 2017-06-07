<%@ Page Language="vb" AutoEventWireup="false" Codebehind="EmployeeSummary.aspx.vb" Inherits="IDR.EmployeeSummary" Trace="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>EmployeeSummary</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<P align="center">Employee Contract Summary</P>
			<P align="center">
				<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="800" border="1">
					<TR>
						<TD style="WIDTH: 264px">
							<P align="left"><asp:label id="lblCustomer" runat="server" Width="64px">Customer:</asp:label><asp:dropdownlist id="ddlCust" runat="server" AutoPostBack="True" Width="176px"></asp:dropdownlist></P>
							<P align="left">Contract:&nbsp;&nbsp;
								<asp:dropdownlist id="ddlContract" runat="server" Width="176px"></asp:dropdownlist></P>
							<P align="left"><asp:calendar id="Calendar1" runat="server">
									<NextPrevStyle ForeColor="White"></NextPrevStyle>
									<TitleStyle ForeColor="White" BackColor="DarkBlue"></TitleStyle>
									<OtherMonthDayStyle ForeColor="LightGray" BackColor="White"></OtherMonthDayStyle>
								</asp:calendar></P>
							<P align="left"><asp:button id="btnSetStart" runat="server" Text="Set Start"></asp:button><asp:button id="btnSetEnd" runat="server" Text="Set End"></asp:button><asp:button id="btnGetReport" runat="server" Text="Get Report"></asp:button></P>
						</TD>
						<TD vAlign="top">
							<P>Report Start Date:
								<asp:label id="lblStart" runat="server"></asp:label></P>
							<P>Report End Date:&nbsp;&nbsp;
								<asp:label id="lblEnd" runat="server"></asp:label></P>
							<P><asp:datagrid id="dgECS" runat="server">
									<HeaderStyle ForeColor="White" BackColor="Navy"></HeaderStyle>
								</asp:datagrid></P>
							<P><asp:label id="lblMsg" runat="server" Width="512px"></asp:label></P>
						</TD>
					</TR>
				</TABLE>
			</P>
			<P align="center"><asp:label id="lblErrMsg" runat="server" Width="500px"></asp:label></P>
			<DIV align="center"><asp:label id="lblIDRErr" runat="server"></asp:label></DIV>
			<DIV align="center"><asp:hyperlink id="lnkAdminMain" runat="server" NavigateUrl="../Admin/Main.aspx" Visible="False">Admin Main Menu</asp:hyperlink></DIV>
			<DIV align="center">&nbsp;</DIV>
			<DIV align="center"><asp:hyperlink id="lnkMainMenu" runat="server" NavigateUrl="../default.aspx">Main Menu</asp:hyperlink></DIV>
		</form>
	</body>
</HTML>
