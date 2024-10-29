using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Armor", menuName = "ScriptableObjects/Armor")]
public class Armor : ScriptableObject
{
    public string armorName;
    public int armorClass;
}
