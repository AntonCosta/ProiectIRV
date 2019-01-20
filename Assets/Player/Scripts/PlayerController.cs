using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public Transform cameraTransform;
    public GameObject camera;
    public GameObject canvas;
    public TextMeshProUGUI healthText;
    [SerializeField] public float health = 100f;
    [SerializeField] private Image redFlash;
    [SerializeField] private Image greenFlash;
    [SerializeField] private RawImage tunnelImage;


    [SerializeField] private GameObject healthDisplay;
    [SerializeField] private Weapon weapon;
    [SerializeField] private float moveSpeed = 0.1f; //might be too fast
    private Quaternion targetRotation;
    private Vector3 baseMovement = new Vector3(0.0f, 0.0f, 0.5f);
    public int direction = 0;

    private bool wait = false;

    public float waitTime = 1;

    public bool rotate = false;

    // Use this for initialization
    void Awake()
    {
        camera = GameObject.FindWithTag("MainCamera");
        cameraTransform = camera.transform;
    }

    private void Start()
    {
        healthText = healthDisplay.GetComponent<TextMeshProUGUI>();
        healthText.SetText(health.ToString() + "%");
        weapon.SetCamera();
    }

    // Update is called once per frame
    void Update()
    {
        bool buttonPressed = Input.GetButton("Fire3");

        if (weapon.Ammo <= 0)
        {
            weapon.HasAmmo = false;
        }

        if (!weapon.HasAmmo)
        {
            if (!weapon.Reloading)
            {
                StartCoroutine(weapon.Reload());
            }
        }

        if (buttonPressed & weapon.CanFire & weapon.HasAmmo & !weapon.Reloading)
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
            tunnelImage.gameObject.SetActive(true);
        }
        else
        {
            tunnelImage.gameObject.SetActive(false);
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

    public void ApplyDamage(float amount)
    {
        Debug.Log("Player taking damage: " + amount);
        health -= amount;
        if(amount > 0)
            StartCoroutine(FlashDamage());
        else
            StartCoroutine(FlashHeal());

        healthText.SetText(health.ToString() + "%");
        if (health <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        Debug.Log("You are dead");
        redFlash.gameObject.SetActive(true);
        gameObject.GetComponent<Rigidbody>().useGravity = true;
    }

    public IEnumerator FlashDamage()
    {
        redFlash.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        if (health > 0)
            redFlash.gameObject.SetActive(false);
    }

    public IEnumerator FlashHeal()
    {
        greenFlash.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        greenFlash.gameObject.SetActive(false);
    }
}
