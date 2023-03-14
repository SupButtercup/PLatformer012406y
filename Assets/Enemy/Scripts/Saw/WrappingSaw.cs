using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrappingSaw : SawScript
{
    private void move()
    {
        if (curIndex == 0)
        {
            transform.position = children[0];
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, curTarget, moveSpeed * Time.deltaTime);
        }
        if (transform.position == curTarget)
        {
            nextTarget();
        }
    }

    private void FixedUpdate()
    {
        move();
    }
}
