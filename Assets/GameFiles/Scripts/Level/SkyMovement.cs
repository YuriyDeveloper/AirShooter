using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyMovement : MonoBehaviour
{

    [SerializeField] private float _movementSpeed;
    
    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        transform.Translate(Vector3.down * _movementSpeed * Time.deltaTime);
    }
}
