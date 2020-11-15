using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SumoStatsUI : MonoBehaviour
{
    [SerializeField]
    private GameObject sumoStatsUI;
    
    [SerializeField]
    private int UIId = 1;

    void Start()
    {
        GameEvents.current.onOpenUI += Show;
        GameEvents.current.onCloseUI += Hide;
        sumoStatsUI.SetActive(false);
    }

    public void Show(int UIId)
    {
        if(this.UIId == UIId)
        {
            if(sumoStatsUI.activeSelf)
            {
                sumoStatsUI.SetActive(false);
            }
            else
            {
                sumoStatsUI.SetActive(true);
            }
        }
    }

    public void Hide(int UIId)
    {
        if(this.UIId == UIId)
        {
            sumoStatsUI.SetActive(false);
        }
    }
    

    private void OnDestroy()
    {
        GameEvents.current.onOpenUI -= Show;
        GameEvents.current.onCloseUI -= Hide;
    }
}
