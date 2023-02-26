using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBulletFactory : IService
{
    public SimpleBullet CreateBullet(GameObject bullet, int moveDirection);
}
