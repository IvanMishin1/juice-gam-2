using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottlesSpawner : MonoBehaviour
{
    public GameObject bottle;
    public GameObject brokenBottle;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Game());
    }
    
    IEnumerator Game()
    {
        Instantiate(bottle, new Vector3(-9.77f, -3.5f, 0), Quaternion.identity);        
        yield return new WaitForSeconds(5);
        StartCoroutine(Game());
    }
}
