using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


[RequireComponent(typeof (PlayerMove))]
public class PlayerControl : MonoBehaviour
{
    private PlayerMove character;

    private Animator playerAnim;
    private bool jump;
    private bool isDead = false;


    private void Awake()
    {
        character = GetComponent<PlayerMove>();
        playerAnim = GetComponent<Animator>();
    }


    private void Update()
    {
        if (!jump && !isDead)
        {
            jump = CrossPlatformInputManager.GetButtonDown("Jump");
        }
    }


    private void FixedUpdate()
    {
        if(!isDead){
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            character.Move(h,jump);
            jump = false;
        }
    }

    public void Die(){
        playerAnim.SetTrigger("Dead");
        isDead = true;
    }
}

