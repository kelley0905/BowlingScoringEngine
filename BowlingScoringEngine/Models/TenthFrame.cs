using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BowlingScoringEngine.Models
{
    public class TenthFrame : Frame
    {
        [RegularExpression(@"[0-9]|/", ErrorMessage = "Please enter 0-9 or / for spare")]
        public string ThirdScore { get; set; }
        public int? ThirdScoreNumber { get; set; }
    }
}