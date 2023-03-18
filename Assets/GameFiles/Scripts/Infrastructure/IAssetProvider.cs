
using System;
using UnityEngine;

public interface IAssetProvider : IService
{
    public PlaneBullet LoadBullet(string path/*, Type type*/);

    public GameObject LoadEnemy( string path );
}
