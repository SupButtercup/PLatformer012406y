using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.U2D.Path;
using UnityEngine;

public class FrogScript : MonoBehaviour
{
    [Header("Jumping")]
    public float jumpHeight;
    public float longJumpLength;
    public float jumpSpeed;
    public LayerMask ground;
    private float jumpTimer;

    private float jumpLength;

    public int facingDir;

    public float range;

    [Header("Aggro")]
    public int patience;

    private int patienceCount = 0;

    private bool mad = false;

    [Header("Health")]
    public int health;

    private Rigidbody2D rig;
    private Transform player;
    private Animator animator;
    private bool isDead = false;
    private bool isJumping = false;
    private bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();

        jumpTimer = jumpSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isDead)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<PlayerScript>().die();
            }
            if (collision.gameObject.CompareTag("PlayerBullet"))
            {
                hurt();
            }
        }
    }

    private void OnBecameVisible()
    {
        isActive = true;
    }

    private void hurt()
    {
        rig.velocity = Vector2.zero;
        health--;
        animator.Play("HurtAnim");
        if (health <= 0)
        {
            isDead = true;
            Destroy(gameObject, 2);
        }
    }

    private void jump()
    {
        jumpTimer = jumpSpeed;
        Vector2 jumpVel;
        if ((math.abs(transform.position.x - player.position.x) >= range) || mad)
        {
            jumpVel = new Vector2(longJumpLength * facingDir, jumpHeight * .5f);
            mad = false;
            patienceCount = 0;
        }
        else
        {
            jumpVel = new Vector2(jumpLength * .5f * facingDir, jumpHeight);
            anger();
        }
        rig.AddForce(jumpVel, ForceMode2D.Impulse);
    }

    private void anger()
    {
        patienceCount++;
        if (patienceCount >= patience)
        {
            mad = true;
        }
    }

    private bool grounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1, ground);
        if (hit)
        {
            if (isJumping)
            {
                rig.velocity = Vector2.zero;
            }
            return true;
        }
        else
        {
            return false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            isJumping = !grounded();
            animator.SetBool("isDead", isDead);
            animator.SetBool("isJumping", isJumping);
            if (player.position.x > transform.position.x)
            {
                facingDir = 1;
            }
            else
            {
                facingDir = -1;
            }
            if (!isJumping)
            {
                transform.localScale = new Vector3(facingDir, 1, 1);
            }

            jumpLength = math.abs(transform.position.x - player.position.x);

            if (!isDead && !isJumping)
            {
                jumpTimer -= Time.deltaTime;
                if (jumpTimer <= 0)
                {
                    jump();
                }
            }
        }
    }
}
