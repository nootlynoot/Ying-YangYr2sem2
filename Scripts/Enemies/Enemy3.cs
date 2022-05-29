using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    enemyHealth1 eH;
    public Transform target;
    private int wavepointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        eH = GetComponent<enemyHealth1>();
        target = Waypoints3.points[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * eH.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints3.points.Length - 1)
        {
            EndPath();
            return;
        }

        wavepointIndex++;
        target = Waypoints3.points[wavepointIndex];
    }

    void EndPath()
    {
        Destroy(gameObject);
    }
}
