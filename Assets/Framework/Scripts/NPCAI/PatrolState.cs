using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class PatrolState : FSMState
{
    private Transform[] waypoints;
    private GameObject npc;
    private Rigidbody npcRd;
    private int targetWaypoint;
    private GameObject player;
    public PatrolState(Transform[] wp, GameObject npc, GameObject player)
    {
        stateID = StateID.Patrol;
        waypoints = wp;
        this.npc = npc;
        targetWaypoint = 0;
        npcRd = npc.GetComponent<Rigidbody>();
        this.player = player;
    }

    public override void DoBeforeEntering()
    {
        Debug.Log("Entering state" + ID);
    }

    public override void DoUpdate()
    {
        CheckTransition();
        PatrolMove();
    }
    private void CheckTransition()
    {
        if (Vector3.Distance(player.transform.position, npc.transform.position) < 5)
        {
            fsm.PerformTransition(Transition.SawPlayer);
        }
    }

    private void PatrolMove()
    {
        npcRd.velocity = npc.transform.forward * 3;
        Transform targetTrans = waypoints[targetWaypoint];
        Vector3 targetPosition = targetTrans.position;
        targetPosition.y = npc.transform.position.y;
        npc.transform.LookAt(targetPosition);
        if (Vector3.Distance(npc.transform.position, targetPosition) < 1)
        {
            targetWaypoint++;
            targetWaypoint %= waypoints.Length;
        }
    }
}
