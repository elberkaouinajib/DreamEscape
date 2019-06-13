using UnityEngine;

public class PlayerMove : MonoBehaviour {

    [SerializeField] private float maxSpeed = 10f;                    // The fastest the player can travel in the x axis.
    [SerializeField] private float jumpForce = 400f;                  // Amount of force added when the player jumps.
    [SerializeField] private bool airControl = false;                 // Whether or not a player can steer while jumping;
    [SerializeField] private LayerMask groundLayer;                  // A mask determining what is ground to the character
    [SerializeField] private Transform groundTracker;

    [SerializeField] private float distToGround;
    private Animator animator;
    private Rigidbody2D rb;

    private bool lookAtRight = true;

    public bool isGrounded(){
        bool grounded = Physics2D.Raycast(groundTracker.position, -Vector3.up, distToGround, groundLayer);
        Debug.DrawRay(groundTracker.position, -Vector3.up * (distToGround + 0.1f) , grounded?Color.green: Color.red);
        return grounded;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        animator = GetComponent<Animator>(); 
    }

    private void Update() {
         animator.SetFloat("vSpeed", rb.velocity.y);
         animator.SetBool("Ground", isGrounded());
    }

    private void Flip()
    {
        lookAtRight = !lookAtRight;
        transform.Rotate(new Vector3(0,180,0));
    }

    public void Move(float move, bool jump){

        bool grounded = isGrounded();

        if (grounded || airControl)
        {
            move = airControl?move /2: move;

            rb.velocity = new Vector2(move*maxSpeed, rb.velocity.y);
            animator.SetFloat("Speed", Mathf.Abs(move));

            if (move > 0 &&  !lookAtRight)
            {
                Flip();
            }
            else if (move < 0 &&  lookAtRight)
            {
                Flip();
            }
        }

        if (grounded && jump)
        {
            animator.SetBool("Ground", false);
            rb.AddForce(new Vector2(0f, jumpForce));
        }
    }

}