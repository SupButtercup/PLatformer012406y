using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed;
    public float lifeSpan;

    public float lifeTimer;

    private Rigidbody2D rig;

    private Vector3 targetPos;
    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        lifeTimer = lifeSpan;
        targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (targetPos - transform.position).normalized;

        transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
        transform.Rotate(new Vector3(0, 0, 90));
        rig.AddForce(direction * speed, ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
