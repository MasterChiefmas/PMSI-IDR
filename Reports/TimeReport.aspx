<%@ Page Language="vb" AutoEventWireup="false" Codebehind="TimeReport.aspx.vb" Inherits="IDR.TimeReport" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>TimeReport</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<DIV align="center">
				<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="800" border="1">
					<TR>
						<TD style="WIDTH: 206px" vAlign="top" align="center" width="206" rowSpan="2"><asp:calendar id="ctlCalendar" runat="server" BackColor="White" Width="200px" DayNameFormat="FirstLetter"
								ForeColor="Black" Height="180px" Font-Size="8pt" Font-Names="Verdana" BorderColor="#999999" CellPadding="4">
								<TodayDayStyle ForeColor="Black" BackColor="#CCCCCC"></TodayDayStyle>
								<SelectorStyle BackColor="#CCCCCC"></SelectorStyle>
								<NextPrevStyle VerticalAlign="Bottom"></NextPrevStyle>
								<DayHeaderStyle Font-Size="7pt" Font-Bold="True" BackColor="#CCCCCC"></DayHeaderStyle>
								<SelectedDayStyle Font-Bold="True" ForeColor="White" BackColor="#666666"></SelectedDayStyle>
								<TitleStyle Font-Bold="True" BorderColor="Black" BackColor="#999999"></TitleStyle>
								<WeekendDayStyle BackColor="#FFFFCC"></WeekendDayStyle>
								<OtherMonthDayStyle ForeColor="#808080"></OtherMonthDayStyle>
							</asp:calendar></TD>
						<TD>
							<P><asp:button id="btnDateBegin" runat="server" Text="Set Begin Date"></asp:button>&nbsp;Begin 
								Date:
								<asp:label id="lblDateBegin" runat="server"></asp:label></P>
							<P><asp:button id="btnDateEnd" runat="server" Text="Set End Date"></asp:button>&nbsp;End 
								Date:
								<asp:label id="lblDateEnd" runat="server"></asp:label></P>
							<P>Inspector:
								<asp:dropdownlist id="ddlInspectors" runat="server" AutoPostBack="True"></asp:dropdownlist></P>
							<P><asp:button id="btnGetRpt" runat="server" Text="Get Report"></asp:button></P>
						</TD>
					</TR>
					<TR>
						<TD><asp:datagrid id="dgRpt" runat="server" BackColor="White" BorderColor="#CC9966" CellPadding="4"
								BorderStyle="None" BorderWidth="1px" Visible="False">
								<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
								<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
								<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
								<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
							</asp:datagrid></TD>
					</TR>
				</TABLE>
			</DIV>
			<DIV align="center">&nbsp;</DIV>
			<DIV align="center">&nbsp;</DIV>
			<DIV align="center">&nbsp;</DIV>
			<DIV align="center"><asp:hyperlink id="lnkAdminMain" runat="server" Visible="False" NavigateUrl="../Admin/Main.aspx">Admin Main Menu</asp:hyperlink></DIV>
			<DIV align="center">&nbsp;</DIV>
			<DIV align="center"><asp:hyperlink id="lnkMainMenu" runat="server" NavigateUrl="../default.aspx">Main Menu</asp:hyperlink></DIV>
		</form>
	</body>
</HTML>
