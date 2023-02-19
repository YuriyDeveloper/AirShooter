

using UnityEngine;

public interface IEnemyFactory : IFactory
{
    public GameObject CreateSimpleEnemyPlane();
    public void CreateMiddleEnemyPlane();
    public void CreateEnemyHardPlane();
}
