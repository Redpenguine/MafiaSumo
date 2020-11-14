using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int betsUINum = 0;

    [SerializeField]
    private int sumoStatsUINum = 1;

    [SerializeField]
    private int sabotageUINum = 2;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartFight()
    {
        GameEvents.current.CloseUI(betsUINum);
        GameEvents.current.CloseUI(sumoStatsUINum);
        GameEvents.current.CloseUI(sabotageUINum);
    }

    public void ShowBetsUI()
    {
        GameEvents.current.OpenUI(betsUINum);
    }

    public void ShowSumoStatsUI()
    {
        GameEvents.current.OpenUI(sumoStatsUINum);
    }

    public void ShowSabotageUI()
    {
        GameEvents.current.OpenUI(sabotageUINum);
    }
}
