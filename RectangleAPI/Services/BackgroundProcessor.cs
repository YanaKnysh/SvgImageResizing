using System.Collections.Concurrent;
using RectangleAPI.Interfaces;
using RectangleAPI.Models;

namespace RectangleAPI.Services;

public class BackgroundProcessor : IBackgroundProcessor
{
    private IWriter _writer;
    private int _numThreads = 1;
    
    BlockingCollection<Size> sizes = new();

    public BackgroundProcessor(IWriter writer)
    {
        _writer = writer;
        for (int i = 0; i < _numThreads; i++)
        {
            var thread = new Thread(OnHandlerStart)
                { IsBackground = true };
            thread.Start();
        }
    }
    
    public void Enqueue(Size size)
    {
        if (!sizes.IsAddingCompleted)
        {
            sizes.Add(size);
        }

        Console.WriteLine(sizes.Count);
    }
    
    public void Stop()
    {
        sizes.CompleteAdding();
    }
    
    private void OnHandlerStart()
    {
        foreach (var size in sizes.GetConsumingEnumerable(CancellationToken.None))
        {
            _writer.Write(size);
            Thread.Sleep(10);
        }
    }   
}