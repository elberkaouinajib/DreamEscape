using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameMaster gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     private void OnTriggerEnter2D(Collider2D other) {
         Debug.Log(other.tag);
        if(other.CompareTag("Coin")){
            Debug.Log("touched");
            Destroy(other.gameObject);
            gm.coins++; 
        }
    }
}
