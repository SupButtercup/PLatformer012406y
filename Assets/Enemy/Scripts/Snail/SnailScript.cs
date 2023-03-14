using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailScript : MonoBehaviour
{
    public int moveDir = -1;
    public float moveSpeed;

    private Rigidbody2D rig;
    private Animator animator;

    public bool isActive;
    public bool isDead;

    public LayerMask layer;

    // Start is called before the first frame update
    protected void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        isDead = false;
    }

    public void die()
    {
        isDead = true;
        Destroy(gameObject, 1);
    }

    private void move()
    {
        transform.localScale = new Vector3(-moveDir, 1, 1);
        rig.velocity = new Vector2(moveSpeed * moveDir, rig.velocity.y);
    }

    private void FixedUpdate()
    {
        if (isActive)
        {
            move();
            checkForWall();
        }
    }

    private void OnBecameVisible()
    {
        isActive = true;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject player = collision.gameObject;
        if (collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<PlayerScript>().die();
            /*if (player.transform.position.y < transform.position.y)
            {
                player.GetComponent<PlayerScript>().die();
            }*/
            /*else
            {
                die();
            }*/

        }
        if (collision.gameObject.CompareTag("Damage") || collision.gameObject.CompareTag("PlayerBullet"))
        {
            die();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            animator.SetBool("isdead", isDead);
        }
    }

    private void checkForWall()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * moveDir, .75f, layer);
        if (hit)
        {
            moveDir *= -1;
        }
    }
}
