using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Transform cameraTransform;
    Quaternion targetRotation;

    [SerializeField] private float moveSpeed = 3f;

    [SerializeField] GameObject proiectil;

    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        cameraTransform = GameObject.FindWithTag("MainCamera").transform;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxis("Vertical");
        float z = Input.GetAxis("Horizontal");

        bool buttonPressed = Input.GetButton("Fire1");

        if (buttonPressed)
        {
            GameObject newInstance = GameObject.Instantiate(proiectil);
            newInstance.transform.position = cameraTransform.position + cameraTransform.forward;
            newInstance.transform.rotation = cameraTransform.rotation;
        }

        Vector3 movement = new Vector3(x, 0.0f, z);

        transform.Translate(movement);

    }
}
