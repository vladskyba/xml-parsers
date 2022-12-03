using System.Xml;
using System.Xml.Schema;

namespace XmlParsers;

public static class XmlHelper
{
    public static readonly string TargetNamespace = "http://flights.com";
    public static readonly string BaseUrl = @"C:\Users\Rambls\Desktop\Универ\ІТОРОІ\Parsers\XmlParsers\XmlFiles";

    public static readonly string BaseEntityUrl = @$"{BaseUrl}\Xsd\Entity.xsd";
    public static readonly string TicketUrl = @$"{BaseUrl}\Xsd\Ticket.xsd";
    public static readonly string UserUrl = @$"{BaseUrl}\Xsd\User.xsd";
    public static readonly string FlightUrl = @$"{BaseUrl}\Xsd\Flight.xsd";
    public static readonly string BookingUrl = @$"{BaseUrl}\Xsd\Booking.xsd";
    public static readonly string FlightManagerUrl = @$"{BaseUrl}\Xsd\FlightManager.xsd";
    
    public static XmlReaderSettings RetreiveXmlReaderSettings()
    {
        var settings = new XmlReaderSettings();
        
        settings.Schemas.Add(TargetNamespace, BaseEntityUrl);
        settings.Schemas.Add(TargetNamespace, TicketUrl);
        settings.Schemas.Add(TargetNamespace, UserUrl);
        settings.Schemas.Add(TargetNamespace, FlightUrl);
        settings.Schemas.Add(TargetNamespace, BookingUrl);
        settings.Schemas.Add(TargetNamespace, FlightManagerUrl);
        
        settings.ValidationType = ValidationType.Schema;
        
        settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
        settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;
        settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;

        return settings;
    }
}