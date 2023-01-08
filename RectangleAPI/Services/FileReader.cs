using Newtonsoft.Json;
using RectangleAPI.Interfaces;
using RectangleAPI.Models;

namespace RectangleAPI.Services;

public class FileReader : IReader
{
    private string jsonFile = @"/Data/initialSize.json";
    
    public Size Read()
    {
        Size result;
        string fileName = Path.GetFullPath(Directory.GetCurrentDirectory() + jsonFile);
        using (StreamReader file = System.IO.File.OpenText(fileName))
        {
            JsonSerializer serializer = new JsonSerializer();
            result = (Size) serializer.Deserialize(file, typeof(Size))!;
        }

        if (result == null)
            throw new Exception($"Json {jsonFile} is invalid");

        return result;
    }
}