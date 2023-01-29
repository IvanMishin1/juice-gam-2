using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottleMover : MonoBehaviour
{
    public GameObject filledBottlePrefab;
    static float speed = 2.2f;
    public static int score;
    bool perfectbool;
    public Text ScoreText;
    public GameObject PerfectText;
    // Start is called before the first frame update

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
            GameObject filledBottle = Instantiate(filledBottlePrefab, transform.position, Quaternion.Euler(0, 0, 0));
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
            GameObject filledBottle = Instantiate(filledBottlePrefab, transform.position, Quaternion.Euler(0, 0, 0));
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