using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class CameraController : MonoBehaviour
{
    private Vector3 defaultCameraPos;
    
    [SerializeField] private GameObject level;

    [Header ("Camera Settings")]
    [SerializeField] private float cameraMovSpeed = 0.5f;
    [SerializeField] private float cameraZoomSpeed = 0.5f;
    [SerializeField] private float minZoom = 10.0f;
    [SerializeField] private float maxZoom = 30.0f;
    [SerializeField] private bool enableZoom = true;

    private void Start()
    {
        if (level.GetComponent<Collider>() == null) { return; }
        UtilsClass.GetGameObjectSize(level);
        SetDefaultCameraPos(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = GetInput();
        transform.Translate(pos);
    }

    private Vector3 GetInput()
    {
        float mouseScrollWheel = Input.GetAxis("Mouse ScrollWheel");
        Vector3 velocity = new Vector3(0, 0, 0);

        // Reset position (For testing purpose)
        if (Input.GetKey(KeyCode.Q))
        {
            transform.position = GetDefaultCameraPos();
        }

        if (transform.position.z < GetCameraMovableArea().z)
        {
            // Move forwards
            if (Input.GetKey(KeyCode.W))
            {
                velocity += new Vector3(0, cameraMovSpeed / 2, cameraMovSpeed / 2);
            }
        }

        if (transform.position.z > -GetCameraMovableArea().z * 2)
        {
            // Move backwards
            if (Input.GetKey(KeyCode.S))
            {
                velocity += new Vector3(0, -cameraMovSpeed / 2, -cameraMovSpeed / 2);
            }
        }

        if (transform.position.x > -GetCameraMovableArea().x)
        {
            // Move left
            if (Input.GetKey(KeyCode.A))
            {
                velocity += new Vector3(-cameraMovSpeed, 0, 0);
            }
        }

        if (transform.position.x < GetCameraMovableArea().x)
        {
            // Move right
            if (Input.GetKey(KeyCode.D))
            {
                velocity += new Vector3(cameraMovSpeed, 0, 0);
            }
        }

        if(enableZoom)
        {
            // Fix the min y position of the camera
            if (transform.position.y > minZoom)
            {
                // Zoom out
                if (mouseScrollWheel > 0f)
                {
                    velocity += new Vector3(0, 0, cameraZoomSpeed);
                }
            }
            // Fix the m y position of the camera
            if (transform.position.y < maxZoom)
            {
                // Zoom in
                if (mouseScrollWheel < 0f)
                {
                    velocity += new Vector3(0, 0, -cameraZoomSpeed);
                }
            }
        }
        return velocity;
    }

    public Vector3 GetCameraMovableArea()
    {
        return UtilsClass.GetGameObjectSize(level) / 4;
    }

    public void SetDefaultCameraPos(Vector3 pos)
    {
        defaultCameraPos = pos;
    }

    public Vector3 GetDefaultCameraPos()
    {
        return defaultCameraPos;
    }

    public void SetEnableZoom(bool status)
    {
        enableZoom = status;
    }

    public bool GetEnableZoom()
    {
        return enableZoom;
    }
}
