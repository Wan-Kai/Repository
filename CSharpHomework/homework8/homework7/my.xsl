<?xml version="1.0" encoding="UTF-8"?>

<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

<xsl:template match="/">
<html>
<body>
<h2>订单内容</h2>
<table>
    <tr bgcolor="#9acd32">
      <th align="left">订单号</th>
      <th align="left">订单名称</th>
      <th align="left">客户姓名</th>
      <th align="left">订单金额</th>
      <th align="left">用户号码</th>
    </tr>
    <xsl:for-each select="Order/orderList/OrderDetails">

	  <tr bgcolor="#D7DF01">
	  <td><xsl:value-of select="orderNumber"/></td>
	  <td><xsl:value-of select="orderName"/></td>
	  <td><xsl:value-of select="orderOwner"/></td>
	  <td><xsl:value-of select="moneyNumber"/></td>
	  <td><xsl:value-of select="orderPhone"/></td>
	  </tr>
      
    </xsl:for-each>   
</table>
</body>
</html>
</xsl:template>
</xsl:stylesheet>