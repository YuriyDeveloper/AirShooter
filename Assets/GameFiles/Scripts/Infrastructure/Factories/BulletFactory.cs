using UnityEngine;

public class BulletFactory : IBulletFactory
{

    public Bullet CreateBullet(GameObject bullet, int moveDirection)
    {
        Bullet simpleBullet = Object.Instantiate(bullet).GetComponent<Bullet>();
        simpleBullet.Direction = moveDirection;
        return simpleBullet.GetComponent<Bullet>();
    }

   
}

