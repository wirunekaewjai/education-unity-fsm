using UnityEngine;
using Devdayo;
using System;

public class Example : MonoBehaviour
{
    Fsm fsm;

	void Start ()
    {
        fsm = new Fsm(this);
        fsm.Go<StateOne>();
    }
}

public class StateOne : FsmState
{
    public override void OnSubscribe()
    {
        base.OnSubscribe();
        Subscribe<Updater>(OnUpdate);
    }

    public override void OnUnsubscribe()
    {
        base.OnUnsubscribe();
        Unsubscribe<Updater>(OnUpdate);
    }

    public override void OnEnter()
    {
        Debug.Log("State One: Enter");
    }

    public override void OnExit()
    {
        Debug.Log("State One: Exit");
    }

    public void OnUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            fsm.Go<StateTwo>();
        }
    }
}

public class StateTwo : FsmStateBehaviour
{
    public override void OnEnter()
    {
        Debug.Log("State Two: Enter");
    }

    public override void OnExit()
    {
        Debug.Log("State Two: Exit");
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            fsm.Go<StateOne>();
        }
    }
}


