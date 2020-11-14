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
        if(this.sabotageName == sabotageName)
        {
            sabotageUI.text = sabotageName + "\nDamage: " + damageType + " " 
                            + damageValue + "\nChance: " + chance + " %" + "\nCost: " + cost + " $";
        }
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

    private void OnDestroy()
    {
        GameEvents.current.onUpdateUI -=UpdateSabotageUI;
    }
}
