using System.Collections.Generic;
using UnityEngine;

public class MainPlayerBulletStateMachine : MonoBehaviour
{
    [SerializeField] private List<GameObject> _bulletTypes;
    private MainPlayerBulletLauncher _bulletLauncher;
    private bool _oneTypeIsActive;
    private bool _twoTypeIsActive;
    private bool _threeTypeIsActive;


    private void Start()
    {
        _bulletLauncher = GetComponent<MainPlayerBulletLauncher>();
        MainPlayerBulletTypeButton.OnOneType += ChoiseTypeOne;
        MainPlayerBulletTypeButton.OnTwoType += ChoiseTypeTwo;
        MainPlayerBulletTypeButton.OnThreeType += ChoiseTypeThree;
    }


    private void Update()
    {
       
    }

    private void OnDisable()
    {
        MainPlayerBulletTypeButton.OnOneType -= ChoiseTypeOne;
        MainPlayerBulletTypeButton.OnTwoType -= ChoiseTypeTwo;
        MainPlayerBulletTypeButton.OnThreeType -= ChoiseTypeThree;
    }

    public void ChoiseTypeOne()
    {
        if (_oneTypeIsActive) { return; }
        _bulletLauncher.StartBulletsLaunch(_bulletTypes[0]);
        _oneTypeIsActive = true;
        _twoTypeIsActive = false;
        _threeTypeIsActive = false;
    }

    public void ChoiseTypeTwo()
    {
        if (_twoTypeIsActive) { return; }
        _bulletLauncher.StartBulletsLaunch(_bulletTypes[1]);
        _oneTypeIsActive = false;
        _twoTypeIsActive = true;
        _threeTypeIsActive = false;
    }

    public void ChoiseTypeThree()
    {
        if(_threeTypeIsActive) { return; }
        _bulletLauncher.StartBulletsLaunch(_bulletTypes[2]);
        _oneTypeIsActive = false;
        _twoTypeIsActive = false;
        _threeTypeIsActive = true;
    }


}
