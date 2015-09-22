using UnityEngine;
using Devdayo;
using System;

public class Example : MonoBehaviour
{
    private Fsm fsm;

    void Awake()
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

        FsmEvent<Collision2D>.Subscribe<CollisionEnter2D>(gameObject, OnCollisionEnter2D);
    }

    public override void OnUnsubscribe()
    {
        base.OnUnsubscribe();

        FsmEvent<Collision2D>.Unsubscribe<CollisionEnter2D>(gameObject, OnCollisionEnter2D);
    }

    public override void OnEnter()
    {
        Debug.Log("One: Enter");
    }

    public override void OnExit()
    {
        Debug.Log("One: Exit");
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision Enter 2D: " + other.gameObject.name);
        fsm.Go<StateTwo>();
    }
}

public class StateTwo : FsmStateBehaviour
{
    public override void OnEnter()
    {
        Debug.Log("Two: Enter");
    }

    public override void OnExit()
    {
        Debug.Log("Two: Exit");
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            fsm.Go<StateOne>();
        }
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
        Debug.Log("Two: Fixed Updating");
    }
}