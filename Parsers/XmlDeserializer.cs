using System.Xml.Schema;
using System.Xml.Serialization;

namespace XmlParsers.Parsers;


public class XmlGenericDeserializer<T> where T : entity
{
    public static T Deserialize(string xml)
    {
        XmlSerializer xsSubmit = new XmlSerializer(typeof(T));
        T obj = default;
        using (FileStream fs = new FileStream(xml, FileMode.OpenOrCreate))
        {
            obj = xsSubmit.Deserialize(fs) as T;
            fs.Close();
            fs.Dispose();
        }
        
        return obj;
    }
}