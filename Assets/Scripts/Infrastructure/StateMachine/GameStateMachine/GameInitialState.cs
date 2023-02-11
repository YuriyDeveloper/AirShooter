


public class GameInitialState : IState
{
    private GameStateMachine _gameStateMachine;
    public GameInitialState(GameStateMachine gameStateMachine)
    {
        _gameStateMachine = gameStateMachine;
    }
  
    public void Enter()
    {
        _gameStateMachine.Enter<LoadSceneState>();
    }

    public void Exit()
    {

    }
}
