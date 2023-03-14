using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StingerScript : MonoBehaviour
{
    public float speed;
    public float lifeSpan;

    public float lifeTimer;

    private Transform player;
    private Rigidbody2D rig;

    private Vector3 targetPos;
    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rig = GetComponent<Rigidbody2D>();
        lifeTimer = lifeSpan;
        targetPos = player.position;
        direction = (targetPos - transform.position).normalized;

        transform.rotation = Quaternion.LookRotation(Vector3.forward, transform.position - player.position);
        rig.AddForce(direction * speed, ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0 )
        {
            Destroy(gameObject);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerScript>().die();
        }
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
