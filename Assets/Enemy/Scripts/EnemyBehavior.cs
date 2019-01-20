using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private EnemyData stats;
    [SerializeField] private float health;
    [SerializeField] private float damage = 10;
    [SerializeField] private PlayerController playerInstance;
    [SerializeField] private float attackRateMin = 3f;
    [SerializeField] private float attackRateMax = 5f;
    [SerializeField] private bool attacking = false;
    private bool dead = false;

    Animator animator;

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
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!attacking)
        {
            Attack();
        }

        Vector3 direction = (playerInstance.gameObject.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
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
        if(playerInstance.health > 0)
            StartCoroutine("AttackAfterDelay");
    }

    public IEnumerator AttackAfterDelay()
    {
        attacking = true;
        float currentAttackRate = Random.Range(attackRateMin, attackRateMax);
        Debug.Log(currentAttackRate);
        yield return new WaitForSeconds(currentAttackRate);
        animator.SetTrigger("Attack");
        if (playerInstance.health > 0)
            playerInstance.ApplyDamage(damage);
        attacking = false;
    }

    public void Die()
    {
        playerInstance.ApplyDamage(-damage);
        Destroy(gameObject);
    }
}
