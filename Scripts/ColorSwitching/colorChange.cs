using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorChange : MonoBehaviour
{
    private float finalRadius = 80;

    private float defaultRadius = 1;

    public float increaseSpeed = 1;

    private bool radiusTrigger;

    public int cooldown = 1;

    private float timeStamp;

    SphereCollider myCol;

    private planeSwitch planeS;
    public GameObject transitionText;
    public GameObject black;
    public GameObject white;

    public bool trigger;
    // Start is called before the first frame update
    void Start()
    {
        planeS = FindObjectOfType<planeSwitch>();

        timeStamp = Time.time + cooldown;

        radiusTrigger = false;

        myCol = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("space"))
        {
            if (radiusTrigger == false && timeStamp <= Time.time)
            {
                radiusTrigger = true;
                timeStamp = Time.time + cooldown;

                StartCoroutine(Transition());
            }
            else if (radiusTrigger == true && timeStamp <= Time.time)
            {
                radiusTrigger = false;
                timeStamp = Time.time + cooldown;

                StartCoroutine(Transition());
            }
        }

        if(radiusTrigger == false)
        {
            RadiusDown();
        }
        else
        {
            RadiusUp();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        propsSwitch p = other.GetComponent<propsSwitch>();
        if(p)
        {
            p.ChangeProp(false);
            trigger = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        propsSwitch p = other.GetComponent<propsSwitch>();
        if (p)
        {
            p.ChangeProp(true);
            trigger = true;
        }
    }


    void RadiusUp()
    {
        if (myCol.radius < finalRadius)
        {
            myCol.radius += 1f * increaseSpeed * Time.deltaTime;
        }

        if (myCol.radius > finalRadius)
        {
            myCol.radius = finalRadius;
        }
    }

    void RadiusDown()
    {
        if (myCol.radius > defaultRadius)
        {
            myCol.radius -= 1f * increaseSpeed * Time.deltaTime;
        }

        if (myCol.radius < defaultRadius)
        {
            myCol.radius = defaultRadius;
        }
    }

    IEnumerator Transition()
    {
        transitionText.SetActive(true);
        if (planeS.trigger == false)
        {
            white.SetActive(false);
            black.SetActive(true);
        }
        if (planeS.trigger == true)
        {
            black.SetActive(false);
            white.SetActive(true);
        }

        yield return new WaitForSeconds(2f);
        transitionText.SetActive(false);
    }
}
