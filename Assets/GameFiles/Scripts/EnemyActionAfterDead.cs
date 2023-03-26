using System.ComponentModel;
using UnityEngine;

public class EnemyActionAfterDead : MonoBehaviour
{
    [SerializeField] private GameGift _gameCoin;
    private IGiftFactory _giftFactory;


    public void SpawnCoin()
    {
        _giftFactory = Services.Container.Single<IGiftFactory>();
        _giftFactory.CreateGift(_gameCoin, transform.position);
    }
}
