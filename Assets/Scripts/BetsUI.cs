using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetsUI : MonoBehaviour
{
    [SerializeField]
    private GameObject betsUI;
    
    [SerializeField]
    private int UIId = 0;

    void Start()
    {
        GameEvents.current.onOpenUI += Show;
        GameEvents.current.onCloseUI += Hide;
        betsUI.SetActive(false);
    }

    public void Show(int UIId)
    {
        if(this.UIId == UIId)
        {
            betsUI.SetActive(true);
        }
    }

    public void Hide(int UIId)
    {
        if(this.UIId == UIId)
        {
            betsUI.SetActive(false);
        }
    }
    

    private void OnDestroy()
    {
        GameEvents.current.onOpenUI -= Show;
        GameEvents.current.onCloseUI -= Hide;
    }
}
