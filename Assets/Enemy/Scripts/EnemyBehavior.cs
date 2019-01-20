using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private EnemyData stats;
    [SerializeField] private float health;
    [SerializeField] private float damage = 10;
    [SerializeField] private PlayerController playerInstance;
    [SerializeField] private float attackRateMin = 3f; //Attack rate is actually between this value and its double
    [SerializeField] private float attackRateMax = 5f;
    [SerializeField] private bool attacking = false;

    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        playerInstance = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

        health = stats.MaxHealth;
        damage = stats.Damage;
        attacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!attacking)
        {
            Attack();
        }
    }

    public void ApplyDamage(float projectileDamage)
    {
        health -= projectileDamage;
        Debug.Log(health);
        Debug.Log(projectileDamage);

        if(health<=0)
        {
            Die();
        }
    }

    public void Attack()
    {
        StartCoroutine("AttackAfterDelay");
    }

    public IEnumerator AttackAfterDelay()
    {
        attacking = true;
        float currentAttackRate = Random.Range(attackRateMin, attackRateMax);
        Debug.Log(currentAttackRate);
        yield return new WaitForSeconds(currentAttackRate);
        playerInstance.ApplyDamage(damage);
        attacking = false;
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
