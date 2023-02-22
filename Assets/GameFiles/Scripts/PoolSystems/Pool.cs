using System.Collections.Generic;
using UnityEngine;

public class Pool<T> where T : MonoBehaviour
{
    public T prefab { get; }
    public bool autoExpand { get; set; }
    public Transform container { get; }

    private List<T> pool;
    public Pool(T prefab, int count)
    {
        this.prefab = prefab;
        container = null;
        CreatePool(count);
    }

    public Pool(T prefab, int count, Transform container)
    {
        this.prefab = prefab;
        this.container = container;
        CreatePool(count);
    }

    private void CreatePool(int count)
    {
        pool = new List<T>();

        for (int i = 0; i < count; i++)
        {
            CreateObject();
        }
    }

    private T CreateObject(bool isActiveByDefault = false)
    {
        var createdObject = Object.Instantiate(prefab, container);
        createdObject.gameObject.SetActive(isActiveByDefault);
        pool.Add(createdObject);
        return createdObject;
    }

    public bool HasFreeElement(out T element, Vector3 spawnPoint)
    {
        foreach (var mono in pool)
        {
            if (!mono.gameObject.activeInHierarchy)
            {
                element = mono;
                mono.gameObject.SetActive(true);
                mono.gameObject.transform.position = spawnPoint;
                return true;
            }
        }
        element = null;
        return false;
    }

    public T GetFreeElement(Vector3 spawnPoint)
    {
        if (HasFreeElement(out var element, spawnPoint))
        {
            return element;

        }
        if (autoExpand)
        {
            return CreateObject(true);
        }
        throw new System.Exception("error pool");
    }
}
