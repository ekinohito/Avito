using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraHandle : MonoBehaviour
{
    public float scaleX = 0.1f;
    public float scaleY = 0.1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDrag()
    {
        float rotationX = -Input.mousePositionDelta.x * scaleX;
        transform.Rotate(0.0f, rotationX, 0.0f, Space.World);

        float rotationY = -Input.mousePositionDelta.y * scaleY;
        transform.Rotate(rotationY, 0.0f, 0.0f);
    }
}
