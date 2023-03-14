using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public GameObject RequiredObjectsController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (RequiredObjectsController.transform.childCount == 0)
        {
            DestroyParentAndChildren(0);
        }
    }

    private void DestroyParentAndChildren(float delay)
    {
        GameObject parent = gameObject;
        List<GameObject> children = new List<GameObject>();
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            children.Add(parent.transform.GetChild(i).gameObject);
        }
        foreach (GameObject child in children)
        {
            Destroy(child.gameObject, delay);
        }
        Destroy(parent, delay);
    }
}
