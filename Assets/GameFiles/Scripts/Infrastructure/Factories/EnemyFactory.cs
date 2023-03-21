using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class EnemyFactory : IEnemyFactory
{
    public void CreateEnemy(GameObject enemy, Transform spawnPoint, GameObject bezierPoints = null)
    {
        GameObject concreteEnemy = Object.Instantiate(enemy);
        concreteEnemy.transform.position = spawnPoint.position;
        foreach (Transform child in bezierPoints.transform)
        {
            concreteEnemy.GetComponent<EnemyBezierMove>().Points.Add(child);
        }
    }

    public void CreateEnemy(GameObject enemy, Transform spawnPoint, List<Transform> bezierPoints = null)
    {
        GameObject concreteEnemy = Object.Instantiate(enemy);
        concreteEnemy.transform.position = spawnPoint.position;
        foreach (Transform child in bezierPoints)
        {
            concreteEnemy.GetComponent<EnemyBezierMove>().Points.Add(child);
        }
    }

}
