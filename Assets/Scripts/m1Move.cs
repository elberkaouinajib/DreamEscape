using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m1Move : MonoBehaviour
{
    float timer=0;
    float waitTime=1.0f;


    // Update is called once per frame
    void Update()
    {
         transform.position=transform.position-(new Vector3(0.1f,0,0));
    }
    private void OnTriggerEnter2D(Collider2D other) {
         if(other.gameObject.tag=="Player")
            GameOverDetect.GameOver();
    }
}
