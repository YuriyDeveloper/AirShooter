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
        int i = 0;
        while (gameObject.activeSelf)
        {
            yield return new WaitForSeconds(4);
            _enemyLaunchPlanes[i].SetActive(true);
            i++;
            yield return new WaitForSeconds(15);
            _enemyLaunchPlanes[i].SetActive(true);
        }
        
    }
}
