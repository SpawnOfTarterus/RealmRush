using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform targetPoint = null;
    [SerializeField] GameObject hitFX = null;
    [SerializeField] GameObject deathFX = null;

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
        GameObject hitFXInstance = Instantiate(hitFX, gameObject.transform.position, Quaternion.identity);
        Destroy(hitFXInstance, 1f);
    }

    public void PlayDeathFX()
    {
        GameObject deathFXInstance = Instantiate(deathFX, gameObject.transform.position, Quaternion.identity);
        Destroy(deathFXInstance, 1f);
    }

}
