using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Apple;
using UnityEngine.EventSystems;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerControl : PartyBehaviour
{
    void Update()
    {
        if (!party.GetIsWaitingForAction())
        {
            MoveSelectedCharacter();
        }
        else
        {
            ChangeSelectedAction();
        }
    }

    private void ChangeSelectedAction()
    {
        party.GetSelectedCharacter().GetActionList().ChangeSelectedAction();
    }

    private void MoveSelectedCharacter()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log("Clicked on UI, ignoring raycast to 3D objects.");
                return; // Exit the method if the click was on a UI element
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                int uiLayer = LayerMask.GetMask("UI");
                
                Debug.Log("Raycast hit a floor: " + hit.collider.gameObject.name);
                party.GetSelectedCharacter().GetMovement().setDestination(hit.point);
                party.GetSelectedCharacter().setDestination(hit.point);
            }
        }

        party.GetSelectedCharacter().getAgent().SetDestination((Vector3)party.GetSelectedCharacter().GetMovement().getDestination());
    }

}
