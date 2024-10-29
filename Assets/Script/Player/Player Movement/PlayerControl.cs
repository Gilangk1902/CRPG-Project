using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Apple;

public class PlayerControl : MonoBehaviour 
{
    [SerializeField] private Party party;

    void Update()
    {
        MouseInput();
        Move();
    }

    private void MouseInput()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) {
                party.getSelectedCharacter().GetMovement().setDestination(hit.point);
                party.getSelectedCharacter().setDestination(hit.point);
            }
        }
    }

    private void Move()
    {
        party.getSelectedCharacter().getAgent().SetDestination((Vector3)party.getSelectedCharacter().GetMovement().getDestination());
    }

}
