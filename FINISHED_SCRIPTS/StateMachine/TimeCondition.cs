using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TimeCondition", menuName = "SVS_AI/Conditions/TimeCondition")]
public class TimeCondition : Condition
{
    public float timeTOWait = 2f, timePased = 0;

    public override bool Test(Agent agent)
    {
        timePased += Time.deltaTime;
        if (timePased >= timeTOWait)
        {
            timePased = 0;
            return true;
        }
        return false;
    }
}
