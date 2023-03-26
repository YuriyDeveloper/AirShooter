using UnityEngine;

public interface IGiftFactory : IFactory
{
    public GameGift CreateGift(GameGift giftObject, Vector3 spawnPoint);
}
