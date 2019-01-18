using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Class used to load scene elements correctly within the level.
/// </summary>
public class Loader : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject playerSpawnPoint;
    public static Loader Instance = null;

    public GameObject PlayerSpawnPoint
    {
        get
        {
            return playerSpawnPoint;
        }
    }

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        if(GameManager.Instance == null)
        {
            Instantiate(gameManager);
            GameManager.Instance.playerSpawnPoint = playerSpawnPoint;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
