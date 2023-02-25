using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SingleEnemySpawner : MonoBehaviour
{
    [SerializeField] private List<EnemyLaunch> _enemyLaunch = new List<EnemyLaunch>();
    

    private IEnemyFactory _enemyFactory;

    private void Start()
    {
        _enemyFactory = Services.Container.Single<IEnemyFactory>();
        StartCoroutine(Spawn());
        StopCoroutine(Spawn());
        
    }

    private IEnumerator Spawn()
    {

        for (int index = 0; index < _enemyLaunch.Count; index++)
        {
             yield return new WaitForSeconds(_enemyLaunch[index].spawnTime);
             _enemyFactory.CreateEnemy(_enemyLaunch[index].enemyPrefab, _enemyLaunch[index].spawnPoint, _enemyLaunch[index]._bezierMove);
        }
    }
}

[Serializable]
public class EnemyLaunch
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public int spawnTime;
    public List<Transform> _bezierMove;
}