<%@ Page Language="vb" AutoEventWireup="false" Codebehind="IDRForm.aspx.vb" Inherits="IDR.IDRForm" trace="False" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>IDRForm</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body ms_positioning="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:label id="lblTitle" style="Z-INDEX: 101; LEFT: 329px; POSITION: absolute; TOP: 8px" runat="server"
				Width="265px" Height="32px" Font-Bold="True" Font-Size="Large">Inspector's Daily Report</asp:label><asp:label id="lblCustomer" style="Z-INDEX: 102; LEFT: 336px; POSITION: absolute; TOP: 80px"
				runat="server" Width="56px">Customer:</asp:label><asp:label id="lblContract" style="Z-INDEX: 103; LEFT: 336px; POSITION: absolute; TOP: 104px"
				runat="server" Width="40px">Contract:</asp:label><asp:label id="lblMilage" style="Z-INDEX: 104; LEFT: 336px; POSITION: absolute; TOP: 136px"
				runat="server">Milage:</asp:label><asp:textbox id="txtMilage" style="Z-INDEX: 105; LEFT: 400px; POSITION: absolute; TOP: 136px"
				runat="server" Width="88px"></asp:textbox><asp:label id="lblHours" style="Z-INDEX: 106; LEFT: 512px; POSITION: absolute; TOP: 136px"
				runat="server">Hours:</asp:label><asp:textbox id="txtHours" style="Z-INDEX: 107; LEFT: 560px; POSITION: absolute; TOP: 136px"
				runat="server"></asp:textbox><asp:label id="lblWeather" style="Z-INDEX: 108; LEFT: 160px; POSITION: absolute; TOP: 80px"
				runat="server" Width="128px" Height="24px">Weather Conditions</asp:label><asp:label id="lblComments" style="Z-INDEX: 109; LEFT: 328px; POSITION: absolute; TOP: 160px"
				runat="server">Comments:</asp:label><asp:textbox id="txtWeather" style="Z-INDEX: 110; LEFT: 160px; POSITION: absolute; TOP: 104px"
				runat="server" Width="120px"></asp:textbox><asp:textbox id="txtComments" style="Z-INDEX: 111; LEFT: 328px; POSITION: absolute; TOP: 176px"
				runat="server" Width="496px" Height="82px"></asp:textbox><asp:label id="lblTempHigh" style="Z-INDEX: 112; LEFT: 160px; POSITION: absolute; TOP: 136px"
				runat="server" Width="32px" Height="16px">High:</asp:label><asp:textbox id="txtTempHigh" style="Z-INDEX: 113; LEFT: 200px; POSITION: absolute; TOP: 136px"
				runat="server" Width="20px" Height="24px" MaxLength="5" Wrap="False"></asp:textbox><asp:label id="lblTempLow" style="Z-INDEX: 114; LEFT: 160px; POSITION: absolute; TOP: 168px"
				runat="server" Width="24px" Height="24px">Low:</asp:label><asp:textbox id="txtTempLow" style="Z-INDEX: 115; LEFT: 200px; POSITION: absolute; TOP: 168px"
				runat="server" Width="20px" Height="24px" MaxLength="5" Wrap="False"></asp:textbox><asp:label id="Label1" style="Z-INDEX: 116; LEFT: 368px; POSITION: absolute; TOP: 40px" runat="server"
				Width="88px" Height="8px">Report Date:</asp:label>
			<TABLE id="tblAddItem" style="Z-INDEX: 117; LEFT: 328px; POSITION: absolute; TOP: 296px"
				height="109" cellSpacing="1" cellPadding="1" width="225" border="1">
				<TR>
					<TD align="center" colSpan="3" height="23" style="HEIGHT: 23px"><STRONG>Report New Item</STRONG></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 25px" height="25">Item</TD>
					<TD style="HEIGHT: 25px" height="25"><asp:dropdownlist id="lstNewItem" runat="server"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 15px">Qty.</TD>
					<TD style="HEIGHT: 15px">
						<asp:textbox id="TextBox1" runat="server"></asp:textbox></TD>
				</TR>
				<TR>
					<TD colSpan="3"><asp:button id="Button1" runat="server" Text="Add Item"></asp:button></TD>
				</TR>
			</TABLE>
			<asp:hyperlink id="lnkMainMenu" style="Z-INDEX: 118; LEFT: 440px; POSITION: absolute; TOP: 504px"
				runat="server" Width="74px" Height="24px" NavigateUrl="/pmsi-idr/default.aspx">Main Menu</asp:hyperlink>
			<asp:datagrid id="dgItems" style="Z-INDEX: 119; LEFT: 568px; POSITION: absolute; TOP: 304px" runat="server"
				Height="144px" Width="248px" BorderWidth="1px" CellPadding="0">
				<HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
			</asp:datagrid>
			<P><asp:label id="lblCustomerVal" style="Z-INDEX: 120; LEFT: 400px; POSITION: absolute; TOP: 80px"
					runat="server" Width="168px"></asp:label><asp:label id="lblContractVal" style="Z-INDEX: 121; LEFT: 400px; POSITION: absolute; TOP: 104px"
					runat="server" Width="168px"></asp:label>
				<asp:Label id="lblIDRDate" style="Z-INDEX: 122; LEFT: 464px; POSITION: absolute; TOP: 40px"
					runat="server" Width="128px"></asp:Label></P>
			<P>&nbsp;</P>
			<P>
				<asp:Label id="lblItemList" style="Z-INDEX: 123; LEFT: 568px; POSITION: absolute; TOP: 272px"
					runat="server" Width="124px">Reported Items:</asp:Label>
				<asp:Label id="lblIDRUID" style="Z-INDEX: 124; LEFT: 608px; POSITION: absolute; TOP: 8px" runat="server"></asp:Label></P>
		</form>
	</body>
</HTML>
