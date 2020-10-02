using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform towerTop = null;
    Enemy target = null;
    [SerializeField] GameObject gun = null;
    int gridSize = 10;
    [SerializeField] int damage = 10;
    [SerializeField] float fireRange = 4.9f;
    Quaternion idlePos;
    float targetDistance = 0;
    public BuildLocation builtPosition;

    public int GetDamage()
    {
        return damage;
    }

    private void Start()
    {
        idlePos = Quaternion.Euler(towerTop.rotation.x, towerTop.rotation.y + 180, towerTop.rotation.z);
    }

    // Update is called once per frame
    void Update()
    {
        SetTarget();
        LookAtTarget();
        Fire();
    }

    private void LookAtTarget()
    {
        if(CheckIfTargetIsInRange())
        {
            towerTop.LookAt(target.GetTargetPoint());
        }
        else
        {
            towerTop.rotation = idlePos;
        }
    }

    private void Fire()
    {
        gun.SetActive(CheckIfTargetIsInRange());
    }

    private bool CheckIfTargetIsInRange()
    {
        if(!target) { return false; }
        var distance = Vector3.Distance(target.transform.position, transform.position) / gridSize;
        return distance <= fireRange;
    }

    private void SetTarget()
    {
        var targets = FindObjectsOfType<Enemy>();
        if(targets.Length <= 0) { target = null; return; }
        target = targets[0];
        foreach(Enemy enemy in targets)
        {
            var myDistance = Vector3.Distance(enemy.transform.position, transform.position);
            targetDistance = Vector3.Distance(target.transform.position, transform.position);
            if(myDistance < targetDistance)
            {
                target = enemy;
            }
        }   
    }
}
