using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Transform target;

    public Transform blackPlayer;
    public Transform colorPlayer;
    public float followSpeed = 2f;

    private void Start()
    {
        target = blackPlayer;
        PlayerInput.instance.ChangeSpace += ChangeTarget;
    }
    void ChangeTarget()
    {
        if (target == blackPlayer)
        {
            target = colorPlayer;
        }
        else target = blackPlayer;
    }
    void Update()
    {
        float xTarget = target.position.x;
        float yTarget = target.position.y;

        float xNew = Mathf.Lerp(transform.position.x, xTarget, Time.deltaTime * followSpeed);
        float yNew = Mathf.Lerp(transform.position.y, yTarget, Time.deltaTime * followSpeed);

        transform.position = new Vector3(xNew, yNew, transform.position.z);
    }
    private void OnDisable()
    {
        PlayerInput.instance.ChangeSpace -= ChangeTarget;
    }
}
