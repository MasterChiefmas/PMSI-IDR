<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ContractStatus.aspx.vb" Inherits="IDR.ContractStatus" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>ContractStatus</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<P align="center">Contract Status</P>
			<P align="center">
				<TABLE id="Table1" style="WIDTH: 750px; HEIGHT: 424px" cellSpacing="1" cellPadding="1"
					width="750" border="1">
					<TR>
						<TD style="WIDTH: 264px" vAlign="top" colSpan="2">
							<P align="left"><asp:label id="lblCustomer" runat="server" Width="64px">Customer:</asp:label><asp:dropdownlist id="lstCustomers" runat="server" Width="160px" AutoPostBack="True"></asp:dropdownlist><asp:label id="lblContract" runat="server" Width="64px">Contract:</asp:label><asp:dropdownlist id="lstContracts" runat="server" Width="160px" AutoPostBack="True"></asp:dropdownlist><asp:button id="btnGetReport" runat="server" Text="Get Report!" Visible="False"></asp:button></P>
						</TD>
					</TR>
					<TR>
						<TD vAlign="top">
							<P><asp:datagrid id="dgReport" runat="server" BorderColor="#999999" BorderStyle="None" BorderWidth="1px"
									BackColor="White" CellPadding="3" GridLines="Vertical">
									<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
									<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
									<AlternatingItemStyle BackColor="#DCDCDC"></AlternatingItemStyle>
									<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
									<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
									<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
								</asp:datagrid></P>
							<P>Total Contract Value: $<asp:label id="lblTCV" runat="server"></asp:label></P>
							<P>Total Cost-To-Date: $<asp:label id="lblCTD" runat="server"></asp:label></P>
							<P>Remaining Contract Value: $
								<asp:label id="lblRCV" runat="server"></asp:label></P>
							<P>Most recent IDR posted:
								<asp:label id="lblLastIDR" runat="server" ForeColor="Transparent"></asp:label></P>
							<asp:label id="lblStatus" runat="server"></asp:label></TD>
					</TR>
				</TABLE>
			</P>
			<DIV align="center"><asp:hyperlink id="lnkAdminMain" runat="server" Visible="False" NavigateUrl="../Admin/Main.aspx">Admin Main Menu</asp:hyperlink></DIV>
			<DIV align="center">&nbsp;</DIV>
			<DIV align="center"><asp:hyperlink id="lnkMainMenu" runat="server" NavigateUrl="../default.aspx">Main Menu</asp:hyperlink></DIV>
			<DIV align="center">&nbsp;</DIV>
			<DIV align="center">
				<DIV align="center">&nbsp;</DIV>
			</DIV>
		</form>
	</body>
</HTML>
