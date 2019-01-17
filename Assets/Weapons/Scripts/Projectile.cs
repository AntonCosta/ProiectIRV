using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float damage = 25f;
    public float Damage { get => damage; set => damage = value; }

    // Start is called before the first frame update
    void OnEnable()
    {
        print(GetComponent<SphereCollider>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.position += transform.forward;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.GetComponent<EnemyBehavior>().ApplyDamage(damage);
            Debug.Log("Collided with enemy");
        }
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
