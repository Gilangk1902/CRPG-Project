using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Character : PartyBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    private Movement movement;
    private Vector3 destination;
    [SerializeField] private GameObject characterReachMarker;
    [SerializeField] private GameObject destinationMarker;
    private int characterReachRadius;
    [SerializeField] private CharacterStatus characterStatus;
    [SerializeField] private Loadout characterLoadout;
    [SerializeField] private ActionList actionList;

    private void Awake()
    {
        characterStatus.character = this;
        actionList.character = this;
        movement = new(transform.position);
        setDestination(this.transform.position);
    }

    private void Update()
    {
        MarkerHandler();
    }

    private void MarkerHandler()
    {
        float distance = Vector3.Distance(destination, this.transform.position);
        if (distance < 1f)  
        {
            disableDestinationMarker();
        }
        else
        {
            destinationMarker.SetActive(true);
        }
    }

    public ActionList GetActionList()
    {
        return actionList;
    }

    public Loadout GetLoadout()
    {
        return characterLoadout;
    }

    public CharacterStatus GetStatus()
    {
        return characterStatus;
    }
    public Movement GetMovement() { return movement; }  

    public NavMeshAgent getAgent() { return agent; }

    public Vector3 getDestination() { return this.destination; }

    public void setCharacterReachRadiusActive(float radius)
    {
        this.characterReachMarker.SetActive(true);
        this.characterReachMarker.transform.localScale = new Vector3(radius*2,0.1f,radius*2);
    }
    public void setCharacterReachRadiusDeactive()
    {
        this.characterReachMarker.SetActive(false);
    }
    public void setDestination(Vector3 destination)
    {
        this.destination = destination;
        setMarker(destination);
        Debug.Log("test");
    }

    public void disableDestinationMarker()
    {
        destinationMarker.SetActive(false);
    }

    public void setMarker(Vector3 position)
    {
        destinationMarker.transform.position = position;
    }
}

public abstract class CharacterBehaviour: MonoBehaviour
{
    [HideInInspector] public Character character;
}