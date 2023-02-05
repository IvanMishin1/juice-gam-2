using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndMenuHandler : MonoBehaviour
{
    public Text[] texts;
    // Start is called before the first frame update
    void Start()
    {
        texts[1].text = BottleMover.score.ToString() + ".00";
        texts[2].text = ((float)BottleMover.score - (float)BottleMover.score / 10).ToString() + "0";
        texts[3].text = ((float)BottleMover.score / 10).ToString() + "0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
