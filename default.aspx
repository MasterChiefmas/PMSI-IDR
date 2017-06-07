<%@ Page Language="vb" AutoEventWireup="false" Codebehind="default.aspx.vb" Inherits="IDR.MainMenu" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>PMSI IDR</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<DIV align="center">
			<form id="Form1" method="post" runat="server">
				<P>&nbsp;</P>
				<P>&nbsp;</P>
				<P>
					<asp:hyperlink id="IDRSubmit" runat="server" NavigateUrl="IDR.aspx">Submit IDR</asp:hyperlink></P>
				<P>
					<asp:hyperlink id="lnkReportsMenu" runat="server" NavigateUrl="Reports/menu.aspx">Reports</asp:hyperlink></P>
				<P>
					<asp:HyperLink id="lnkManageCust" runat="server" NavigateUrl="Admin/Main.aspx" Visible="False">Admin Menu</asp:HyperLink></P>
				<P><A href="/idr/ChangeLog.htm">Change Log</A></P>
				<P><asp:hyperlink id="HyperLink3" runat="server" NavigateUrl="logout.aspx">Logout</asp:hyperlink></P>
				<P>&nbsp;</P>
				<P>&nbsp;</P>
			</form>
		</DIV>
	</body>
</HTML>
