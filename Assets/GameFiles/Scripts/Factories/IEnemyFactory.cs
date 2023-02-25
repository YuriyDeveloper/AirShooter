

using System.Collections.Generic;
using UnityEngine;

public interface IEnemyFactory : IFactory
{
    public void CreateEnemyPlane(GameObject enemy, Transform spawnPoint, List<Transform> bezierPoints);
   
}
