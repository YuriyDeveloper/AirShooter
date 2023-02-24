using UnityEngine;
using System;
public class AssetProvider : IAssetProvider
{
    public SimpleBullet LoadBullet(string path)
    {
        SimpleBullet asset = Resources.Load(path, typeof(SimpleBullet)) as SimpleBullet;
        return asset;
    }

    public GameObject LoadEnemy(string path)
    {
        GameObject plane = Resources.Load(path) as GameObject;
        return plane;
    }
}
