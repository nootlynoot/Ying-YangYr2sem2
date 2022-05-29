using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretShoot : MonoBehaviour
{
    //Shooting variables
    public GameObject bulletPrefab;
    public GameObject waves;
    public Transform firePoint;
    public Animator anim;
    public float fireRate = 1f;
    public float fireCountdown = 0f;

    //Effective range & targetting variables
    public Transform target;
    public float range = 10f;
    public float turnSpeed = 10f;

    //Color coding variables
    public string enemyWhiteTag = "EnemyW";
    public string enemyBlackTag = "EnemyB";

    public void Start()
    {
        anim = GetComponent<Animator>();
        waves.SetActive(false);
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    public void Update()
    {
        if (target == null)
        {
            return;
        }

        //Target lockon
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        StartCoroutine(WaveActive());
        StartCoroutine(AnimActive());
        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet bullet = bulletGO.GetComponent<bullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    IEnumerator WaveActive()
    {
        waves.SetActive(true);

        yield return new WaitForSeconds(1);

        waves.SetActive(false);
    }

    public IEnumerator AnimActive()
    {
        anim.SetBool("Fire",true);

        yield return new WaitForSeconds(1f);

        anim.SetBool("Fire",false);
    }
}
