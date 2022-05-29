using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class propsSwitch : MonoBehaviour
{
	public GameObject black, white;

	// Start is called before the first frame update
	void Start()
	{
		ChangeProp(true);
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	public void ChangeProp(bool b)
	{
		if (!b)
		{
			black.SetActive(false);
			white.SetActive(true);
		}
		else
		{
			black.SetActive(true);
			white.SetActive(false);
		}
	}
}
