using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    protected Transform target;
    public float smoothSpeed = .15f;
    public Vector3 offset = new Vector3(0, 2, -10);

    public float leftBound;
    public float rightBound;
    public float upBound;
    public float downBound;

    // Start is called before the first frame update
    protected void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void FixedUpdate()
    {
        Vector3 goalPos = target.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, goalPos, smoothSpeed);

        transform.position = smoothPos;

        //transform.LookAt(target);

        if (transform.position.x <= leftBound)
        {
            transform.position = new Vector3(leftBound, transform.position.y, transform.position.z);
        }
        else if (transform.position.x >= rightBound)
        {
            transform.position = new Vector3(rightBound, transform.position.y, transform.position.z);
        }
        if (transform.position.y <= downBound)
        {
            transform.position = new Vector3(transform.position.x, downBound, transform.position.z);
        }
        else if (transform.position.y >= upBound)
        {
            transform.position = new Vector3(transform.position.x, upBound, transform.position.z);
        }
    }

    private void LateUpdate()
    {
        
    }
}
