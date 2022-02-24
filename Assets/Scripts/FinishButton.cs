using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishButton : ButttonInteractivity
{
    public override void ActivateAction()
    {
        GameManager.instance.LoadNextLevel();
    }
}
