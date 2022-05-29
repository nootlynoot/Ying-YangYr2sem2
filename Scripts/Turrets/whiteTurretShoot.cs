using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whiteTurretShoot : turretShoot
{

    void UpdateTarget()
    {
        // Shoot white enemies if turret's tag is white
        if (gameObject.tag == "White")
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyWhiteTag);
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
