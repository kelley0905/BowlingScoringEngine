using BowlingScoringEngine.Business_Logic;
using BowlingScoringEngine.Models;
using BowlingScoringEngine.ViewModels;
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
            var model = new BowlingViewModel();
            model.NineFrames = frames;
            model.LastFrame = new TenthFrame { FirstScore = "0", SecondScore = "0", ThirdScore = "0" };
            //return View(frames);
            return View(model);
        }

        [HttpPost]
        public ActionResult ScoreMe(BowlingViewModel viewModel)
        {
            ScoringEngine.CalculateScore(viewModel.NineFrames, viewModel.LastFrame);
            TempData["frames"] = viewModel.NineFrames;
            return RedirectToAction("Index");
        }

    }
}