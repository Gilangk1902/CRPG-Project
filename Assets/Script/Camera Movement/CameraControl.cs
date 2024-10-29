using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private GameObject cam;
    [SerializeField] private int speed;
    [SerializeField] private Transform cameraAnchor;
    [SerializeField] private CameraMovement cameraMovement;
    private readonly int cameraRotationSpeed = 50;
    void Update()
    {
        SetCameraDirectionTo(cameraAnchor);
        ControlCamera();
    }

    private void ControlCamera()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        cameraMovement.Move(speed, this.gameObject,-moveZ, moveX);

        if(Input.GetKey(KeyCode.Q))
        {
            cameraMovement.Rotate(cameraRotationSpeed, this.gameObject, -1);
        }
        if (Input.GetKey(KeyCode.E))
        {
            cameraMovement.Rotate(cameraRotationSpeed, this.gameObject, 1);
        }
    }

    private void SetCameraDirectionTo(Transform direction)
    {
        cam.transform.LookAt(direction);
    }
}
