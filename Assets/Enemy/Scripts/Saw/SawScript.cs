using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SawScript : MonoBehaviour
{
    protected List<Vector3> children = new List<Vector3>();
    protected Vector3 curTarget;
    protected int curIndex;

    public float moveSpeed;

    protected bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        curIndex = 1;
        children.Add(transform.position);
        for (int i = 0; i < transform.childCount; i++)
        {
            children.Add(transform.GetChild(i).transform.position);
        }
        curTarget = children[curIndex];
    }

    protected void OnBecameVisible()
    {
        isActive = true;
    }

   /* protected void OnBecameInvisible()
    {
        isActive = false;
    }*/

    protected void move()
    {
        transform.position = Vector3.MoveTowards(transform.position, curTarget, moveSpeed * Time.deltaTime);
        if (transform.position == curTarget)
        {
            nextTarget();
        }


        /*if (toTarget)
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
        }*/
    }

    protected void nextTarget()
    {
        curIndex++;
        try
        {
            curTarget = children[curIndex];
        }
        catch (System.ArgumentOutOfRangeException)
        {
            curIndex = 0;
            curTarget = children[curIndex];
        }
        
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerScript>().die();
        }
    }

    protected void FixedUpdate()
    {
        if (isActive)
        {
            move();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
