using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCountDown : MonoBehaviour
{
    public GameObject textDisplay;
    public int secondsLeft = 90;
    public bool takingAway = false;

    void Start()
    {
        textDisplay.GetComponent<Text>().text = secondsLeft + "s";
    }

    void Update()
    {
        if(takingAway == false && secondsLeft > 0)
        {
            StartCoroutine(TimerTake());
        }
    }

    IEnumerator BonusTimer()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft += 20;
        textDisplay.GetComponent<Text>().text = secondsLeft + "s";
        takingAway = false;
    }

    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        textDisplay.GetComponent<Text>().text = secondsLeft + "s";
        takingAway = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Cherry")
        {
            secondsLeft = secondsLeft + 20;
        }
    }
}
