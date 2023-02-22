
using System.Collections.Generic;
using UnityEngine;

public class BezierMove : MonoBehaviour
{
    [SerializeField] private List<Transform> _points;
    [Range(0, 1)] [SerializeField] private float _pathPoint;
    [SerializeField] private float _speed;

    public float PathPoint { get { return _pathPoint; } }
    public List<Transform> Points { get { return _points; }  set { _points = value; } }

    private void Update()
    {
        Move();
        IncreaseValue();
    }

    private void Move()
    {
        transform.position = Bezier.GetFifePoints(_points[0].position, _points[1].position,
                    _points[2].position, _points[3].position, _points[4].position, _pathPoint);
    }

    private void IncreaseValue()
    {
        _pathPoint += _speed * Time.deltaTime;
    }

    private void OnDrawGizmos()
    {
        int sigmentsNumber = 20;
        Vector2 preveousePoint = _points[0].position;
        for (int i = 0; i < sigmentsNumber + 1; i++)
        {
            float parameter = (float)i / sigmentsNumber;
            Vector2 point = Bezier.GetFifePoints(_points[0].position, _points[1].position,
               _points[2].position, _points[3].position, _points[4].position, parameter);
            Gizmos.DrawLine(preveousePoint, point);
            preveousePoint = point;
        }
    }

}
