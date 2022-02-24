using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityController : MonoBehaviour
{
    public bool multiJumping = false;

    Rigidbody2D rg2D;
    bool isLanded = true;

    private void Awake()
    {
        rg2D = GetComponent<Rigidbody2D>();
    }
    public void Move(float value, float speed)
    {
        Vector2 dir = new Vector2(value * speed, rg2D.velocity.y);
        rg2D.velocity = dir;
    }
    public void Jump(float value)
    {
        if(isLanded || multiJumping)
        {
            Vector2 force = new Vector2(rg2D.velocity.x, value);
            rg2D.velocity = force;
            isLanded = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isLanded = true;
    }
}
