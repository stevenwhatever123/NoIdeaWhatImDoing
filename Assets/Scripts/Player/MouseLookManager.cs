using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookManager : MonoBehaviour
{
    [SerializeField]
    float sensitivityX = 8f;

    [SerializeField]
    float sensitivityY = 8f;

    float mouseX, mouseY;

    [SerializeField]
    Transform PlayerCamera;

    [SerializeField]
    float xClampPositive = 85f;

    [SerializeField]
    float xClampNegative = 50f;

    [SerializeField]
    float xRotation = 0f;


    void Update()
    {
        if(Time.timeScale > 0)
        {
            transform.Rotate(Vector3.up * mouseX * Time.deltaTime);

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -xClampPositive, xClampNegative);
            Vector3 targetRotation = transform.eulerAngles;
            targetRotation.x = xRotation;
            PlayerCamera.eulerAngles = targetRotation;
        }
    }

    public void RecieveInput(Vector2 mouseInput)
    {
        mouseX = mouseInput.x * sensitivityX;
        mouseY = mouseInput.y * sensitivityY;
    }
}
