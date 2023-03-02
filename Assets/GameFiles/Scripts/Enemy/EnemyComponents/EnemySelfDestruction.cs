using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DestructionType
{
    None,
    BezierEndPoint
}

public class EnemySelfDestruction : MonoBehaviour
{
    [SerializeField] private DestructionType _destructionIf;
    private EnemyBezierMove _bezierMove;
    private bool _canBezierEndPointDestruction;

    private void Start()
    {
        _bezierMove = GetComponent<EnemyBezierMove>();
        ChoiseDestructionType();   
    }

    private void ChoiseDestructionType()
    {
        switch (_destructionIf)
        {
            case DestructionType.BezierEndPoint:
                _canBezierEndPointDestruction = true;
                break;

        }    
    }

    private void Update()
    {
        if (_canBezierEndPointDestruction)
        {
            BezierEndPointDestruction();
        }
    }

    private void BezierEndPointDestruction()
    {
        if (_bezierMove != null)
        {
            if (_bezierMove.PathPoint >= 1)
            {
                gameObject.SetActive(false);
            }
        }
    }

}
