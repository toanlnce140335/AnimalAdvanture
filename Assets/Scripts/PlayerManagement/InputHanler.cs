using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHanler : MonoBehaviour
{
    public int Side { get { return _side; } }
    private int _side;

    private bool _isTouchJumpBtn = false;
    public bool IsTouchJumpBtn
    {
        get { return _isTouchJumpBtn; }
        set
        {
            if (_isTouchJumpBtn == value) return;
            _isTouchJumpBtn = value;
        }
    }

    public bool IsTouchShoottingBtn { get { return _isTouchShoottingBtn; } }
    private bool _isTouchShoottingBtn;


    public void OnLeftBtbHold() => _side = -1;
    public void OnRightBtbHold() => _side = 1;
    public void OnBtbRelease() => _side = 0;

    public void OnJumpBtbHold() => _isTouchJumpBtn = true;
    public void OnBtbDown() => _isTouchJumpBtn = false;

    public void OnShoottingBtbPress() => _isTouchShoottingBtn = true;
    public void OnShoottingBtbRelease() => _isTouchShoottingBtn = false;

}
