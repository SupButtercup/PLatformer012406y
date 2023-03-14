using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrappingPlatform : MovingPlatScript
{
    private void move()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
        if (transform.position == targetPos)
        {
            if (targetPos.y > 0)
            {
                transform.position = new Vector3(targetPos.x, -targetPos.y, targetPos.z);
            }
            else
            {
                transform.position = new Vector3(targetPos.x, -targetPos.y + 2, targetPos.z);
            }
        }
        
    }

    private void FixedUpdate()
    {
        move();
    }
}
