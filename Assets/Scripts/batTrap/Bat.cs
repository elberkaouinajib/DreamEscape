using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{


	public float moveSpeed = 6f;

	public float frequency = 10f;

	public float magnitude = 1f;


    public string batMove;
     Vector3 pos;
     private void Start() {
          pos=transform.position;
     }

    // Update is called once per frame
    void Update()
    {
         switch (batMove)
         {
             case "Crazy":CrazyMove(); break;
             default: NormalMove(); break;
         }
    }
    private void OnTriggerEnter2D(Collider2D other) {
         if(other.gameObject.tag=="Player")
            GameManager.Instance.GameOver();
    }

    private void NormalMove(){
         transform.position=transform.position-(new Vector3(0.1f,0,0));
        
    }

    private void CrazyMove(){
		pos -= transform.right * Time.deltaTime * moveSpeed;
		transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
    }
}
