using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BetsUI : MonoBehaviour
{
    [SerializeField]
    private GameObject betsUI;

    [SerializeField]
    private Text coefficientRedSumo;

    [SerializeField]
    private Text coefficientBlueSumo;

    [HideInInspector]
    public float redCoeff = 10;
    [HideInInspector]
    public float blueCoeff = 10;

    [SerializeField] private float minRedCoeff = 1.1f;
    [SerializeField] private float maxRedCoeff = 2.4f;
    [SerializeField] private float minBlueCoeff = 2.6f;
    [SerializeField] private float maxBlueCoeff = 4.4f;
    [SerializeField] private float sumCoeff = 5f;

    [SerializeField]
    private int UIId = 0;

    void Start()
    {
        GameEvents.current.onOpenUI += Show;
        GameEvents.current.onCloseUI += Hide;
        GameEvents.current.onUpdateAfterFight += Coefficients;
        Coefficients();
        betsUI.SetActive(false);
    }

    public void Show(int UIId)
    {
        if(this.UIId == UIId)
        {
            if(betsUI.activeSelf)
            {
                betsUI.SetActive(false);
            }
            else
            {
                betsUI.SetActive(true);
                UpdateText();
            }
        }
    }

    public void Hide(int UIId)
    {
        if(this.UIId == UIId)
        {
            betsUI.SetActive(false);
        }
    }

    private void Coefficients()
    {
        redCoeff = 10;
        blueCoeff = 10;
        while(redCoeff+blueCoeff > sumCoeff)
        {
            redCoeff = Random.Range(minRedCoeff, maxRedCoeff);
            blueCoeff = Random.Range(minBlueCoeff, maxBlueCoeff);
        }
        UpdateText();
    }

    private void UpdateText()
    {
        coefficientRedSumo.text = redCoeff.ToString("#.#");
        coefficientBlueSumo.text = blueCoeff.ToString("#.#");
    }
    

    private void OnDestroy()
    {
        GameEvents.current.onOpenUI -= Show;
        GameEvents.current.onCloseUI -= Hide;
        GameEvents.current.onUpdateAfterFight -= Coefficients;
    }
}
