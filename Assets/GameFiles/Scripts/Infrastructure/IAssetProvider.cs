
using System;
using UnityEngine;

public interface IAssetProvider : IService
{
    public SimpleBullet LoadBullet(string path/*, Type type*/);

    public GameObject LoadEnemy( string path );
}
