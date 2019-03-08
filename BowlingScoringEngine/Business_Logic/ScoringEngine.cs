using BowlingScoringEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BowlingScoringEngine.Business_Logic
{
    public static class ScoringEngine
    {
        public static List<Frame> SetupFrames()
        {
            List<Frame> frames = new List<Frame>();
            for (int i = 0; i < 8; i++)
            {
                frames.Add(new Frame { FirstScore = "0", SecondScore = "0" });
            }
            frames.Add(new TenthFrame { FirstScore = "0", SecondScore = "0", ThirdScore = "0" });
            return frames;
        }

        public static void CalculateScore(IList<Frame> frames)
        {
            GetFormattedFrames(frames);
            for (int i = 0; i < frames.Count; i++)
            {
                var nextFrameIndex = i + 1;
                switch (frames[i].Status)
                {
                    case ScoreType.Strike:
                        frames[i].Total = 10; 
                        if (nextFrameIndex < frames.Count)
                        {
                            frames[i].Total += frames[i + 1].FirstScoreNumber;
                            frames[i].Total += frames[i + 1].SecondScoreNumber;
                        }
                        break;
                    case ScoreType.Spare:
                        frames[i].Total = 10;
                        if (nextFrameIndex < frames.Count)
                        {
                            frames[i].Total += frames[i + 1].FirstScoreNumber;
                        }
                        break;
                    case ScoreType.OpenFrame:
                        frames[i].Total = frames[i]?.FirstScoreNumber + frames[i]?.SecondScoreNumber;
                        break;
                    default:
                        frames[i].Total = 0;
                        break;
                }
                if (i != 0)
                {
                    frames[i].Total += frames[i - 1].Total;
                }
            }
        }

        private static void GetFormattedFrames(IList<Frame> frames)
        {
            foreach (var frame in frames)
            {
                //strikes
                if (frame.FirstScore.ToLower() == "x" || frame.FirstScore == "10")
                {
                    frame.FirstScoreNumber = 10;
                    frame.Status = ScoreType.Strike;
                }
                else
                {
                    frame.FirstScoreNumber = Convert.ToInt16(frame.FirstScore);
                    frame.Status = ScoreType.OpenFrame;
                }
                //spares
                if (frame.SecondScore == "/")
                {
                    frame.SecondScoreNumber = 10 - frame.FirstScoreNumber;
                    frame.Status = ScoreType.Spare;
                }
                else
                {
                    frame.SecondScoreNumber = Convert.ToInt16(frame.SecondScore);
                    if (frame.Status != ScoreType.Strike)
                    {
                        frame.Status = ScoreType.OpenFrame;
                        if (frame.FirstScoreNumber + frame.SecondScoreNumber == 10)
                        {
                            frame.Status = ScoreType.Spare;
                        }
                    }
                }
            }
        }
    }
}