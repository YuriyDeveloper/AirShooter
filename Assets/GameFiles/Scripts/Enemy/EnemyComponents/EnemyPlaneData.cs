using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlaneData : MonoBehaviour
{
    [SerializeField] private float _collisisonDamage;

    public float CollisionDamage { get => _collisisonDamage; }
}
