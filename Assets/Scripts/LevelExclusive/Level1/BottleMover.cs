using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottleMover : MonoBehaviour
{
    public Sprite filledBottle;
    static float speed = 2.2f;
    public static int score;
    bool perfectbool;
    public Text ScoreText;
    public GameObject PerfectText;
    Animator objectAnimator;
    double audioDelta = 0;
    double lastDspTime = 0;
    public AudioSource fill;
    public AudioSource perfectfill;
    // Start is called before the first frame update
    void Start()
    {
        audioDelta = AudioSettings.dspTime - lastDspTime;
        lastDspTime = AudioSettings.dspTime;
        objectAnimator = GetComponent<Animator>();
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
        if (col.gameObject.name == "perfect")
        {
            ButtonPress.isthereabottle = true;
            perfectfill.Play();
            if(perfectbool)
            {
                perfectbool = false;
                return;
            }
            objectAnimator.SetBool("fullbottle", true);
            score += 2;
            ScoreText.text = "MONEY: " + ((float)(score) / 10).ToString();
            StartCoroutine(ShowPerfect());
            perfectbool = true;
        }
        else if(col.gameObject.name == "score")
        {
            fill.Play();
            CamerShake.shake = true;
            ButtonPress.isthereabottle = true;
            if(perfectbool)
            {
                perfectbool = false;
                return;
            }
            objectAnimator.SetBool("fullbottle", true);
            score++;
            ScoreText.text = "MONEY: " + ((float)(score) / 10).ToString();
            perfectbool = true;
        }
    }
    IEnumerator ShowPerfect()
    {
        PerfectText.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        PerfectText.SetActive(false);
    }
}