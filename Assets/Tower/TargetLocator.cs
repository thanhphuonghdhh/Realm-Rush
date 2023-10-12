using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] Transform target;
    [SerializeField] float range = 15f;
    [SerializeField] ParticleSystem particle;

    void Update()
    {
        FindClosestTarget();
        AimTarget();    
    }

    void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        float minDistance = float.MaxValue;
        Transform closestTarget = null;
        foreach (Enemy enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            if (distance < minDistance)
            {
                minDistance = distance;
                closestTarget = enemy.transform;
            }

        }
        target = closestTarget;

    }
    void AimTarget()
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);
        
        weapon.LookAt(target);

        if (targetDistance < range) Attack(true); else Attack(false);
    }

    void Attack(bool isAttack)
    {
        var emissionModule = particle.emission;
        emissionModule.enabled = isAttack;
    }
}
