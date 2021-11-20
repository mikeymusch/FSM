using UnityEngine;

[CreateAssetMenu(menuName = "FSM/State")]
public class State : ScriptableObject
{
    [SerializeField] string name;
    [SerializeField] Action<StateMachine>[] enterActions;
    [SerializeField] Action<StateMachine>[] updateActions;
    [SerializeField] Action<StateMachine>[] fixedUpdateActions;
    [SerializeField] Action<StateMachine>[] exitActions;
    [SerializeField] Transition[] transitions;
    
    public string Name => name;

    public void DoEnterActions(StateMachine stateMachine)
    {
        LoopThroughAndAct(enterActions, stateMachine);
    }

    public void DoUpdateActions(StateMachine stateMachine)
    {
        LoopThroughAndAct(updateActions, stateMachine);
    }

    public void DoFixedUpdateActions(StateMachine stateMachine)
    {
        LoopThroughAndAct(fixedUpdateActions, stateMachine);
    }

    public void DoExitActions(StateMachine stateMachine)
    {
        LoopThroughAndAct(exitActions, stateMachine);
    }

    public State CheckTransitions(StateMachine stateMachine)
    {
        for (int i = 0; i < transitions.Length; i++)
        {
            return transitions[i].CheckCondition(stateMachine) ? transitions[i].TrueState : transitions[i].FalseState;
        }

        return this;
    }

    void LoopThroughAndAct(Action<StateMachine>[] actions, StateMachine stateMachine)
    {
        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].Act(stateMachine);
        }
    }
}
