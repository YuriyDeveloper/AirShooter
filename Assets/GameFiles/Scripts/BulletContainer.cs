using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletContainer : MonoBehaviour
{
    [SerializeField] private List<GameObject> _container;
    [SerializeField] private List<float> _xDirectionAngle;
    [SerializeField] private float _spawnInterval;
    public List<GameObject> Container { get => _container; }
    public List<float> XDirectionAngle { get => _xDirectionAngle; }
    public float SpawnInterval { get => _spawnInterval; }
}
