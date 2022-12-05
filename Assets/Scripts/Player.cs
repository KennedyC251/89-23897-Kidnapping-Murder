using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //movement
    public CharacterController CC;
    public float moveSpeed;
    public float gravity = -9.8f;
    public float jump;
    public float verticalSpeed;

    //UI
    public GameObject BlueUI;

    //collision
    public bool GotKey1 = false;

    private void Start()
    {
        //setactive
        BlueUI.SetActive(false);
    }

    void Update()
    {
        Vector3 movement = Vector3.zero;

        float forwardMovement = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float sideMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        movement += (transform.forward * forwardMovement) + (transform.right * sideMovement);

        if (CC.isGrounded)
        {
            verticalSpeed = 0f;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalSpeed = jump;
            }
        }

        verticalSpeed += (gravity * Time.deltaTime);
        movement += (transform.up * verticalSpeed * Time.deltaTime);

        CC.Move(movement);
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Key1script k1 = hit.gameObject.GetComponent<Key1script>();
        if (k1)
        {
            Destroy(hit.gameObject);
            BlueUI.SetActive(true);

            GotKey1 = true;

        }
        Removescript rs = hit.gameObject.GetComponent<Removescript>();
        if (rs && GotKey1)
        {
            Destroy(hit.gameObject);

            BlueUI.SetActive(false);

        }
    }
}
