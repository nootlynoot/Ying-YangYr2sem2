using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathSwitch : MonoBehaviour
{
    public GameObject blackL, blackR, whiteL, whiteR;

	bool trigger;

	public int cooldown = 1;

	private float timeStamp;

	// Start is called before the first frame update
	void Start()
    {
		trigger = true;

		ChangePath();

		timeStamp = Time.time + cooldown;
	}

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown("space"))
		{
			if (trigger == false && timeStamp <= Time.time)
			{
				trigger = true;
				ChangePath();
				timeStamp = Time.time + cooldown;
			}
			else if (trigger == true && timeStamp <= Time.time)
			{
				trigger = false;
				ChangePath();
				timeStamp = Time.time + cooldown;
			}
		}
    }

	void ChangePath()
	{
		if (trigger == false && timeStamp <= Time.time)
		{
			blackL.SetActive(false);
			blackR.SetActive(false);
			whiteL.SetActive(true);
			whiteR.SetActive(true);
		}
		else if (trigger == true && timeStamp <= Time.time)
		{
			blackL.SetActive(true);
			blackR.SetActive(true);
			whiteL.SetActive(false);
			whiteR.SetActive(false);
		}
	}
}
