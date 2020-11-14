using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCoreLoop : MonoBehaviour
{
    public static int RoundMoney = 1000;

    [SerializeField]
    private Text roundMoneyTextUI;
    void Start()
    {
        UpdateUI();
    }

    public void Confirm()
    {
        GameEvents.current.UpdateUI("Poison");    
        UpdateUI();
    }

    private void UpdateUI()
    {
        roundMoneyTextUI.text = RoundMoney + " $";
    }
}
