using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    double audioDelta = 0;
    double lastDspTime = 0;
    public AudioSource audioSource;

    void Start()
    {
        audioDelta = AudioSettings.dspTime - lastDspTime;
        lastDspTime = AudioSettings.dspTime;
    }

    void Update()
    {
        audioDelta = AudioSettings.dspTime - lastDspTime;
        lastDspTime = AudioSettings.dspTime;
        transform.Translate((float)(2.2f * audioDelta), 0, 0);
        if (transform.position.x > 17.024f) 
        {
            transform.position = new Vector3(-8.997f, transform.position.y, transform.position.z);
        }
    }
}
