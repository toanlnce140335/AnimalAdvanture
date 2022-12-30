using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarHandler : MonoBehaviour
{
    public GameObject[] stars;
    public int cherriesCount = 0;
    //public int cherryLeft = 0;

    // Start is called before the first frame update
    void Start()
    {
        cherriesCount = GameObject.FindGameObjectsWithTag("Cherry").Length;
    }

    public void starsAchived()
    {
        int cherryLeft = GameObject.FindGameObjectsWithTag("Cherry").Length;
        int cherriesCollected = cherriesCount - cherryLeft;

        float percentage = float.Parse(cherriesCollected.ToString()) / float.Parse(cherriesCount.ToString()) * 100f;
        if(percentage >= 33f && percentage < 66)
        {
            //first star
            stars[0].SetActive(true);
        }else if(percentage >= 66 && percentage < 70)
        {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
        }
        else
        {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
        }
    }
}
