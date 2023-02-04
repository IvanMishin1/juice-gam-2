using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnyPlay : MonoBehaviour
{
    public AudioSource[] SFX;
    public int SFXNumber;
    public bool play;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(play)
        {
            SFX[SFXNumber].Play();
            play = false;
        }
    }
    
    public void PlaySFX()
    {
        SFX[SFXNumber].Play();
    }
}
