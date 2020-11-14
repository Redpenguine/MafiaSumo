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
            Instantiate(sabotagePrefab, sabotageArea);
            sabotageList.Add(sabotagePrefab);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
