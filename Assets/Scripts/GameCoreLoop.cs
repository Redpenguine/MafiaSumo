﻿using System.Collections;
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

    [SerializeField]
    private Text roundMessageUI;

    [SerializeField]
    private GameObject goodEndUI;

    [SerializeField]
    private GameObject badEndUI;

    [SerializeField]
    private GameObject storyUI;

    [SerializeField]
    private SoundManager SoundManager;

    private float redCoeff;

    public SumoStatsDTO red = new SumoStatsDTO();
    public SumoStatsDTO blue = new SumoStatsDTO();

    void Start()
    {
        Lives = 5;
        storyUI.SetActive(false);
        goodEndUI.SetActive(false);
        badEndUI.SetActive(false);
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
        if (Fight() == 0)
        {
            SoundManager.SetWinMusic();
            int goalCheck = bossMoney + (int)(bossBet * redCoeff);
            if (goalCheck >= BossMoneyGoal)
            {
                goodEndUI.SetActive(true);
                SoundManager.SetGoodEndMusic();
            }
            bossMoney += (int)(bossBet * redCoeff);
            UpdateBossMoneyUI();
        }
        else
        {
            SoundManager.SetLostMusic();
            Lives--;
            Debug.Log("Lives " + Lives);
            Debug.Log("redCoeff " + redCoeff + " bossBet * redCoeff" + bossBet * redCoeff);
            bossMoney -= bossBet;
            UpdateBossMoneyUI();
            if (Lives == 0)
            {
                SoundManager.SetBadEndMusic();
                Debug.Log("Die, finish game");
                badEndUI.SetActive(true);
            }
        }

        roundMessageUI.text = GetMessage();

        FinishFight();
        
    }

    private void FinishFight()
    {
        SetStatsSumo();
        GameEvents.current.UpdateAfterFight();
        RoundMoney = 1000;
        //GameEvents.current.UpdateUI();
    }

    private string GetMessage()
    {
        string message = "The fierce battle ends and the winner is...\n";

        string mawashiDown = StatsLogicCounters.CountMawashiLost(red, blue, 20) *
            StatsLogicCounters.CountMawashiLost(blue, red, 20) == 0 ? "ripping off the opponent's mawashi" : "";

        if (Fight() == 0)
        {
            message += $"Red sumo {mawashiDown}\n";
            message += "Boss wins and his trust in you grows (just like money)\n";
        }
        else
        {
            message += $"Blue sumo {mawashiDown}\n";
            message += "Boss lost and he is very angry \n";
            message += $"You are losing your finger, left {Lives} \n";
        }

        return message;
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
