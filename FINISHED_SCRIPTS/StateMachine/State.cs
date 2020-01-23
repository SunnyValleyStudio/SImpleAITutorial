using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Agent))]
public class State : MonoBehaviour
{
    public Agent agent;
    public List<Transition> transitions = new List<Transition>();
    protected UniversalMovement movementController;

    private void Awake()
    {
        agent = GetComponent<Agent>();
        movementController = GetComponent<UniversalMovement>();
    }

    public virtual void OnEnable()
    {

    }
    public virtual void OnDisable()
    {

    }

    public virtual void Update()
    {

    }

    private void FixedUpdate()
    {
        foreach (Transition transition in transitions)
        {
            if (transition.condition.Test(agent))
            {
                transition.target.enabled = true;
                this.enabled = false;
                return;
            }
        }
    }

    [Serializable]
    public struct Transition
    {
        public Condition condition;
        public State target;
    }
}
