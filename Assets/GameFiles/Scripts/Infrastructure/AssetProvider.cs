using UnityEngine;
using System;
public class AssetProvider : IAssetProvider
{
    public Bullet LoadBullet(string path)
    {
        Bullet asset = Resources.Load(path, typeof(Bullet)) as Bullet;
        return asset;
    }

    public GameObject LoadEnemy(string path)
    {
        GameObject plane = Resources.Load(path) as GameObject;
        return plane;
    }
}
