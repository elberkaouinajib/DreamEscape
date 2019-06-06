using UnityEngine;

public class PlayerMove : MonoBehaviour {

    [SerializeField] private float maxSpeed = 10f;                    // The fastest the player can travel in the x axis.
    [SerializeField] private float jumpForce = 400f;                  // Amount of force added when the player jumps.
    [Range(0, 1)] [SerializeField] private float crouchSpeed = .36f;  // Amount of maxSpeed applied to crouching movement. 1 = 100%
    [SerializeField] private bool airControl = false;                 // Whether or not a player can steer while jumping;
    [SerializeField] private LayerMask whatIsGround;                  // A mask determining what is ground to the character

    [SerializeField] private float distToGround;
    private Animator animator;
    private Rigidbody2D rb;

    public bool isGrounded(){
        Debug.DrawRay(transform.position, -Vector3.up * (this.distToGround + 0.1f) , Color.green);
        return Physics2D.Raycast(transform.position, -Vector3.up, this.distToGround, this.whatIsGround);
    }

    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>(); 
        this.animator = GetComponent<Animator>(); 
        //this.distToGround = GetComponent<Collider2D>().bounds.extents.y;
    }

    void Update(){
        if(isGrounded()){
        }
    }

    public void Move(float move, bool crouch, bool jump){
         // If crouching, check to see if the character can stand up
        /*if (!crouch && this.animator.GetBool("Crouch"))
        {
            // If the character has a ceiling preventing them from standing up, keep them crouching
            if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
            {
                crouch = true;
            }
        }*/

        // Set whether or not the character is crouching in the animator
        this.animator.SetBool("Crouch", crouch);

        //only control the player if grounded or airControl is turned on
        if (isGrounded() || this.airControl)
        {
            // Reduce the speed if crouching by the crouchSpeed multiplier
            move = (crouch ? move*crouchSpeed : move);

            move = airControl?move /2: move;

            // The Speed animator parameter is set to the absolute value of the horizontal input.
            this.animator.SetFloat("Speed", Mathf.Abs(move));

            // Move the character
            this.rb.velocity = new Vector2(move*maxSpeed, rb.velocity.y);

            // If the input is moving the player right and the player is facing left...
            /*if (move > 0 && !m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
                // Otherwise if the input is moving the player left and the player is facing right...
            else if (move < 0 && m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }*/
        }

         // If the player should jump...
         Debug.Log(this.isGrounded());
        if (this.isGrounded() && jump)
        {
            // Add a vertical force to the player.
            this.animator.SetBool("Ground", false);
            this.rb.AddForce(new Vector2(0f, this.jumpForce));
        }
    }

}