﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[System.Serializable]
public class SabotageBlueprint : MonoBehaviour
{
   
    public string sabotageName;
    public SabotagePattern.DamageType damageState;
    public string damageType;
    public int damageValue;
    public int chance;
    public int cost;

    public int sabotageValue = 0;

    [HideInInspector]
    public int sliderMaxValue;

    [HideInInspector]
    public int sabotageDamage;

    private SumoStatsDTO red;
    private SumoStatsDTO blue;

    public Text sabotageUI;
    public Text sliderTextUI;
    public Slider slider;
    void Start()
    {
        DamageType();
        red = FindObjectOfType<GameCoreLoop>().red;
        blue = FindObjectOfType<GameCoreLoop>().blue;
        GameEvents.current.onUpdateUI +=UpdateSabotageUI;
        GameEvents.current.onSabotageValue +=SabotageValue;
        UpdateSabotageUI();
        
    }

    private void DamageType()
    {
        switch(damageState)
        {
            case SabotagePattern.DamageType.Phisical:
            damageType = "Phisical";
            break;
            case SabotagePattern.DamageType.Moral:
            damageType = "Moral";
            break;
            case SabotagePattern.DamageType.Corruptibility:
            damageType = "Corruptibility";
            break;
            case SabotagePattern.DamageType.Mavashi:
            damageType = "Mavashi";
            break;
            case SabotagePattern.DamageType.Fortune:
            damageType = "Fortune";
            break;
        }
    }

    private void UpdateSetChanceBySumo()
    {
        if(SabotageUI.currentSumo == 0)
        {
            SetChanceBySumo(red);
        }
        else if(SabotageUI.currentSumo == 1)
        {
            SetChanceBySumo(blue);
        }
    }

    public void SabotageValue()
    {
        GameCoreLoop.SabotageRoundCost += sabotageValue;
    }

    public void SliderValueChange()
    {
        sabotageValue = (int)(slider.value*cost);
        sliderTextUI.text = sabotageValue.ToString() + " $";
    }

    public void UpdateSabotageUI()
    {
        UpdateSliderMaxValue();
        UpdateSetChanceBySumo();
        slider.value = 0;
            sabotageUI.text = sabotageName + "\nDamage: " + damageType + " " 
                            + damageValue + "\nChance: " + chance + " %" + "\nCost: " + cost + " $";
        
       
       
    }

    public void UpdateSliderMaxValue()
    {
        slider.maxValue = GameCoreLoop.RoundMoney/cost;
    }

    
    private void RoundMoneyChange()
    {
        int difference = GameCoreLoop.RoundMoney - (int)(slider.value*cost);
        if(difference >= 0)
            GameCoreLoop.RoundMoney = difference;
    }

    public void SetChanceBySumo(SumoStatsDTO sumoStats)
    {
        
        switch (sabotageName)
        {
            case SabotageConstants.Poison:
                chance = (int)(((StatsGenerator.maxState - sumoStats.PhysicalState)/(float)StatsGenerator.maxState) * 100f);
                break;
            case SabotageConstants.Fight:
                chance = (int)(((StatsGenerator.maxState - sumoStats.PhysicalState)/(float)StatsGenerator.maxState) * 100f);
                break;
            case SabotageConstants.DamageMawashi:
                chance = (int)(((StatsGenerator.maxState - sumoStats.MawashiStr)/(float)StatsGenerator.maxState) * 100f);
                break;
            case SabotageConstants.Curse:
                chance = (int)(((StatsGenerator.maxState - sumoStats.Fortune)/(float)StatsGenerator.maxState) * 100f);
                break;
            case SabotageConstants.Intimidation:
                chance = (int)(((StatsGenerator.maxState - sumoStats.Morale)/(float)StatsGenerator.maxState) * 100f);
                break;
            case SabotageConstants.Bribe:
                chance = (int)(((StatsGenerator.maxState - sumoStats.Corruptibility)/(float)StatsGenerator.maxState) * 100f);
                break;
            default:
                throw new Exception("No such sabotage name in list!");
        } 
    }

    public void DamageByType(SumoStatsDTO sumoStats)
    {
        
        switch (sabotageName)
        {
            case SabotageConstants.Poison:
                chance = (int)(((StatsGenerator.maxState - sumoStats.PhysicalState)/(float)StatsGenerator.maxState) * 100f);
                break;
            case SabotageConstants.Fight:
                chance = (int)(((StatsGenerator.maxState - sumoStats.PhysicalState)/(float)StatsGenerator.maxState) * 100f);
                break;
            case SabotageConstants.DamageMawashi:
                chance = (int)(((StatsGenerator.maxState - sumoStats.MawashiStr)/(float)StatsGenerator.maxState) * 100f);
                break;
            case SabotageConstants.Curse:
                chance = (int)(((StatsGenerator.maxState - sumoStats.Fortune)/(float)StatsGenerator.maxState) * 100f);
                break;
            case SabotageConstants.Intimidation:
                chance = (int)(((StatsGenerator.maxState - sumoStats.Morale)/(float)StatsGenerator.maxState) * 100f);
                break;
            case SabotageConstants.Bribe:
                chance = (int)(((StatsGenerator.maxState - sumoStats.Corruptibility)/(float)StatsGenerator.maxState) * 100f);
                break;
            default:
                throw new Exception("No such sabotage name in list!");
        } 
    }

    private void OnDestroy()
    {
        GameEvents.current.onUpdateUI -=UpdateSabotageUI;
        GameEvents.current.onSabotageValue -=SabotageValue;
    }
}
