using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleMover : MonoBehaviour
{
    public Sprite filledBottle;
    static float speed = 2f;
    static int score;
    public SpriteRenderer spriteRenderer;
    bool perfectbool;
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
            Debug.Log("Your score is " + score);
            Debug.Log("Perfect!");
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
            Debug.Log("Your score is " + score);
            perfectbool = true;
        }
    }
}
