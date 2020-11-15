using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsLogicCounters
{
    public static int CountPower(SumoStatsDTO sumoStats, int maxState)
    {
        var power = sumoStats.PhysicalState * sumoStats.Morale * (1 + sumoStats.Fortune / (2 * maxState));
        return power;
    }

    public static int CountMawashiLost(SumoStatsDTO sumoStatsAtk, SumoStatsDTO sumoStatsDef, int maxState)
    {
        var atkPower = (float)(sumoStatsAtk.PhysicalState * sumoStatsAtk.Morale)/(maxState^2);
        var defPower = (float)(sumoStatsDef.MawashiStr / maxState * (1 + sumoStatsDef.Fortune / (float)(2 * maxState)));
        return atkPower>=defPower ? 1 : 0;
    }
}
