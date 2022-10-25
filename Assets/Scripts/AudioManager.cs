using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip _smallEnemyDeathSound;
    public AudioClip _mediumEnemyDeathSound;
    public AudioClip _playerDeathSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SmallEnemyDeathSound()
    {
        audioSource.PlayOneShot(_smallEnemyDeathSound);
    }

    public void PlayerDeathSound()
    {
        audioSource.PlayOneShot(_playerDeathSound);
    }
}
