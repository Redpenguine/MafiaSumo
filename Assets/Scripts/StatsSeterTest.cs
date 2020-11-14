using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsSeterTest : MonoBehaviour
{
    public SumoStatsAreaController red;
    public SumoStatsAreaController blue;

    void Start()
    {
        
    }


    public void SetStats()
    {
        var sumosStats = StatsGenerator.GeneratePairSumo();

        red.SetNewSumo(sumosStats[0]);

        blue.SetNewSumo(sumosStats[1]);
    }
}
