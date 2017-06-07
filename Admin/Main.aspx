<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Main.aspx.vb" Inherits="IDR.Main" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Main</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<P align="center">
				<asp:HyperLink id="lnkManClients" runat="server" NavigateUrl="ManageClient.aspx">Manage Clients</asp:HyperLink></P>
			<P align="center">
				<asp:HyperLink id="lnkManContr" runat="server" NavigateUrl="ManageContracts.aspx">Manage Contracts</asp:HyperLink></P>
			<P align="center">
				<asp:HyperLink id="lnkManUsers" runat="server" NavigateUrl="ManageUsers.aspx">Manage Users</asp:HyperLink></P>
			<P align="center">
				<asp:HyperLink id="lnkMainMenu" runat="server" NavigateUrl="../default.aspx">Main Menu</asp:HyperLink></P>
			<P align="center">&nbsp;</P>
		</form>
	</body>
</HTML>
