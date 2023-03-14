using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyScript : MonoBehaviour
{
    public float moveSpeed;

    protected Transform target;
    protected bool toTarget = true;

    protected bool isActive = false;

    protected Vector3 startPos;
    protected Vector3 targetPos;

    protected bool isDead = false;
    protected Animator animator;

    // Start is called before the first frame update
    protected void Start()
    {
        target = transform.GetChild(0);
        startPos = transform.position;
        targetPos = target.position;
        animator = GetComponent<Animator>();
    }

    protected void OnBecameVisible()
    {
        isActive = true;
    }

    protected void OnBecameInvisible()
    {
        isActive = false;
    }

    protected void OnCollisionEnter2D(Collision2D collision)
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

    protected void move()
    {
        if (toTarget)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            if (transform.position == targetPos)
            {
                toTarget = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, moveSpeed * Time.deltaTime);
            if (transform.position == startPos)
            {
                toTarget = true;
            }
        }
    }

    protected void die()
    {
        isDead = true;
        animator.SetBool("isDead", isDead);
        Destroy(gameObject, .75f);
    }

    protected void FixedUpdate()
    {
        if (isActive && !isDead)
        {
            move();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
