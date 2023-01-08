using Newtonsoft.Json;
using RectangleAPI.Interfaces;
using RectangleAPI.Models;

namespace RectangleAPI.Services;

public class FileWriter : IWriter
{
    private string jsonFile = @"/Data/currentSize.json";
    
    public void Write(Size size)
    {
        var fileName = Path.GetFullPath(Directory.GetCurrentDirectory() + jsonFile);
        if (!File.Exists(fileName))
            throw new Exception($"Json file {jsonFile} does not exist.");
            
        using (var file = File.OpenText(fileName))
        {
            dynamic jsonObj = JsonConvert.DeserializeObject(file.ReadToEnd());
            file.Close();
            jsonObj["height"] = size.Height;
            jsonObj["width"] = size.Width;
            string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText(fileName, output);
        }
    }
}