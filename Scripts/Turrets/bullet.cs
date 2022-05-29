using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;

    public bool modeTrigger;

    enemyHealth enemyHp;
    void Start()
    {
        enemyHp = FindObjectOfType<enemyHealth>();
    }

    public void Seek (Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

		if (dir.magnitude <= distanceThisFrame && modeTrigger == false)
		{
			HitTarget();
			return;
		}

        if(dir.magnitude <= distanceThisFrame && modeTrigger == true)
		{
            StartCoroutine(DestoryOverTime());
            return;
		}

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }

    void HitTarget()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<enemyHealth1>().TakeDamage();
    }

    IEnumerator DestoryOverTime()
	{
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
	}
}
