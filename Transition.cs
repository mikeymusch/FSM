using System;
using UnityEngine;

[Serializable]
public class Transition
{
    [SerializeField] Condition condition;
    [SerializeField] State trueState;
    [SerializeField] State falseState;

    public State TrueState => trueState;
    public State FalseState => falseState;

    public bool CheckCondition(StateMachine stateMachine)
    {
        return condition.Check(stateMachine);
    }
}