

using UnityEngine;

public class EnemyFactory : IEnemyFactory
{
    private IAssetProvider _assetProvider;
    public GameObject CreateSimpleEnemyPlane()
    {
        // GameObject plane = Object.Instantiate(Resources.Load("Prefabs/EnemyPlanes/EnemyPlane"));
        EnemyPlane plane = _assetProvider.Load("Prefabs/EnemyPlanes/EnemyPlane");
        plane
        return plane;
    }
    
    public void CreateMiddleEnemyPlane()
    {
        
    }

    public void CreateEnemyHardPlane()
    {
       
    }
}
