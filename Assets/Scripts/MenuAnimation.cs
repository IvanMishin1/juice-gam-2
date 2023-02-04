using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.UI;

public class MenuAnimation : MonoBehaviour
{
    public Sprite[] frames;
    public float speed; 
    private int currentFrame;
    public int framesArraySize;

    void Start()
    {
        currentFrame = -1;
        StartCoroutine("ChangeTexture");
    }

    public IEnumerator ChangeTexture()
    {
        currentFrame++;
        if (currentFrame > framesArraySize - 1) {currentFrame = 0;}
        gameObject.GetComponent<Image>().sprite = frames[currentFrame];
        yield return new WaitForSeconds(speed);
        StartCoroutine("ChangeTexture");
    }
}
