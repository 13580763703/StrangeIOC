using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMSystem
{
    //��ǰ״̬����������Щ״̬
    private Dictionary<StateID, FSMState> states;
    //״̬������ʲô״̬
    private FSMState currentState;
    public FSMState CurrentState
    {
        get { return currentState; }
    }
    public FSMSystem()
    {
        states = new Dictionary<StateID, FSMState>();
    }
    //��״̬���������״̬
    public void AddState(FSMState state)
    {
      if (states == null)
      {
          Debug.LogError("this state what you want to add is null ");return;
      }
      if (states.ContainsKey(state.ID))
      {
          Debug.LogError("this state" + state.ID + " what you want to add is exist!");return;
      }
        state.fsm = this;
      states.Add(state.ID, state);
    }
    //��״̬�����Ƴ�״̬
    public void RemoveState(FSMState state)
    {
        if (states == null)
        {
            Debug.LogError("this state what you want to add is null "); return;
        }
        if (states.ContainsKey(state.ID)==false)
        {
            Debug.LogError("this state"+state.ID+" what you want to remove is not exist!"); return;
        }
        states.Remove(state.ID);
    }

    public void PerformTransition(Transition trans)
    {
        if(trans == Transition.NullTransition)
        {
            Debug.LogError("NullTransition is not allowed for a real transition");
            return;
        }
        StateID id = currentState.GetOutputState(trans);
        if(id == StateID.NullStateID)
        {
            Debug.Log("Transition is not to be happened");
            return ;
        }
        FSMState state;
        states.TryGetValue(id, out state);
        currentState.DoBeforeLeaving();
        currentState = state;
        currentState.DoBeforeEntering();

    }

    public void Start(StateID id)
    {
        FSMState state;
        bool isGet = states.TryGetValue(id, out state);
        if (isGet)
        {
            state.DoBeforeEntering();
            currentState = state;
        }
        else
        {
            Debug.LogError("this state" + id + "is not exist in the fsm.");
        }

    }
}
