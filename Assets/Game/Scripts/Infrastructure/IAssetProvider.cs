

using UnityEngine;

public interface IAssetProvider : IService
{
    public GameObject Load(string path);


}
