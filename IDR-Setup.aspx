<%@ Page Language="vb" AutoEventWireup="false" Codebehind="IDR-Setup.aspx.vb" Inherits="IDR.IDR_Setup" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>IDR_Setup</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<P align="center">
				<asp:label id="lblTitle" runat="server" Font-Size="Large" Font-Bold="True" Height="32px" Width="265px">Inspector's Daily Report</asp:label></P>
			<P align="center">&nbsp;</P>
			<P align="center">
				<asp:label id="lblCustomer" runat="server" Width="64px">Customer:</asp:label>
				<asp:dropdownlist id="lstCustomers" runat="server" Width="160px" AutoPostBack="True"></asp:dropdownlist></P>
			<P align="center">
				<asp:label id="lblContract" runat="server" Width="64px">Contract:</asp:label>
				<asp:dropdownlist id="lstContracts" runat="server" Width="160px" AutoPostBack="True"></asp:dropdownlist></P>
			<P align="center">
				<asp:calendar id="IDRDate" runat="server" Font-Size="8pt" Height="180px" Width="200px" CellPadding="4"
					BorderColor="#999999" Font-Names="Verdana" ForeColor="Black" DayNameFormat="FirstLetter" BackColor="White">
					<TodayDayStyle ForeColor="Black" BackColor="#CCCCCC"></TodayDayStyle>
					<SelectorStyle BackColor="#CCCCCC"></SelectorStyle>
					<NextPrevStyle VerticalAlign="Bottom"></NextPrevStyle>
					<DayHeaderStyle Font-Size="7pt" Font-Bold="True" BackColor="#CCCCCC"></DayHeaderStyle>
					<SelectedDayStyle Font-Bold="True" ForeColor="White" BackColor="#666666"></SelectedDayStyle>
					<TitleStyle Font-Bold="True" BorderColor="Black" BackColor="#999999"></TitleStyle>
					<WeekendDayStyle BackColor="#FFFFCC"></WeekendDayStyle>
					<OtherMonthDayStyle ForeColor="#808080"></OtherMonthDayStyle>
				</asp:calendar></P>
			<P align="center">
				<asp:Button id="btnContinue" runat="server" Text="Continue" Visible="False"></asp:Button></P>
			<P align="center">
				<asp:HyperLink id="lnkMainMenu" runat="server" NavigateUrl="default.aspx">Main Menu</asp:HyperLink></P>
		</form>
	</body>
</HTML>
