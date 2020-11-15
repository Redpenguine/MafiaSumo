using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SabotagePattern
{
    public enum DamageType
    {
        Phisical,
        Moral,
        Corruptibility,
        Mavashi,
        Fortune
    }
    public string sabotageName;
    public DamageType damageType;
    public int damageValue;
    public int cost;
}
