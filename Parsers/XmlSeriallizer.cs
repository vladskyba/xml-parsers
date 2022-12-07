﻿using System.Xml;
using System.Xml.Serialization;

public class XmlGenericSerializer<T> where T : entity
{
    public static string Serialize(T obj)
    {
        XmlSerializer xsSubmit = new XmlSerializer(typeof(T));
        using (var sww = new StringWriter())
        {
            using (XmlTextWriter writer = new XmlTextWriter(sww) { Formatting = Formatting.Indented })
            {
                xsSubmit.Serialize(writer, obj);
                return sww.ToString();
            }
        }
    }
}