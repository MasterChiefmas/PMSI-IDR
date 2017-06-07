<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ManageContracts.aspx.vb" Inherits="IDR.ManageContracts" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>ManageContracts</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/nav4-0" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<DIV align="center">Contract List Management</DIV>
			<DIV align="center">&nbsp;</DIV>
			<DIV align="center">
				<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="700" align="center" border="1">
					<TR>
						<TD align="center" width="292" bgColor="#0033cc" height="21"><FONT color="white">Select 
								Client</FONT></TD>
						<TD align="center" bgColor="#0033cc" height="21"><FONT color="white">Contract List</FONT></TD>
					</TR>
					<TR>
						<TD vAlign="top" width="292" height="153" rowSpan="2">
							<P>Client:</P>
							<P><asp:dropdownlist id="lstClients" runat="server" AutoPostBack="True"></asp:dropdownlist></P>
						</TD>
						<TD colSpan="2" height="78">
							<P><asp:dropdownlist id="lstContracts" runat="server" AutoPostBack="True"></asp:dropdownlist></P>
							<P><asp:textbox id="TBNameChange" runat="server" Visible="False"></asp:textbox><asp:button id="btnContractNameChange" runat="server" Visible="False" Text="Save Change"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
								<asp:button id="btnArchive" runat="server" Text="Archive"></asp:button></P>
						</TD>
					</TR>
					<TR>
						<TD height="153">
							<P>New Contract</P>
							<P>Contract Name:
								<asp:textbox id="txtNewContract" runat="server"></asp:textbox></P>
							<P>Project Engineer:
								<asp:dropdownlist id="ddlEngineers" runat="server"></asp:dropdownlist></P>
							<P><asp:button id="btnAddContract" runat="server" Visible="False" Text="Add Contract"></asp:button><asp:requiredfieldvalidator id="RFVAddContract" runat="server" ErrorMessage="Contract name cannot be blank"
									Display="Dynamic" ControlToValidate="txtNewContract"></asp:requiredfieldvalidator></P>
						</TD>
					</TR>
					<TR>
						<TD align="center" width="292" bgColor="#0033cc" height="32"><FONT color="white">Materials 
								On Contract (Qty/Unit Price)</FONT></TD>
						<TD align="center" bgColor="#0033cc" height="32"><FONT color="white">Available 
								Materials</FONT></TD>
					</TR>
					<TR>
						<TD vAlign="top" width="292">
							<P><asp:listbox id="lstContractMaterials" runat="server" Width="288px"></asp:listbox></P>
							<P><asp:button id="btnRemove" runat="server" Text="Remove Selected Material"></asp:button></P>
						</TD>
						<TD vAlign="top">
							<P><asp:dropdownlist id="lstMaterials" runat="server"></asp:dropdownlist></P>
							<P><asp:requiredfieldvalidator id="RFVContractQty" runat="server" ErrorMessage="Contract Quantity required to add a material"
									Display="Dynamic" ControlToValidate="txtContractQty"></asp:requiredfieldvalidator></P>
							<P><asp:requiredfieldvalidator id="RFVUnitPrice" runat="server" ErrorMessage="Unit price required to add a material"
									ControlToValidate="txtUnitPrice"></asp:requiredfieldvalidator></P>
							<P>
								<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" border="0">
									<TR>
										<TD width="121">Contract Quantity:
										</TD>
										<TD><asp:textbox id="txtContractQty" runat="server"></asp:textbox></TD>
									</TR>
									<TR>
										<TD width="121">Unit Price:
										</TD>
										<TD><asp:textbox id="txtUnitPrice" runat="server"></asp:textbox></TD>
									</TR>
								</TABLE>
							</P>
							<P><asp:button id="btnAddMaterial" runat="server" Text="Add Material"></asp:button></P>
						</TD>
					</TR>
				</TABLE>
			</DIV>
			<DIV align="center">&nbsp;</DIV>
			<DIV align="center"><asp:hyperlink id="lnkAdminMain" runat="server" NavigateUrl="Main.aspx">Admin Main Menu</asp:hyperlink></DIV>
			<DIV align="center">&nbsp;</DIV>
			<DIV align="center"><asp:hyperlink id="lnkMainMenu" runat="server" NavigateUrl="../default.aspx">Main Menu</asp:hyperlink></DIV>
			<DIV align="center"><asp:label id="lblDebug" runat="server">debug</asp:label></DIV>
		</form>
	</body>
</HTML>
