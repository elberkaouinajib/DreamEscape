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

    private void Start(){
        character = GetComponent<PlayerMove>();
        playerAnim = character.GetComponent<Animator>();
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
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        character.Move(h,jump, isDead);
        jump = false;
    }

    public void Die(){
        playerAnim.SetTrigger("Dead");
        isDead = true;
    }
}

