<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

<xsl:template match="/">

	<xsl:for-each select="/doc/Report">
	<h2>IDR Report for <xsl:value-of select="@Name"/>/<xsl:value-of select="@Contract"/></h2>
		<table border="1" cellpadding="0" cellspacing="0" width="800">
			<xsl:for-each select="IDR">
			<tr>
				<td rowspan="2">
					<table border="0">
						<tr><td>IDR Date:</td><td><xsl:value-of select="IDR_DATE"/></td></tr>
						<tr><td>Hours Charged:</td><td><xsl:value-of select="Hours_Charged"/></td></tr>
						<tr><td>Expenses:</td><td><xsl:value-of select="Expenses"/></td></tr>
						<tr><td>Milage:</td><td><xsl:value-of select='IDR_MILAGE'/></td></tr>
					</table>
				</td>
				<td valign="top">Inspector: <xsl:value-of select="Engineer"/></td>
			</tr>
			<tr>
			</tr>
			<tr>
				<td  colspan="2" align="center"><b>Weather Comments</b></td>
			</tr>
			<tr>
				<td><xsl:value-of select="Weather"/>&#160;</td>
				<td>
					<table border="0">
						<tr><td colspan="2">Temperature High:</td><td><xsl:value-of select="High_Temp"/></td></tr>
						<tr><td colspan="2">Temperature Low:</td><td><xsl:value-of select="Low_Temp"/></td></tr>
					</table>
				</td>
			</tr>
			<tr>
				<td colspan="2" align="center"><b>Comments</b></td>
			</tr>
			<tr>
				<td colspan="2"><xsl:value-of select="Comments"/></td>
			</tr>
			<tr><td colspan="2" align="center"><b>Materials</b></td></tr>
				<xsl:for-each select="Item">
					<tr>
						<td colspan="2">
							<xsl:value-of select="Qty"/>&#160;
							<xsl:value-of select="UnitType"/> of 
							<xsl:value-of select="Material"/>
						</td>
					</tr>
				</xsl:for-each>
			<tr bgcolor="LightGrey"><td colspan="2" align="center">&#160;</td></tr>
			</xsl:for-each>
		</table>
	</xsl:for-each>

		<p align="center"><a href="./menu.aspx">Return to Reports Menu</a></p>
		<p align="center"><a href="../default.aspx">Return to Main Menu</a></p>


</xsl:template>

</xsl:stylesheet>
		