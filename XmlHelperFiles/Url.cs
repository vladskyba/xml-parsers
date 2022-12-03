namespace XmlParsers;

public class Url
{
    public readonly string BaseUrl;
    public readonly string XmlName;

    public string FullPath => @$"{BaseUrl}\{XmlName}";
    
    public Url(string baseUrl, string xmlName)
    {
        BaseUrl = baseUrl;
        XmlName = xmlName;
    }
}