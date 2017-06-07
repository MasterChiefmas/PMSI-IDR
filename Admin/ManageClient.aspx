<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ManageClient.aspx.vb" Inherits="IDR.ManageCust" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>ManageCust</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/nav4-0" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<P style="FONT-SIZE: larger" align="center">Manage Clients</P>
			<P>
				<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="500" align="center" border="1">
					<TR>
						<TD width="233" rowSpan="6"><asp:listbox id="lboxClients" runat="server" Height="332px" Width="256px" AutoPostBack="True"></asp:listbox></TD>
						<TD vAlign="top">
							<P><asp:label id="lblNew" runat="server">New Client:</asp:label></P>
							<P>
								<asp:RequiredFieldValidator id="RFVNewClient" runat="server" ErrorMessage="Client Name Cannot Be Blank" ControlToValidate="txtNewClient"
									Display="Dynamic"></asp:RequiredFieldValidator><asp:textbox id="txtNewClient" runat="server" Width="224px"></asp:textbox></P>
							<P><asp:button id="btnAddClient" runat="server" Text="Add Client"></asp:button></P>
						</TD>
					</TR>
					<TR>
						<TD vAlign="top">
							<P><asp:label id="EditLBL" runat="server" Visible="False">Edit Client:</asp:label></P>
							<P>
								<asp:RequiredFieldValidator id="RFVEditClient" runat="server" ErrorMessage="Client Name Cannot Be Blank" ControlToValidate="EditTxtBox"
									Display="Dynamic"></asp:RequiredFieldValidator><asp:textbox id="EditTxtBox" runat="server" Width="224px" Visible="False"></asp:textbox></P>
							<P><asp:button id="EditBTN" runat="server" Text="Save Changes" Visible="False"></asp:button><INPUT id="HidCustID" type="hidden" name="HidCustID" runat="server"></P>
						</TD>
					</TR>
				</TABLE>
			</P>
			<P align="center"><asp:hyperlink id="lnkAdminMain" runat="server" NavigateUrl="Main.aspx">Admin Main Menu</asp:hyperlink></P>
			<P align="center">
				<asp:HyperLink id="lnkMainMenu" runat="server" NavigateUrl="../default.aspx">Main Menu</asp:HyperLink></P>
		</form>
	</body>
</HTML>
