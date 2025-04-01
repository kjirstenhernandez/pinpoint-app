namespace pinpoint_app.Model;

public class Event
// Primary event model;
{
    public string id { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public string address { get; set; }
    public double lat { get; set; } // will be used for GIS mapping
    public double lon { get; set; } 
    public EventType type { get; set; } // allows us to set specific options for the event category
    public string date { get; set; } 
    public string time { get; set; } 
    public string imageURL { get; set; }

    public string DateTimeDisplay => $"{date}, {time}";
}

public enum EventType
{
    convention,
    seminar,
    fundraiser,
    party,
    sportEvent,
    privateEvent,
    publicEvent,
    workshop,
    festival,
    corporateEvent,
    schoolEvent,
    performance

}
