using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BattleShipAIWeb.Controllers
{
    public class PlayController : Controller
    {
        public ActionResult Index()
        {
            Models.Player player = new Models.Player("ajdk");
            Models.Computer comp = new Models.Computer();

            return View();
        }

        //public ActionResult PlayGame()
        //{
        //    return View(new Models.WebGame());
        //}

        private Models.Player _myGame;

        public Models.Player MyGame
        {
            get
            {
                if (Session["myGame"] == null)
                {
                    _myGame = new Models.Player("asdf");
                }
                return _myGame;
            }
            set { _myGame = value; }
        }
        

        //
        // GET: /Play/

       
        //public ActionResult Target(int x, int y)
        //{
        //    var player = (Models.Player)Session["game"];
        //    Models.Point point = new Models.Point(x, y, Models.PointStatus.Empty);
            
        //    player.ocean.Target(point, Models.Player.score);
        //    //update the game object
        //    Session["myGame"] = this.MyGame;
        //    return Content("O");
        //}

    }
}
