using UnityEngine;

public class GyroController : MonoBehaviour
{
    public float moveSpeed = 2.0f;  // Speed of movement
    public float rotationSpeed = 50.0f; // Speed of manual rotation

    private bool gyroEnabled;  // Check if gyroscope is available
    private Gyroscope gyro;    // Gyroscope sensor
    private Quaternion gyroInitialRotation; // Stores initial gyroscope rotation

    void Start()
    {
        // Enable Gyroscope if supported
        gyroEnabled = EnableGyro();
    }

    void Update()
    {
        // Apply headset rotation using gyroscope if available
        if (gyroEnabled)
        {
            ApplyGyroRotation();
        }

        // Move forward/backward/left/right using keyboard keys
        HandleKeyboardMovement();

        // Rotate manually using arrow keys
        HandleManualRotation();
    }

    bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            gyroInitialRotation = Quaternion.Euler(90f, 0f, 0f); // Adjust rotation for Unity
            return true;
        }
        return false;
    }

    void ApplyGyroRotation()
    {
        // Convert gyroscope data to Unity's coordinate system
        transform.rotation = gyroInitialRotation * GyroToUnity(gyro.attitude);
    }

    Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w); // Convert gyro coordinates to Unity format
    }

    void HandleKeyboardMovement()
    {
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) // Move forward
        {
            moveDirection += transform.forward;
        }
        if (Input.GetKey(KeyCode.S)) // Move backward
        {
            moveDirection -= transform.forward;
        }
        if (Input.GetKey(KeyCode.A)) // Move left
        {
            moveDirection -= transform.right;
        }
        if (Input.GetKey(KeyCode.D)) // Move right
        {
            moveDirection += transform.right;
        }

        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    void HandleManualRotation()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) // Rotate left
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow)) // Rotate right
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }
}
