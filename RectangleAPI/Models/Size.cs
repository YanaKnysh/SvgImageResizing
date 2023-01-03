using Newtonsoft.Json;

namespace RectangleAPI.Models;

[JsonObject]
public class Size
{
    public Size(string height, string width)
    {
        Height = height;
        Width = width;
    }

    [JsonProperty("height")]
    public string Height { get; set; }
    [JsonProperty("width")]
    public string Width { get; set; }
}