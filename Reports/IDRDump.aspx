<%@ Page Language="vb" AutoEventWireup="false" Codebehind="IDRDump.aspx.vb" Inherits="IDR.IDRDump" Trace="false"%>
<%@ Register TagPrefix="uc1" TagName="IDRView" Src="IDRView.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>IDRDump</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:label id="lblJob" style="Z-INDEX: 110; LEFT: 24px; POSITION: absolute; TOP: 248px" runat="server">Job</asp:label><asp:label id="lblClient" style="Z-INDEX: 109; LEFT: 24px; POSITION: absolute; TOP: 208px"
				runat="server">Client</asp:label><asp:dropdownlist id="ddlContracts" style="Z-INDEX: 108; LEFT: 96px; POSITION: absolute; TOP: 248px"
				runat="server" Width="176px"></asp:dropdownlist><asp:dropdownlist id="ddlClients" style="Z-INDEX: 107; LEFT: 96px; POSITION: absolute; TOP: 208px"
				runat="server" Width="176px" AutoPostBack="True"></asp:dropdownlist><asp:label id="dEnd" style="Z-INDEX: 106; LEFT: 296px; POSITION: absolute; TOP: 168px" runat="server"
				Width="152px"></asp:label><asp:button id="btnSetBegin" style="Z-INDEX: 101; LEFT: 240px; POSITION: absolute; TOP: 128px"
				runat="server" CommandName="SetDateBegin" CommandArgument="Ascending" Text="Set"></asp:button><asp:button id="btnSetEnd" style="Z-INDEX: 102; LEFT: 240px; POSITION: absolute; TOP: 160px"
				runat="server" CommandName="SetDateEnd" CommandArgument="Ascending" Text="Set"></asp:button><asp:label id="lblBegin" style="Z-INDEX: 103; LEFT: 24px; POSITION: absolute; TOP: 128px" runat="server">From:</asp:label><asp:label id="lblEnd" style="Z-INDEX: 104; LEFT: 24px; POSITION: absolute; TOP: 160px" runat="server">To:</asp:label><asp:label id="dBegin" style="Z-INDEX: 105; LEFT: 296px; POSITION: absolute; TOP: 128px" runat="server"
				Width="152px"></asp:label><asp:button id="btnExecute" style="Z-INDEX: 111; LEFT: 24px; POSITION: absolute; TOP: 288px"
				runat="server" CommandName="GetReport" CommandArgument="Ascending" Text="Get Report"></asp:button><asp:textbox id="txtDateBegin" style="Z-INDEX: 112; LEFT: 72px; POSITION: absolute; TOP: 128px"
				runat="server"></asp:textbox><asp:textbox id="txtDateEnd" style="Z-INDEX: 113; LEFT: 72px; POSITION: absolute; TOP: 160px"
				runat="server"></asp:textbox></form>
		<asp:xml id="Xml1" runat="server"></asp:xml>
		<p align="center">
			<asp:hyperlink id="lnkAdminMain" style="Z-INDEX: 114; LEFT: 16px; POSITION: absolute; TOP: 336px"
				runat="server" NavigateUrl="../Admin/Main.aspx">Admin Main Menu</asp:hyperlink>
		</p>
		<p align="center">
			<asp:hyperlink id="lnkMainMenu" style="Z-INDEX: 115; LEFT: 24px; POSITION: absolute; TOP: 376px"
				runat="server" NavigateUrl="../default.aspx">Main Menu</asp:hyperlink>
		</p>
	</body>
</HTML>
