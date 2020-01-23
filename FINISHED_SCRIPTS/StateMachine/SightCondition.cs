using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="SightCondition", menuName ="SVS_AI/Conditions/SightCondition")]
public class SightCondition : Condition
{
    public override bool Test(Agent agent)
    {
        return agent.target;
    }
}
