<%@ Page Language="vb" AutoEventWireup="false" Codebehind="DevReport.aspx.vb" Inherits="IDR.DevReport" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>DevReport</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/nav4-0">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<P align="center">
				<TABLE id="Table1" height="216" cellSpacing="1" cellPadding="1" width="714" border="1">
					<TR>
						<TD width="254" rowSpan="2">
							<asp:Calendar id="Calendar1" runat="server" BackColor="White" Width="200px" DayNameFormat="FirstLetter"
								ForeColor="Black" Height="180px" Font-Size="8pt" Font-Names="Verdana" BorderColor="#999999"
								CellPadding="4">
								<TodayDayStyle ForeColor="Black" BackColor="#CCCCCC"></TodayDayStyle>
								<SelectorStyle BackColor="#CCCCCC"></SelectorStyle>
								<NextPrevStyle VerticalAlign="Bottom"></NextPrevStyle>
								<DayHeaderStyle Font-Size="7pt" Font-Bold="True" BackColor="#CCCCCC"></DayHeaderStyle>
								<SelectedDayStyle Font-Bold="True" ForeColor="White" BackColor="#666666"></SelectedDayStyle>
								<TitleStyle Font-Bold="True" BorderColor="Black" BackColor="#999999"></TitleStyle>
								<WeekendDayStyle BackColor="#FFFFCC"></WeekendDayStyle>
								<OtherMonthDayStyle ForeColor="#808080"></OtherMonthDayStyle>
							</asp:Calendar></TD>
						<TD></TD>
					</TR>
					<TR>
						<TD></TD>
					</TR>
				</TABLE>
			</P>
		</form>
	</body>
</HTML>
