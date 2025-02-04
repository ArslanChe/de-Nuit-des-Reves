using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float mouseSensitivity = 5f;
    public float verticalRotationLimit = 80f;
    public float smoothTime = 0.1f;

    private float currentXRotation = 0f;
    private Vector3 currentVelocity;

    void Update()
    {
        if (player == null) return;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(Vector3.up * mouseX);

        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        currentXRotation -= mouseY;
        currentXRotation = Mathf.Clamp(currentXRotation, -verticalRotationLimit, verticalRotationLimit);

        Camera.main.transform.localRotation = Quaternion.Euler(currentXRotation, 0f, 0f);

        Vector3 targetPosition = player.position;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothTime);
    }
}