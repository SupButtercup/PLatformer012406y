using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    private bool isCollected = false;
    private Collider2D collider;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isCollected)
        {
            if (collision.CompareTag("Player"))
            {
                isCollected = true;
                collision.GetComponent<PlayerScript>().collectGun(gameObject);
                animator.enabled = false;
                transform.rotation = Quaternion.Euler(0, 0, 0);
                collider.enabled = false;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
