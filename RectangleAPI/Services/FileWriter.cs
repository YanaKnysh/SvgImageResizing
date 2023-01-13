using Newtonsoft.Json;
using RectangleAPI.Interfaces;
using RectangleAPI.Models;

namespace RectangleAPI.Services;

public class FileWriter : IWriter
{
    public void Write(Size size)
    {
        var jsonFilePath = Common.Constants.JsonFilePath;
        var fileName = Path.GetFullPath(Directory.GetCurrentDirectory() + jsonFilePath);
        if (!File.Exists(fileName))
            throw new Exception($"Json file {jsonFilePath} does not exist.");
            
        using (var file = File.OpenText(fileName))
        {
            dynamic jsonObj = JsonConvert.DeserializeObject(file.ReadToEnd())!;
            file.Close();
            jsonObj!["height"] = size.Height;
            jsonObj["width"] = size.Width;
            string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText(fileName, output);
        }
    }
}