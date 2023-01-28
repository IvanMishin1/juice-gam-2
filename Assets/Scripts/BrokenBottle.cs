using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrokenBottle : MonoBehaviour
{
    float speed = 2.2f;
    public Text ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "BrokenCollect")
        {
            Destroy(this.gameObject);
            ScoreText.text = "SCORE: " + BottleMover.score.ToString();
        }
    }
}
