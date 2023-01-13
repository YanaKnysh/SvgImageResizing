using Microsoft.AspNetCore.Mvc;
using RectangleAPI.Interfaces;
using RectangleAPI.Models;

namespace RectangleAPI.Controllers;

[ApiController]
[Route("[controller]/")]
public class RectangleController : ControllerBase
{
    private readonly IBackgroundProcessor _backgroundProcessor;
    private readonly IReader _reader;

    public RectangleController(IBackgroundProcessor backgroundProcessor, IReader reader)
    {
        _backgroundProcessor = backgroundProcessor;
        _reader = reader;
    }
    
    [HttpGet("initial-size")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Size))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<Size> GetInitialSize()
    {
        Size initialSize;
        
        try
        {
            initialSize = _reader.Read();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
        
        return Ok(initialSize);
    }
    
    [HttpPost("perimeter")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<string> GetPerimeter(Size currentSize)
    {
        try
        {
            _backgroundProcessor.Enqueue(currentSize);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }

        return Ok((2*(currentSize.Height + currentSize.Width)).ToString());
    }
}