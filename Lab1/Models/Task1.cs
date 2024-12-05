using Lab1.Interfaces;

namespace Lab1.Models;

public class Task1 : ITask
{
    private const int SequenceNumber = 1;
    private const int Step = 10;
    private const int Start = 1;
    private readonly List<int> _numbers;

    public Task1(int length)
    {
        _numbers = new List<int>(length);
    }
    
    private void InputNumbers()
    {
        for (var i = 0; i < _numbers.Capacity; i++)
        {
            Console.Write($"Enter number {i + 1}: ");
            _numbers.Add(int.Parse(Console.ReadLine() ?? "0"));
        }
    }
    
    private void PrintAppropriateNumbers()
    {
        Console.WriteLine("Appropriate numbers:");
        foreach (var number in _numbers)
        {
            if (number is <= Step + SequenceNumber and >= Start)
            {
                Console.WriteLine(number);
            }
        }
    }

    public void Run()
    {
        InputNumbers();
        PrintAppropriateNumbers();
    }
}