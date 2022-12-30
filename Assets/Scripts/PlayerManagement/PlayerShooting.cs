using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private InputHanler _ip;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _atkSpeed;
    private float atkTimeStemp;

    // Start is called before the first frame update
    void Start()
    {
        atkTimeStemp = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Shooting();
    }

    private void Shooting()
    {
        if (atkTimeStemp <= 0)
        {
            if (_ip.IsTouchShoottingBtn)
            {
                var b = Instantiate(_bullet, _firePoint);
                b.transform.parent = null;
                atkTimeStemp = _atkSpeed;
            }
        }
        else
        {
            atkTimeStemp -= Time.deltaTime;
        }
    }
}
