using System;
using Microsoft.AspNetCore.Mvc;
using RectangleChecker.Models;
using System.Collections.Generic;

namespace RectangleChecker.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet("/")]
        public ActionResult Index()
        {
            return View("RectangleForm");
        }

        [HttpGet("/rectangle_result")]
        public ActionResult Result()
        {
            Dictionary<string, object> Shapes = new Dictionary<string, object>();
            Rectangle myRectangle = new Rectangle(Int32.Parse(Request.Query["side-length"]), Int32.Parse(Request.Query["side-width"]));
            Shapes.Add("ResultingRectangle", myRectangle);
            if (myRectangle.IsSquare())
            {
              Cube myCube = new Cube(myRectangle);
              Shapes.Add("ResultingCube", myCube);
            }
            return View("RectangleResult", Shapes);
        }

    }
}
