using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Condition : ScriptableObject
{
    public virtual bool Test(Agent agent)
    {
        return false;
    }
}
