<%@ Page Language="vb" AutoEventWireup="false" Codebehind="login.aspx.vb" Inherits="IDR.login" Trace="false" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Chien Corporation IDR</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<P align="center">&nbsp;</P>
			<P align="center">&nbsp;</P>
			<P align="center">&nbsp;</P>
			<P align="center"><asp:label id="lblLogin" runat="server" DESIGNTIMEDRAGDROP="7" Font-Size="Larger" Width="80px">Chien Corporation IDR</asp:label></P>
			<P align="center"><asp:label id="txtMsg" runat="server" Width="104px"></asp:label></P>
			<P align="center">
				<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="300" border="1">
					<TR>
						<TD style="WIDTH: 98px; HEIGHT: 30px">User Name:</TD>
						<TD style="HEIGHT: 30px"><asp:textbox id="txtUserName" runat="server" Width="156"></asp:textbox></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 98px">Password:</TD>
						<TD><asp:textbox id="txtPassword" runat="server" Width="156px" TextMode="Password"></asp:textbox></TD>
					</TR>
				</TABLE>
			</P>
			<P align="center"><asp:button id="Button1" runat="server" Text="Login"></asp:button></P>
			<P align="center">&nbsp;</P>
			<P align="center">&nbsp;</P>
		</form>
	</body>
</HTML>
