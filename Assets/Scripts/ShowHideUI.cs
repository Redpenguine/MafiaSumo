using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideUI : MonoBehaviour
{
    // [SerializeField]
    // private GameObject[] UIGameObject;

    // [SerializeField]
    // private int[] UINum;

    private Dictionary<GameObject, int> UI = new Dictionary<GameObject, int>();

    void Awake()
    {
        // for(int i = 0; i < UINum.Length; i++)
        // {
        //     UI.Add(UIGameObject[i], UINum[i]);
        // }
    }

    void Start()
    {
        GameEvents.current.onOpenUI += Show;
        GameEvents.current.onCloseUI += Hide;

        foreach(KeyValuePair<GameObject, int> keyValue in UI)
        {
            keyValue.Key.SetActive(false); 
        }

        
        
    }

    public void Show(int UIname)
    {
        foreach(KeyValuePair<GameObject, int> keyValue in UI)
        {
            if(keyValue.Value == UIname)
            {
                keyValue.Key.SetActive(true);
            }
        }
    }

    public void Hide(int UIname)
    {
        foreach(KeyValuePair<GameObject, int> keyValue in UI)
        {
            if(keyValue.Value == UIname)
            {
                keyValue.Key.SetActive(false);
            }
        }
    }
    
    
    private void OnDestroy()
    {
        GameEvents.current.onOpenUI -= Show;
        GameEvents.current.onCloseUI -= Hide;
    }
}
