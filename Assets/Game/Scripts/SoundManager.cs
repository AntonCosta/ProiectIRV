using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance = null;
    [SerializeField] private GameObject playerInstance;
    private AudioSource source;
    public AudioClip Clip;
    public int priority = 100;
    public float volume = 1;
    public float pitch = 1;
    public bool Loop = false;
    public float SpacialBlend = 1f;
    


    // Start is called before the first frame update

    private void Awake()
    {
        Debug.Log("SoundManager is awake");
        if(Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        source = GetComponent<AudioSource>();
        if (source == null)
        {
            source = gameObject.AddComponent<AudioSource>();
        }
        playerInstance = GameManager.Instance.Player;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = playerInstance.transform.position;
        this.transform.rotation = playerInstance.transform.rotation;
    }

    public void SetSourceProperties(AudioClip clip, float volume, int priority, float pitch, bool loop, float spacialBlend)

    {

        source.clip = clip;
        source.volume = volume;
        source.priority = priority;
        source.pitch = pitch;
        source.loop = loop;
        source.spatialBlend = spacialBlend;

    }

    public void Play()

    {

        SetSourceProperties(Clip, volume, priority, pitch, Loop, SpacialBlend);
        source.Play();

    }
}
