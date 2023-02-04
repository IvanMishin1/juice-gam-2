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
    public AudioSource falsegrab;
    public AudioSource falsefill;
    public static bool isthereabottle;
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
            if(isthereabottle)
            {
                //do animation
                transform.Translate(0, 1 * debugnumber, 0);
                if(transform.position.y >= 3.7f)
                {   
                    goingup = false;
                    goingdown = true;
                    pressed = false;
                    isthereabottle = false;
                }
            }
            else
            {
                falsefill.Play();
                //spawn spill
                transform.Translate(0, 1 * debugnumber, 0);
                if(transform.position.y >= 3.7f)
                {   
                    goingup = false;
                    goingdown = true;
                    pressed = false;
                    isthereabottle = false;
                }
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
        BrokenBottleCollector.SetActive(false);
        if(isthereabrokenbottle)
        {
            BrokeBottleCollectorAnimator.SetBool("isgrabbing", true);
            yield return new WaitForSeconds(0.5f);
            BrokeBottleCollectorAnimator.SetBool("isgrabbing", false);
        }
        else
        {
            falsegrab.Play();
            BrokeBottleCollectorAnimator.SetBool("falsegrab", true);
            yield return new WaitForSeconds(0.3f);
            BrokeBottleCollectorAnimator.SetBool("falsegrab", false);
        }
        isthereabrokenbottle = false;
    }
}
