using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTextController : MonoBehaviour
{
    public Text TextBtn;
    public GameObject DoorSkin;
    public int skinNum;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("PinkManBought", 1);
    }

    // Update is called once per frame
    void Update()
    {

        int[] skinArray =
        {
            PlayerPrefs.GetInt("PinkManBought"),
            PlayerPrefs.GetInt("VirtualGuyBought"),
            PlayerPrefs.GetInt("MaskDudeBought"),
            PlayerPrefs.GetInt("FrogBought")
        };
        if (skinArray[skinNum] == 0)
        {
            TextBtn.text = "Buy";
        }
        else
        {
            TextBtn.text = "Seclect";
        }
    }
}
