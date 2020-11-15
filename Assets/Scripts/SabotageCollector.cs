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
        for(int i = 0; i < 6; i++)
        {
            var instant = Instantiate(sabotagePrefab, sabotageArea);
            instant.GetComponent<SabotageBlueprint>().sabotageName = sabotagePatternArray[i].sabotageName;
            //Debug.Log("sabotageName = " + sabotagePatternArray[i].sabotageName);
            instant.GetComponent<SabotageBlueprint>().damageState  = sabotagePatternArray[i].damageType;
            instant.GetComponent<SabotageBlueprint>().damageValue = sabotagePatternArray[i].damageValue;
            instant.GetComponent<SabotageBlueprint>().cost = sabotagePatternArray[i].cost;
            
            sabotageList.Add(instant);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
