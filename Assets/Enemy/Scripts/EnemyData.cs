using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/EnemyData")]
public class EnemyData : ScriptableObject
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private float damage;

    public float MaxHealth { get => maxHealth; set => maxHealth = value; }
    public float Damage { get => damage; set => damage = value; }

    // Start is called before the first frame update
    void OnEnable()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
