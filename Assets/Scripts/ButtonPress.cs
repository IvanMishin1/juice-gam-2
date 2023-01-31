using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    public float debugnumber;
    bool pressed = false;
    bool goingdown = true;
    bool goingup = false;
    public float secondstowait;
    public GameObject BrokenBottleCollector;
    public Animator BrokeBottleCollectorAnimator;
    public static bool isthereabrokenbottle;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            pressed = true;
        }
        if(pressed && goingdown)
        {
            transform.Translate(0, -1 * debugnumber, 0);
            if(transform.position.y <= 1.88f)
            {
                goingdown = false;
                StartCoroutine(WaitBeforeGoingUp());
            }
        }
        if(pressed && goingup)
        {
            transform.Translate(0, 1 * debugnumber, 0);
            if(transform.position.y >= 3.7f)
            {
                goingup = false;
                goingdown = true;
                pressed = false;
            }
        }
        if(Input.GetMouseButtonDown(1))
        {
            StartCoroutine(CollectBrokenGlass());
        }
    }

    IEnumerator WaitBeforeGoingUp()
    {
        yield return new WaitForSeconds(secondstowait);
        goingup = true;
    }

    IEnumerator CollectBrokenGlass()
    {
        BrokenBottleCollector.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        if(isthereabrokenbottle)
        {
            BrokeBottleCollectorAnimator.SetBool("isgrabbing", true);
            yield return new WaitForSeconds(0.5f);
            BrokeBottleCollectorAnimator.SetBool("isgrabbing", false);
            BrokenBottleCollector.SetActive(false);
        }
        else
        {
            BrokenBottleCollector.SetActive(false);
            BrokeBottleCollectorAnimator.SetBool("falsegrab", true);
            yield return new WaitForSeconds(0.3f);
            BrokeBottleCollectorAnimator.SetBool("falsegrab", false);
        }
        isthereabrokenbottle = false;
    }
}
