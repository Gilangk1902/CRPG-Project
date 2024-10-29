using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Party : MonoBehaviour
{
    [SerializeField] private Player selectedCharacter;
    [SerializeField] private Player slot1;
    [SerializeField] private Player slot2;
    [SerializeField] private Player slot3;
    [SerializeField] private Player slot4;

    private void Start()
    {
        this.selectedCharacter = this.slot1;
    }

    private void Update()
    {
        changeSelectedCharacter();
    }

    private void changeSelectedCharacter()
    {
        if(Input.GetKeyUp(KeyCode.Alpha1)) { 
            selectedCharacter = slot1;
        }        
        if(Input.GetKeyUp(KeyCode.Alpha2))
        {
            selectedCharacter = slot2;
        }
    }

    public Player getSelectedCharacter() { return selectedCharacter; }
}
