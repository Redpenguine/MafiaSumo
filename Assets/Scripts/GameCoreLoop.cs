using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCoreLoop : MonoBehaviour
{
    public static int RoundMoney = 1000;
    public static int SabotageRoundCost = 0;

    [SerializeField]
    private Text roundMoneyTextUI;

    public SumoStatsDTO red = new SumoStatsDTO();
    public SumoStatsDTO blue = new SumoStatsDTO();
    // public static SumoStatsAreaController red;
    // public static SumoStatsAreaController blue;

    void Start()
    {
        UpdateUI();
        SetStatsSumo();
    }

    public void Confirm()
    {
        CountAllSabotageValue();
        GameEvents.current.UpdateUI("Poison");  
        GameEvents.current.UpdateUI("Beat"); 
        GameEvents.current.UpdateUI("Intimidate"); 
        GameEvents.current.UpdateUI("Curse"); 
        GameEvents.current.UpdateUI("Bribe"); 
        GameEvents.current.UpdateUI("Prune mawashi");  
        
        UpdateUI();
    }

    private void UpdateUI()
    {
        roundMoneyTextUI.text = RoundMoney + " $";
    }

    private void CountAllSabotageValue()
    {
        GameEvents.current.SabotageValue();
        int def = RoundMoney - SabotageRoundCost;
        if(def >= 0)
        {
            RoundMoney = def;
            
        }
        SabotageRoundCost = 0;

    }

    public void SetStatsSumo()
    {
        var sumosStats = StatsGenerator.GeneratePairSumo();

        red = sumosStats[0];

        blue = sumosStats[1];
    }
}
