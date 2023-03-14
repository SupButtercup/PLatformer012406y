using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnhideScript : MonoBehaviour
{
    public GameObject affectedLayer;
    private Renderer layerSprite;
    // Start is called before the first frame update
    void Start()
    {
        layerSprite = affectedLayer.GetComponent<Renderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            layerSprite.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            layerSprite.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
