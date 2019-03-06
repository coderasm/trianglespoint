
using System;

namespace triangle_using_point
{
  class Program
  {
    static void Main(string[] args)
    {
      int[][] rightTriangleVertices = new int[3][] { new int[]{ 0, 0 }, new int[]{ 0, 1 }, new int[]{ 1, 0 } };
      var rightTriangle = new Triangle(rightTriangleVertices);
      int[][] obtuseTriangleVertices = new int[3][] { new int[] { 0, 0 }, new int[] { -1, 1 }, new int[] { 1, 0 } };
      var obtuseTriangle = new Triangle(obtuseTriangleVertices);
      int[][] acuteTriangleVertices = new int[3][] { new int[] { 0, 0 }, new int[] { 1, 3 }, new int[] { 3, 0 } };
      var acuteTriangle = new Triangle(acuteTriangleVertices);

      rightTriangle.TestIfTriangle();
      obtuseTriangle.TestIfTriangle();
      acuteTriangle.TestIfTriangle();
      Console.ReadKey();
    }
  }
}
