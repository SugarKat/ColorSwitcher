using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public static ObjectMover instance;

    List<BlockMovement> objectsToMove = new List<BlockMovement>();
    int dir = 1;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("ObjectMover per daug");
            Destroy(this);
            return;
        }
        instance = this;
    }
    private void Start()
    {
        GameManager.instance.MoveObjects += ActivateObjects;
    }
    void ActivateObjects()
    {
        MoveObjects();
        RotateObjects();
        dir *= -1;
    }
    void MoveObjects()
    {
        foreach (BlockMovement obj in objectsToMove)
        {
            Vector3 pos = obj.transform.position;
            obj.transform.position = new Vector3(pos.x + (obj.MoveBy.x * dir), pos.y + (obj.MoveBy.y * dir), 0);
        }
    }
    void RotateObjects()
    {
        foreach (BlockMovement obj in objectsToMove)
        {
            Vector3 rotation = obj.transform.rotation.eulerAngles;
            rotation.z += obj.RotateBy * dir;
            obj.transform.rotation = Quaternion.Euler(rotation);
        }
    }
    private void OnDisable()
    {
        GameManager.instance.MoveObjects -= ActivateObjects;
    }
    public void AddObject(BlockMovement obj)
    {
        objectsToMove.Add(obj);
    }
}
