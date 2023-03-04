using UnityEngine;

public class BulletFactory : IBulletFactory
{

    public Bullet CreateBullet(GameObject bullet)
    {
        Bullet simpleBullet = Object.Instantiate(bullet).GetComponent<Bullet>();
        return simpleBullet.GetComponent<Bullet>();
    }

   
}

