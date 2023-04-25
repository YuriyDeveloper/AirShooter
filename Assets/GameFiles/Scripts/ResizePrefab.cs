using UnityEngine;

public class ResizePrefab : MonoBehaviour
{
    public Camera mainCamera; // ��������� �� ������
    public GameObject prefab; // ��������� �� ������

    void Start()
    {
        // �������� ������ ������
        float height = 2f * mainCamera.orthographicSize;
        float width = height * mainCamera.aspect;

        // ������� ������ �������
        Vector3 scale = prefab.transform.localScale;
        scale.x = width;
        scale.y = height;
        prefab.transform.localScale = scale;
    }
}