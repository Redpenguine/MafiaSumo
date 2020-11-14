using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SumoStatsAreaController : MonoBehaviour
{
    protected SumoStatsDTO SumoStats = new SumoStatsDTO();

    public void SetNewSumo(SumoStatsDTO sumoStatsDTO)
    {
        SumoStats = sumoStatsDTO;
    }

    void Start()
    {
        UpdateSumo();
        GameEvents.current.onUpdateSumo += UpdateSumo;
    }

    private void UpdateSumo()
    {
        if(this.gameObject.name == "SumoStatsAreaRed")
        {
            SumoStats = FindObjectOfType<GameCoreLoop>().red;
        }
        else if(this.gameObject.name == "SumoStatsAreaBlue"){
            SumoStats = FindObjectOfType<GameCoreLoop>().blue;
        }
    }
    // Update is called once per frame
    void Update()
    {
        SetStats(SumoStats);
    }

    protected void SetStats(SumoStatsDTO sumoStats)
    {
        var panels = this.GetComponentsInChildren<GridLayoutGroup>();

        foreach (var panel in panels)
        {
            switch (panel.name)
            {
                case "PhysicalStatePanel":
                    panel.GetComponentsInChildren<Text>().FirstOrDefault(x => x.gameObject.name == "State_value").text = sumoStats.PhysicalState.ToString();
                    break;
                case "MoralePanel":
                    panel.GetComponentsInChildren<Text>().FirstOrDefault(x => x.gameObject.name == "State_value").text = sumoStats.Morale.ToString();
                    break;
                case "CorruptibilityPanel":
                    panel.GetComponentsInChildren<Text>().FirstOrDefault(x => x.gameObject.name == "State_value").text = sumoStats.Corruptibility.ToString();
                    break;
                case "MawashiStrPanel":
                    panel.GetComponentsInChildren<Text>().FirstOrDefault(x => x.gameObject.name == "State_value").text = sumoStats.MawashiStr.ToString();
                    break;
                case "FortunePanel":
                    panel.GetComponentsInChildren<Text>().FirstOrDefault(x => x.gameObject.name == "State_value").text = sumoStats.Fortune.ToString();
                    break;
                default:
                    break;
            }
        }
    }
}
