// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
public class Enabled
{
    public bool book { get; set; }
    public bool scroll { get; set; }
    public bool wands { get; set; }
    public bool npcs { get; set; }
    public bool dispensers { get; set; }
    public bool commands { get; set; }
    public bool treasure { get; set; }
    public bool trades { get; set; }
    public bool looting { get; set; }
}

public class BaseProperties
{
    public int speed_duration { get; set; }
    public int speed_strength { get; set; }
    public int jump_boost_duration { get; set; }
    public int jump_boost_strength { get; set; }
}

public class Root
{
    public Enabled enabled { get; set; }
    public string tier { get; set; }
    public string element { get; set; }
    public string type { get; set; }
    public int cost { get; set; }
    public int chargeup { get; set; }
    public int cooldown { get; set; }
    public BaseProperties base_properties { get; set; }
}