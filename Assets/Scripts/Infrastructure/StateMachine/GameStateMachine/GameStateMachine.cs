

using System;
using System.Collections.Generic;

public class GameStateMachine 
{
    private Dictionary<Type, IState> _states;
    private IState _activeState;
    public GameStateMachine()
    {
        _states = new Dictionary<Type, IState>()
        {
            [typeof(GameInitialState)] = new GameInitialState(),
            [typeof(LoadSceneState)] = new LoadSceneState(),
        };
    }

    public void Enter<TState>() where TState : class, IState
    {
        IState state = ChangeState<TState>();
        state.Enter();
    }

    private T ChangeState<T>() where T : class, IState
    {
        _activeState?.Exit();

        T state = GetState<T>();
        _activeState = state;

        return state;
    }

    private TState GetState<TState>() where TState : class, IState 
    {
        return _states[typeof(TState)] as TState;
    }

      
}
