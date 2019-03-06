using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace triangle_using_point
{
  class Program
  {
    static void Main(string[] args)
    {
      var pointOne = new Point();
      var pointTwo = new Point();
      var pointThree = new Point();
      string[] places = {"first", "second", "third"};
      const int NUM_OF_POINTS = 3;
      double sideOne = 0;
      double sideTwo = 0;
      double sideThree = 0;

      for (int i = 0; i < NUM_OF_POINTS; i++)
      {
        int[] point = { 0, 0 };
        var parsedOrdinate = false;
        var parsedCoordinate = false;
        do
        {
          Console.Write($"Enter {places[i]} point: ");
          var entry = Console.ReadLine();
          var coordinates = entry.Split(',');
          parsedOrdinate = Int32.TryParse(coordinates[0].Trim(' '), out point[0]);
          parsedCoordinate = Int32.TryParse(coordinates[1].Trim(' '), out point[1]);
        } while (!parsedCoordinate || !parsedOrdinate);
        if (i == 0)
          pointOne.setPoint(point[0], point[1]);
        if (i == 1)
          pointTwo.setPoint(point[0], point[1]);
        if (i == 2)
          pointThree.setPoint(point[0], point[1]);
      }

      sideOne = Math.Abs(pointOne.dist(pointTwo));
      sideTwo = Math.Abs(pointOne.dist(pointThree));
      sideThree = Math.Abs(pointThree.dist(pointTwo));
    }
  }
}
