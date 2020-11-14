using System.Collections.Generic;
using UnityEngine;

public class StatsGenerator
{
    public static int minState = 5;
    public static int maxState = 20;

    public static SumoStatsDTO GenerateSumo()
    {
        var newSumo = new SumoStatsDTO();

        newSumo.PhysicalState = Random.Range(minState, maxState);

        newSumo.Morale = Random.Range(minState, maxState);

        newSumo.Corruptibility = Random.Range(minState, maxState);

        newSumo.MawashiStr = Random.Range(minState, maxState);

        newSumo.Fortune = Random.Range(minState, maxState);

        return newSumo;
    }

    public static List<SumoStatsDTO> GeneratePairSumo()
    {
        var redSumo = new SumoStatsDTO();

        redSumo = GenerateSumo();

        var blueSumo = new SumoStatsDTO();

        blueSumo = GenerateSumo();

        if (StatsLogicCounters.CountPower(redSumo, maxState) > StatsLogicCounters.CountPower(blueSumo, maxState))
        {
            var temp = redSumo;
            redSumo = blueSumo;
            blueSumo = temp;
        }

        return new List<SumoStatsDTO>() { redSumo, blueSumo};
    }
}
