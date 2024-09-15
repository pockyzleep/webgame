using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public Transform player; // Reference to the player's transform
    public float smoothSpeed = 0.125f; // Smoothing speed
    public Vector3 offset; // Offset between the camera and the player

    private void LateUpdate() {
        // Desired position is the player's position plus the offset
        Vector3 desiredPosition = player.position + offset;

        // Smoothly interpolate between the current position and the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Set the camera's position to the smoothed position, preserving the camera's z position
        smoothedPosition.z = transform.position.z;

        transform.position = smoothedPosition;
    }
}
