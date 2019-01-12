using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Weapon")]
public class Weapon : ScriptableObject
{
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private float damage = 1;
    [SerializeField] private int maxAmmo = 10;
    [SerializeField] private int ammo;
    [SerializeField] private float reloadTime = 2.0f;
    [SerializeField] private Projectile projectile;
    [SerializeField] private bool canFire = true;
    [SerializeField] private bool hasAmmo = true;
    [SerializeField] private bool reloading = false;
    [SerializeField] private PlayerController player;
    [SerializeField] private Transform mainCamera;

    #region Properties
    public int Ammo { get => ammo; set => ammo = value; }
    public bool CanFire { get => canFire; set => canFire = value; }
    public bool HasAmmo { get => hasAmmo; set => hasAmmo = value; }
    public bool Reloading { get => reloading; set => reloading = value; }
    #endregion

    // Start is called before the first frame update
    public void OnEnable()
    {
        player = FindObjectOfType<PlayerController>();
        mainCamera = player.cameraTransform;
        ammo = maxAmmo;
        Debug.Log("Weapon Started");
    }

    public IEnumerator Fire()
    {
        Debug.Log("Firing " + ammo);
        GameObject newInstance = Instantiate(projectile.gameObject);
        newInstance.transform.position = mainCamera.position + mainCamera.forward;
        newInstance.transform.rotation = mainCamera.rotation;
        ammo--;
        canFire = false;
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }

    public IEnumerator Reload()
    {
        Debug.Log("Begun reloading");
        reloading = true;
        yield return new WaitForSeconds(reloadTime);
        reloading = false;
        ammo = maxAmmo;
        hasAmmo = true;
    }
}
