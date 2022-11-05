using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float minZoom = 10.0f;
    public float maxZoom = 30.0f;

    // Update is called once per frame
    void Update()
    {   
            Vector3 p = GetInput();
            transform.Translate(p);
    }

    private Vector3 GetInput()
    {
        float mouseScrollWheel = Input.GetAxis("Mouse ScrollWheel");
        Vector3 velocity = new Vector3(0, 0, 0);

        // Reset position (For testing purpose)
        if(Input.GetKey(KeyCode.Q))
        {
            transform.position = Vector3.zero;
        }
        // Move forwards
        if (Input.GetKey(KeyCode.W))
        {
            velocity += new Vector3(0, 1, 0);
        }
        // Move backwards
        if (Input.GetKey(KeyCode.S))
        {
            velocity += new Vector3(0, -1, 0);
        }
        // Move left
        if (Input.GetKey(KeyCode.A))
        {
            velocity += new Vector3(-1, 0, 0);
        }
        // Move right
        if (Input.GetKey(KeyCode.D))
        {
            velocity += new Vector3(1, 0, 0);
        }
        // Fix the min y position of the camera
        if (transform.position.y > minZoom)
        {
            // Zoom out
            if (mouseScrollWheel > 0f)
            {
                velocity += new Vector3(0, 0, 1);
            }
        }
        // Fix the m y position of the camera
        if (transform.position.y < maxZoom)
        {
            // Zoom in
            if (mouseScrollWheel < 0f)
            {
                velocity += new Vector3(0, 0, -1);
            }
        }
        return velocity;
    }
}
