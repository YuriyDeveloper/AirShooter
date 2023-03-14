using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletContainer : MonoBehaviour
{
    [SerializeField] private List<GameObject> _container;
    [SerializeField] private float _spawnInterval;
    public List<GameObject> Container { get => _container; }
    public float SpawnInterval { get => _spawnInterval; }
}
