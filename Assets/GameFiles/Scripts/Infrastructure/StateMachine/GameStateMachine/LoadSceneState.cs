
public class LoadSceneState : IPayloadedState<string>
{
    private GameStateMachine _gameStateMachine;
    private SceneLoader _sceneLoader;
    public LoadSceneState(GameStateMachine gameStateMachine)
    {
        _sceneLoader = new SceneLoader();
        _gameStateMachine = gameStateMachine;
    }
    public void Enter(string scenePath)
    {
        _sceneLoader.Load(scenePath);
    }

    public void Exit()
    {
        
    }
}
