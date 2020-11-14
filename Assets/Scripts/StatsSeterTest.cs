using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsSeterTest : MonoBehaviour
{
    public SumoStatsAreaController red;
    public SumoStatsAreaController blue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetStats()
    {
        var sumosStats = StatsGenerator.GeneratePairSumo();

        red.SetNewSumo(sumosStats[0]);

        blue.SetNewSumo(sumosStats[1]);
    }
}
