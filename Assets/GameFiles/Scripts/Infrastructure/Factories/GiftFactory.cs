using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftFactory : IGiftFactory
{
    private static Pool<GameGift> _pool;

    public GameGift CreateGift(GameGift giftObject, Vector3 spawnPoint)
    {
        if (_pool == null)
        {
            _pool = new Pool<GameGift>(giftObject, 10);
        }
        GameGift concretteGameGift = _pool.GetFreeElement(spawnPoint);
        return concretteGameGift;
    }
}
