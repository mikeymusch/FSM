using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] State initialState;
    State _currentState;

    public void Awake()
    {
        Initialize(initialState);
    }

    void Update()
    {
        _currentState.DoUpdateActions(this);
        ChangeStateIfNecessary(this);
    }

    void FixedUpdate()
    {
        _currentState.DoFixedUpdateActions(this);
    }

    #region State Changing Methods

    void ChangeState(State state)
    {
        _currentState.DoExitActions(this);
        Initialize(state);
    }

    void Initialize(State state)
    {
        _currentState = state;
        _currentState.DoEnterActions(this);
    }

    void ChangeStateIfNecessary(StateMachine stateMachine)
    {
        var nextState = _currentState.CheckTransitions(this);
        if (nextState != _currentState)
            ChangeState(nextState);
    }

    #endregion
}