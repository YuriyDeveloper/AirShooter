using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : IEnemyFactory
{
    private IAssetProvider _assetProvider;
    public void CreateEnemyPlane(GameObject enemy, Transform spawnPoint, List<Transform> bezierPoints = null)
    {
           
        GameObject concreteEnemy = Object.Instantiate(enemy);
        concreteEnemy.transform.position = spawnPoint.position;

       
    }
}
