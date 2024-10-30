using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : CharacterBehaviour
{
    [SerializeField] private AbilityScore abilityScore;
    [SerializeField] private int hitDieSize;
    [SerializeField] private int level;
    [SerializeField] private int currentHealth;
    private int baseArmorClass = 10;
    [SerializeField] private int armorClass;


    private void Start()
    {
        currentHealth = GetMaxHealth();
        this.armorClass = GetArmorClass();
    }

    public int GetMaxHealth()
    {
        int constitution = abilityScore.GetConstitutionModifier();
        return (hitDieSize + level*hitDieSize + 2*level + 2*level*constitution - 2)/2;
    }

    public int GetArmorClass()
    {
        return baseArmorClass + abilityScore.GetDexterityModifier() + character.GetLoadout().GetArmor().armorClass;
    }

    public AbilityScore GetAbilityScore()
    {
        return this.abilityScore;
    }
}
