using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryManager : MonoBehaviour
{
    [SerializeField] GameObject rinoInfo;
    [SerializeField] GameObject pangolinsInfo;
    [SerializeField] GameObject tamarinInfo;
    [SerializeField] GameObject jaguarInfo;
    [SerializeField] GameObject tigerCatInfo;
    [SerializeField] GameObject okapiInfo;

    public void RinoInfoOnClick()
    {
        rinoInfo.SetActive(true);
    }
    public void PangolinsInfoOnClick()
    {
        pangolinsInfo.SetActive(true);
    }
    public void TamarinInfoOnClick()
    {
        tamarinInfo.SetActive(true);
    }
    public void JaguarInfoOnClick()
    {
        jaguarInfo.SetActive(true);
    }
    public void TigerCatInfoOnClick()
    {
        tigerCatInfo.SetActive(true);
    }
    public void OkapiInfoOnClick()
    {
        okapiInfo.SetActive(true);
    }

    public void CloseOnClick()
    {
        rinoInfo.SetActive(false);
        pangolinsInfo.SetActive(false);
        tamarinInfo.SetActive(false);
        jaguarInfo.SetActive(false);
        tigerCatInfo.SetActive(false);
        okapiInfo.SetActive(false);
    }
}
