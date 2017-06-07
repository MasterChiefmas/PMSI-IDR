<%@ Page Language="vb" AutoEventWireup="false" Codebehind="IDR.aspx.vb" Inherits="IDR.IDR" Trace="True" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>IDR</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<DIV align="center"><asp:label id="lblTitle" runat="server" Width="265px" Height="32px" Font-Bold="True" Font-Size="Large">Inspector's Daily Report</asp:label>
				<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="800" border="1">
					<TR>
						<TD vAlign="top" align="center" width="264">
							<P align="left"><asp:label id="lblCustomer" runat="server" Width="64px">Customer:</asp:label><asp:dropdownlist id="lstCustomers" runat="server" Width="160px" AutoPostBack="True"></asp:dropdownlist></P>
							<P align="left"><asp:label id="lblContract" runat="server" Width="64px">Contract:</asp:label><asp:dropdownlist id="lstContracts" runat="server" Width="160px" AutoPostBack="True"></asp:dropdownlist></P>
							<P align="left">IDR Date:</P>
							<P align="left"><asp:calendar id="IDRDate" runat="server" Width="200px" Height="180px" Font-Size="8pt" BackColor="White"
									DayNameFormat="FirstLetter" ForeColor="Black" Font-Names="Verdana" BorderColor="#999999" CellPadding="4">
									<TodayDayStyle ForeColor="Black" BackColor="#CCCCCC"></TodayDayStyle>
									<SelectorStyle BackColor="#CCCCCC"></SelectorStyle>
									<NextPrevStyle VerticalAlign="Bottom"></NextPrevStyle>
									<DayHeaderStyle Font-Size="7pt" Font-Bold="True" BackColor="#CCCCCC"></DayHeaderStyle>
									<SelectedDayStyle Font-Bold="True" ForeColor="White" BackColor="#666666"></SelectedDayStyle>
									<TitleStyle Font-Bold="True" BorderColor="Black" BackColor="#999999"></TitleStyle>
									<WeekendDayStyle BackColor="#FFFFCC"></WeekendDayStyle>
									<OtherMonthDayStyle ForeColor="#808080"></OtherMonthDayStyle>
								</asp:calendar></P>
						</TD>
						<TD vAlign="top" align="center">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="1">
								<TR>
									<TD style="WIDTH: 163px" width="163">
										<P><asp:label id="lblWeather" runat="server" Width="128px" Height="24px">Weather Conditions</asp:label></P>
										<P><asp:textbox id="txtWeather" runat="server" Width="120px"></asp:textbox></P>
										<P><asp:label id="lblTempHigh" runat="server" Width="32px" Height="16px">High:</asp:label><asp:textbox id="txtTempHigh" runat="server" Width="20px" Height="24px" Wrap="False" MaxLength="5"></asp:textbox></P>
										<P><asp:label id="lblTempLow" runat="server" Width="24px" Height="24px">Low:</asp:label><asp:textbox id="txtTempLow" runat="server" Width="20px" Height="24px" Wrap="False" MaxLength="5"></asp:textbox></P>
									</TD>
									<TD vAlign="top">
										<P><asp:label id="lblComments" runat="server" Width="35px">Comments:</asp:label></P>
										<P><asp:textbox id="txtComments" runat="server" Width="420px" Height="100px" Columns="40" Rows="5"
												TextMode="MultiLine"></asp:textbox></P>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 163px" vAlign="top" width="163">
										<P><asp:label id="lblMilage" runat="server">Milage:</asp:label><asp:textbox id="txtMilage" runat="server" Width="40px"></asp:textbox></P>
										<P><asp:label id="lblHours" runat="server">Hours:</asp:label><asp:textbox id="txtHours" runat="server" Width="40px"></asp:textbox></P>
										<P>Expenses:$
											<asp:TextBox id="txtExpenses" runat="server" Width="46px"></asp:TextBox></P>
										<P><asp:button id="btnAction" runat="server" Visible="False"></asp:button></P>
									</TD>
									<TD>
										<TABLE id="tblAddItem" height="109" cellSpacing="0" cellPadding="0" width="420" border="0">
											<TR>
												<TD align="center" colSpan="3" height="23"><STRONG>Report New Item</STRONG></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 33px" height="33">Item</TD>
												<TD style="HEIGHT: 33px" height="33"><asp:dropdownlist id="lstNewItem" runat="server"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD height="15">Qty.</TD>
												<TD height="15"><asp:textbox id="txtQty" runat="server"></asp:textbox></TD>
											</TR>
											<TR>
												<TD colSpan="3">
													<P><asp:button id="btnAddItem" runat="server" Text="Add/Modify"></asp:button></P>
													<P><asp:label id="lblItemList" runat="server" Width="124px">Reported Items:</asp:label></P>
												</TD>
											</TR>
										</TABLE>
										<asp:datagrid id="dgItems" runat="server" CellPadding="0" BorderWidth="1px" HorizontalAlign="Right"
											Enabled="False">
											<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											<HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
										</asp:datagrid></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
			</DIV>
			<DIV align="center">
				<asp:Label id="lblStatus" runat="server"></asp:Label></DIV>
			<DIV align="center">&nbsp;</DIV>
			<DIV align="center"><asp:hyperlink id="lnkAdminMain" runat="server" Visible="False" NavigateUrl="Admin/Main.aspx">Admin Main Menu</asp:hyperlink></DIV>
			<DIV align="center">&nbsp;</DIV>
			<DIV align="center"><asp:hyperlink id="lnkMainMenu" runat="server" NavigateUrl="default.aspx">Main Menu</asp:hyperlink></DIV>
			<DIV align="center">&nbsp;</DIV>
		</form>
	</body>
</HTML>
