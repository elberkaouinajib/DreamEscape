using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Fox : MonoBehaviour {

    public Transform groundTracker;
    public Transform wallTracker;
    public float speed = 1f;
    public float  maxSpeed = 1f;

    public LayerMask groundLayer;
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
        Debug.DrawRay(groundTracker.position, -transform.up * rayCastDistance, Color.green);
        return Physics2D.Raycast(groundTracker.position, -transform.up, rayCastDistance, groundLayer);
    }

    private RaycastHit2D isInWall() {
        bool inWall = Physics2D.Raycast(wallTracker.position, transform.right, 1, groundLayer);
        Debug.DrawRay(wallTracker.position, transform.right* 1,Color.blue);
        return Physics2D.Raycast(wallTracker.position, transform.right, 1, groundLayer);
    }


    private void Update() {
        if(Math.Abs(rb.velocity.x) <= maxSpeed){
            rb.AddForce(transform.right * speed);
        }
        if(isGround().collider == null){
            Flip();
        }

        if(isInWall().collider != null){
            Flip();
        }

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            Debug.Log("Dead");
            GameManager.Instance.GameOver();
        }
    }
}