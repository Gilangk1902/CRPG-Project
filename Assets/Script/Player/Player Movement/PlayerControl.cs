using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Apple;

public class PlayerControl : PartyBehaviour
{
    void Update()
    {
        ChangeSelectedAction();
        if (!party.GetIsWaitingForAction())
        {
            MoveSelectedCharacter();
        }
    }

    private void ChangeSelectedAction()
    {
        party.getSelectedCharacter().GetActionList().ChangeSelectedAction();
    }

    private void MoveSelectedCharacter()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                party.getSelectedCharacter().GetMovement().setDestination(hit.point);
                party.getSelectedCharacter().setDestination(hit.point);
            }
        }

        party.getSelectedCharacter().getAgent().SetDestination((Vector3)party.getSelectedCharacter().GetMovement().getDestination());
    }

}
