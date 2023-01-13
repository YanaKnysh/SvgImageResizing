using System.Configuration;
using Newtonsoft.Json;
using RectangleAPI.Interfaces;
using RectangleAPI.Models;

namespace RectangleAPI.Services;

public class FileReader : IReader
{
    public Size Read()
    {
        var jsonFilePath = Common.Constants.JsonFilePath;
        Size result;
        string fileName = Path.GetFullPath(Directory.GetCurrentDirectory() + jsonFilePath);
        using (StreamReader file = System.IO.File.OpenText(fileName))
        {
            JsonSerializer serializer = new JsonSerializer();
            result = (Size) serializer.Deserialize(file, typeof(Size))!;
        }

        if (result == null)
            throw new Exception($"Json {jsonFilePath} is invalid");

        return result;
    }
}