using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionList : CharacterBehaviour
{
    [SerializeField] private Action[] actions;
    [SerializeField] private Action selectedAction;
    private void Awake()
    {
        //selectedAction.actionList = this;
    }
    private void Update()
    {
        //ChangeSelectedAction();
        if(selectedAction != null )
        {
            selectedAction.ActionControl();

        }
    }

    public void ChangeSelectedAction()
    {
        if (Input.GetKeyUp(KeyCode.L))
        {
            selectedAction = actions[0];
            selectedAction.actionList = this;
            character.party.SetIsWaitingForAction(true);
            character.setCharacterReachRadiusActive(selectedAction.GetRange());
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            selectedAction = null;
            character.party.SetIsWaitingForAction(false);
            character.setCharacterReachRadiusDeactive();
        }
    }

    public Action GetSelectedAction() { return this.selectedAction; }
}

public abstract class ActionListBehaviour: MonoBehaviour
{
    [HideInInspector] public ActionList actionList;
}