using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoppedMovingPlatScript : MovingPlatScript
{
    private bool isActive = false;
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

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isActive = true;
        }
        collision.transform.SetParent(transform);
    }

    protected void FixedUpdate()
    {
        if (isActive)
        {
            move();
        }
    }
}
