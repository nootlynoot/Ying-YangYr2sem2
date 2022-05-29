using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretSwitch : MonoBehaviour
{
	public GameObject black, white;

	public bool trigger;

	public int cooldown = 1;

	private float timeStamp;

	// Start is called before the first frame update
	void Start()
	{
		trigger = false;

		//timeStamp = Time.time + cooldown;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			if (trigger == false && timeStamp <= Time.time)
			{
				trigger = true;
				timeStamp = Time.time + cooldown;
			}
			else if (trigger == true && timeStamp <= Time.time)
			{
				trigger = false;
				timeStamp = Time.time + cooldown;
			}
		}


		if (!trigger)
		{
			black.SetActive(true);
			white.SetActive(false);
		}
		else
		{
			black.SetActive(false);
			white.SetActive(true);
		}
	}
}
