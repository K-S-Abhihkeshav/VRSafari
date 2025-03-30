using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forward : MonoBehaviour
{
    public float playerSpeed = 2f;
    public bool isMoving;
    private float gazeTime = 0f;
    public float requiredGazeTime = 1f;
    private Vector3 initialForward;
    private float currentSpeed = 0f;
    private float acceleration = 1f; // Speed increase per second
    private float deceleration = 2f; // Speed decrease per second

    void Start()
    {
        initialForward = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z).normalized;
    }

    void Update()
    {
        Vector3 currentForward = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z).normalized;
        float angleDifference = Vector3.Angle(initialForward, currentForward);

        if (Camera.main.transform.forward.y < 0.3f && angleDifference < 35f)
        {
            gazeTime += Time.deltaTime;
            if (gazeTime >= requiredGazeTime)
            {
                isMoving = true;
            }
        }
        else
        {
            gazeTime = 0f;
            isMoving = false;
            initialForward = currentForward;
        }

        // Smooth acceleration and deceleration
        if (isMoving)
        {
            currentSpeed = Mathf.Lerp(currentSpeed, playerSpeed, Time.deltaTime * acceleration);
        }
        else
        {
            currentSpeed = Mathf.Lerp(currentSpeed, 0, Time.deltaTime * deceleration);
        }

        // Move smoothly based on current speed, keeping movement in the XZ plane
        Vector3 moveDirection = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z).normalized;
        transform.position += moveDirection * currentSpeed * Time.deltaTime;
    }

}
