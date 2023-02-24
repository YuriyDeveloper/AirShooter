
using UnityEngine;

public class BulletFactory : IBulletFactory
{
    private IAssetProvider _assetProvider;


    public SimpleBullet CreateSimpleBullet(BulletType bulletType)
    {
        _assetProvider = Services.Container.Single<IAssetProvider>();
        SimpleBullet bullet = null;
        if (bulletType == BulletType.MainPlayer)
        {
            bullet = _assetProvider.LoadBullet("Prefabs/Bullets/PlayerSimpleBullet");
        }
        else if (bulletType == BulletType.Enemy)
        {
            bullet = _assetProvider.LoadBullet("Prefabs/Bullets/EnemySimpleBullet");
        }

        return bullet;
    }

    public void CreateMiddleBullet()
    {

    }

    public void CreateHardBullet()
    {

    }
}
