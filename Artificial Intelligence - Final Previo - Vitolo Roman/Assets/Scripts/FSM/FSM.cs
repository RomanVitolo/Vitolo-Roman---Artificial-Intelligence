using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM<T>
{
    private FSMState<T> _currentState;

    public void SetInitialState(FSMState<T> initialState)
    {
        _currentState = initialState;
        _currentState.Awake();
    }
    
    public void OnUpdate()
    {
        _currentState.Execute();
    }

    public void DoTransition(T input)
    {
        FSMState<T> newState = _currentState.GetTransition(input);
        if (newState == null) return;
        _currentState.Sleep();
        _currentState = newState;
        newState.Awake();
    }
    
}
