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

    private Transform mainCamera;

    #region Properties
    public int Ammo { get => ammo; set => ammo = value; }
    public bool CanFire { get => canFire; set => canFire = value; }
    public bool HasAmmo { get => hasAmmo; set => hasAmmo = value; }
    public bool Reloading { get => reloading; set => reloading = value; }
    #endregion

    // Start is called before the first frame update
    public void OnEnable()
    {        
        ammo = maxAmmo;
        canFire = true;
        hasAmmo = true;
        reloading = false;
        Debug.Log("Weapon Started");
    }

    public void SetCamera()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    public IEnumerator Fire()
    {
        GameObject newInstance = Instantiate(projectile.gameObject);
        newInstance.transform.position = mainCamera.position + mainCamera.forward * 2;
        newInstance.transform.rotation = mainCamera.rotation;
        ammo--;
        canFire = false;
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }

    public IEnumerator Reload()
    {
        reloading = true;
        yield return new WaitForSeconds(reloadTime);
        reloading = false;
        ammo = maxAmmo;
        hasAmmo = true;
    }
}
