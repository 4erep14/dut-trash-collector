using Lab1.Interfaces;

namespace Lab1.Models;

public class Task2 : ITask
{
    private const double Tolerance = 0.01;
    private readonly double _fistSide;
    private readonly double _secondSide;
    private readonly double _thirdSide;

    public Task2(int fistSide, int secondSide, int thirdSide)
    {
        _fistSide = fistSide;
        _secondSide = secondSide;
        _thirdSide = thirdSide;
        ValidateTriangle();
    }

    private double CalculatePerimeter()
    {
        return _fistSide + _secondSide + _thirdSide;
    }

    private double CalculateArea()
    {
        var halfPerimeter = CalculatePerimeter() / 2;
        return Math.Sqrt(halfPerimeter * (halfPerimeter - _fistSide) * (halfPerimeter - _secondSide) * (halfPerimeter - _thirdSide));
    }

    private string DetermineTriangleType()
    {
        if (IsEquilateral())
        {
            return "Equilateral";
        }

        if (IsIsosceles())
        {
            return "Isosceles";
        }

        return "Versatile";
    }

    private bool IsIsosceles()
    {
        return Math.Abs(_fistSide - _secondSide) < Tolerance || Math.Abs(_secondSide - _thirdSide) < Tolerance || Math.Abs(_fistSide - _thirdSide) < Tolerance;
    }

    private bool IsEquilateral()
    {
        return Math.Abs(_fistSide - _secondSide) < Tolerance && Math.Abs(_secondSide - _thirdSide) < Tolerance;
    }

    private void ValidateTriangle()
    {
        if (_fistSide + _secondSide <= _thirdSide ||
            _fistSide + _thirdSide <= _secondSide ||
            _secondSide + _thirdSide <= _fistSide)
        {
            throw new ArgumentException("Triangle with such sides does not exist");
        }
    }

    public void Run()
    {
        Console.WriteLine($"Perimeter: {CalculatePerimeter()}");
        Console.WriteLine($"Area: {CalculateArea()}");
        Console.WriteLine($"Type: {DetermineTriangleType()}");
    }
}