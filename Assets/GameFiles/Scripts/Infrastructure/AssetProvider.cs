using UnityEngine;
using System;
public class AssetProvider : IAssetProvider
{
    public PlaneBullet LoadBullet(string path)
    {
        PlaneBullet asset = Resources.Load(path, typeof(PlaneBullet)) as PlaneBullet;
        return asset;
    }

    public GameObject LoadEnemy(string path)
    {
        GameObject plane = Resources.Load(path) as GameObject;
        return plane;
    }
}
