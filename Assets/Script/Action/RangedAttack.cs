using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : Action
{
    private int maxTarget = 1;
    private float longRange = 15f;
    public override void ActionControl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Character"))
                {
                    float distance = Vector3.Distance(actionList.character.transform.position, hit.collider.transform.position);

                    if (distance <= longRange)
                    {
                        Debug.Log(actionList.character.name + " Attacked " + hit.collider.gameObject.name + " for " + CalculateDamage() + " damage with " + GetActionName());
                    }
                    else
                    {
                        Debug.Log("Target is out of range!");
                    }
                }
            }
        }
    }

    public override int CalculateDamage()
    {
        int weaponAttackDie = actionList.character.GetLoadout().GetRangedWeapon().attackDie;
        int baseDamage = Random.Range(1, weaponAttackDie + 1);

        int bonusDamage = actionList.character.GetStatus().GetAbilityScore().GetStrengthModifier();
        return baseDamage + bonusDamage;
    }

    public override string GetActionName()
    {
        return "Ranged Attack";
    }

    public override float GetRange()
    {
        return this.longRange;
    }
}
