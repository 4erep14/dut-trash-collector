using Lab1.Interfaces;

namespace Lab1.Models;

public class Task3 : ITask
{
    private const int Start = 10;
    private const int SequenceNumber = 1;
    
    private readonly List<int> _numbers;
    public Task3()
    {
        _numbers = new List<int>(Start + SequenceNumber);
        InputNumbers();
    }
    
    private void InputNumbers()
    {
        for (var i = 0; i < Start + SequenceNumber; i++)
        {
            Console.Write($"Enter number {i + 1}: ");
            _numbers.Add(int.Parse(Console.ReadLine() ?? "0"));
        }
    }

    private int GetMax()
    {
        return _numbers.Max();
    }

    private int GetMin()
    {
        return _numbers.Min();
    }

    public void Run()
    {
        Console.WriteLine($"Max: {GetMax()}");
        Console.WriteLine($"Min: {GetMin()}");
    }
}