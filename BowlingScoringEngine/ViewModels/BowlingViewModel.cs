using BowlingScoringEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BowlingScoringEngine.ViewModels
{
    public class BowlingViewModel
    {
        public List<Frame> NineFrames { get; set; }
        public TenthFrame LastFrame { get; set; }
    }
}