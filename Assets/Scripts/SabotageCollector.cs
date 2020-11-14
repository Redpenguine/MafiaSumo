using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SabotageCollector : MonoBehaviour
{
    [SerializeField]
    private Transform sabotageArea;

    [SerializeField]
    private GameObject sabotagePrefab;

    [SerializeField]
    private SabotagePattern[] sabotagePatternArray;

    private List<GameObject> sabotageList;
    void Start()
    {
        sabotageList = new List<GameObject>();
        foreach (var sabotageName in SabotageConstants.Sabotages)
        {
            var sabotageBlueprint = sabotagePrefab.GetComponent<SabotageBlueprint>();
            sabotageBlueprint.sabotageName = sabotageName;
            Instantiate(sabotagePrefab, sabotageArea);
            sabotageList.Add(sabotagePrefab);
        }
    }

    public void UpdateChances(SumoStatsDTO sumoStats)
    {
        foreach (var sabotage in sabotageList)
        {
            var sabotageBlueprint = sabotage.GetComponent<SabotageBlueprint>();
            sabotageBlueprint.SetChanceBySumo(sumoStats);
        }
    }
}
