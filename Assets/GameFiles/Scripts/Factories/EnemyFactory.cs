

using UnityEngine;

public class EnemyFactory : IEnemyFactory
{
    private IAssetProvider _assetProvider;
    public GameObject CreateEnemyPlane(EnemyPlaneType type, Transform point)
    {
        _assetProvider = Services.Container.Single<IAssetProvider>();
        if (type == EnemyPlaneType.simplePlane)
        {
             return Object.Instantiate(_assetProvider.Load("Prefabs/EnemyPlanes/EnemyPlane_1"), point);
        }
        return null;
      
    }
}
