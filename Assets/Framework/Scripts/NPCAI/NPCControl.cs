using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCControl : MonoBehaviour
{
    private FSMSystem fsm;
    public Transform[] waypoints;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        InitFSM();
    }
    /// <summary>
    /// ³õÊ¼»¯×´Ì¬»ú
    /// </summary>
    void InitFSM()
    {
        fsm = new FSMSystem();

        PatrolState patrolState = new PatrolState(waypoints,this.gameObject,player);
        patrolState.AddTranstion(Transition.SawPlayer, StateID.Chase);

        ChaseState chaseState = new ChaseState(this.gameObject,player);
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
