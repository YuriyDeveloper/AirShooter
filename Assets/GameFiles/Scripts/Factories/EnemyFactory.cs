using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : IEnemyFactory
{
    private IAssetProvider _assetProvider;
    public GameObject CreateEnemyPlane(EnemyType enemyType, EnemyPlaneType type, SimpleEnemyPlaneID _simpleEnemyPlaneID, Transform spawnPoint, List<Transform> bezierPoints)
    {
        _assetProvider = Services.Container.Single<IAssetProvider>();
        if (type == EnemyPlaneType.simplePlane)
        {
            GameObject plane = Object.Instantiate(_assetProvider.LoadEnemy("Prefabs/Enemy/EnemyPlane_1"));
            plane.transform.position = spawnPoint.position;
            foreach (Transform bezierPoint in bezierPoints)
            {
                plane.GetComponent<EnemyBezierMove>().Points.Add(bezierPoint);
                
            }
            return plane;
        }















        return null;
      
    }
}
