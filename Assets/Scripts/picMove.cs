using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class picMove : MonoBehaviour
{
    public float speed;
    public float high;

    float startY;
    bool isUp = true;
    float timer;

    Vector3 desiredPos;

    Vector3 originalPos;
    private void Start()
    {
        startY = transform.position.y;
        desiredPos = new Vector3(transform.position.x, transform.position.y + high, transform.position.z);
        originalPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(isUp){
            transform.
            transform.position=transform.position+(new Vector3(0,speed,0));
            if(transform.position.y>=startY+transform.localScale.y*2)
                isUp=false;              
        }
        else{
            transform.position=transform.position-(new Vector3(0,speed,0));
            if(transform.position.y<=startY)
                isUp=true;     
        }*/
        timer += Time.deltaTime;
        transform.position = Vector3.Lerp(originalPos, desiredPos, Mathf.PingPong(timer * speed, 1.0f));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            GameManager.Instance.GameOver();
    }
}