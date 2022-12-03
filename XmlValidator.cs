using System.Xml;
using System.Xml.Schema;

namespace XmlParsers;

public static class XmlValidator
{
    public static void ValidateXmlDocument(Url url)
    {
        var settings = XmlHelper.RetreiveXmlReaderSettings();
        
        settings.ValidationEventHandler += ValidationCallBack;
        var reader = XmlReader.Create(url.FullPath, settings);

        Console.WriteLine($"Validate {url.XmlName}:");
        
        while (reader.Read());
    }

    private static void ValidationCallBack(object sender, ValidationEventArgs args)
    {
        if (args.Severity == XmlSeverityType.Warning)
            Console.WriteLine("\tWarning: Matching schema not found. No validation occurred." + args.Message);
        else
            Console.WriteLine("\tValidation error: " + args.Message);
    }
}