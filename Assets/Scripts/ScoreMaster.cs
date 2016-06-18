using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreMaster
{
    public static List<int> ScoreCumultative (List<int> rolls)
    {
        // returns a list of cumulative scores like a normal score card
        List<int> cumulativeScores = new List<int>();
        int runningTotal = 0;

        foreach (int frameScore in ScoreFrames(rolls))
        {
            runningTotal += frameScore;
            cumulativeScores.Add(runningTotal);
        }

        return cumulativeScores;

    }
    public static List<int> ScoreFrames (List<int> rolls)
    {
        // reutrns a list of individual frames scores; not cumulative

        List<int> frameList = new List<int>();



        return frameList;
    }
}