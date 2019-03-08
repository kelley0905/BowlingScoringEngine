using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BowlingScoringEngine.Models
{
    public class Frame
    {
        [RegularExpression("[0-9]|x|X",ErrorMessage = "Please enter 0-9 or X for strike")]
        public string FirstScore { get; set; }
        public int? FirstScoreNumber { get; set; }
        [RegularExpression("[0-9]|/", ErrorMessage = "Please enter 0-9 or / for spare")]
        public string SecondScore { get; set; }
        public int? SecondScoreNumber { get; set; }
        public ScoreType? Status { get; set; }
        public int? Total { get; set; }
    }
}