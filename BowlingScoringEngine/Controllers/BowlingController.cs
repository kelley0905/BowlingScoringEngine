using BowlingScoringEngine.Business_Logic;
using BowlingScoringEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BowlingScoringEngine.Controllers
{
    public class BowlingController : Controller
    {
        // GET: Bowling
        [HttpGet]
        public ActionResult Index()
        {
            var model = TempData["frames"] as IList<Frame>;
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(IList<Frame> frames)
        {
            return RedirectToAction("ScoreMe");
        }

        [HttpGet]
        public ActionResult ScoreMe()
        {
            List<Frame> frames = ScoringEngine.SetupFrames();

            return View(frames);
        }

        [HttpPost]
        public ActionResult ScoreMe(IList<Frame> frames)
        {
            ScoringEngine.CalculateScore(frames);
            TempData["frames"] = frames;
            return RedirectToAction("Index");
        }

    }
}