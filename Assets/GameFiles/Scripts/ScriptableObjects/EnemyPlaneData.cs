using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObject/Enemy")]
public class EnemyPlaneData : ScriptableObject
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private float _speed;

    public Sprite Sprite { get { return _sprite; } }
    public float speed { get { return _speed; } }
}
