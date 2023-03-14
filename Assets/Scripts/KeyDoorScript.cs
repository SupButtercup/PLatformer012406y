using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KeyDoorScript : MonoBehaviour
{
    public GameObject key;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (key.gameObject.IsDestroyed())
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
