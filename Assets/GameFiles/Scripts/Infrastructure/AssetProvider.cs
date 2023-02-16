using UnityEngine;

public class AssetProvider : IAssetProvider
{
    public GameObject Load(string path)
    {
        GameObject asset = Resources.Load(path) as GameObject;
        return asset;
    }

}
