using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    void Update()
    {
        transform.position += new Vector3(2.2f * Time.deltaTime, 0, 0);
        if (transform.position.x > 10) 
        {
            transform.position = new Vector3(-10, transform.position.y, transform.position.z);
        }
    }
}
