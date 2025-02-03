using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float mouseSensitivity = 2f;
    public float minY = -90f, maxY = 90f;

    private float rotationX = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        Vector3 forward = transform.forward;
        Vector3 right = transform.right;

        forward.y = 0;  
        right.y = 0;    
        forward.Normalize();
        right.Normalize();

        transform.position += forward * moveZ + right * moveX;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, minY, maxY);

        transform.rotation = Quaternion.Euler(rotationX, transform.rotation.eulerAngles.y + mouseX, 0);
    }
}
