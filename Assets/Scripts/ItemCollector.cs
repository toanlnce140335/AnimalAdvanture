using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int cherries = 0;
    public GameObject textDisplay;
    public float secondsLeft = 0;
    public bool takingAway = false;
    public GameOver GameOver;

    [SerializeField] private Text cherriesText;
    [SerializeField] private AudioSource collectionSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            Destroy(collision.gameObject, 0.2f);
            collectionSoundEffect.Play();
            cherries++;
            cherriesText.text = ":" + cherries;
            StartCoroutine(BonusTimer());
        }

    }
    private void Update()
    {
        if (!takingAway && secondsLeft > 0)
        {
            secondsLeft -= Time.deltaTime;
            textDisplay.GetComponent<Text>().text = Mathf.Ceil(secondsLeft) + "s";
        }
        else if(secondsLeft < 0)
        {
            secondsLeft = 0f;
            textDisplay.GetComponent<Text>().text = secondsLeft + "s";
            Invoke("LoadGameOver", 0.1f);
        }
    }
    IEnumerator BonusTimer()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft += 5;
        textDisplay.GetComponent<Text>().text = secondsLeft + "s";
        takingAway = false;
    }

    private void LoadGameOver()
    {
        GameOver.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

}
