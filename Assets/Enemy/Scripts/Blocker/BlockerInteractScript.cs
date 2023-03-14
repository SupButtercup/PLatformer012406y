using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockerInteractScript : MonoBehaviour
{
    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!isDead)
            {
                collision.gameObject.GetComponent<PlayerScript>().die();
            }
        }
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            die();
        }
    }

    private void die()
    {
        isDead = true;
        Rigidbody2D[] rigs = transform.parent.GetComponentsInChildren<Rigidbody2D>();
        Animator[] animators = transform.parent.GetComponentsInChildren<Animator>();
        Collider2D[] colliders = transform.parent.GetComponentsInChildren<Collider2D>();
        foreach (Rigidbody2D rig in rigs)
        {
            rig.gravityScale = 1;
        }
        foreach (Animator animator in animators)
        {
            animator.enabled = false;
        }
        foreach( Collider2D collider in colliders)
        {
            collider.enabled = false;
        }
        DestroyParentAndChildren(1.5f);
    }

    private void DestroyParentAndChildren(float delay)
    {
        GameObject parent = transform.parent.gameObject;
        List<GameObject> children = new List<GameObject>();
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            children.Add(parent.transform.GetChild(i).gameObject);
        }
        foreach (GameObject child in children)
        {
            Destroy(child.gameObject, delay);
        }
        Destroy(parent, delay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
