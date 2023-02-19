using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlane : MonoBehaviour
{

    [SerializeField] private EnemyPlaneData _enemyPlaneData;
    private Sprite _sprite;
    private float _speed;
    private void Start()
    {
        _sprite = GetComponent<Sprite>();
        _sprite = _enemyPlaneData.Sprite;
        _speed = _enemyPlaneData.speed;

    }
}
