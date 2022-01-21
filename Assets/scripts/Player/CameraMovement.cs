using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] float MouseSensitivity = 100f;
    float xRotation= 0f;
    public Transform Body;



    private void Start()
    {       
        Cursor.lockState = CursorLockMode.Locked;

    }


    public void Update()
    {

        float MouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

        xRotation -= MouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, MouseY, 0f);
        Body.Rotate(Vector3.up * MouseX);

        //camera.eulerAngles += MouseSensitivity * new Vector3(x: -Input.GetAxis("Mouse Y"), y: Input.GetAxis("Mouse X"), z: 0);

    }
}
