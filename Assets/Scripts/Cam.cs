using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public Transform camTransform;
    public float mouseSensitivity;
    public float camRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float MouseInputY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        camRotation -= MouseInputY;
        camRotation = Mathf.Clamp(camRotation, -90f, 90f);
        camTransform.localRotation = Quaternion.Euler(new Vector3(camRotation, 0f, 0f));

        float MouseInputX = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.rotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0f, MouseInputX, 0f));
    }
}
