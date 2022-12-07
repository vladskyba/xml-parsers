<?xml version="1.0" encoding="utf-8" ?>
<xsl:stylesheet version="1.0"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:flm="http://flights.com">

    <xsl:template match="/">
        <html>
            <body>
                <h1>Flights</h1>

                <h2>Hight cost</h2>
                <table border="1">
                    <tr bgcolor="#ff4400">
                        <th></th>
                        <th>Start</th>
                        <th>Destination</th>
                        <th>DepartureTime</th>
                        <th>ArrivalTime</th>
                        <th>Cost</th>
                    </tr>
                    <xsl:for-each select="flm:flights/flm:flight">
                        <xsl:if test="flm:cost &gt; 1">
                            <tr bgcolor="#ff7d4d">
                                <td><xsl:value-of select="@id"/></td>
                                <td><xsl:value-of select="flm:start"/></td>
                                <td><xsl:value-of select="flm:destination"/></td>
                                <td><xsl:value-of select="flm:departureTime"/></td>
                                <td><xsl:value-of select="flm:arrivalTime"/></td>
                                <td><xsl:value-of select="flm:cost"/></td>
                            </tr>
                        </xsl:if>
                    </xsl:for-each>
                    
                </table>

                <h2>Arrived</h2>

            </body>
        </html>
    </xsl:template>

</xsl:stylesheet>