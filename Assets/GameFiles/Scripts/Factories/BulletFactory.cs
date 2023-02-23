
using UnityEngine;

public class BulletFactory : IBulletFactory
{
    public SimpleBullet CreateSimpleBullet(BulletType bulletType)
    {
        SimpleBullet bullet = null;
        if (bulletType == BulletType.MainPlayer)
        {
             bullet = Resources.Load("Prefabs/Bullets/PlayerSimpleBullet", typeof(SimpleBullet)) as SimpleBullet;
        }
        else if (bulletType == BulletType.Enemy)
        {
            bullet = Resources.Load("Prefabs/Bullets/EnemySimpleBullet", typeof(SimpleBullet)) as SimpleBullet;
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
