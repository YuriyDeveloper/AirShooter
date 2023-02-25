using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupEnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _bezierPoints;
    [SerializeField] private int _countSpawnEnemy;
    [SerializeField] private int _firstSpawnTime;
    [SerializeField] private int _intervalBetweenSpawn;

    private IEnemyFactory _enemyFactory;

    private void Start()
    {
        _enemyFactory = Services.Container.Single<IEnemyFactory>();
        StartCoroutine(Spawn());
    }
   

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(_firstSpawnTime);
        for (int i = 0; i < _countSpawnEnemy; i++)
        {
            
            //_enemyFactory.CreateEnemyPlane();
            yield return new WaitForSeconds(_intervalBetweenSpawn);
        }
    }
}
