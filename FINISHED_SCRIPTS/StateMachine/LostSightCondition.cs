using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "LostSightCondition", menuName = "SVS_AI/Conditions/LostSightCondition")]
public class LostSightCondition : Condition
{
    public override bool Test(Agent agent)
    {
        return agent.target == null;
    }
}
