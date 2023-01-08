using Newtonsoft.Json;

namespace RectangleAPI.Models;

[JsonObject]
public class Size
{
    [JsonProperty("height")]
    public int Height { get; set; }
    [JsonProperty("width")]
    public int Width { get; set; }
}