
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class BezierPath : MonoBehaviour
{

    //[SerializeField] private Transform _p0;
    //[SerializeField] private Transform _p1;
    //[SerializeField] private Transform _p2;
    //[SerializeField] private Transform _p3;
    //[SerializeField] private Transform _p4;
    [SerializeField] private List<Transform> _points;

    [Range(0, 1)]
    [SerializeField] private float _t;
    public float T { get { return _t; } }

    private void Start()
    {

    }

    private void Update()
    {
        transform.position = Bezier.GetFifePoints(_points[0].position, _points[1].position,
            _points[2].position, _points[3].position, _points[4].position, _t);
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
