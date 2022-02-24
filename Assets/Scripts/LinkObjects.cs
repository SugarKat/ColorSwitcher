using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkObjects : MonoBehaviour
{
    GameObject linkedObject;

    public GameObject prefab;
    public bool reverseLink = false;

    void Start()
    {
        if(prefab == null)
        {
            Debug.LogError("Must assing prefab before play");
            return;
        }
        if(reverseLink)
        {
            linkedObject = GameManager.instance.CreateObjectInBlack(transform, prefab);
        }
        else
        {
            linkedObject = GameManager.instance.CreateObjectInColor(transform, prefab);
        }
    }
    private void OnEnable()
    {
        PlayerInput.instance.ChangeSpace += MoveLinkedObject;
    }
    void MoveLinkedObject()
    {
        if (reverseLink && linkedObject != null)
        {
            linkedObject.transform.position = transform.position;
            linkedObject.transform.rotation = transform.rotation;
            return;
        }
        else if (linkedObject != null)
        {
            transform.position = linkedObject.transform.position;
            transform.rotation = linkedObject.transform.rotation;
        }
        else
        {
            Debug.LogError("NO LINKED OBJECT (if this multiple times changing levels theres a problem)");
        }
    }
    private void OnDestroy()
    {
        PlayerInput.instance.ChangeSpace -= MoveLinkedObject;
    }
}
