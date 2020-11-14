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

    public int sabotageValue = 0;

    [HideInInspector]
    public int sliderMaxValue;

    [HideInInspector]
    public int sabotageDamage;

    public Text sabotageUI;
    public Text sliderTextUI;
    public Slider slider;
    void Start()
    {
        GameEvents.current.onUpdateUI +=UpdateSabotageUI;
        GameEvents.current.onSabotageValue +=SabotageValue;
        sabotageUI.text = sabotageName + "\nDamage: " + damageType + " " 
                            + damageValue + "\nChance: " + chance + " %" + "\nCost: " + cost + " $";

        UpdateSliderMaxValue();

        
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

    public void UpdateSabotageUI(string sabotageName)
    {
        if(this.sabotageName == sabotageName)
        {
            sabotageUI.text = sabotageName + "\nDamage: " + damageType + " " 
                            + damageValue + "\nChance: " + chance + " %" + "\nCost: " + cost + " $";
        }
       
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

    private void OnDestroy()
    {
        GameEvents.current.onUpdateUI -=UpdateSabotageUI;
        GameEvents.current.onSabotageValue -=SabotageValue;
    }
}
