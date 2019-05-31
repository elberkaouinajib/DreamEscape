using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Fox : MonoBehaviour {

    public Transform groundTracker;
    public float speed = 1f;
    public float  maxSpeed = 1f;

    public LayerMask layer;
    private Rigidbody2D rb;


    public float rayCastDistance;

    private void Flip()
    {
        rb.velocity = -rb.velocity;
        transform.Rotate(new Vector3(0,180,0));
    }

    private void Start() {
       rb = GetComponent<Rigidbody2D>();
    }

    private RaycastHit2D isGround() {
        return Physics2D.Raycast(groundTracker.position, -transform.up, rayCastDistance, layer);
    }

    private RaycastHit2D isInWall() {
        return Physics2D.Raycast(groundTracker.position, transform.right, 1, layer);
    }


    private void Update() {
        Debug.Log(Math.Abs(rb.velocity.x));
        if(Math.Abs(rb.velocity.x) <= maxSpeed){
            rb.AddForce(transform.right * speed);
        }
        if(isGround().collider == null){
            Flip();
        }

        if(isInWall().collider != null){
            Flip();
        }
        /* if(!isGround()){
            Flip();
        }*/
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            GameOverDetect.GameOver();
        }
    }
}