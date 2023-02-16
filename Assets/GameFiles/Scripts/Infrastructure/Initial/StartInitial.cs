using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartInitial : MonoBehaviour
{
    private StartGame _startGame;
    private void Awake()
    {
        _startGame = new StartGame();
    }
}
