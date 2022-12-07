using System.Text;
using XmlParsers;
using XmlParsers.Parsers;

// Validation

XmlValidator.ValidateXmlDocument(new Url(XmlHelper.BaseUrl, @"Xml/Bookings.xml"));
XmlValidator.ValidateXmlDocument(new Url(XmlHelper.BaseUrl, @"Xml/Flight.xml"));
XmlValidator.ValidateXmlDocument(new Url(XmlHelper.BaseUrl, @"Xml/Flights.xml"));
XmlValidator.ValidateXmlDocument(new Url(XmlHelper.BaseUrl, @"Xml/InvalidFlights.xml"));
XmlValidator.ValidateXmlDocument(new Url(XmlHelper.BaseUrl, @"Xml/Ticket.xml"));
XmlValidator.ValidateXmlDocument(new Url(XmlHelper.BaseUrl, @"Xml/User.xml"));

// Sereallization

var marshalledTicket1 = new Ticket() { seat = 1, line = 1, id = 1, userId = 1, bookingId = 1 };
var marshalledTicket2 = new Ticket() { seat = 1, line = 2, id = 2, userId = 1, bookingId = 1 };

var marshalledBooking = new Booking
{
    bookingStatus = BookingStatus.Active, 
    tickets = new List<Ticket>() {marshalledTicket1, marshalledTicket2  }, flightId = 1, id = 1
};

Console.WriteLine($"Booking to marshalling: {marshalledBooking}\n");

var createdXml = XmlGenericSerializer<Booking>.Serialize(marshalledBooking);
File.WriteAllText(new Url(XmlHelper.BaseUrl, @"Xml/marshalledBooking.xml").FullPath, createdXml, Encoding.Unicode);

var bookingDemarshalled =  XmlGenericDeserializer<Booking>.Deserialize(new Url(XmlHelper.BaseUrl, @"Xml/marshalledBooking.xml").FullPath);
Console.WriteLine($"\nDemarshalled booking: {bookingDemarshalled}");

var bookingCustom =  XmlGenericDeserializer<Booking>.Deserialize(new Url(XmlHelper.BaseUrl, @"Xml/Booking.xml").FullPath);
Console.WriteLine($"\nCustom booking: {bookingCustom}");

var parsedBookingsDOM = XmlDomParser.ParseBookings(new Url(XmlHelper.BaseUrl, @"Xml/Bookings.xml").FullPath);

foreach (var booking in parsedBookingsDOM)
{
    Console.WriteLine(booking);
}

XmlTransform.TransformXMLToHTML(new Url(XmlHelper.BaseUrl, @"Xml/Flights.xml").FullPath,
    new Url(XmlHelper.BaseUrl, @"Xml/Flights.xslt").FullPath);