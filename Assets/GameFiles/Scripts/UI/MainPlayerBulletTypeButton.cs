using System;
using UnityEngine;

public class MainPlayerBulletTypeButton : MonoBehaviour
{
    public static Action OnOneType;
    public static Action OnTwoType;
    public static Action OnThreeType;

    public void ChoiseTypeOne()
    {
        OnOneType?.Invoke();
    }

    public void ChoiseTypeTwo()
    {
        OnTwoType?.Invoke();
    }

    public void ChoiseTypeThree()
    {
        OnThreeType?.Invoke();
    }
}
