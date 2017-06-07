<%@ Page Language="vb" AutoEventWireup="false" Codebehind="InspectorManageMain.aspx.vb" Inherits="IDR.InspectorManageMain" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>InspectorManageMain</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:ListBox id="EmpList" style="Z-INDEX: 101; LEFT: 24px; POSITION: absolute; TOP: 64px" runat="server"
				Width="192px" Height="216px" Rows="10" AutoPostBack="True"></asp:ListBox>
			<asp:Label id="Label1" style="Z-INDEX: 102; LEFT: 24px; POSITION: absolute; TOP: 32px" runat="server"
				Width="192px" Height="24px">Employees:</asp:Label>
			<asp:Label id="LblMsg" style="Z-INDEX: 103; LEFT: 32px; POSITION: absolute; TOP: 288px" runat="server"
				Width="176px" Height="24px"></asp:Label>
			<asp:HyperLink id="lnkMainMenu" style="Z-INDEX: 104; LEFT: 408px; POSITION: absolute; TOP: 312px"
				runat="server" Width="104px" Height="24px" NavigateUrl="/pmsi-idr/default.aspx">Main Menu</asp:HyperLink>
			<asp:TextBox id="FirstName" style="Z-INDEX: 105; LEFT: 408px; POSITION: absolute; TOP: 64px"
				runat="server" Width="208px" Visible="False"></asp:TextBox>
			<asp:TextBox id="LastName" style="Z-INDEX: 106; LEFT: 408px; POSITION: absolute; TOP: 96px" runat="server"
				Width="208px" Visible="False"></asp:TextBox>
			<asp:TextBox id="dbug" style="Z-INDEX: 107; LEFT: 408px; POSITION: absolute; TOP: 144px" runat="server"
				Height="136px" Width="209px"></asp:TextBox>
		</form>
	</body>
</HTML>
