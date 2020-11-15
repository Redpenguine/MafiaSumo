using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCoreLoop : MonoBehaviour
{
    public static int RoundMoney;
    public static int Lives = 5;
    public static int SabotageRoundCost = 0;

    public int bossMoney = 1000000000;
    public int BossMoneyGoal = 2000000000;
    public int bossBet = 100000000;

    [SerializeField]
    private int roundMoneyUpd = 1000;
    

    [SerializeField]
    private Text roundMoneyTextUI;

    [SerializeField]
    private Slider slider;

    [SerializeField]
    private Text monetTextUI;

    private float redCoeff;

    public SumoStatsDTO red = new SumoStatsDTO();
    public SumoStatsDTO blue = new SumoStatsDTO();

    void Start()
    {
        redCoeff = FindObjectOfType<BetsUI>().redCoeff;
        GameEvents.current.onUpdateUI += UpdateUI;
        RoundMoneyUpdate();
        UpdateUI();
        SetStatsSumo();
        UpdateBossMoneyUI();
    }

    private void UpdateBossMoneyUI()
    {
        slider.maxValue = BossMoneyGoal;
        slider.value = bossMoney;
        monetTextUI.text = bossMoney + "$";
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
        if(Fight() == 0)
        {
            int goalCheck = bossMoney + (int)(bossBet * redCoeff);
            if(goalCheck >= BossMoneyGoal)
            {
                Debug.Log("Boss win");
            }
           bossMoney += (int)(bossBet * redCoeff);
           UpdateBossMoneyUI(); 
        }
        else 
        {
           Lives --;
           Debug.Log("Lives " + Lives);
           Debug.Log("redCoeff " + redCoeff + " bossBet * redCoeff" + bossBet * redCoeff);
           bossMoney -= bossBet;
           UpdateBossMoneyUI();
           if(Lives == 0)
           {
               Debug.Log("Die, finish game");
           }
        }
        FinishFight();
        
    }

    private void FinishFight()
    {
        SetStatsSumo();
        GameEvents.current.UpdateAfterFight();
        RoundMoney = 1000;
        //GameEvents.current.UpdateUI();
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

        GameEvents.current.UpdateSumo();
    }

    private int Fight()
    {
        Debug.Log("red atack, blue = " + StatsLogicCounters.CountMawashiLost(red, blue, 20));
        Debug.Log("blue atack, red = " + StatsLogicCounters.CountMawashiLost(blue, red, 20));
        if(StatsLogicCounters.CountWiner(red, blue) == 0)
        {
            Debug.Log("StatsLogicCounters.CountPower(red, 20) = " + StatsLogicCounters.CountPower(red, 20));
            Debug.Log("Победил красный");
            return 0;
        }
        else
        {
            Debug.Log("Победил синий");
            return 1;
            
        }
        
    }

    private void OnDestroy()
    {
        GameEvents.current.onUpdateUI -= UpdateUI;
    }
}
