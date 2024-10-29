using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityScore : MonoBehaviour
{
    [SerializeField] private int strengthAbilityScore;
    [SerializeField] private int dexterityAbilityScore;
    [SerializeField] private int constitutionAbilityScore;
    [SerializeField] private int intelligenceAbilityScore;
    [SerializeField] private int wisdomAbilityScore;
    [SerializeField] private int charismaAbilityScore;

    public int GetStrengthModifier()
    {
        return (strengthAbilityScore - 10) / 2;
    }

    public int GetDexterityModifier()
    {
        return (dexterityAbilityScore - 10) / 2;
    }

    public int GetConstitutionModifier()
    {
        return (constitutionAbilityScore - 10) / 2;
    }

    public int GetIntelligenceModifier()
    {
        return (intelligenceAbilityScore - 10) / 2;
    }

    public int GetWisdomModifier()
    {
        return (wisdomAbilityScore - 10) / 2;
    }

    public int GetCharismaModifier()
    {
        return (charismaAbilityScore - 10) / 2;
    }
}
