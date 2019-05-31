using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePlatform : MonoBehaviour
{
    public float frequance;
     private float timer = 0.0f;
     private Collider2D collider;
     private SpriteRenderer sprite;
     private void Start() {
         collider=GetComponent<Collider2D>();
         sprite=GetComponent<SpriteRenderer>();
     }
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>frequance){
            collider.enabled=!collider.enabled;
            sprite.enabled=!sprite.enabled;
            timer=0;
        }
    }
}
