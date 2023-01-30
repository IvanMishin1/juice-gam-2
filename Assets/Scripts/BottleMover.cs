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
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "perfect")
        {
            if(perfectbool)
            {
                perfectbool = false;
                return;
            }
            spriteRenderer.sprite = filledBottle;
            score += 3;
            ScoreText.text = "SCORE: " + score.ToString();
            StartCoroutine(ShowPerfect());
            perfectbool = true;
        }
        else if(col.gameObject.name == "score")
        {
            if(perfectbool)
            {
                perfectbool = false;
                return;
            }
            spriteRenderer.sprite = filledBottle;
            score++;
            ScoreText.text = "SCORE: " + score.ToString();
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