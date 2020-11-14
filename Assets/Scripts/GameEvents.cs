using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }

    public event Action<int> onOpenUI;
    public void OpenUI(int UIid)
    {
        onOpenUI?.Invoke(UIid);
    }

    public event Action<int> onCloseUI;
    public void CloseUI(int UIid)
    {
        onCloseUI?.Invoke(UIid);
    }

    public event Action<string> onUpdateUI;
    public void UpdateUI(string UIname)
    {
        onUpdateUI?.Invoke(UIname);
    }

    public event Action onSabotageValue;
    public void SabotageValue()
    {
        onSabotageValue?.Invoke();
    }



    
}
