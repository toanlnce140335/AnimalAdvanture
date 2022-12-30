using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    //Player
    public bool doubleJump = false;

    //PlayerLife
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private AudioSource deathSoundEffect;
    public GameOver GameOver;
    public GameFinish GameFinish;

    //PlayerMove
    private BoxCollider2D coll;
    private SpriteRenderer sprite;

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private InputHanler ip;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private enum MovementState { idle, running, jumping, falling }

    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private GameObject jumpEffect;
    [SerializeField] private GameObject landEffect;
    [SerializeField] private GameObject runEffect;
    [SerializeField] private Transform effectPoint;
    [SerializeField] private Transform effectLeftPoint;

    public string player;

    //CheckPoint
    private Vector2 checkPoint;
    [SerializeField] private PlayerHealth playerHealth;

    void Start()
    {
        player = PlayerPrefs.GetString("PlayerSelected");
        //PlayerMove
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        if (player != "Human" && player != "FemaleHuman" && player != "Monkey" && player != "Pangolin")
        {
            moveSpeed = 9f;
        }
        if (player != "Human" && player != "FemaleHuman" && player != "Monkey" && player != "Rhino")
        {
            moveSpeed = 12f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
        else if (collision.gameObject.CompareTag("Finish"))
        {
            LoadGameFinish();
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CheckPoint"))
        {
            Animator animStemp = collision.GetComponent<Animator>();
            if (!animStemp.isActiveAndEnabled)
            {
                animStemp.enabled = true;
                checkPoint = collision.transform.position;
            }
        }
    }

    private void LoadGameFinish()
    {
        Time.timeScale = 0;
        GameFinish.gameObject.SetActive(true);
    }

    private void LoadGameOver()
    {
        Time.timeScale = 0;
        GameOver.gameObject.SetActive(true);
    }

    public void Retry()
    {
        playerHealth = GetComponent<PlayerHealth>();
        if (playerHealth != null)
            playerHealth.health = playerHealth.maxHealth;
        transform.position = checkPoint;
        anim.SetTrigger("live");
    }

    public void Die()
    {
        deathSoundEffect.Play();
        anim.SetTrigger("death");
        Invoke("LoadGameOver", .15f);
    }

    void PlayOnKeyBoard()
    {
        dirX = ip.Side;
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (!ip.IsTouchJumpBtn && IsGrounded())
        {
            doubleJump = false;
        }

        if (ip.IsTouchJumpBtn)
        {
            if (IsGrounded() || (doubleJump && player != "Human" && player != "FemaleHuman" && player != "Rhino"))
            {
                jumpSoundEffect.Play();
                Island = true;
                var jump = Instantiate(jumpEffect, effectPoint.transform);
                jump.transform.parent = null;
                Destroy(jump, .5f);
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);                
                if (doubleJump)
                {
                    anim.SetTrigger("double-jump");
                    StartCoroutine(DelayJump());
                }
                doubleJump = !doubleJump;
            }
            ip.IsTouchJumpBtn = false;
        }

        UpdateAnimationState();
    }

    IEnumerator DelayJump()
    {
        yield return new WaitForSeconds(.5f);
        anim.SetTrigger("double-jump");
    }

    private void Update()
    {
        PlayOnKeyBoard();
    }

    private bool Island = false;
    private void UpdateAnimationState()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            transform.localScale = new Vector3(1, 1, 1);
            var run = Instantiate(runEffect, effectLeftPoint.transform);
            Destroy(run, .2f);
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            transform.localScale = new Vector3(-1, 1, 1);
            var run = Instantiate(runEffect, effectLeftPoint.transform);
            Destroy(run, .2f);
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            if (IsGrounded() && Island == true)
            {
                Island = false;
                var land1 = Instantiate(landEffect, effectPoint.transform);
                Destroy(land1, .5f);
            }
            state = MovementState.falling;
        }
        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

}
