using System;
using System.Collections.Generic;

public class GameStateMachine : IGameStateMachine
{
    private Dictionary<Type, IExitableState> _states;
    private IExitableState _activeState;
    public GameStateMachine()
    {
        _states = new Dictionary<Type, IExitableState>()
        {
            [typeof(ProjectInitialState)] = new ProjectInitialState(this),
            [typeof(LoadSceneState)] = new LoadSceneState(this),
            [typeof(MainMenuState)] = new MainMenuState(this),
            [typeof(GamePauseState)] = new GamePauseState(this),
            [typeof(GameLoopState)] = new GameLoopState(this)
        };
    }

    public void Enter<TState>() where TState : class, IState
    {
       
        IState state = ChangeState<TState>();
        state.Enter();
    }

    public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
    {
        TState state = ChangeState<TState>();
        state.Enter(payload);
    }

    private TState ChangeState<TState>() where TState : class, IExitableState
    {
        _activeState?.Exit();

        TState state = GetState<TState>();
        _activeState = state;

        return state;
    }

    private TState GetState<TState>() where TState : class, IExitableState 
    {
        return _states[typeof(TState)] as TState;
    }

      
}
