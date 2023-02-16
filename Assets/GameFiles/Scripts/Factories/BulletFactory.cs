
using UnityEngine;

public class BulletFactory : IBulletFactory
{
    public SimpleBullet CreateSimpleBullet()
    {
        SimpleBullet bullet = Resources.Load("Prefabs/Weapons/SimpleBullet", typeof(SimpleBullet)) as SimpleBullet;
        return bullet;
    }

    public void CreateMiddleBullet()
    {

    }

    public void CreateHardBullet()
    {

    }
}
