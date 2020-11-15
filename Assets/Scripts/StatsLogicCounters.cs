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
        var atkPower = (float)(sumoStatsAtk.PhysicalState * sumoStatsAtk.Morale)/(maxState * maxState);
        var defPower = (float) sumoStatsDef.MawashiStr / maxState * (1 + sumoStatsDef.Fortune / (2 * maxState));
        return atkPower>=defPower ? 0 : 1;
    }

    public static int CountWiner(SumoStatsDTO sumoStatsRed, SumoStatsDTO sumoStatsBlue)
    {
        if (sumoStatsRed.Corruptibility == 0) // продался
        {
            return 1; // второй победил
        }

        if (sumoStatsBlue.Corruptibility == 0) // продался
        {
            return 0; // первый победил
        }

        var redPower = CountPower(sumoStatsRed, StatsGenerator.maxState) * CountMawashiLost(sumoStatsBlue, sumoStatsRed, StatsGenerator.maxState);
        var bluePower = CountPower(sumoStatsBlue, StatsGenerator.maxState) * CountMawashiLost(sumoStatsRed, sumoStatsBlue, StatsGenerator.maxState);

        if (redPower > bluePower)
        {
            return 0;
        }
        else if (redPower < bluePower)
        {
            return 1;
        }
        else // если равны
        {
            var winer = sumoStatsRed.Fortune > sumoStatsBlue.Fortune ? 0 : 1;
            return winer;
        }
    }
}
