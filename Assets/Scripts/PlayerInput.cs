using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInput : MonoBehaviour
{
    public static PlayerInput instance;

    public delegate void ChangeAction();
    public event ChangeAction ChangeSpace;
    public delegate void Interact();
    public event Interact PlayerInteraction;

    [SerializeField]
    EntityController blackPlayer;
    [SerializeField]
    EntityController colorPlayer;
    public float speed = .2f;
    public float jumpForce = .5f;
    public float Timer = 10f;
    public TextMeshProUGUI TimerText;

    float countdown;
    bool activeBlack = true;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Too much input O_o");
            Destroy(this);
            return;
        }
        instance = this;
    }
    private void Start()
    {
        countdown = Timer;
    }
    void Update()
    {
        if(!activeBlack)
        {
            countdown -= Time.deltaTime;
            TimerText.text = string.Format("{0:00}", countdown % 60);
            if(countdown <= 0)
            {
                activeBlack = !activeBlack;
                ChangeSpace?.Invoke();
                countdown = Timer;
            }
        }
        float horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.F))
        {
            activeBlack = !activeBlack;
            ChangeSpace?.Invoke();
            countdown = Timer;
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            PlayerInteraction?.Invoke();
        }
        if(activeBlack)
        {
            blackPlayer.Move(horizontal, speed);
            if(Input.GetKeyDown(KeyCode.Space))
            {
                blackPlayer.Jump(jumpForce);
            }
        }
        else
        {
            colorPlayer.Move(horizontal, speed);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                colorPlayer.Jump(jumpForce);
            }
        }
    }
}
