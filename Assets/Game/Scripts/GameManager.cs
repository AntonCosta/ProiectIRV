using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    [SerializeField] public GameObject playerSpawnPoint;
    [SerializeField] GameObject playerPrefab;

    #region Properties
    public GameObject Player { get => playerPrefab; }
    #endregion

    private void Awake()
    {
        Debug.Log("GameManager is Awake");
        if(Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        SetupScene();
    }

    private void SpawnPlayer()
    {
        if(playerSpawnPoint == null)
        {
            playerSpawnPoint = Loader.Instance.PlayerSpawnPoint;
        }
        playerPrefab = Instantiate(playerPrefab);
        playerPrefab.transform.position = playerSpawnPoint.transform.position;
        playerPrefab.transform.rotation = playerSpawnPoint.transform.rotation;
    }

    private void SpawnEnemies()
    {

    }

    private void SetupScene()
    {
        SpawnPlayer();
        SpawnEnemies();
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
