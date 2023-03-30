using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameCoin : GameGift
{
    [SerializeField] private float _moveSpeed;

    private IGameData _gameData;

    private void Update()
    {
        transform.position += new Vector3(0, _moveSpeed * -1 * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<MainPlayer>())
        {
            UICoinText.SetCoinCount();
            _gameData = Services.Container.Single<IGameData>();
            _gameData.IncreaseInt(StatsParameter.STAT_PARAM_COIN_COUNT);
            gameObject.SetActive(false);
        }
    }
}
