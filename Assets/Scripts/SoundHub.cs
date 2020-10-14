using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHub : MonoBehaviour
{
    [SerializeField] AudioClip[] towerFiring = null;
    [SerializeField] AudioClip[] enemyDeath = null;
    [SerializeField] AudioClip explosion = null;

    private void Awake()
    {
        var amount = FindObjectsOfType<SoundHub>();
        if (amount.Length > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        var myAudioSource = GetComponent<AudioSource>();
        myAudioSource.Play();
    }

    public AudioClip PlayTowerFiringSound()
    {
        var thisClip = towerFiring[Random.Range(0, towerFiring.Length)];
        return thisClip;
    }

    public AudioClip PlayEnemyDeathSound()
    {
        var thisClip = enemyDeath[Random.Range(0, enemyDeath.Length)];
        return thisClip;
    }

    public AudioClip PlayExplosionSound()
    {
        return explosion;
    }



}
