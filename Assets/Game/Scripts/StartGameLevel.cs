using UnityEngine;

public class StartGameLevel : MonoBehaviour
{
    private Services _services;
    private IGameStateMachine _gameStateMachine;

    private void Start()
    {
        _gameStateMachine = (IGameStateMachine)_services.AllServices[ServicesKey._gameStateMachine];
        _gameStateMachine.Enter<LoadSceneState, string>(ScenePath.oneGameLevelScene);
    }
}
