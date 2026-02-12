using System.Collections.Concurrent;
Queue<string> insertCommands = new Queue<string>();
ConcurrentQueue<string> removeCommands = new ConcurrentQueue<string>();


void AddToQueue(string command)
{
    insertCommands.Enqueue(command);
}


void OnlyReadQueueValue()
{
    if (insertCommands.Count > 0)
    {
        string first = insertCommands.Peek();
        Console.WriteLine(first);

    }
}

void ReadQueue()
{
    if (insertCommands.Count > 0)
    {
        string first = insertCommands.Dequeue();
        Console.WriteLine(first);
    }
}

void AddToConcurrentQueue(string command)
{
    removeCommands.Enqueue(command);
}
void OnlyReadConcurrent()
{
    if (removeCommands.Count > 0)
    {
        removeCommands.TryPeek(out string value);
        Console.WriteLine(value);
    }
}
void ReadConcurrent()
{
    if (removeCommands.Count > 0)
    {
        removeCommands.TryDequeue(out string value);
        Console.WriteLine(value);
    }
}
AddToQueue("Insert_1");
AddToQueue("Insert_2");
AddToConcurrentQueue("cos");
ReadConcurrent();
OnlyReadQueueValue();
ReadQueue();
ReadQueue();
ReadConcurrent();


Console.ReadLine();