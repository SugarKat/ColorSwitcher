using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    public Vector2 MoveBy;
    public float RotateBy;

    private void Start()
    {
        ObjectMover.instance.AddObject(this);
    }
}
