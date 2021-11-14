using UnityEngine;

[CreateAssetMenu(menuName = "FSM/State")]
public class State : ScriptableObject
{
    [SerializeField] Action[] enterActions;
    [SerializeField] Action[] updateActions;
    [SerializeField] Action[] fixedUpdateActions;
    [SerializeField] Action[] exitActions;
    [SerializeField] Transition[] transitions;

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

    void LoopThroughAndAct(Action[] actions, StateMachine stateMachine)
    {
        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].Act(stateMachine);
        }
    }
}