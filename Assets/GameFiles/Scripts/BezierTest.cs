using UnityEditor.U2D.Path;
using UnityEngine;

[ExecuteAlways]
public class BezierTest : MonoBehaviour
{
    public Transform p0;
    public Transform p1;
    public Transform p2;
    public Transform p3;
    public Transform p4;

    [Range(0, 1)]
    public float t;

    public void Update()
    {
        transform.position = Bezier.GetFifePoints(p0.position, p1.position, p2.position, p3.position, p4.position, t);
    }

    private void OnDrawGizmos()
    {
        int sigmentsNumber = 20;
        Vector2 preveousePoint = p0.position;

        for (int i = 0; i < sigmentsNumber + 1; i++)
        {
            float parameter = (float)i / sigmentsNumber;
            Vector2 point = Bezier.GetFifePoints(p0.position, p1.position, p2.position, p3.position, p4.position, parameter);
            Gizmos.DrawLine(preveousePoint, point);
            preveousePoint = point;
        }
    }

}
