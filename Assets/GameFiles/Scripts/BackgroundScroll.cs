using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private float _speed = 0.1f;

    private void Update()
    {
        Scroll();
    }

    private void Scroll()
    {
        Vector2 offset = _meshRenderer.material.mainTextureOffset;
        offset = offset + new Vector2(0, _speed * Time.deltaTime);
        _meshRenderer.material.mainTextureOffset = offset;
    }

}
