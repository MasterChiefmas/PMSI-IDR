<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ManageUsers.aspx.vb" Inherits="IDR.ManageUsers" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>ManageUsers</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/nav4-0">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<P align="center">Manage Users</P>
			<P align="center">
				<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="300" border="1">
					<TR>
						<TD>
							<P align="center">
								<asp:ListBox id="lstUSers" runat="server" Width="353px" Height="240px"></asp:ListBox></P>
						</TD>
						<TD>
							<asp:TextBox id="TextBox1" runat="server"></asp:TextBox>
							<asp:TextBox id="TextBox2" runat="server"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD></TD>
						<TD></TD>
					</TR>
					<TR>
						<TD></TD>
						<TD></TD>
					</TR>
				</TABLE>
			</P>
			<P align="center">&nbsp;</P>
			<P align="center">&nbsp;</P>
		</form>
	</body>
</HTML>
