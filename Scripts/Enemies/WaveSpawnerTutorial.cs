using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawnerTutorial : MonoBehaviour
{
    tutorialPanels tP;
    public GameObject panels;

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject enemy5;
    public GameObject enemy6;
    public GameObject enemy7;
    public GameObject enemy8;
    public GameObject enemy9;
    public GameObject enemy10;
    public GameObject enemy11;
    public GameObject enemy12;

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
    static AudioSource myAudio;
    public static AudioClip meneSound;

    public int waveIndex = 0;

    public bool reachWave;
    bool stopRoutine;
    //public bool newEnemy;
    public Wave[] waves;

    void Start()
    {
        tP = FindObjectOfType<tutorialPanels>();
        meneSound = Resources.Load<AudioClip>("Menacing1");
        myAudio = GetComponent<AudioSource>();
        planeS = FindObjectOfType<planeSwitch>();
        stopRoutine = true;
    }
    // Update is called once per frame
    void Update()
    {
        waveCountdownText.text = waveIndex.ToString();

        if(tP.triggerNo == 10 && stopRoutine == true)
		{
            StartCoroutine(SpawnEnemyWave1());
            stopRoutine = false;
		}

        if (tP.triggerNo == 13 && stopRoutine == false)
		{
            StartCoroutine(RegainTime1());
            stopRoutine = true;
        }

        if(tP.triggerNo == 16 && stopRoutine == true)
		{
            StartCoroutine(SpawnEnemyWave2());
            stopRoutine = false;
		}

        if (tP.triggerNo == 18 && stopRoutine == false)
        {
            StartCoroutine(RegainTime2());
            stopRoutine = true;
        }

        if (tP.triggerNo == 21 && stopRoutine == true)
        {
            StartCoroutine(RegainTime3());
            stopRoutine = false;
        }

        if (tP.triggerNo == 26 && stopRoutine == false)
        {
            StartCoroutine(SpawnEnemyWave3());
            stopRoutine = true;
        }

        if (tP.triggerNo == 29 && stopRoutine == true)
        {
            StartCoroutine(RegainTime4());
            stopRoutine = false;
        }

        if (tP.triggerNo == 31 && stopRoutine == false)
        {
            StartCoroutine(RegainTime5());
            stopRoutine = true;
        }
    }

    IEnumerator SpawnEnemyWave1()
	{
        panels.SetActive(false);
        waveIndex = 1;
        Instantiate(enemy4, spawnPoint2.position, spawnPoint2.rotation);

        yield return new WaitForSeconds(3f);

        Instantiate(enemy2, spawnPoint2.position, spawnPoint2.rotation);

        yield return new WaitForSeconds(4f);

        Time.timeScale = 0;
        tP.triggerNo = 12;
        panels.SetActive(true);
    }

    IEnumerator SpawnEnemyWave2()
    {
        panels.SetActive(false);
        waveIndex = 2;
        Instantiate(enemy6, spawnPoint2.position, spawnPoint2.rotation);

        yield return new WaitForSeconds(1f);

        Time.timeScale = 0;
        tP.triggerNo = 17;
        panels.SetActive(true);
    }

    IEnumerator SpawnEnemyWave3()
    {
        panels.SetActive(false);
        waveIndex = 3;
        
        Instantiate(enemy4, spawnPoint2.position, spawnPoint2.rotation);
        yield return new WaitForSeconds(0.5f);
        Instantiate(enemy4, spawnPoint2.position, spawnPoint2.rotation);
        yield return new WaitForSeconds(0.5f);
        Instantiate(enemy4, spawnPoint2.position, spawnPoint2.rotation);
        yield return new WaitForSeconds(0.5f);
        Instantiate(enemy4, spawnPoint2.position, spawnPoint2.rotation);

        yield return new WaitForSeconds(2f);

        Instantiate(enemy1, spawnPoint1.position, spawnPoint1.rotation);
        yield return new WaitForSeconds(0.5f);
        Instantiate(enemy1, spawnPoint1.position, spawnPoint1.rotation);
        yield return new WaitForSeconds(0.5f);
        Instantiate(enemy1, spawnPoint1.position, spawnPoint1.rotation);
        yield return new WaitForSeconds(0.5f);
        Instantiate(enemy1, spawnPoint1.position, spawnPoint1.rotation);
        yield return new WaitForSeconds(0.5f);
        Instantiate(enemy12, spawnPoint2.position, spawnPoint2.rotation);
        yield return new WaitForSeconds(1f);

        Time.timeScale = 0;
        tP.triggerNo = 27;
        panels.SetActive(true);
    }

    IEnumerator RegainTime1()
	{
        Time.timeScale = 1;
        panels.SetActive(false);
        yield return new WaitForSeconds(3f);
        tP.triggerNo = 14;
        panels.SetActive(true);
	}

    IEnumerator RegainTime2()
    {
        Time.timeScale = 1;
        panels.SetActive(false);
        yield return new WaitForSeconds(1f);
        Instantiate(enemy8, spawnPoint2.position, spawnPoint2.rotation);
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0;
        tP.triggerNo = 19;
        panels.SetActive(true);
    }

    IEnumerator RegainTime3()
	{
        Time.timeScale = 1;
        panels.SetActive(false);
        yield return new WaitForSeconds(5f);
        tP.triggerNo = 22;
        panels.SetActive(true);
    }

    IEnumerator RegainTime4()
    {
        Time.timeScale = 1;
        panels.SetActive(false);
        yield return new WaitForSeconds(10f);
        Instantiate(enemy10, spawnPoint2.position, spawnPoint2.rotation);
        Time.timeScale = 0;
        tP.triggerNo = 30;
        panels.SetActive(true);
    }

    IEnumerator RegainTime5()
    {
        Time.timeScale = 1;
        panels.SetActive(false);
        yield return new WaitForSeconds(10f);
        tP.triggerNo = 32;
        panels.SetActive(true);
    }
}
