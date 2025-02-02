using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float mouseSensitivity = 5f;
    public float minY = -90f, maxY = 90f;

    private float rotationX = 0f;

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(moveX, 0, moveZ);

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, minY, maxY);

        transform.localRotation = Quaternion.Euler(rotationX, transform.localRotation.eulerAngles.y + mouseX, 0);
    }
}
