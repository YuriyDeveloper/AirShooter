using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAircraftFlightController : MonoBehaviour
{
    [SerializeField] private List<GameObject> _enemyLaunchPlanes;
    [SerializeField] private List<float> _intervalBetweenLaunches;
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
        foreach (GameObject launch in _enemyLaunchPlanes)
        {
            int index = 0;
            yield return new WaitForSeconds(_intervalBetweenLaunches[index]);
            if (launch == null) { break; }
            launch.SetActive(true);
            
        }
        
    }
}
