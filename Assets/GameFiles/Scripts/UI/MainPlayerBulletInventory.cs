using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerBulletInventory : MonoBehaviour
{
    [SerializeField] private List<MainPlayerBulletTypeButton> _mainPlayerBulletTypeButtons;

    private bool _isActive;

    public void ToggleActivationButtons()
    {
        if (!_isActive)
        {
            ActivationMainPlayerBulletTypeButtons();
            _isActive = true;
        }
        else
        {
            DeactivationMainPlayerBulletTypeButtons();
            _isActive = false;
        }
    }

    private void ActivationMainPlayerBulletTypeButtons()
    {
        foreach (MainPlayerBulletTypeButton concretteButton in _mainPlayerBulletTypeButtons)
        {
            concretteButton.gameObject.SetActive(true);   
        }
    }

    private void DeactivationMainPlayerBulletTypeButtons()
    {
        foreach (MainPlayerBulletTypeButton concretteButton in _mainPlayerBulletTypeButtons)
        {
            concretteButton.gameObject.SetActive(false);
        }
    }
}
