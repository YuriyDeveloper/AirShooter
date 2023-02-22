using System.Collections;
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
    [SerializeField] private List<Transform> _bezierPoints;
    private Transform _spawnPoint;

    [SerializeField] private EnemyType _enemyType;
    [SerializeField] private EnemyPlaneType _enemyPlaneType;

    [SerializeField] private int _countSpawnEnemy;
    [SerializeField] private int _intervalBetweenSpawn;

    private IEnemyFactory _enemyFactory;

    private void Start()
    {
        _enemyFactory = Services.Container.Single<IEnemyFactory>();
        _spawnPoint = _bezierPoints[0];
        ChoiseEnemy();
    }
    private void ChoiseEnemy()
    {
        if (_enemyType == EnemyType.plane)
        {
            StartCoroutine(SpawnEnemyPlane());
            StopCoroutine(SpawnEnemyPlane());
        }
    }

    private IEnumerator SpawnEnemyPlane()
    {
        for (int i = 0; i < _countSpawnEnemy; i++)
        {
            
            GameObject plane = _enemyFactory.CreateEnemyPlane(_enemyPlaneType, _spawnPoint, _bezierPoints);
            yield return new WaitForSeconds(_intervalBetweenSpawn);
        }
    }
}
