
using UnityEngine;

public class BulletFactory : IBulletFactory
{
    public SimpleBullet CreateSimpleBullet(BulletType bulletType, int moveDirection)
    {
        SimpleBullet bullet = null;
        if (bulletType == BulletType.MainPlayer)
        {
             bullet = Resources.Load("Prefabs/Weapons/PlayerSimpleBullet", typeof(SimpleBullet)) as SimpleBullet;
        }
        else if (bulletType == BulletType.Enemy)
        {
            bullet = Resources.Load("Prefabs/Weapons/EnemySimpleBullet", typeof(SimpleBullet)) as SimpleBullet;
        }

        bullet.Direction = moveDirection;
        return bullet;
    }

    public void CreateMiddleBullet()
    {

    }

    public void CreateHardBullet()
    {

    }
}
