using XmlParsers;

XmlValidator.ValidateXmlDocument(new Url(XmlHelper.BaseUrl, @"Xml/Bookings.xml"));
XmlValidator.ValidateXmlDocument(new Url(XmlHelper.BaseUrl, @"Xml/InvalidFlights.xml"));