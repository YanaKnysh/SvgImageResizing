using RectangleAPI.Models;

namespace RectangleAPI.Interfaces;

public interface IBackgroundProcessor
{
    void Enqueue(Size size);
}