using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Condition")]
public abstract class Condition : ScriptableObject
{
    public abstract bool Check(StateMachine stateMachine);
}