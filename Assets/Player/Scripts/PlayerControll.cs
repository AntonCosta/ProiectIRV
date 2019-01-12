using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    Transform cameraTransform;
    [SerializeField] GameObject proiectil;

    // Use this for initialization
    void Start()
    {
        cameraTransform = GameObject.FindWithTag("MainCamera").transform;
    }

    // Update is called once per frame
    void Update()
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

        transform.position += x * cameraTransform.right * Time.deltaTime
            + z * cameraTransform.forward * Time.deltaTime;


    }
}
