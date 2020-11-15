using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SabotageUI : MonoBehaviour
{
    [SerializeField]
    private GameObject sabotageUI;

    [SerializeField]
    private GameObject head;

    [SerializeField]
    private int UIId = 2;

    public static int currentSumo;

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
            if(sabotageUI.activeSelf)
            {
                sabotageUI.SetActive(false);
            }
            else
            {
                sabotageUI.SetActive(true);
            }
        }
    }

    public void Hide(int UIId)
    {
        if(this.UIId == UIId)
        {
            sabotageUI.SetActive(false);
        }
    }

    public void SumoData(int n)
    {
         
        if(n == 0)
        {
            currentSumo = n;
            //head.GetComponent<Text>().text = "Red sumo";
            head.GetComponent<Image>().color = new Color(255f, 0f, 0f, 100f);
            GameEvents.current.UpdateUI();
        }

        if(n == 1)
        {
            currentSumo = n;
            //head.GetComponent<Text>().text = "Blue sumo";
            head.GetComponent<Image>().color = new Color(0f, 0f, 255f, 100f);
            GameEvents.current.UpdateUI();
        }
    }

    

    private void OnDestroy()
    {
        GameEvents.current.onOpenUI -= Show;
        GameEvents.current.onCloseUI -= Hide;
    }
}
