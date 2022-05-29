using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WellOfBalance : MonoBehaviour
{
    private Endpoint endPoint;
    private SpriteRenderer sD;
    //public Sprite[] sprite;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        endPoint = FindObjectOfType<Endpoint>();
        sD = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(UpdateWOB());
    }

    private IEnumerator UpdateWOB()
    {
        if (endPoint.white == endPoint.black)
        {
            anim.SetBool("balance", true);
            anim.SetBool("unbalancew1", false);
            anim.SetBool("unbalancew2", false);
            anim.SetBool("unbalancew3", false);
            anim.SetBool("unbalancew", false);
        }
        if (endPoint.white - endPoint.black >= 1)
        {
            anim.SetBool("unbalancew1", true);
            anim.SetBool("balance", false);
            anim.SetBool("unbalancew2", false);
            anim.SetBool("unbalancew3", false);
            anim.SetBool("unbalancew", false);
        }
        if (endPoint.white - endPoint.black >= 4)
        {
            anim.SetBool("unbalancew2", true);
            anim.SetBool("balance", false);
            anim.SetBool("unbalancew1", false);
            anim.SetBool("unbalancew3", false);
            anim.SetBool("unbalancew", false);
        }
        if (endPoint.white - endPoint.black >= 6)
        {
            anim.SetBool("unbalancew3", true);
            anim.SetBool("balance", false);
            anim.SetBool("unbalancew2", false);
            anim.SetBool("unbalancew1", false);
            anim.SetBool("unbalancew", false);
        }
        if (endPoint.white - endPoint.black >= 8)
        {
            anim.SetBool("unbalancew", true);
            anim.SetBool("balance", false);
            anim.SetBool("unbalancew2", false);
            anim.SetBool("unbalancew3", false);
            anim.SetBool("unbalancew1", false);
        }
        if (endPoint.black - endPoint.white >= 1)
        {
            anim.SetBool("unbalanceb1", true);
            anim.SetBool("balance", false);
            anim.SetBool("unbalanceb2", false);
            anim.SetBool("unbalanceb3", false);
            anim.SetBool("unbalanceb", false);
        }
        if (endPoint.black - endPoint.white >= 4)
        {
            anim.SetBool("unbalanceb2", true);
            anim.SetBool("balance", false);
            anim.SetBool("unbalanceb1", false);
            anim.SetBool("unbalanceb3", false);
            anim.SetBool("unbalanceb", false);
        }
        if (endPoint.black - endPoint.white >= 6)
        {
            anim.SetBool("unbalanceb3", true);
            anim.SetBool("balance", false);
            anim.SetBool("unbalanceb2", false);
            anim.SetBool("unbalanceb1", false);
            anim.SetBool("unbalanceb", false);
        }
        if (endPoint.black - endPoint.white >= 8)
        {
            anim.SetBool("unbalanceb", true);
            anim.SetBool("balance", false);
            anim.SetBool("unbalanceb2", false);
            anim.SetBool("unbalanceb3", false);
            anim.SetBool("unbalanceb1", false);
        }

        yield return null;
    }
}
