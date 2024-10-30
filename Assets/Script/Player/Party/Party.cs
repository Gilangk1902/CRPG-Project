using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Party : MonoBehaviour
{
    [SerializeField] private bool isWaitingForAction;

    [SerializeField] private PlayerControl playerControl;

    [SerializeField] private Character selectedCharacter;
    [SerializeField] private Character partySlot1;
    [SerializeField] private Character partySlot2;
    [SerializeField] private Character partySlot3;
    [SerializeField] private Character partySlot4;

    private void Awake()
    {
        isWaitingForAction = false;
        this.selectedCharacter = this.partySlot1;
        selectedCharacter.party= this;
        playerControl.party= this;
    }
    private void Start()
    {
        
    }

    private void Update()
    {
        if(!isWaitingForAction)
        {
            changeSelectedCharacter();
        }
    }

    private void changeSelectedCharacter()
    {
        if(Input.GetKeyUp(KeyCode.Alpha1)) { 
            selectedCharacter = partySlot1;
        }        
        if(Input.GetKeyUp(KeyCode.Alpha2))
        {
            selectedCharacter = partySlot2;
        }
    }

    public Character getSelectedCharacter() { return selectedCharacter; }

    public void SetIsWaitingForAction(bool value)
    {
        this.isWaitingForAction = value;
    }

    public bool GetIsWaitingForAction()
    {
        return this.isWaitingForAction;
    }
}

public abstract class PartyBehaviour: MonoBehaviour
{
    [HideInInspector] public Party party;
}