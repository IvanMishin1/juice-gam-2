using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public AudioSource music;
    // Start is called before the first frame update
    void Start()
    {
        BottleMover.score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(music.isPlaying == false && PauseManager.playing)
        {
            SceneManager.LoadScene("EndMenu");
        }   
    }
}
