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
    public void OpenUI(int id)
    {
        onOpenUI?.Invoke(id);
    }

    public event Action<int> onCloseUI;
    public void CloseUI(int id)
    {
        onCloseUI?.Invoke(id);
    }



    
}
