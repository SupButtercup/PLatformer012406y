using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeScript : FlyScript
{
    public GameObject bulletPrefab;
    public LayerMask playerLayer;
    public LayerMask groundLayer;
    public bool debug = false;
    public float bulletTime;
    private float bulletCDown;

    private int facingDir = 1;

    private Transform player;

    void Start()
    {
        target = transform.GetChild(0);
        startPos = transform.position;
        targetPos = target.position;

        bulletCDown = bulletTime;

        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    private void die()
    {
        isDead = true;
        animator.SetBool("isDead", isDead);
        Destroy(gameObject, .75f);
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

    private bool seePlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -(transform.position - player.position), (transform.position - player.position).magnitude, groundLayer);
        
        if (!hit)
        {
            if (-(transform.position - player.position).x < 0)
            {
                facingDir = 1;
            }
            else
            {
                facingDir = -1;
            }
            return true;
        }
        return false;
    }

    private void shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = new Vector3(transform.position.x + .101f * facingDir, transform.position.y - .292f, transform.position.z);
    }

    private void Update()
    {
        if (isActive)
        {
            transform.localScale = new Vector3(facingDir, 1, 1);
            if (debug)
            {
                print(seePlayer());
                Debug.DrawRay(transform.position, -(transform.position - player.position), Color.white);
            }
            if (seePlayer())
            {
                bulletCDown -= Time.deltaTime;
                if (bulletCDown <= 0)
                {
                    bulletCDown = bulletTime;
                    shoot();
                }
            }
        }
    }
}
