using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����Щ״̬ת��������
public enum Transition
{
    NullTransition = 0
}
//״̬ID,��ÿһ��״̬��Ψһ��ʾ,һ��״̬��һ��stateid,���Ҹ�����״̬�������ظ�
public enum StateID
{
    NullStateID = 0
}

public abstract class FSMState
{
    protected StateID stateID;
    public StateID ID
    {
        get { return stateID; }
    }

    protected Dictionary<Transition,StateID> map = new Dictionary<Transition, StateID> ();
    public void AddTranstion(Transition trans,StateID id)
    {
        if(Transition.NullTransition == trans || StateID.NullStateID == id)
        {
            Debug.LogError("Transtion or stateid is null");
            return;
        }
        if (map.ContainsKey(trans))
        {
            Debug.LogError("State" +stateID+ "is already has transtion" + trans);
            return;
        }
        map.Add(trans,id);
    }
    public void DeleteTranstion(Transition trans,StateID id)
    {
        if(map.ContainsKey(trans) == false)
        {
            Debug.LogWarning("The transtion" + trans + "what you want to delete is not exist in the map!");
            return;
        }
        map.Remove(trans);
    }
    public StateID GetOutputState(Transition trans)
    {
        if (map.ContainsKey(trans))
        {
            return map[trans];
        }
        return StateID.NullStateID;
    }

    public virtual void DoBeforeEntering() { }
    public virtual void DoBeforeLeaving() { }
}
