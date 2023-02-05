using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public static bool playing = true;
    public Button button;
    public Sprite[] sprites;
    public AudioSource music;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Clicked()
    {
        if(playing)
        {
            button.image.sprite = sprites[1];
            playing = false;
            music.Pause();
        }
        else
        {
            button.image.sprite = sprites[2];
            playing = true;
            music.Play();
        }
    }
}
