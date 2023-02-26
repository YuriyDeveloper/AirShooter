using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SingleEnemySpawner : MonoBehaviour
{
    [SerializeField] private List<SingleEnemyLaunch> _enemyLaunch = new List<SingleEnemyLaunch>();
    

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
             _enemyFactory.CreateEnemy(_enemyLaunch[index].enemyPrefab, _enemyLaunch[index]._bezierMove[0], _enemyLaunch[index]._bezierMove);
        }
    }
}

[Serializable]
public class SingleEnemyLaunch
{
    public GameObject enemyPrefab;
    public int spawnTime;
    public List<Transform> _bezierMove;
}