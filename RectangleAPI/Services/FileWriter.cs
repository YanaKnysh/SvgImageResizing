using Newtonsoft.Json;
using RectangleAPI.Interfaces;
using RectangleAPI.Models;

namespace RectangleAPI.Services;

public class FileWriter : IWriter
{
    public void Write(Size size)
    {
        string fileName = Path.GetFullPath(Directory.GetCurrentDirectory() + @"\Data/currentSize.json");
        using (StreamReader file = File.OpenText(fileName))
        {
            dynamic jsonObj = JsonConvert.DeserializeObject(file.ReadToEnd()) ?? throw new InvalidOperationException();
            file.Close();
            jsonObj["height"] = size.Height;
            jsonObj["width"] = size.Width;
            string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText(fileName, output);
        }
    }
}