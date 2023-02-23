using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBulletFactory : IService
{
    public SimpleBullet CreateSimpleBullet(BulletType bulletType);
}
