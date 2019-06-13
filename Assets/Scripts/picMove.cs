using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class picMove : MonoBehaviour
{
    public float speed;

    float startY;
    bool isUp=true;
    private void Start() {
        startY=transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
            if(isUp){
                transform.position=transform.position+(new Vector3(0,speed,0));
                if(transform.position.y>=startY+transform.localScale.y*2)
                    isUp=false;              
            }
            else{
                transform.position=transform.position-(new Vector3(0,speed,0));
                if(transform.position.y<=startY)
                    isUp=true;     
            }
    }

    private void OnTriggerEnter2D(Collider2D other) {
         if(other.gameObject.tag=="Player")
            GameManager.Instance.GameOver();
    }
}
