using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 3;


    public SpriteRenderer playerSr;
    public PlayerManager playerManager;
    private Animator anim;
    [SerializeField] private float immortalTime;
    public float stempTime;

    [SerializeField] private AudioSource dieSoundEffect;
    void Start()
    {
        health = maxHealth;
        anim = GetComponent<Animator>();
        stempTime = 0;
    }

    private void Update()
    {
        if (stempTime > 0)
        {
            stempTime -= Time.deltaTime;
        }
    }

    // Update is called once per frame
    public void TakeDamage(int amount)
    {
        if (health > 0)
        {
            if (stempTime <= 0)
            {
                dieSoundEffect.Play();
                health -= amount;
                anim.SetBool("hit", true);
                StartCoroutine(DelayTakeDame());
            }
        }

        if (health <= 0)
        {
            transform.GetComponent<PlayerManager>().Die();
        }
    }

    IEnumerator DelayTakeDame()
    {
        stempTime = immortalTime;
        yield return new WaitForSeconds(immortalTime);
        anim.SetBool("hit", false);
    }
}
