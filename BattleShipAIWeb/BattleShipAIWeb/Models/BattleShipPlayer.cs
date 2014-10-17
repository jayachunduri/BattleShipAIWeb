using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BattleShipAIWeb.Models
{
    abstract class BattleShipPlayer
    {
        //properties
        public string name;
        public int score;
        public Point point;
        public List<Point> pointsHit;
        public Grid ocean;
        public List<Ship> ships;

        //Constructors
        public BattleShipPlayer()
        {
            score = 100;
            pointsHit = new List<Point>();
            this.point = new Point();
            this.ocean = new Grid();
            this.ships = new List<Ship>() {
            new Ship(ShipType.Battleship),
            new Ship(ShipType.Carrier),
            new Ship(ShipType.Cruiser),
            new Ship(ShipType.Minesweeper),
            new Ship(ShipType.Submarine)
            };

            foreach (var ship in ships)
            {
                this.ocean.PlaceShip(ship);
            }

        }

        public BattleShipPlayer(string name)
        {
            score = 100;
            pointsHit = new List<Point>();
            this.name = name;
            this.point = new Point();
            this.ocean = new Grid();
            this.ships = new List<Ship>() {
            new Ship(ShipType.Battleship),
            new Ship(ShipType.Carrier),
            new Ship(ShipType.Cruiser),
            new Ship(ShipType.Minesweeper),
            new Ship(ShipType.Submarine)
            };

            foreach (var ship in ships)
            {
                this.ocean.PlaceShip(ship);
            }
        }

        //memebers
        public abstract void GenerateCoordinates();
        public abstract bool GoodCoordinates();
    }
}