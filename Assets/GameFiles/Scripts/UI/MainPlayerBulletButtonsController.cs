using System.Collections.Generic;
using UnityEngine;

public class MainPlayerBulletButtonsController : MonoBehaviour
{
    [SerializeField] private MainPlayerBulletLauncher _mainPlayerBulletLauncher;
    [SerializeField] private List<BulletContainer> _mainPlayerBulletContainers;

    public void OnEnable()
    {
        MainPlayerBulletTypeButton.OnActivationBUlletContainer += BulletContainerActivated;
    }

    private void BulletContainerActivated(int containerIndex)
    {
        Debug.Log("ContainerINdex " + containerIndex);
        _mainPlayerBulletLauncher.BulletContainer = _mainPlayerBulletContainers[containerIndex - 1];
    }


}
