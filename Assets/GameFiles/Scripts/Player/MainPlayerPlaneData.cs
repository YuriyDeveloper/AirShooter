using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerPlaneData : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPointsTransform;
    [SerializeField] private float _collisisonDamage;

    public float CollisionDamage { get => _collisisonDamage; }

    private float _giftCoinCount;

    public void GetGiftCoin(int count)
    {

    }

}
