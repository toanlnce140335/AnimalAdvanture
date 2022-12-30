using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPManager : MonoBehaviour
{
    private string Button1 = "1";
    private string Button2 = "2";
    private string Button3 = "3";
    private string Button4 = "4";
    private string Button5 = "5";

    public void OnPurchaseComplete(Product product)
    {
        if (product.definition.id == Button1)
        {
            Debug.Log("Buy id 1 complete");
            ScoreHandler.instance.increaseCoins(1);
        }
        if (product.definition.id == Button2)
        {
            Debug.Log("Buy id 2 complete");
            ScoreHandler.instance.increaseCoins(2);
        }
        if (product.definition.id == Button3)
        {
            Debug.Log("Buy id 3 complete");
            ScoreHandler.instance.increaseCoins(3);
        }
        if (product.definition.id == Button4)
        {
            Debug.Log("Buy id 4 complete");
            ScoreHandler.instance.increaseCoins(4);
        }
        if (product.definition.id == Button5)
        {
            Debug.Log("Buy id 5 complete");
            ScoreHandler.instance.increaseCoins(5);
        }
    }
    public void OnPurchaseFailure(Product product, PurchaseFailureReason reason)
    {
        Debug.Log("Your purchase failed because" + reason);
    }
}
