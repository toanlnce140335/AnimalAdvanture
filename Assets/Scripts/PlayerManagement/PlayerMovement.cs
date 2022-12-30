using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private GameObject jumpEffect;
    [SerializeField] private GameObject landEffect;
    [SerializeField] private GameObject runEffect;
    [SerializeField] private Transform effectPoint;

    private enum MovementState { idle, running, jumping, falling }

    //TestMovement
    private float horizontalMove = 0f;
    private bool canDoubleJump;
    public float runSpeedHorizontal = 2;
    public float runSpeed = 1.25f;
    public float jumpSpeed = 3;
    public float doubleJumpSpeed = 2.5f;
    [SerializeField] private InputHanler ip;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (horizontalMove > 0)
        {
            sprite.flipX = false;
            anim.SetBool("Run", true);
            var run = Instantiate(runEffect, effectPoint.transform);
            run.transform.parent = null;
            Destroy(run, .5f);
        }

        else if (horizontalMove < 0)
        {
            sprite.flipX = true;
            anim.SetBool("Run", true);
            var run = Instantiate(runEffect, effectPoint.transform);
            run.transform.parent = null;
            Destroy(run, .5f);
        }

        else
        {
            anim.SetBool("Run", false);
        }


        if (CheckGround.isGrounded == false)
        {
            anim.SetBool("Jump", true);
            anim.SetBool("Run", false);
            var land1 = Instantiate(landEffect, effectPoint.transform);
            //land.transform.parent = null;
            Destroy(land1, .5f);
        }
        if (CheckGround.isGrounded == true)
        {
            anim.SetBool("Jump", false);
            anim.SetBool("DoubleJump", false);
            anim.SetBool("Idle", false);
        }

        if (rb.velocity.y < 0)
        {
            anim.SetBool("Idle", true);
        }
        else if (rb.velocity.y > 0)
        {
            anim.SetBool("Idle", false);
        }
        //if (rb.bodyType != RigidbodyType2D.Static)
        //{
        //    dirX = Input.GetAxisRaw("Horizontal");
        //    rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        //    if (Input.GetButtonDown("Jump") && IsGrounded())
        //    {
        //        jumpSoundEffect.Play();
        //        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        //    }
        //}        

        //UpdateAnimationState();
    }

    //void FixedUpdate()
    //{
    //    horizontalMove = ip.Horizontal * runSpeedHorizontal;
    //    transform.position += new Vector3(horizontalMove, 0, 0) * Time.deltaTime * runSpeed;
    //}

    //private void UpdateAnimationState()
    //{
    //    MovementState state;
    
    //    if (dirX > 0f)
    //    {
    //        state = MovementState.running;
    //        sprite.flipX = false;
    //    }
    //    else if (dirX < 0f)
    //    {
    //        state = MovementState.running;
    //        sprite.flipX = true;
    //    }
    //    else
    //    {
    //        state = MovementState.idle;
    //    }

    //    if (rb.velocity.y > .1f)
    //    {
    //        state = MovementState.jumping;
    //    }
    //    else if (rb.velocity.y < -.1f)
    //    {
    //        state = MovementState.falling;
    //    }

    //    anim.SetInteger("state", (int)state);
    //}

    //private bool IsGrounded()
    //{
    //    return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    //}

    public void Jump()
    {
        if (CheckGround.isGrounded)
        {
            canDoubleJump = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
        else
        {

            if (canDoubleJump)
            {
                anim.SetBool("DoubleJump", true);
                rb.velocity = new Vector2(rb.velocity.x, doubleJumpSpeed);
                canDoubleJump = false;
            }

        }
    }
}
