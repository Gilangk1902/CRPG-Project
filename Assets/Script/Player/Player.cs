using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    private Movement movement;
    private Vector3 destination;
    [SerializeField] private GameObject destinationMarker;
    [SerializeField] private CharacterStatus characterStatus;
    [SerializeField] private Loadout characterLoadout;

    private void Awake()
    {
        characterStatus.character = this;
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
    [HideInInspector] public Player character;
}