using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[System.Serializable]
public class SabotageBlueprint : MonoBehaviour
{
    public string sabotageName;
    public string damageType;
    public int damageValue;
    public int chance;
    public int cost;

    [HideInInspector]
    public int sliderMaxValue;

    public Text sabotageUI;
    public Text sliderTextUI;
    public Slider slider;
    void Start()
    {
        GameEvents.current.onUpdateUI +=UpdateSabotageUI;
        sabotageUI.text = sabotageName + "\nDamage: " + damageType + " " 
                            + damageValue + "\nChance: " + chance + " %" + "\nCost: " + cost + " $";

        UpdateSliderMaxValue();

        
    }

    public void SliderValueChange()
    {
        sliderTextUI.text = (slider.value*cost).ToString() + " $";
    }

    public void UpdateSabotageUI(string sabotageName)
    {
        //if(this.sabotageName == sabotageName)
        //{
            sabotageUI.text = sabotageName + "\nDamage: " + damageType + " " 
                            + damageValue + "\nChance: " + chance + " %" + "\nCost: " + cost + " $";
        //}
       RoundMoneyChange();
       UpdateSliderMaxValue();
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
                chance = sumoStats.PhysicalState / StatsGenerator.maxState * 100;
                break;
            case SabotageConstants.Fight:
                chance = sumoStats.PhysicalState / StatsGenerator.maxState * 100;
                break;
            case SabotageConstants.DamageMawashi:
                chance = sumoStats.MawashiStr / StatsGenerator.maxState * 100;
                break;
            case SabotageConstants.Curse:
                chance = sumoStats.Fortune / StatsGenerator.maxState * 100;
                break;
            case SabotageConstants.Intimidation:
                chance = sumoStats.Morale / StatsGenerator.maxState * 100;
                break;
            case SabotageConstants.Bribe:
                chance = sumoStats.Corruptibility / StatsGenerator.maxState * 100;
                break;
            default:
                throw new Exception("No such sabotage name in list!");
        }

        UpdateSabotageUI(sabotageName);
    }

    private void OnDestroy()
    {
        GameEvents.current.onUpdateUI -=UpdateSabotageUI;
    }
}
