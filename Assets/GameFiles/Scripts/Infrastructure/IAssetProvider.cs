
using System;
using UnityEngine;

public interface IAssetProvider : IService
{
    public Bullet LoadBullet(string path/*, Type type*/);

    public GameObject LoadEnemy( string path );
}
