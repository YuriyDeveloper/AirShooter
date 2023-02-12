


public class GameInitialState : IState
{
    private GameStateMachine _gameStateMachine;
    public GameInitialState(GameStateMachine gameStateMachine)
    {
        _gameStateMachine = gameStateMachine;
        RegisterServices();
    }
  
    public void Enter()
    {
        _gameStateMachine.Enter<LoadSceneState, string>(ScenePath.downloadScene);
    }

    public void RegisterServices()
    {
        Services.Register("bulletFactory", new BulletFactory());
    }

    public void Exit()
    {

    }
}
