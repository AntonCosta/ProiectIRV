using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform cameraTransform;
    [SerializeField] Weapon weapon;

    // Use this for initialization
    void Awake()
    {
        cameraTransform = GameObject.FindWithTag("MainCamera").transform;
        Debug.Log(weapon.CanFire);
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Vertical");
        float z = Input.GetAxis("Horizontal");

        bool buttonPressed = Input.GetButton("Fire1");

        if (weapon.Ammo <= 0)
        {
            Debug.Log("Out of ammo");
            weapon.HasAmmo = false;
        }

        if (!weapon.HasAmmo)
        {
            Debug.Log("No ammo");
            if(!weapon.Reloading)
            {
                StartCoroutine(weapon.Reload());
            }
        }

        if (buttonPressed & weapon.CanFire & weapon.HasAmmo & !weapon.Reloading)
        {
            Debug.Log("Trying to fire");
            StartCoroutine(weapon.Fire());
        }
    }
}
