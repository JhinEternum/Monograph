using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attention : GAction
{
    public override bool PrePerform()
    {
        return true;
    }

    public override bool PostPerform()
    {
        agentBeliefs.RemoveState("attention");
        return true;
    }
}
