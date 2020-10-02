using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform targetPoint = null;
    [SerializeField] GameObject hitFX = null;
    [SerializeField] GameObject deathFX = null;
    [SerializeField] GameObject exploadFX = null;
    public Transform FXParent;
         
    public Transform GetTargetPoint()
    {
        return targetPoint;
    }

    private void OnParticleCollision(GameObject other)
    {
        int damage = other.GetComponentInParent<Tower>().GetDamage();
        GetComponent<Health>().TakeDamage(damage);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void PlayHitFX()
    {
        GameObject hitFXInstance = Instantiate(hitFX, gameObject.transform.position, Quaternion.identity, FXParent);
        float deathDelay = hitFXInstance.GetComponent<ParticleSystem>().main.duration;
        Destroy(hitFXInstance, deathDelay);
    }

    public void PlayDeathFX()
    {
        GameObject deathFXInstance = Instantiate(deathFX, gameObject.transform.position, Quaternion.identity, FXParent);
        float deathDelay = deathFXInstance.GetComponent<ParticleSystem>().main.duration;
        Destroy(deathFXInstance, deathDelay);
    }

    public void ExploadOnTarget()
    {
        GameObject exploadFXInstance = Instantiate(exploadFX, gameObject.transform.position, Quaternion.identity, FXParent);
        float deathDelay = exploadFXInstance.GetComponent<ParticleSystem>().main.duration;
        Destroy(exploadFXInstance, deathDelay);
        Destroy(gameObject);
    }

}
