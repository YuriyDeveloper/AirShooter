using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : IEnemyFactory
{
    private IAssetProvider _assetProvider;
    public GameObject CreateEnemyPlane(EnemyPlaneType type, Transform spawnPoint, List<Transform> bezierPoints)
    {
        _assetProvider = Services.Container.Single<IAssetProvider>();
        if (type == EnemyPlaneType.simplePlane)
        {
            GameObject plane = Object.Instantiate(_assetProvider.Load("Prefabs/EnemyPlanes/EnemyPlane_1"));
            plane.transform.position = spawnPoint.position;
            foreach (Transform bezierPoint in bezierPoints)
            {
                plane.GetComponent<BezierMove>().Points.Add(bezierPoint);
            }
            return plane;
        }
        return null;
      
    }
}
