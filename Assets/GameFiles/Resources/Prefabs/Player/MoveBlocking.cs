using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class MoveBlocking : MonoBehaviour
{
    public float minX;
    public float maxX;

    private void Update()
    {
        float newXpos = Mathf.Clamp(transform.position.x * transform.position, minX, maxX);

        transform.position = new Vector2(newXpos, 0);
    }
}
