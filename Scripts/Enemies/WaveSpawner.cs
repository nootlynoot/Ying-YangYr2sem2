using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public GameObject[] enemy1;
    public GameObject[] enemy2;
    /*public GameObject[] enemy3;
    public GameObject[] enemy4;*/
    /*public Transform enemyPrefab1;
    public Transform enemyPrefab2;*/

    public Transform spawnPoint1;
    public Transform spawnPoint2;
    /*public Transform spawnPoint3;
    public Transform spawnPoint4;*/

    public float timeBetweenWaves = 15f;
    private float countDown = 7f;

    public Text waveCountdownText;
    public GameObject waveIncomingText;
    private planeSwitch planeS;
    public GameObject black;
    public GameObject white;
    public GameObject black2;
    public GameObject white2;
    AudioSource myAudio;
    public AudioClip meneSound;

    public int waveIndex = 0;

    public bool reachWave;
    //public bool newEnemy;
    public Wave[] waves;

    void Start()
    {
        myAudio = GetComponent<AudioSource>();
        planeS = FindObjectOfType<planeSwitch>();
    }
    // Update is called once per frame
    void Update()
    {
        // set reachwave to true if it is wave 6, set reachwave to false if it is not wave 6
        if (waveIndex >= 6)
        {
            reachWave = true;
        }
        else if (waveIndex != 6)
        {
            reachWave = false;
        }

        /*if (waveIndex <= 4)
        {
            newEnemy = false;
        }
        else if (waveIndex >= 5)
        {
            newEnemy = true;
        }*/

        // Set wave incoming text active if countdown is less than 5 seconds but more than 0
        if (countDown > 0f && countDown < 5f && reachWave == false)
        {
            waveIncomingText.SetActive(true);
            if (planeS.trigger == false)
            {
                myAudio.PlayOneShot(meneSound);
                white.SetActive(false);
                black.SetActive(true);
                white2.SetActive(false);
                black2.SetActive(true);
            }
            if (planeS.trigger == true)
            {
                myAudio.PlayOneShot(meneSound);
                black.SetActive(false);
                white.SetActive(true);
                black2.SetActive(false);
                white2.SetActive(true);
            }
            /*waveIncomingText.SetActive(true);*/
        }
        // Spawn the wave when countdown hits 0 and set countdown to follow time between wave
        if (countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            /*if (waveIndex < 4)
            {
                StartCoroutine(SpawnWave());
            }
            else if (waveIndex > 4)
            {
                StartCoroutine(SpawnNewWave());
            }*/
            countDown = timeBetweenWaves;
        }

        countDown -= Time.deltaTime;

        /*waveCountdownText.text = Mathf.Round(countDown).ToString();*/

        waveCountdownText.text = waveIndex.ToString();
    }

    IEnumerator SpawnWave()
    {
        // if it is not wave 6(reach wave is false) and it is not wave 5, then spawn normal enemies
        while (reachWave == false && waveIndex < 5)
        {
            waveIndex++;
            Wave wave = waves[waveIndex];
            waveIncomingText.SetActive(false);
            for (int i = 0; i < wave.count; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(1f / wave.rate);
                
            }
            //Wait();
            break;
        }
        // if it is not wave 6 and it is 5 and above, then add speed enemies on top of normal enemies
        while (reachWave == false && waveIndex > 4)
        {
            waveIndex++;
            Wave wave = waves[waveIndex];
            waveIncomingText.SetActive(false);
            for (int i = 0; i < wave.count; i++)
            {
                SpawnExtraEnemy();
                yield return new WaitForSeconds(1f / wave.rate);
                
            }
            //Wait();
            break;
        }
    }

    /*IEnumerator SpawnNewWave()
    {
        while (reachWave == false)
        {
            Wave wave = waves[waveIndex];
            waveIncomingText.SetActive(false);
            for (int i = 0; i < wave.count; i++)
            {
                SpawnExtraEnemy();
                yield return new WaitForSeconds(1f / wave.rate);
            }
            waveIndex++;

        }
    }*/

    void SpawnEnemy()
    {
        // Instantiate enemy at their respective spawn points.
        Instantiate(enemy1[Random.Range(0, 2)], spawnPoint1.position, spawnPoint1.rotation);
        Instantiate(enemy2[Random.Range(0, 2)], spawnPoint2.position, spawnPoint2.rotation);
    }

    void SpawnExtraEnemy()
    {
        Instantiate(enemy1[Random.Range(0, enemy1.Length)], spawnPoint1.position, spawnPoint1.rotation);
        Instantiate(enemy2[Random.Range(0, enemy2.Length)], spawnPoint2.position, spawnPoint2.rotation);
    }
}
