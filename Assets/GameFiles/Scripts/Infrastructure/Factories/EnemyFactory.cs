using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class EnemyFactory : IEnemyFactory
{
    private IAssetProvider _assetProvider;
    public void CreateEnemy(GameObject enemy, Transform spawnPoint, List<Transform> bezierPoints = null)
    {
        GameObject concreteEnemy = Object.Instantiate(enemy);
        concreteEnemy.transform.position = spawnPoint.position;

        foreach (Transform bezierPoint in bezierPoints)
        {
            concreteEnemy.GetComponent<EnemyBezierMove>().Points.Add(bezierPoint);

        }
    }

}
