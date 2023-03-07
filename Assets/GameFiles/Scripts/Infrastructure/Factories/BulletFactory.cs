using UnityEngine;

public class BulletFactory : IBulletFactory
{

    public Bullet CreateBullet(GameObject bullet, bool firstBulletDestroy)
    {
        Bullet concretteBullet = Object.Instantiate(bullet).GetComponent<Bullet>();
       // if (firstBulletDestroy) { concretteBullet.gameObject.SetActive(false); }
        return concretteBullet.GetComponent<Bullet>();
    }

   
}

