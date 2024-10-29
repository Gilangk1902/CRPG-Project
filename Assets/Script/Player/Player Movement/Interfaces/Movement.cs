using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement
{
    private Vector3? destination;
    public Movement(Vector3? destination)
    {
        this.destination = destination;
    }

    public void setDestination(Vector3 transform)
    {
        destination= transform; 
    }

    public Vector3? getDestination()
    {
        return destination.Value;
    }
}
