using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    plane,
    rockets,
    boss
}

public enum EnemyPlaneType
{
    simplePlane,
    middlePlane,
    hardPlane
}

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;

    [SerializeField] private EnemyType _enemyType;
    [SerializeField] private EnemyPlaneType _enemyPlaneType;

    [SerializeField] private int _countSpawnEnemy;

    private IEnemyFactory _enemyFactory;

    private void Start()
    {
        _enemyFactory = Services.Container.Single<IEnemyFactory>();
        ChoiseEnemy();
    }
    private void ChoiseEnemy()
    {
        if (_enemyType == EnemyType.plane)
        {
            SpawnEnemyPlane();
        }
    }

    private void SpawnEnemyPlane()
    {
        for (int i = 0; i < _countSpawnEnemy; i++)
        {
            GameObject plane = _enemyFactory.CreateEnemyPlane(_enemyPlaneType, _spawnPoint);
            
        }
    }
}
