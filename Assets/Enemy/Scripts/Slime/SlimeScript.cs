using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeScript : SnailScript
{
    [Header("Positions")]
    public Vector3 startPos;
    public Vector3 targetPos;

    private SlimeTarget target;

    private bool toTarget;

    private void Start()
    {
        base.Start();
        target = GetComponentInChildren<SlimeTarget>();
        startPos = transform.position;
        targetPos = new Vector3(target.transform.position.x, startPos.y, startPos.z);
        toTarget = true;

    }

    private void OnBecameInvisible()
    {
        isActive = false;
    }

    private void move()
    {
        transform.localScale = new Vector3(-moveDir, 1, 1);
        if (toTarget)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            if (transform.position.x == targetPos.x)
            {
                toTarget = false;
                moveDir *= -1;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, moveSpeed * Time.deltaTime);
            if (transform.position.x == startPos.x)
            {
                toTarget = true;
                moveDir *= -1;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isActive)
        {
            move();
        }
    }
}
