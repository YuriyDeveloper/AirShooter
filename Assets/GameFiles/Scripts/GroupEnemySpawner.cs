using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GroupEnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GroupEnemyLaunch> _groupEnemyLaunch = new List<GroupEnemyLaunch>();
    [SerializeField] private int _intervalBetweenSpawnTime;

    private IEnemyFactory _enemyFactory;

    private void Start()
    {
        _enemyFactory = Services.Container.Single<IEnemyFactory>();
        StartCoroutine(Spawn());
        StopCoroutine(Spawn());

    }

    private IEnumerator Spawn()
    {

        for (int indexLaunch = 0; indexLaunch < _groupEnemyLaunch.Count; indexLaunch++)
        {
            yield return new WaitForSeconds(_groupEnemyLaunch[indexLaunch]._firstSpawnTime);
            for (int indexEnemyPrefab = 0; indexEnemyPrefab < _groupEnemyLaunch[indexLaunch].enemyPrefabs.Count; indexEnemyPrefab++)
            {
                _enemyFactory.CreateEnemy(_groupEnemyLaunch[indexLaunch].enemyPrefabs[indexEnemyPrefab], _groupEnemyLaunch[indexLaunch]._bezierMove[0], _groupEnemyLaunch[indexLaunch]._bezierMove);
                yield return new WaitForSeconds(_intervalBetweenSpawnTime);
            }
                
        }
    }
}

[Serializable]
public class GroupEnemyLaunch
{
    public List<GameObject> enemyPrefabs;
    public int _firstSpawnTime;
    public List<Transform> _bezierMove;
}