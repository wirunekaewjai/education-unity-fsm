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

	void OnDestroy()
	{
		fsm.Destroy();
	}
}

public class StateOne : FsmState
{
    protected override void OnSubscribe ()
	{
		base.OnSubscribe ();
		Subscribe<Updater>(gameObject, OnUpdate);
	}

    protected override void OnUnsubscribe()
    {
        base.OnUnsubscribe();
        Unsubscribe<Updater>(gameObject, OnUpdate);
    }

    protected override void OnEnter ()
	{
		base.OnEnter ();
		Debug.Log("State One: Enter");
	}

    protected override void OnExit ()
	{
		base.OnExit ();
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
	protected override void OnEnter ()
	{
		base.OnEnter ();
        Debug.Log("State Two: Enter");
    }

	protected override void OnExit ()
	{
		base.OnExit ();
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


