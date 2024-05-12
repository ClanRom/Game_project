using System;
using System.Collections.Generic;
public class StateMachine
{
    private StateSM _currentState;
    private Dictionary<Type, StateSM> _states = new Dictionary<Type, StateSM>();
    
    public StateSM CurrentState => _currentState;
    public void AddState(StateSM state)
    {
        _states.Add(state.GetType(), state);
    }

    public void EnterIn<T>() where T : StateSM
    {
        var type = typeof(T);
        if (type == _currentState?.GetType())
            return;

        if (_states.TryGetValue(typeof(T), out StateSM state))
        {
            _currentState?.Exit();
            _currentState = state;
            _currentState.Enter();
        }
    }

    public void Update()
    {
        _currentState?.Update();
    }
}
