using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : FSMState
{
    public ChaseState()
    {
        stateID = StateID.Chase;
    }

    public override void DoBeforeEntering()
    {
        Debug.Log("Entering state" + ID);
    }

    public override void DoUpdate()
    {
        
    }
}
