using UnityEngine;

public class BulletFactory : IBulletFactory
{

    public Bullet CreateBullet(GameObject bullet, bool firstBulletDestroy, float XRotation)
    {
        Bullet concretteBullet = Object.Instantiate(bullet).GetComponent<Bullet>();
        IBullet iBullet = concretteBullet as IBullet;
        iBullet.XRotation = XRotation;
        if (firstBulletDestroy) { concretteBullet.gameObject.SetActive(false); }
        return concretteBullet.GetComponent<Bullet>();
    }

   
}

