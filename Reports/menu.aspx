<%@ Page Language="vb" AutoEventWireup="false" Codebehind="menu.aspx.vb" Inherits="IDR.menu" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>menu</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<P align="center">Reports Menu</P>
			<P align="center">
				<asp:HyperLink id="lnkIDRDump" runat="server" NavigateUrl="IDRDump.aspx">IDR Dump</asp:HyperLink></P>
			<P align="center"><asp:hyperlink id="lnkTimeRpt" runat="server" NavigateUrl="TimeReport.aspx">Time Report</asp:hyperlink></P>
			<P align="center"><asp:hyperlink id="lnkContractStatus" runat="server" NavigateUrl="ContractStatus.aspx">Contract Status</asp:hyperlink></P>
			<P align="center"><A href="./ECS.aspx">Inspector Contract Summary</A></P>
			<DIV align="center"><asp:hyperlink id="lnkAdminMain" runat="server" NavigateUrl="../Admin/Main.aspx" Visible="False">Admin Main Menu</asp:hyperlink></DIV>
			<DIV align="center">&nbsp;</DIV>
			<DIV align="center"><asp:hyperlink id="lnkMainMenu" runat="server" NavigateUrl="../default.aspx">Main Menu</asp:hyperlink></DIV>
			<DIV align="center">&nbsp;</DIV>
		</form>
	</body>
</HTML>
