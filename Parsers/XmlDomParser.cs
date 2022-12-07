using System.Xml;

namespace XmlParsers.Parsers;

public static class XmlDomParser
{
    public static IEnumerable<Booking> ParseBookings(string xmlPath)
    {
        var bookings = new List<Booking>();
        
        var document = new XmlDocument();
        document.Load(xmlPath);
        var root = document.DocumentElement;

        if (document.DocumentElement is null)
        {
            return null!;
        }
        else
        {
            foreach (XmlElement xmlElement in document.DocumentElement)
            {
                var booking = new Booking();
                var identifier = xmlElement.Attributes.GetNamedItem("id");
                booking.id = ulong.Parse(identifier.Value);
                
                foreach (XmlNode node in xmlElement.ChildNodes)
                {
                    switch (node.LocalName)
                    {
                        case "flightId":
                        {
                            booking.flightId = ulong.Parse(node.InnerText);
                            break;
                        }
                        case "bookingStatus":
                        {
                            Enum.TryParse(node.InnerText, out BookingStatus status);
                            booking.bookingStatus = status;
                            break;   
                        }
                        case "ticket":
                        {
                            booking.tickets.Add(ParseTicketNode(node));
                            break;
                        }
                    }
                }
                
                bookings.Add(booking);
            }    
        }
        return bookings;
    }

    private static Ticket ParseTicketNode(XmlNode ticketNode)
    {
        var ticketId = ticketNode.Attributes?.GetNamedItem("id")?.Value;

        var ticket = new Ticket
        {
            id = ulong.Parse(ticketId)
        };
        
        for (int i = 0; i < ticketNode.ChildNodes.Count; i++)
        {

            var innerElement = ticketNode.ChildNodes[i];
            
            switch (innerElement.LocalName)
            {
                case "seat":
                {
                    ticket.seat = byte.Parse(innerElement.InnerText);
                    break;
                }
                case "line":
                {
                    ticket.line = byte.Parse(innerElement.InnerText);
                    break;
                }
                case "bookingId":
                {
                    ticket.bookingId = ulong.Parse(innerElement.InnerText);
                    break;
                }
                case "userId":
                {
                    ticket.userId = ulong.Parse(innerElement.InnerText);
                    break;
                }
            }   
        }

        return ticket;
    }
}