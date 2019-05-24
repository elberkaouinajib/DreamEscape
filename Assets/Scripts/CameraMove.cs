using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
     public float speed = 1.0f;

    void Update()
    {
        GetComponent<Camera>().transform.position=GetComponent<Camera>().transform.position + (new Vector3(0.04f,0,0));
    }
    private void LateUpdate() {
         Vector3 v3 = transform.position;
         v3.y = Mathf.Lerp (v3.y, player.transform.position.y, speed);
         transform.position = v3;
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
    }
    

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject==player)
            GameOverDetect.GameOver();
    }

}
