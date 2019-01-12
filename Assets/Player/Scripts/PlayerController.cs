using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Transform cameraTransform;
    [SerializeField] Weapon weapon;
    Quaternion targetRotation;

    [SerializeField] private float moveSpeed = 3f;

    [SerializeField] GameObject proiectil;
    

    // Use this for initialization
    void Awake()
    {
        cameraTransform = GameObject.FindWithTag("MainCamera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Vertical");
        float z = Input.GetAxis("Horizontal");

        bool buttonPressed = Input.GetButton("Fire1");

        Vector3 movement = new Vector3(x, 0.0f, z);

        transform.Translate(movement);

        if (weapon.Ammo <= 0)
        {
            weapon.HasAmmo = false;
        }

        if(!weapon.HasAmmo)
        {
            if(!weapon.Reloading)
            {
                StartCoroutine(weapon.Reload());
            }
        }

        if(buttonPressed & weapon.CanFire & weapon.HasAmmo & !weapon.Reloading)
        {
            StartCoroutine(weapon.Fire());
        }

    }
}
