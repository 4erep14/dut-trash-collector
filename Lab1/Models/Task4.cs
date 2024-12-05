using Lab1.Interfaces;

namespace Lab1.Models;

public class Task4 : ITask
{
    private const int Start = 10;
    private const int SequenceNumber = 1;
    private readonly int _m;
    
    private readonly List<int> _numbers;
    public Task4(int m)
    {
        _m = m;
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

    private IEnumerable<int> GetOnlyBiggerThenMByModule()
    {
        return _numbers.Where(number => Math.Abs(number) > _m);
    }

    public void Run()
    {
        var numbers = GetOnlyBiggerThenMByModule();
        Console.WriteLine("Numbers bigger then m by module:");
        foreach (var number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}