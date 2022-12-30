using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinSpkieBall : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 60f;
    [SerializeField] float x;
    [SerializeField] float y;
    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles = new Vector3(0, 0, Mathf.PingPong(Time.time * rotateSpeed, x) - y);
    }
}
