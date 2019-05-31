using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMove : MonoBehaviour
{
    public float speed;
    public GameObject endObject;

     private float timer = 0.0f;
     public Vector3 desiredPos;
     
     private Vector3 originalPos;
     
     void Start () {
         desiredPos=endObject.transform.position;
         originalPos = transform.position;
     }
     
     void Update () {
          timer += Time.deltaTime;
         transform.position=Vector3.Lerp(originalPos, desiredPos, Mathf.PingPong(timer*speed, 1.0f));
     }
     
     private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Player"){
            other.gameObject.transform.SetParent(transform);
        }
     }
     private void OnTriggerExit2D(Collider2D other) {
         if(other.tag=="Player"){
            other.gameObject.transform.SetParent(null);
        }
     }
}
