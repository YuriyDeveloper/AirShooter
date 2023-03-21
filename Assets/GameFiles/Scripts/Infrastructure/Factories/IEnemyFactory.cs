

using System.Collections.Generic;
using UnityEngine;

public interface IEnemyFactory : IFactory
{
    public void CreateEnemy(GameObject enemy, Transform spawnPoint, GameObject bezierPoints);

    public void CreateEnemy(GameObject enemy, Transform spawnPoint, List<Transform> bezierPoints);
}
