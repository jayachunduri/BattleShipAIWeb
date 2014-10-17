using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BattleShipAIWeb.Models
{
    public class WebGame
    {
        public Models.Player player{get; set;}
        public Models.Computer comp{ get; set;}

        public WebGame(Models.Player player, Models.Computer comp)
        {
            this.player = player;
            this.comp = comp;
        }

        //Function for game logic
        //
    }
}