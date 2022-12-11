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
    public GameObject Key1UI;
    public GameObject Key2UI;

    //collision
    public bool GotKey1 = false;
    public bool GotKey2 = false;

    private void Start()
    {
        //setactive
        Key1UI.SetActive(false);
        Key2UI.SetActive(false);
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
            Key1UI.SetActive(true);

            GotKey1 = true;
        }

        Key2script k2 = hit.gameObject.GetComponent<Key2script>();
        if (k2)
        {
            Destroy(hit.gameObject);
            Key2UI.SetActive(true);

            GotKey2 = true;

        }

        Door1script d1s = hit.gameObject.GetComponent<Door1script>();
        if (d1s && GotKey1)
        {
            Destroy(hit.gameObject);

            Key1UI.SetActive(false);
        }

        Door2script d2s = hit.gameObject.GetComponent<Door2script>();
        if (d2s && GotKey2)
        {
            Destroy(hit.gameObject);

            Key2UI.SetActive(false);

        }
    }
}
