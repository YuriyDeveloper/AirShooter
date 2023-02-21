

using System.Collections.Generic;
using UnityEngine;

public interface IEnemyFactory : IFactory
{
    public GameObject CreateEnemyPlane(EnemyPlaneType type, Transform point, List<Transform> bezierPoints);
   
}
