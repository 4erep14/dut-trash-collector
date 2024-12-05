using Lab1.Interfaces;
using Lab1.Models;

namespace Lab1;

internal static class Program
{
    static void Main(string[] args)
    {
        ITask task1 = new Task1(3);
        ITask task2 = new Task2(3, 4, 5);
        ITask task3 = new Task3();
        ITask task4 = new Task4(3);
        
        ITask[] baseTasks = [task1, task2, task3, task4];
        
        foreach (var task in baseTasks)
        {
            task.Run();
        }
    }
}