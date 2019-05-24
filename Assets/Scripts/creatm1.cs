using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creatm1 : MonoBehaviour
{

    public GameObject m1;

    public Transform spawner;
    private bool playerIsInTrap = false;
    float timer=0;
    float waitTime=5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerIsInTrap)
        {
            timer+=Time.deltaTime;
            if(timer>=waitTime){
                Instantiate(m1,spawner.position,Quaternion.identity);
                timer=0;
            }
        }
        else if(timer>0)
            timer=0;

    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="Player")
        {
            playerIsInTrap=true;
            Debug.Log("enter");
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag=="Player")
          {
            playerIsInTrap=false;
            Debug.Log("out");
          }

        if(other.gameObject.tag=="Monster")
            Destroy(other.gameObject);
    
    }
}
