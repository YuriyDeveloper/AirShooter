using UnityEngine;

internal interface IShipBullet
{
    public Collider2D MainPlayerCollider { get; set; }

    public void FlyToMainPlayer();
}