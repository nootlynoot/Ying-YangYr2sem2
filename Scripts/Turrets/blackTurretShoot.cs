using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blackTurretShoot : turretShoot
{
    void UpdateTarget()
    {
        // Shoot black enemies if turret's tag is black
        if (gameObject.tag == "Black")
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyBlackTag);
            float shortestDistance = Mathf.Infinity;
            GameObject nearestEnemy = null;

            foreach (GameObject enemy in enemies)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if (distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy;
                }
            }

            if (nearestEnemy != null && shortestDistance <= range)
            {
                target = nearestEnemy.transform;
            }
            else
            {
                target = null;
            }
        }
    }
}
