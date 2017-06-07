<%@ Control Language="vb" AutoEventWireup="false" Codebehind="IDRView.ascx.vb" Inherits="IDR.IDRView" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="1">
	<TR>
		<TD style="WIDTH: 299px" vAlign="top">
			<P>Date:
				<asp:Label id="lblDate" runat="server"></asp:Label></P>
			<P>Customer:
				<asp:Label id="lblCustomer" runat="server"></asp:Label></P>
			<P>Contract:
				<asp:Label id="lblContract" runat="server"></asp:Label></P>
			<P>Inspector:
				<asp:Label id="lblInspector" runat="server"></asp:Label></P>
		</TD>
		<TD>
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="1">
				<TR>
					<TD style="WIDTH: 284px; HEIGHT: 95px">
						<P>Weather Conditions:</P>
						<P>High:
							<asp:Label id="lblHighTemp" runat="server"></asp:Label></P>
						<P>Low:
							<asp:Label id="lblLowTemp" runat="server"></asp:Label></P>
					</TD>
					<TD style="HEIGHT: 95px" vAlign="top" align="left">
						<P>Inspectors Comments:</P>
						<P>
							<asp:Label id="lblComments" runat="server"></asp:Label></P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 284px">
						<P>Milage:
							<asp:Label id="lblMilage" runat="server"></asp:Label></P>
						<P>Hours:
							<asp:Label id="lblHours" runat="server"></asp:Label></P>
						<P>Expenses:
							<asp:Label id="lblExpenses" runat="server"></asp:Label></P>
					</TD>
					<TD vAlign="top">
						<P>Materials:</P>
						<P>
							<asp:DataGrid id="DataGrid1" runat="server"></asp:DataGrid></P>
					</TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
</TABLE>
