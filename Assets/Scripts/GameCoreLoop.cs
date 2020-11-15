using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCoreLoop : MonoBehaviour
{
    public static int RoundMoney;

    private static int roundMoneyUpd = 1000;
    public static int SabotageRoundCost = 0;

    [SerializeField]
    private Text roundMoneyTextUI;

    public SumoStatsDTO red = new SumoStatsDTO();
    public SumoStatsDTO blue = new SumoStatsDTO();
    // public static SumoStatsAreaController red;
    // public static SumoStatsAreaController blue;

    void Start()
    {
        GameEvents.current.onUpdateUI += UpdateUI;
        RoundMoneyUpdate();
        UpdateUI();
        SetStatsSumo();
    }

    private void RoundMoneyUpdate()
    {
        RoundMoney = roundMoneyUpd;
    }

    public void Confirm()
    {
        CountAllSabotageValue();
        GameEvents.current.UpdateUI();  
        
    }

    public void StartFight()
    {
        Fight();
        SetNewBets();
        SetStatsSumo();
        RoundMoney = 1000;
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

    public void SetNewBets()
    {
        Debug.Log("Матч изменился");
    }

    public void SetStatsSumo()
    {
        var sumosStats = StatsGenerator.GeneratePairSumo();

        red = sumosStats[0];

        blue = sumosStats[1];

        GameEvents.current.UpdateSumo();
    }

    private void Fight()
    {
        Debug.Log("red atack, blue = " + StatsLogicCounters.CountMawashiLost(red, blue, 20));
        Debug.Log("blue atack, red = " + StatsLogicCounters.CountMawashiLost(blue, red, 20));
        if(StatsLogicCounters.CountPower(red, 20) > StatsLogicCounters.CountPower(blue, 20))
        {
            
            Debug.Log("StatsLogicCounters.CountPower(red, 20) = " + StatsLogicCounters.CountPower(red, 20));
            Debug.Log("Победил красный");
        }
        else
        {
            
            Debug.Log("Победил синий");
        }
        
    }

    private void OnDestroy()
    {
        GameEvents.current.onUpdateUI -= UpdateUI;
    }
}
