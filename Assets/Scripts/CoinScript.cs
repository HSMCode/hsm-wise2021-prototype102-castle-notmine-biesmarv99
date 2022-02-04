using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            //Instantiate(coin, coinPosition, coin.transform.rotation, gameObject.transform);
            Destroy(gameObject);
        }        
    }
}
