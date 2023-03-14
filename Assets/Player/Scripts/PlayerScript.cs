using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public GameObject bulletPrefab;

    [Header("Debug")]
    public bool debug;
    public bool isDead;

    [Header("Shooting")]
    public float shootCDown = 2f;
    private float shootTimer;
    private bool canShoot = false;


    [Header("Movement")]
    public int moveSpeed;
    public int jumpHeight;
    public int maxJumps;
    public float maxJumpVel;
    public LayerMask ground;

    private int jumpCount;

    private float xInput;
    private bool isJumping;
    private bool isWalking;
    private bool hasGun;

    private Rigidbody2D rig;
    private Animator animator;
    private AudioSource audio;
    private Collider2D collider;

    private int facingDir;
    // Start is called before the first frame update
    void Start()
    {
        
        xInput = 0f;
        isJumping = false;
        hasGun = false;
        facingDir = 1;

        shootTimer = 0;

        jumpCount = maxJumps;
    }

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        collider = GetComponent<Collider2D>();
    }

    public void collect(int value)
    {

    }

    public void collectSecret()
    {

    }

    public void die()
    {
        rig.constraints = RigidbodyConstraints2D.FreezePosition;
        collider.enabled = false;
        isDead = true;
        Destroy(gameObject, 3);
        if (hasGun)
        {
            Destroy(GameObject.FindGameObjectWithTag("Gun").gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (!isDead)
        {
            xInput = Input.GetAxis("Horizontal");
            move(xInput);

            if ((rig.velocity.y > maxJumpVel) && isJumping)
            {
                rig.velocity = new Vector2(rig.velocity.x, maxJumpVel);
            }
        }
    }

    private void shoot()
    {
        if (hasGun && canShoot)
        {
            shootTimer = shootCDown;
            canShoot = false;
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = new Vector3(transform.position.x + .724f * facingDir, transform.position.y + .66f, transform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("walking", isWalking);
        animator.SetBool("jumping", isJumping);
        animator.SetBool("isdead", isDead);

        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0)
        {
            canShoot = true;
        }

        if (isGrounded() && rig.velocity.y <= 0)
        {
            resetJumpCount();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            shoot();
        }

        if (debug)
        {
            Debug.DrawRay(transform.position, Vector3.down * 10, Color.white, 0);
        }

    }

    private void jump()
    {
        if (jumpCount > 0)
        {
            isJumping = true;
            rig.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            jumpCount--;
        }
    }

    private void move(float xIn)
    {
        if (xIn != 0 && !isJumping)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
        
        if (xIn > 0)
        {
            facingDir = 1;
        }
        else if (xIn < 0)
        {
            facingDir = -1;
        }
        if (isWalking || isJumping)
        {
            transform.localScale = new Vector3(facingDir, transform.localScale.y, transform.localScale.z);
        }
        rig.velocity = new Vector2(xIn * moveSpeed, rig.velocity.y);
    }

    private void resetJumpCount()
    {
        isJumping = false;
        jumpCount = maxJumps;
    }

    private bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0, -.1f, 0), Vector2.down, .2f, ground);
        if (hit)
        {
            if (hit.collider.gameObject.CompareTag("Ground"))
            {
                return true;
            }
        }
        return false;
    }

    public void collectGun(GameObject gun)
    {
        gun.transform.SetParent(transform);
        gun.transform.localPosition = new Vector3(.724f, .66f, 0);
        if (facingDir < 0)
        {
            gun.GetComponent<SpriteRenderer>().flipX = true;
        }
        hasGun = true;
    }
}
