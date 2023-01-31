using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrokenBottle : MonoBehaviour
{
    float speed = 2.2f;
    public Text ScoreText;
    public GameObject perfectText;
    public AudioSource audioSource;
    double audioDelta = 0;
    double lastDspTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        audioDelta = AudioSettings.dspTime - lastDspTime;
        lastDspTime = AudioSettings.dspTime;
    }

    // Update is called once per frame
    void Update()
    {
        audioDelta = AudioSettings.dspTime - lastDspTime;
        lastDspTime = AudioSettings.dspTime;
        transform.Translate((float)(speed * audioDelta), 0, 0);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "bperfect")
        {
            BottleMover.score += 3;
            ScoreText.text = "SCORE: " + BottleMover.score.ToString();
            StartCoroutine(ShowPerfect());
        }
        else if(col.gameObject.name == "bscore")
        {
            BottleMover.score++;
            ScoreText.text = "SCORE: " + BottleMover.score.ToString();
            Destroy(this.gameObject);
        }
    }

    IEnumerator ShowPerfect()
    {
        perfectText.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        perfectText.SetActive(false);
        Destroy(this.gameObject);
    }
}
