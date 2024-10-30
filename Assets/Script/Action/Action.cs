using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : ActionListBehaviour
{
    public abstract void ActionControl();

    public abstract float GetRange();
}
