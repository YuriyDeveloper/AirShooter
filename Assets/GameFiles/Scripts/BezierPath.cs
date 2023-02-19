
using UnityEngine;

[ExecuteAlways]
public class BezierPath : MonoBehaviour
{
    [SerializeField] private Transform _p0;
    [SerializeField] private Transform _p1;
    [SerializeField] private Transform _p2;
    [SerializeField] private Transform _p3;
    [SerializeField] private Transform _p4;

    [Range(0, 1)]
    [SerializeField] private float _t;
    
    public float T { get { return _t; } }

    private void Update()
    {
        transform.position = Bezier.GetFifePoints(_p0.position, _p1.position, _p2.position, _p3.position, _p4.position, _t);
    }

    private void OnDrawGizmos()
    {
        int sigmentsNumber = 20;
        Vector2 preveousePoint = _p0.position;

        for (int i = 0; i < sigmentsNumber + 1; i++)
        {
            float parameter = (float)i / sigmentsNumber;
            Vector2 point = Bezier.GetFifePoints(_p0.position, _p1.position, _p2.position, _p3.position, _p4.position, parameter);
            Gizmos.DrawLine(preveousePoint, point);
            preveousePoint = point;
        }
    }

}
