using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreakRock : MonoBehaviour
{
    private ParticleSystem particle;
    private SpriteRenderer sr;
    private BoxCollider2D bc;

    [SerializeField] private Sprite exploisionIcon;
    [SerializeField] private Image exploisionBtn;
    public bool isClickExpoisionBtn = false;

    private void Awake()
    {
        particle = GetComponentInChildren<ParticleSystem>();
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if(isClickExpoisionBtn) StartCoroutine(Break());
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player" && (PlayerPrefs.GetString("PlayerSelected") == "Rhino" || PlayerPrefs.GetString("PlayerSelected") == "Pangolin"))
        {
            exploisionBtn.gameObject.SetActive(true);
        }
    }

    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    if (collision.transform.tag == "Player" && (PlayerPrefs.GetString("PlayerSelected") == "Rhino" || PlayerPrefs.GetString("PlayerSelected") == "Pangolin"))
    //    {
    //        if (isClickExpoisionBtn)
    //        {
    //            doBreak = true;
    //            //StartCoroutine(Break());
    //        }            
    //    }
    //}

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player" && (PlayerPrefs.GetString("PlayerSelected") == "Rhino" || PlayerPrefs.GetString("PlayerSelected") == "Pangolin"))
        {
            exploisionBtn.gameObject.SetActive(false); 
        
        }
    }

    private IEnumerator Break()
    {
        Debug.Log("Rock break");
        isClickExpoisionBtn = false;
        particle.Play();
        exploisionBtn.gameObject.SetActive(false);
        sr.enabled = false;
        bc.enabled = false;
        yield return new WaitForSeconds(particle.main.startLifetime.constantMax);
        Destroy(gameObject);
    }


    public void OnClickExpoision()
    {
        isClickExpoisionBtn = true;
    }
}
