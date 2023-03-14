using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockerScript : MonoBehaviour
{
    public int length;
    [Header("Prefabs")]
    public GameObject head;
    public GameObject body;
    public GameObject bodyAlt;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;

        GameObject headPart = Instantiate(head);
        headPart.transform.SetParent(transform);
        headPart.transform.localPosition = Vector3.zero;

        for (int i = 0; i < length - 1; i++)
        {
            GameObject bodyPart;
            if (i % 2 == 0)
            {
                bodyPart = Instantiate(bodyAlt);
            }
            else
            {
                bodyPart = Instantiate(body);
            }
            bodyPart.transform.SetParent(transform);
            bodyPart.transform.localPosition = new Vector3(0, -i - 1, 0);
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
