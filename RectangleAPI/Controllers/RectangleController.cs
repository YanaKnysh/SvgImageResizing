using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RectangleAPI.Interfaces;
using RectangleAPI.Models;

namespace RectangleAPI.Controllers;

[ApiController]
[Route("[controller]/")]
public class RectangleController : ControllerBase
{
    private readonly IBackgroundProcessor _backgroundProcessor;

    public RectangleController(IBackgroundProcessor backgroundProcessor)
    {
        _backgroundProcessor = backgroundProcessor;
    }
    
    [HttpGet]
    [Route("initialsize")]
    public ActionResult<Size> GetInitialSize()
    {
        Size? initialSize;
        string fileName = Path.GetFullPath(Directory.GetCurrentDirectory() + @"\Data/initialSize.json");
        using (StreamReader file = System.IO.File.OpenText(fileName))
        {
            JsonSerializer serializer = new JsonSerializer();
            initialSize = (Size) serializer.Deserialize(file, typeof(Size))!;
        }

        if (initialSize == null)
            return BadRequest("Json is invalid");
        
        return Ok(initialSize);
    }
    
    [HttpPost]
    [Route("perimeter")]
    public ActionResult<string> GetPerimeter(Size currentSize)
    {
        var isHeightCorrect = int.TryParse(currentSize.Height, out int currentHeight);
        var isWidthCorrect = int.TryParse(currentSize.Width, out int currentWidth);
        
        if (isHeightCorrect && isWidthCorrect)
        {
            _backgroundProcessor.Enqueue(currentSize);
        }
        else
        {
            return BadRequest("Parameters are not correct");
        }
        
        return Ok((currentHeight * currentWidth).ToString());
    }
}