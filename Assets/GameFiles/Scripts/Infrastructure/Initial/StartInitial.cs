using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartInitial : MonoBehaviour
{
    
    private StartGame _startGame;
    
    private void Start()
    {
        _startGame = new StartGame();

    }
}
