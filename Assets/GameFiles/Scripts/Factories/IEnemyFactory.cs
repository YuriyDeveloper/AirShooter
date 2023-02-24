

using System.Collections.Generic;
using UnityEngine;

public interface IEnemyFactory : IFactory
{
    public GameObject CreateEnemyPlane(EnemyType enemyType, EnemyPlaneType type, SimpleEnemyPlaneID _simpleEnemyPlaneID, Transform spawnPoint, List<Transform> bezierPoints);
   
}
