using UnityEngine;

public class BulletFactory : IBulletFactory
{
    public SimpleBullet CreateBullet(GameObject bullet, int moveDirection)
    {
        SimpleBullet simpleBullet = Object.Instantiate(bullet).GetComponent<SimpleBullet>();
        simpleBullet.Direction = moveDirection;
        return simpleBullet.GetComponent<SimpleBullet>();
    }

   
}
