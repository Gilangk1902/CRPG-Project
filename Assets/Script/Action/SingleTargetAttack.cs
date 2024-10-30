using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTargetAttack : Action
{
    private int maxTarget = 1;
    private float meleeRange = 2.5f;
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

                    // Check if the target is within the attack radius
                    if (distance <= meleeRange)
                    {
                        Debug.Log(actionList.character.name + " Attacked " + hit.collider.gameObject.name + " for " + CalculateDamage() + " damage");
                    }
                    else
                    {
                        Debug.Log("Target is out of range!");
                    }
                }
            }
        }
    }

    private int CalculateDamage()
    {
        int weaponAttackDie = actionList.character.GetLoadout().GetMelee().attackDie;
        int baseDamage = Random.Range(1, weaponAttackDie + 1);

        int bonusDamage = actionList.character.GetStatus().GetAbilityScore().GetStrengthModifier();
        return baseDamage + bonusDamage;
    }

    public override float GetRange()
    {
        return this.meleeRange;
    }
}
