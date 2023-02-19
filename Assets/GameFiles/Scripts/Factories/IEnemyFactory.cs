

using UnityEngine;

public interface IEnemyFactory : IFactory
{
    public GameObject CreateEnemyPlane(EnemyPlaneType type, Transform point);
   
}
