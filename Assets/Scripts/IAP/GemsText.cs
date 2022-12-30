using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class GemsText : MonoBehaviour
{
     Text coinsText;

    void Awake()
    {
        coinsText = GetComponent<Text>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        coinsText.text = "" + ScoreHandler.instance.Coins;
    }
}
