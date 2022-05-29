using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealth1: MonoBehaviour
{
    public float hp;
    public Image[] healthBar;
    public GameObject dieFX;
    PlayerStats pS;
    AudioSource myAudio;
    public AudioClip poofSound;
    public GameObject deathEffect;
    public float speed = 10f;
    public GameObject ghostBody;

    [HideInInspector]
    public int enemiesDown;
    float originalSpeed;
    public bool slow;

    /*    public GameObject poofText;*/

    // Start is called before the first frame update
    void Start()
    {
        originalSpeed = speed;
        slow = false;
        deathEffect.SetActive(false);
        ghostBody.SetActive(true);
        myAudio = GetComponent<AudioSource>();
        pS = FindObjectOfType<PlayerStats>();
        dieFX.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (hp == 5)
        {
            healthBar[0].enabled = true;
            healthBar[1].enabled = false;
            healthBar[2].enabled = false;
            healthBar[3].enabled = false;
            healthBar[4].enabled = false;
        }

        if (hp == 4)
        {
            healthBar[0].enabled = false;
            healthBar[1].enabled = true;
            healthBar[2].enabled = false;
            healthBar[3].enabled = false;
            healthBar[4].enabled = false;
        }

        if (hp == 3)
        {
            healthBar[0].enabled = false;
            healthBar[1].enabled = false;
            healthBar[2].enabled = true;
            healthBar[3].enabled = false;
            healthBar[4].enabled = false;
        }

        if (hp == 2)
        {
            healthBar[0].enabled = false;
            healthBar[1].enabled = false;
            healthBar[2].enabled = false;
            healthBar[3].enabled = true;
            healthBar[4].enabled = false;
        }
        if (hp == 1)
        {
            healthBar[0].enabled = false;
            healthBar[1].enabled = false;
            healthBar[2].enabled = false;
            healthBar[3].enabled = false;
            healthBar[4].enabled = true;
        }
        if (hp == 0)
        {
            healthBar[0].enabled = false;
            healthBar[1].enabled = false;
            healthBar[2].enabled = false;
            healthBar[3].enabled = false;
            healthBar[4].enabled = false;
        }

        if(slow)
		{
            speed /= 2;
		}
		else
		{
            speed = originalSpeed;
		}

        enemyDie();
    }

    public void enemyDie()
    {
        if (hp <= 0f)
        {
            enemiesDown += 1;
            StartCoroutine(Poof());
        }
    }

    public void TakeDamage()
    {
        hp -= 1f;
    }

    IEnumerator Poof()
    {
        gameObject.tag = "Untagged";
        ghostBody.SetActive(false);
        deathEffect.SetActive(true);
        dieFX.SetActive(true);
        myAudio.PlayOneShot(poofSound,0.5f);
        yield return new WaitForSeconds(0.5f);
        pS.Money += 5;
        Destroy(gameObject);
    }
}
