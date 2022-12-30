using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArraySkin : MonoBehaviour
{
    public static ArraySkin instance;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    public int[] skinArray = { 1, 1, 0, 0, 0};
}
