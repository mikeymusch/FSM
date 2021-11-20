using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] State initialState;
    protected State _currentState;
    
    public State CurrentState => _currentState;

    protected virtual void Awake()
    {
        Initialize(initialState);
    }

    protected virtual void Update()
    {
        _currentState.DoUpdateActions(this);
        ChangeStateIfNecessary(this);
    }

    protected virtual void FixedUpdate()
    {
        _currentState.DoFixedUpdateActions(this);
    }

    #region State Changing Methods

    protected virtual void ChangeState(State state)
    {
        _currentState.DoExitActions(this);
        Initialize(state);
    }

    protected virtual void Initialize(State state)
    {
        _currentState = state;
        _currentState.DoEnterActions(this);
    }

    protected virtual void ChangeStateIfNecessary(StateMachine stateMachine)
    {
        var nextState = _currentState.CheckTransitions(this);
        if (nextState != _currentState)
            ChangeState(nextState);
    }

    #endregion
}
