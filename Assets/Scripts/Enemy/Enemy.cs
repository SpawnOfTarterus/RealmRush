﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform targetPoint = null;
    [SerializeField] GameObject hitFX = null;
    [SerializeField] GameObject deathFX = null;
    [SerializeField] GameObject exploadFX = null;
    [SerializeField] int scoreValue = 10;
    public Transform FXParent;
         
    public Transform GetTargetPoint()
    {
        return targetPoint;
    }

    private void OnParticleCollision(GameObject other)
    {
        int damage = other.GetComponentInParent<Tower>().GetDamage();
        if (GetComponent<Health>().enabled == false) { PlayHitFX(); return; }
        GetComponent<Health>().TakeDamage(damage);
    }

    public void PlayHitFX()
    {
        GameObject hitFXInstance = Instantiate(hitFX, targetPoint.position, Quaternion.identity, FXParent);
        float deathDelay = hitFXInstance.GetComponent<ParticleSystem>().main.duration;
        AudioSource.PlayClipAtPoint(FindObjectOfType<SoundHub>().PlayTowerFiringSound(), Camera.main.transform.position, .05f);
        Destroy(hitFXInstance, deathDelay);
    }

    public void PlayDeathFX()
    {
        GameObject deathFXInstance = Instantiate(deathFX, gameObject.transform.position, Quaternion.identity, FXParent);
        float deathDelay = deathFXInstance.GetComponent<ParticleSystem>().main.duration;
        AudioSource.PlayClipAtPoint(FindObjectOfType<SoundHub>().PlayEnemyDeathSound(), Camera.main.transform.position, .05f);
        Destroy(deathFXInstance, deathDelay);
    }

    public void ExploadOnTarget()
    {
        if (GetComponent<EnemyMovement>().levelLost) { return; }
        AudioSource.PlayClipAtPoint(FindObjectOfType<SoundHub>().PlayExplosionSound(), Camera.main.transform.position, .1f);
        GameObject exploadFXInstance = Instantiate(exploadFX, gameObject.transform.position, Quaternion.identity, FXParent);
        float deathDelay = exploadFXInstance.GetComponent<ParticleSystem>().main.duration;
        Destroy(exploadFXInstance, deathDelay);
        if (FindObjectOfType<LivesControl>()) { FindObjectOfType<LivesControl>().LoseLife(); }
        FindObjectOfType<EnemySpawner>().RemoveEnemyFromInPlayList(this);
        Destroy(gameObject);
    }

    public void Die()
    {
        if(GetComponent<EnemyMovement>().levelLost) { return; }
        PlayDeathFX();
        FindObjectOfType<ScoreControl>().AddToScore(scoreValue);
        FindObjectOfType<EnemySpawner>().RemoveEnemyFromInPlayList(this);
        Destroy(gameObject);
    }

    public void ExploadOnGameOver()
    {
        GameObject exploadFXInstance = Instantiate(exploadFX, gameObject.transform.position, Quaternion.identity, FXParent);
        AudioSource.PlayClipAtPoint(FindObjectOfType<SoundHub>().PlayExplosionSound(), Camera.main.transform.position, .1f);
        float deathDelay = exploadFXInstance.GetComponent<ParticleSystem>().main.duration;
        Destroy(exploadFXInstance, deathDelay);
        FindObjectOfType<EnemySpawner>().RemoveEnemyFromInPlayList(this);
        Destroy(gameObject);
    }
}
