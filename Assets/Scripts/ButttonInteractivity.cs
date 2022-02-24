using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButttonInteractivity : MonoBehaviour
{
    public GameObject text;

    private void OnEnable()
    {
        text.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            text.SetActive(true);
            PlayerInput.instance.PlayerInteraction += ActivateAction;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            text.SetActive(false);
            PlayerInput.instance.PlayerInteraction -= ActivateAction;
        }
    }
    public virtual void ActivateAction()
    {
        Debug.Log("This is class is used as a base for other buttons functionality");
    }
}
