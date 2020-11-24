using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLerpToTransform : MonoBehaviour {

    // Sets target, speed and bounds
    public Transform camTarget;
    public float trackingSpeed;
    public float minX;
    public float minY;
    public float maxX;
    public float maxY;
    // Called with every fixed frame
    void FixedUpdate()
    {
        // null check ensures a valid transform component was assigned to the camTarget field
        if (camTarget != null) 
    {
            // Performs linear interpolation
            var newPos = Vector2.Lerp(transform.position,
            camTarget.position,
            Time.deltaTime * trackingSpeed);
            var camPosition = new Vector3(newPos.x, newPos.y, -10f);
            var v3 = camPosition;
            var clampX = Mathf.Clamp(v3.x, minX, maxX);
            var clampY = Mathf.Clamp(v3.y, minY, maxY);
            transform.position = new Vector3(clampX, clampY, -10f);
        }
    }
}
