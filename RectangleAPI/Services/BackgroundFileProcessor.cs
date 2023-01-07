using System.Collections.Concurrent;
using Newtonsoft.Json;
using RectangleAPI.Models;

namespace RectangleAPI.Services;

public class BackgroundFileWriter//BackgroundProcessor -  interface
{
    private static BackgroundFileWriter instance = null;
    private static readonly object padlock = new object();
    
    BlockingCollection<Size> sizes = new BlockingCollection<Size>();

    public static BackgroundFileWriter Instance
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new BackgroundFileWriter(1);
                }

                return instance;
            }
        }    
    }
    
    private BackgroundFileWriter(int numThreads)
    {
        for (int i = 0; i < numThreads; i++)
        {
            var thread = new Thread(OnHandlerStart)
                { IsBackground = true };//Mark 'false' if you want to prevent program exit until jobs finish
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
        //This will cause '_jobs.GetConsumingEnumerable' to stop blocking and exit when it's empty
        sizes.CompleteAdding();
    }
    
    private void OnHandlerStart()
    {
        foreach (var size in sizes.GetConsumingEnumerable(CancellationToken.None))
        {
            string fileName = Path.GetFullPath(Directory.GetCurrentDirectory() + @"\Data/currentSize.json");
            using (StreamReader file = System.IO.File.OpenText(fileName))
            {
                dynamic jsonObj = JsonConvert.DeserializeObject(file.ReadToEnd()) ?? throw new InvalidOperationException();
                file.Close();
                jsonObj["height"] = size.Height;
                jsonObj["width"] = size.Width;
                string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                System.IO.File.WriteAllText(fileName, output);
            }
            Thread.Sleep(10);
        }
    }
}