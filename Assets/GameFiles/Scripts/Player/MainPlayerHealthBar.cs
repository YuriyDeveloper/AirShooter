using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPlayerHealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;

    private void OnEnable()
    {
        PlayerPlaneState.OnMainPlayerPlaneDamage += DecreaseHealth;
    }

    private void OnDisable()
    {
        PlayerPlaneState.OnMainPlayerPlaneDamage -= DecreaseHealth;
    }

    public void SetHealth(float health)
    {
        _healthBar.value = health;
    }

    public float GetHealth()
    {
        return _healthBar.value;
    }

    public void DecreaseHealth(float damageValue)
    {
        _healthBar.value -= damageValue / 100;   
    }
}
