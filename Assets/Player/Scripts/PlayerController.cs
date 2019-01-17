using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform cameraTransform;
    [SerializeField] Weapon weapon;
    Quaternion targetRotation;

    [SerializeField] private float moveSpeed = 0.1f; //might be too fast

    [SerializeField] GameObject proiectil;

    private Vector3 baseMovement = new Vector3(0.0f, 0.0f, 0.5f);

    public int direction = 0;

    private bool wait = false;

    public float waitTime = 1;

    public bool rotate = false;
    //pt iluzia de rotatie trebuie apelat in update pentru a se misca incet cu atatea grade, trebuie sa il pacalesc cumva sa faca asta numa upa wait

    // Use this for initialization
    void Awake()
    {
        cameraTransform = GameObject.FindWithTag("MainCamera").transform;
    }

    private void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Vertical");
        float z = Input.GetAxis("Horizontal");

        bool buttonPressed = Input.GetButton("Fire1");

        

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

    private void FixedUpdate()
    {
        if (!wait)
        {
            Vector3 movement = baseMovement * moveSpeed;
            transform.Translate(movement);
        }

        if (rotate)
        {
            TurnInDirection(direction);
        }
    }

    public void SetWaitTime(bool time)
    {
        wait = time;
    }

    public void TurnInDirection(int directionToTurn)//Transform target)// 
    {        
        Quaternion currentRotation = transform.rotation;
        Quaternion wantedRotation = currentRotation * Quaternion.AngleAxis(directionToTurn, Vector3.up);
        transform.rotation = Quaternion.Slerp(currentRotation, wantedRotation, Time.deltaTime * waitTime);
    }

}
