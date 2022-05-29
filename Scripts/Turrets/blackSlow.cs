using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blackSlow : MonoBehaviour
{
	public GameObject shockwave;
	public GameObject gongFX;
	Animator anim;
	static AudioSource myAudio;
	public static AudioClip gongSound;

	// Start is called before the first frame update
	void Start()
	{
		gongSound = Resources.Load<AudioClip>("Gong3");
		myAudio = GetComponent<AudioSource>();
		anim = GetComponent<Animator>();
		gongFX.SetActive(false);
		anim.SetBool("Slow", false);
		shockwave.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnTriggerStay(Collider other)
	{
		if (gameObject.tag == "Black" && other.gameObject.tag == "EnemyB")
		{
			gongFX.SetActive(true);
			shockwave.SetActive(true);
			anim.SetBool("Slow", true);
			StartCoroutine(Gong());
			enemyHealth1 eh = GetComponent<enemyHealth1>();
			eh.slow = true;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (gameObject.tag == "Black" && other.gameObject.CompareTag("EnemyB"))
		{
			StartCoroutine(Gong());
		}
	}

	private void OnTriggerExit(Collider other)
	{
		shockwave.SetActive(false);
		gongFX.SetActive(false);
		anim.SetBool("Slow", false);
		enemyHealth1 eh = GetComponent<enemyHealth1>();
		eh.slow = false;
	}

	IEnumerator Gong()
	{
		//myAudio.PlayOneShot(gongSound);
		yield return new WaitForSeconds(1f);
	}
}
