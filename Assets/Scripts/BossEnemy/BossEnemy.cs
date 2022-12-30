using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossEnemy : MonoBehaviour
{
    [SerializeField] private int _heart;
    [SerializeField] private GameObject Finish;
    private enum TypeBoss
    {
        MeleeBoss,
        RangeBoss,
        FinalBoss
    }

    [SerializeField] private TypeBoss _typeBoss;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _activeRange;

    [Header("MeleeBoss")]
    [SerializeField] private float _meleeAtkRange;
    [SerializeField] private float _meleeRunSpeed;
    [SerializeField] private Transform _meleePoint;

    [Header("RangeBoss")]
    [SerializeField] private float _timeWaitNextAtk;
    [SerializeField] private float _rangeAtk;
    [SerializeField] private int _countAtk;
    [SerializeField] private float _rangeRunSpeed;
    [SerializeField] private Transform _rangePoint;
    [SerializeField] private GameObject _bullet;

    [Header("FinalBoss")]
    [SerializeField] private float _dashRange;
    [SerializeField] private float _dashSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _rangeSkillAtk;
    [SerializeField] private float _finalBossRunSpeed;
    private bool canDash = true;
    private bool canJump = true;


    private Animator anim;
    private Rigidbody2D rb;
    private Transform player;
    public bool isActive = false;
    public bool isDelay = false;
    public Slider heathBar;
    private CapsuleCollider2D col;
    private int currentHeart;
    private bool isDeath = false;
    private int countAtk;
    private float timeWaitNextAtk;

    void Start()
    {
        currentHeart = _heart;
        countAtk = _countAtk;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CapsuleCollider2D>();
        Finish = GameObject.FindGameObjectWithTag("Finish");
        player = GameObject.FindGameObjectWithTag("Player").transform;
        heathBar = GameObject.FindGameObjectWithTag("BossHeartSlider").GetComponent<Slider>();
        heathBar.gameObject.SetActive(false);
        Finish.SetActive(false);
    }

    private void Update()
    {
        CheckPlayer();
        ActiveState();
    }

    private void CheckPlayer()
    {
        if (!isDeath)
        {
            if (Vector2.Distance(transform.position, player.position) <= _activeRange)
            {
                if (!isActive)
                {
                    isActive = true;
                    heathBar.gameObject.SetActive(true);
                    heathBar.maxValue = _heart;
                    heathBar.value = currentHeart;
                }
            }
        }
    }

    public void TakeDame()
    {
        if (isActive)
        {
            currentHeart -= 1;
            heathBar.value = currentHeart;

            if(currentHeart == 0)
            {
                isDeath = true;
                Finish.SetActive(true);

                if (_typeBoss != TypeBoss.FinalBoss)
                {
                    anim.SetTrigger("Die");
                    col.direction = CapsuleDirection2D.Horizontal;
                    col.size = new Vector2(4.1f, 2.5f);
                    Invoke("DelayDie", .5f);
                }
                else
                {
                    anim.enabled = false;
                    transform.localRotation = Quaternion.Euler(0, 0, 90); 
                    Invoke("DelayDie", .5f);
                }
            }
        }
    }

    private void DelayDie()
    {
        heathBar.gameObject.SetActive(false);
        rb.bodyType = RigidbodyType2D.Kinematic;
        col.isTrigger = true;
    }

    private void ActiveState()
    {
        if (isActive && !isDeath)
        {
            if (_typeBoss == TypeBoss.MeleeBoss)
            {
                float speed = _rangeRunSpeed;
                if (currentHeart <= _heart / 2)
                {
                    anim.SetTrigger("Enraged");
                    speed = _rangeRunSpeed * 2;
                }

                if (isDelay == false)
                {
                    anim.SetBool("IsRun", true);
                    if (player.position.x > transform.position.x)
                    {
                        transform.localScale = new Vector3(1, 1, 1);
                    }
                    else
                    {
                        transform.localScale = new Vector3(-1, 1, 1);
                    }

                    rb.velocity = Vector2.right * speed * transform.localScale.x;

                    if (player.position.x == transform.position.x)
                    {
                        rb.velocity = Vector2.zero;
                    }
                }
                else
                {
                    rb.velocity = Vector2.zero;
                }
            }
            else if (_typeBoss == TypeBoss.RangeBoss)
            {
                if (player.position.x > transform.position.x)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
                else
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }

                float speed = _rangeRunSpeed;
                if (currentHeart <= _heart / 2)
                {
                    anim.SetTrigger("Enraged");
                    speed = _rangeRunSpeed * 2;
                    countAtk = _countAtk * 2;
                    timeWaitNextAtk = _timeWaitNextAtk / 2;
                }

                if (isDelay == false)
                {
                    anim.SetBool("IsRun", true);
                    rb.velocity = Vector2.right * speed * transform.localScale.x;

                    if (player.position.x == transform.position.x)
                    {
                        rb.velocity = Vector2.zero;
                    }
                }
                else
                {
                    rb.velocity = Vector2.zero;
                }
            }
            else if (_typeBoss == TypeBoss.FinalBoss)
            {
                if (player.position.x + 1> transform.position.x)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
                else
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }

                float speed = _finalBossRunSpeed;
                if (currentHeart <= _heart / 2)
                {
                    //???
                    anim.SetTrigger("Enraged");
                    speed = _finalBossRunSpeed * 2;
                }

                if (isDelay == false)
                {
                    if (Vector2.Distance(transform.position, player.position) < _dashRange && canDash)
                    {
                        StartCoroutine(DashAttack());
                    }else if(Vector2.Distance(transform.position, player.position) > _dashRange && canJump)
                    {
                        StartCoroutine(JumpAttack());
                    }

                    if (player.position.x == transform.position.x)
                    {
                        rb.velocity = Vector2.zero;
                    }
                }
                else
                {
                    rb.velocity = Vector2.zero;
                }
            }
        }
    }

    bool jumpAtk = false;
    bool dashAtk = false;

    IEnumerator JumpAttack()
    {
        canJump = false;
        canDash = false;
        jumpAtk = true;
        anim.SetTrigger("Atk2");
        rb.velocity = new Vector2( _dashSpeed * transform.localScale.x, _jumpForce);
        yield return new WaitForSeconds(1);
        anim.SetTrigger("Atk2");
        jumpAtk = false;
        yield return new WaitForSeconds(3);
        canDash = true;
        canJump = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player" && !isDelay && !isDeath)
        {
            if (_typeBoss == TypeBoss.FinalBoss)
            {
                if (!canDash && !canJump && jumpAtk)
                {
                    PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
                    playerHealth.TakeDamage(1);
                    
                    isDelay = false;
                }
            }
        }
    }

    IEnumerator DashAttack()
    {
        canJump = false;
        canDash = false;
        dashAtk = true;
        anim.SetTrigger("Atk1");
        rb.velocity = Vector2.right * _dashSpeed * transform.localScale.x;
        yield return new WaitForSeconds(1f);
        if(dashAtk)
            anim.SetTrigger("Atk1");
        yield return new WaitForSeconds(3f);
        canDash = true;
        canJump = true;
        dashAtk = false;
    }

    IEnumerator RangeAttack()
    {
        int count = 0;
        while(count < countAtk)
        {
            anim.SetTrigger("Attack");
            var b = Instantiate(_bullet, _rangePoint.position, Quaternion.identity);
            b.GetComponent<BananaBullet>().Shoot(player.transform.position - transform.position);
            yield return new WaitForSeconds(.3f);
            anim.SetTrigger("Attack");
            count++;
            yield return new WaitForSeconds(timeWaitNextAtk);
        }
        yield return new WaitForSeconds(2f);
        isDelay = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player" && !isDelay && !isDeath)
        {
            if (_typeBoss == TypeBoss.MeleeBoss)
            {
                isDelay = true;
                rb.velocity = Vector2.zero;
                StartCoroutine(MeleeDelayAtk("Attack", .3f));
            }else if (_typeBoss == TypeBoss.RangeBoss)
            {
                isDelay = true;
                StartCoroutine(RangeAttack());
            }else if (_typeBoss == TypeBoss.FinalBoss)
            {
                if (!canDash && !canJump && dashAtk)
                {
                    dashAtk = false;
                    anim.SetTrigger("Atk1");
                    isDelay = true;
                    StartCoroutine(MeleeDelayAtk("Atk2", .8f));
                }
            }
        }
    }

    IEnumerator MeleeDelayAtk(string triggerName, float time)
    {
        anim.SetTrigger(triggerName);
        yield return new WaitForSeconds(time);
        anim.SetTrigger(triggerName);
        Collider2D t = Physics2D.OverlapCircle(_meleePoint.position, _meleeAtkRange, _layerMask);
        if(t != null)
        {
            PlayerHealth playerHealth = t.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(1);
        }
        anim.SetBool("IsRun", false);
        yield return new
            WaitForSeconds(2f);
        anim.SetBool("IsRun", true);
        isDelay = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _activeRange);
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _dashRange);
        
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(_meleePoint.position, _meleeAtkRange);
    }
}
