using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loadout : MonoBehaviour
{
    [SerializeField] private Armor armor;
    [SerializeField] private Melee melee;
    [SerializeField] private RangedWeapon ranged;
    public Armor GetArmor()
    {
        return this.armor;
    }

    public Melee GetMelee()
    {
        return this.melee;
    }

    public RangedWeapon GetRangedWeapon()
    {
        return this.ranged; 
    }
}
