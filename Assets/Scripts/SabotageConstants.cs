using System.Collections.Generic;

public class SabotageConstants
{
    public const string Poison = "Poison";
    public const string Fight = "Fight";
    public const string DamageMawashi = "Damage mawashi";
    public const string Curse = "Curse";
    public const string Intimidation = "Intimidation";
    public const string Bribe = "Bribe";

    public static List<string> Sabotages = new List<string>() { Poison, Fight, DamageMawashi, Curse, Intimidation, Bribe };
}
