using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAircraftFlightController : MonoBehaviour
{
    [SerializeField] private List<GameObject> _enemyLaunchPlanes;

    private void Start()
    {
        StartLaunches();
    }

    private void StartLaunches()
    {
        StartCoroutine(StartLaunchesCoroutine());
        StopCoroutine(StartLaunchesCoroutine());
    }

    private IEnumerator StartLaunchesCoroutine()
    {
        yield return new WaitForSeconds(4);
        _enemyLaunchPlanes[0].SetActive(true);
    }
}
