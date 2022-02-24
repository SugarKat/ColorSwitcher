using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunctionality : ButttonInteractivity
{
    public override void ActivateAction()
    {
        GameManager.instance.ActivateObj();
    }
}
