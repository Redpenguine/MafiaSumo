using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SabotageUI : MonoBehaviour
{
    [SerializeField]
    private GameObject sabotageUI;

    [SerializeField]
    private int UIId = 2;

    void Start()
    {
        GameEvents.current.onOpenUI += Show;
        GameEvents.current.onCloseUI += Hide;
        sabotageUI.SetActive(false);
    }

    public void Show(int UIId)
    {
        if(this.UIId == UIId)
        {
            sabotageUI.SetActive(true);
        }
    }

    public void Hide(int UIId)
    {
        if(this.UIId == UIId)
        {
            sabotageUI.SetActive(false);
        }
    }
    

    private void OnDestroy()
    {
        GameEvents.current.onOpenUI -= Show;
        GameEvents.current.onCloseUI -= Hide;
    }
}
