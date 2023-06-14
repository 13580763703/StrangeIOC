using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : FSMState
{
    private Transform[] waypoints;
    private GameObject npc;
    public PatrolState(Transform[] wp,GameObject npc)
    {
        stateID = StateID.Patrol;
        waypoints = wp;
        this.npc = npc;
    }

    public override void DoBeforeEntering()
    {
        Debug.Log("Entering state" + ID);
    }

    public override void DoUpdate()
    {
        
    }
}
