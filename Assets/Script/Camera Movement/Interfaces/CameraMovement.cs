using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{   
    public void Move(int speed, GameObject camera, float moveX, float moveZ)
    {
        Vector3 move = (camera.transform.right * moveX) + (camera.transform.forward * moveZ);
        move = move.normalized;
        camera.transform.Translate(move * speed * Time.deltaTime, Space.World);
    }

    public void Rotate(int speed, GameObject camera, int direction)
    {
        transform.Rotate(0, direction * speed * Time.deltaTime, 0);
    }

}
