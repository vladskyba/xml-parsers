using System.Text;
using System.Xml;
using System.Xml.Xsl;

public static class XmlTransform 
{
    public static string TransformXMLToHTML(string inputXml, string xsltString)
    {
        XslCompiledTransform transform = new XslCompiledTransform();
        using(XmlReader reader = XmlReader.Create(new StringReader(xsltString))) {
            transform.Load(reader);
        }
        StringWriter results = new StringWriter();
        using(XmlReader reader = XmlReader.Create(new StringReader(inputXml)))
        {
            var xml = reader.Read();
            
            string msg_xml = Encoding.UTF8.GetString(Encoding.UTF8.GetPreamble());
            if (xml.StartsWith(msg_xml))
            {
                xml = xml.Remove(0, msg_xml.Length);
            }
            
            transform.Transform(reader, null, results);
        }

        return results.ToString();
    }
}
