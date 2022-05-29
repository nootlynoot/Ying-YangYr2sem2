using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Endpoint : MonoBehaviour
{
    public int white = 0;
    public int black = 0;

    public AudioClip popSound;
    public GameObject boomFX;
    public GameObject popFX;
    public GameObject blackParticle, whiteParticle;
    /*public Image wellOfBalance;

    public Sprite balance;
    public Sprite unbalanceYin2;
    public Sprite unbalanceYin4;
    public Sprite unbalanceYin6;
    public Sprite unbalanceYin;

    public Sprite unbalanceYang2;
    public Sprite unbalanceYang4;
    public Sprite unbalanceYang6;
    public Sprite unbalanceYang;*/

    public Sprite[] wordW;
    public Sprite[] wordB;
    AudioSource myAudio;

    private WaveSpawner waveS;

    public int balancew;
    public int balanceb;

    // Start is called before the first frame update
    void Start()
    {
        waveS = FindObjectOfType<WaveSpawner>();
        myAudio = GetComponent<AudioSource>();
        boomFX.SetActive(false);
        popFX.SetActive(false);
        blackParticle.SetActive(false);
        whiteParticle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        balanceb = black - white;
        balancew = white - black;

        /*if (black == white)
        {
            balance = true;
        }
        if (white - black >= 4 && white - black < 6)
        {
            unbalanceWhite1 = true;
        }
*/
        /*if (black - white >= 8 || white - black >= 8 || waveS.waveIndex == 5 && white != black)
        {
            Debug.Log("ded");

            boomFX.SetActive(true);
        }*/
    }

    IEnumerator PopActive()
    {
        //Debug.Log("popactive ran");

        popFX.SetActive(true);

        yield return new WaitForSeconds(1);

        popFX.SetActive(false);
    }

    IEnumerator WhiteParti()
    {
        whiteParticle.SetActive(true);

        yield return new WaitForSeconds(1);

        whiteParticle.SetActive(false);
    }

    IEnumerator BlackParti()
    {
        blackParticle.SetActive(true);

        yield return new WaitForSeconds(1);

        blackParticle.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        // Increase Yin/Yang based on type of enemy that enters the well.
        if (other.tag == "EnemyW")
        {
            white+=1;
            //myAudio.PlayOneShot(popSound, 0.5f);
            StartCoroutine(PopActive());
            StartCoroutine(WhiteParti());
            /*Debug.Log(white);          
            Debug.Log("White increased");*/
        }

        if (other.tag == "EnemyB")
        {
            black+=1;
            //myAudio.PlayOneShot(popSound, 0.5f);
            StartCoroutine(PopActive());
            StartCoroutine(BlackParti());
            /*Debug.Log(black);
            Debug.Log("Black increased");*/
        }
    }
}
