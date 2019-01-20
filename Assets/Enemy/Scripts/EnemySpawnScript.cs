using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private GameObject enemyInstance;
    private bool enemySpawned = false;
    private bool enemyDead = false;

    #region Properties
    public bool EnemyDead { get => enemyDead; set => enemyDead = value; }
    #endregion

    // Start is called before the first frame update
    void OnEnable()
    {
        enemyInstance = Instantiate(enemyPrefab, transform);
        enemySpawned = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyInstance == null)
        {
            enemySpawned = false;
            enemyDead = true;
            gameObject.SetActive(false);
        }
    }
}
