using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public int value;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (CompareTag("Secret"))
            {
                collision.GetComponent<PlayerScript>().collectSecret();
            }
            else
            {
                collision.GetComponent<PlayerScript>().collect(value);
            }
            Destroy(gameObject);
        }
    }

}
