using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //stores the state of the animation


    //stores the velocity of the jump
    [SerializeField] public int JUMPVEL = 20;
    [SerializeField] private static float VEL = 4;

    public Animator anim;
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private LayerMask collectable;
    [SerializeField] private LayerMask trap; // stores the trap
    [SerializeField] private AudioSource jumpSoundEffect;
    //[SerializeField] private AudioSource deathSoundEffect;


    private enum MovementState { idle, running, jumping, falling }
    MovementState state; //enum object


    Vector3 move = new Vector3(VEL, 0, 0);


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(state);
        UpdateAnimationState();

        if (Input.GetButton("Jump") && IsGrounded())
        {
            //transform.localScale = new Vector3(1,1,0);
            rb.velocity = new Vector2(rb.velocity.x, JUMPVEL);
            jumpSoundEffect.Play();
        }
        if (ItemCollect())
        {
            Debug.Log("Item is present");
        }


    }
    private void UpdateAnimationState()
    {

        float dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * VEL, rb.velocity.y);
        if (dirX > 0)
        {
            state = MovementState.running;
            //anim.SetBool("running", true);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (dirX < 0)
        {
            state = MovementState.running;
            //anim.SetBool("running", true);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            state = MovementState.idle;
        }
        // as velocity in y axis is imprecise even if the player
        // is not jumping then also sometimes it shows value greater
        // than 0
        if (rb.velocity.y > 0.1f)
        {
            state = MovementState.jumping;

        }
        else if (rb.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }
        //if(TrapCollide())
        //{
        //    anim.SetTrigger("death");
        //    Debug.Log("Died");
        //}
        anim.SetInteger("state",(int)state);

    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size,
            0f, Vector2.down, .1f, jumpableGround);
    }
    private bool ItemCollect()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size,
            0f, Vector2.down, .0f, collectable);
    }
}
//    private bool TrapCollide()
//    {
//        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, new Vector2(1,0), 0f, trap);
//    }
//}