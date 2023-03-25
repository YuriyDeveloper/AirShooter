using System;
using UnityEngine;

public class MainPlayerBulletTypeButton : MonoBehaviour
{
    [SerializeField] private int _bulletContainerIndex;

    public static Action<int> OnActivationBUlletContainer;

    public void ActivationButtonContainer()
    {
        OnActivationBUlletContainer?.Invoke(_bulletContainerIndex);
    }
}
