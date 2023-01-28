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
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
            if(transform.position.y >= 3)
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
        yield return new WaitForSeconds(0.5f);
        BrokenBottleCollector.SetActive(false);
    }
}
