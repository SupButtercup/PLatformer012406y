using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatScript : MonoBehaviour
{
    [Header("Positions")]
    public Vector3 startPos;
    public Vector3 targetPos;

    [Header("Movement")]
    public float moveSpeed;

    protected Target target;

    protected bool toTarget;

    protected void Awake()
    {
        target = GetComponentInChildren<Target>();
        startPos = transform.position;
        targetPos = target.transform.position;
        toTarget = true;
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }

    protected void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    protected void FixedUpdate()
    {
        move();
    }
}
