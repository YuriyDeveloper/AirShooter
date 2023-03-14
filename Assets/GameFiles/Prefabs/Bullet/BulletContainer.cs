using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletContainer : MonoBehaviour
{
    [SerializeField] private List<GameObject> _container;

    public List<GameObject> Container { get => _container; }
}
