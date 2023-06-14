using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCControl : MonoBehaviour
{
    private FSMSystem fsm;
    public Transform[] waypoints;
    // Start is called before the first frame update
    void Start()
    {
        InitFSM();
    }
    /// <summary>
    /// ³õÊ¼»¯×´Ì¬»ú
    /// </summary>
    void InitFSM()
    {
        fsm = new FSMSystem();

        PatrolState patrolState = new PatrolState(waypoints,this.gameObject);
        patrolState.AddTranstion(Transition.SawPlayer, StateID.Chase);

        ChaseState chaseState = new ChaseState();
        chaseState.AddTranstion(Transition.LostPlayer, StateID.Patrol);

        fsm.AddState(patrolState);
        fsm.AddState(chaseState);

        fsm.Start(StateID.Patrol);
    }

    private void Update()
    {
        fsm.CurrentState.DoUpdate();
    }
}
