namespace TabletopConnect.Domain.Entities.Common.ValueObjects;

public class Location
{
    public string Address { get; private set; }
    public string City { get; private set; }
    public string Country { get; private set; }

    public Location(string address, string city, string country)
    {
        Address = address;
        City = city;
        Country = country;
    }
}
