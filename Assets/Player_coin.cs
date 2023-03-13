using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_coin : MonoBehaviour
{
    public int nCoin = 0;
    public Text TextCoins;

    // Update is called once per frame
    void Update()
    {
        TextCoins.text= nCoin + " x";
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "coin")
        {
            nCoin = nCoin + 1;
        }
    }
}
