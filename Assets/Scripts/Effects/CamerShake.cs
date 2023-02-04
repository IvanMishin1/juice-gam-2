using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerShake : MonoBehaviour
{
    public Transform Camera;
    Transform savedCamera;
    public static bool shake;
    public float most;
    public float least;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        savedCamera = Camera;
    }

    // Update is called once per frame
    void Update()
    {
        if(shake)
        {
            Camera.Translate(Random.Range(least, most), Random.Range(least, most), 0);
            timer += Time.deltaTime;
            Debug.Log(timer);
            if(timer >= 0.1f)
            {
                shake = false;
                timer = 0;
                Camera.position = savedCamera.position;
            }
        }
    }
}
