using UnityEngine;

public abstract class Action<T> : ScriptableObject where T : StateMachine
{
    public abstract void Act(T stateMachine);
}
