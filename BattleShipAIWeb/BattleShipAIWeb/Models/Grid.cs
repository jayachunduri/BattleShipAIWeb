using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BattleShipAIWeb.Models
{
     public enum PlaceShipDirection
    {
        Horizontal = 1,
        Vertical = 2
    }

     class Grid
     {
         //properties
         public Point[,] Ocean { get; set; }
         public List<Ship> ListOfShips { get; set; }
         public bool AllShipsDestroyed
         {
             get
             {
                 return ListOfShips.All(x => x.IsDistroyed);
             }
         }
         //public int Score { get; set; }

         public Grid()
         {
             //initialize ocean
             Ocean = new Point[10, 10];
             ListOfShips = new List<Ship>();

             //loop to initialize all points
             for (int x = 0; x < 10; x++) //x coordinate
             {
                 for (int y = 0; y < 10; y++) //y coordinate
                 {
                     Ocean[x, y] = new Point(x, y, PointStatus.Empty);
                 }
             }


         }

         //method to place ships
         public void PlaceShip(Ship shipToPlace)
         {
             bool yesShip = false;
             int startx = 0, starty = 0;
             int direction = 0;

             //need to generate a set of x-coordinate and y-coordinate, so that they are valid
             while (!yesShip)
             {
                 Random rng = new Random();

                 //random coordinates
                 startx = rng.Next(0, 10);
                 starty = rng.Next(0, 10);

                 //random direction
                 direction = rng.Next(1, 3);
                 yesShip = CanPlaceShip(shipToPlace, (PlaceShipDirection)direction, startx, starty);
             }

             //make sure there is no ship in that part of ocean
             for (int i = 0; i < shipToPlace.length; i++)
             {
                 //change the status of that point in ocean (from empty) to ship
                 Ocean[startx, starty].status = PointStatus.Ship;
                 //add that point to ship's occupaid points
                 shipToPlace.occupiedPoint.Add(Ocean[startx, starty]);

                 if ((PlaceShipDirection)direction == PlaceShipDirection.Horizontal)
                 {
                     startx++;
                 }
                 else
                     starty++;
             }
             //add that ship to list of ships in the ocean
             ListOfShips.Add(shipToPlace);
         }

         //method to display grid to user
         public void DisplayOcean()
         {

             Console.ForegroundColor = ConsoleColor.White;
             Console.WriteLine("    0  1  2  3  4  5  6  7  8  9  X");
             Console.WriteLine("===================================");
             Console.ResetColor();

             //loop for y axis
             for (int y = 0; y < 10; y++)
             {
                 Console.ForegroundColor = ConsoleColor.White;
                 Console.Write("{0}||", y);
                 Console.ResetColor();

                 for (int x = 0; x < 10; x++)
                 {
                     if (Ocean[x, y].status == PointStatus.Empty || Ocean[x, y].status == PointStatus.Ship)
                     {
                         Console.ForegroundColor = ConsoleColor.Blue;
                         Console.Write("[ ]");
                         Console.ResetColor();
                     }
                     else if (Ocean[x, y].status == PointStatus.Hit)
                     {
                         Console.ForegroundColor = ConsoleColor.Red;
                         Console.Write("[X]");
                         Console.ResetColor();
                     }
                     else if (Ocean[x, y].status == PointStatus.Miss)
                     {
                         Console.ForegroundColor = ConsoleColor.Green;
                         Console.Write("[O]");
                         Console.ResetColor();
                     }
                 }
                 Console.ResetColor();
                 Console.WriteLine();
             }
             Console.ForegroundColor = ConsoleColor.White;
             Console.WriteLine("Y||");
             Console.ResetColor();
         }

         //determine the logic hits or misses
         public void Target(Point point, int score)
         {
             if (Ocean[point.x, point.y].status == PointStatus.Ship)
             {
                 Ocean[point.x, point.y].status = PointStatus.Hit;
                 point.status = PointStatus.Hit;
                 score += 100;
             }
             else if (Ocean[point.x, point.y].status == PointStatus.Empty)
             {
                 Ocean[point.x, point.y].status = PointStatus.Miss;
                 point.status = PointStatus.Miss;
                 score -= 10;
             }
         }



         //function returns TRUE if there is a ship in that part of ocean or reached end of ocean
         public bool CanPlaceShip(Ship shipToPlace, PlaceShipDirection direction, int startx, int starty)
         {
             //Make sure there is not already ship in that part of ocean
             //Also can't place a ship out of a ocean
             for (int i = 0; i < shipToPlace.length; i++)
             {
                 if (Ocean[startx, starty].status == PointStatus.Ship)
                     return false;

                 if (direction == PlaceShipDirection.Vertical)
                 {
                     starty++;
                     if (starty > 9)
                         return false;
                 }
                 else if (direction == PlaceShipDirection.Horizontal)
                 {
                     startx++;
                     if (startx > 9)
                         return false;
                 }

             }
             return true;

         }
     }
}