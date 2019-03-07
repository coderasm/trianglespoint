using System;
using System.Linq;

namespace triangle_using_point
{
  class Triangle
  {
    private Point PointOne { get; set; } = new Point();
    private Point PointTwo { get; set; } = new Point();
    private Point PointThree { get; set; } = new Point();
    private double SideOne { get; set; } = 0;
    private double SideTwo { get; set; } = 0;
    private double SideThree { get; set; } = 0;
    private double AngleOne { get; set; } = 0;
    private double AngleTwo { get; set; } = 0;
    private double AngleThree { get; set; } = 0;
    private double[] SortedSides { get; set; } = { 0, 0, 0};

    public Triangle()
    {

    }
    public Triangle(int[][] points)
    {
      if (points.Length == 3)
      {
        setPoints(points);
      }
    }

    public void setPoints(int[][] points)
    {
      if (points.Length == 3)
      {
        for (int i = 0; i < points.Length; i++)
        {
          //Set point
          if (i == 0 && points[0].Length == 2)
            PointOne.setPoint(points[0][0], points[0][1]);
          if (i == 1 && points[1].Length == 2)
            PointTwo.setPoint(points[1][0], points[1][1]);
          if (i == 2 && points[2].Length == 2)
            PointThree.setPoint(points[2][0], points[2][1]);
        }
        setSides();
        SetSortedSides();
        setAngles();
      }
    }

    private void setSides()
    {
      SideOne = Math.Abs(PointOne.dist(PointTwo));
      SideTwo = Math.Abs(PointOne.dist(PointThree));
      SideThree = Math.Abs(PointThree.dist(PointTwo));
    }

    private void SetSortedSides()
    {
      double[] sideLengths = { SideOne, SideTwo, SideThree };
      Array.Sort(sideLengths);
      SortedSides = sideLengths;
    }

    private void setAngles()
    {
      //Using law of cosines
      AngleOne = Math.Round(Math.Acos((Math.Pow(SideOne, 2) + Math.Pow(SideTwo, 2) - Math.Pow(SideThree, 2)) / (2 * SideOne * SideTwo)) * (180 / Math.PI));
      AngleTwo = Math.Round(Math.Acos((Math.Pow(SideOne, 2) + Math.Pow(SideThree, 2) - Math.Pow(SideTwo, 2)) / (2 * SideOne * SideThree)) * (180 / Math.PI));
      AngleThree = Math.Round(Math.Acos((Math.Pow(SideTwo, 2) + Math.Pow(SideThree, 2) - Math.Pow(SideOne, 2)) / (2 * SideTwo * SideThree)) * (180 / Math.PI));
    }

    public void TestIfTriangle()
    {
      Console.Write($"Triangle: ");
      PointOne.print();
      PointTwo.print();
      PointThree.print();
      Console.WriteLine();
      //Test if triangle
      if (!isTriangle())
      {
        Console.WriteLine("Not a triangle.");
        return;
      }
      //Test if right triangle
      if (isRightTriangle())
      {
        Console.WriteLine("Is a right triangle.");
      }
      //Test if acute triangle
      if (isAcute())
      {
        Console.WriteLine("Is an acute triangle.");
      }
      //Test if acute triangle
      if (isObtuse())
      {
        Console.WriteLine("Is an obtuse triangle.");
      }
      //Test if isosceles triangle
      if (isIsosceles())
      {
        Console.WriteLine("Is an isosceles triangle.");
      }
      //Test if equilateral triangle
      if (isEquilateral())
      {
        Console.WriteLine("Is an equilateral triangle.");
      }
    }

    private bool isTriangle()
    {
      return (SideOne + SideTwo > SideThree &&
        SideOne + SideThree > SideTwo &&
        SideTwo + SideThree > SideOne) ||
        (AngleOne + AngleTwo + AngleThree == 180);
    }

    private bool isRightTriangle()
    {
      return AngleOne == 90 || AngleTwo == 90 || AngleThree == 90 ||
        Math.Round(Math.Pow(SortedSides[2], 2)) == Math.Round(Math.Pow(SortedSides[0], 2) + Math.Pow(SortedSides[1], 2));
    }

    private bool isAcute()
    {
      return (AngleOne < 90 && AngleTwo < 90 && AngleThree < 90) ||
        Math.Round(Math.Pow(SortedSides[2], 2)) < Math.Round(Math.Pow(SortedSides[0], 2) + Math.Pow(SortedSides[1], 2));
    }

    private bool isObtuse()
    {
      return AngleOne > 90 || AngleTwo > 90 || AngleThree > 90 ||
        Math.Round(Math.Pow(SortedSides[2], 2)) > Math.Round(Math.Pow(SortedSides[0], 2) + Math.Pow(SortedSides[1], 2));
    }

    private bool isIsosceles()
    {
      return AngleOne == AngleTwo ||
        AngleOne == AngleThree ||
        AngleTwo == AngleThree ||
        SideOne == SideTwo ||
        SideOne == SideThree ||
        SideTwo == SideThree;
    }

    private bool isEquilateral()
    {
      return (AngleOne == AngleTwo &&
        AngleOne == AngleThree &&
        AngleTwo == AngleThree) ||
        (SideOne == SideTwo &&
        SideOne == SideThree &&
        SideTwo == SideThree);
    }
  }
}
