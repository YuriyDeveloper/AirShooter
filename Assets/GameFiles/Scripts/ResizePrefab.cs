using UnityEngine;

public class ResizePrefab : MonoBehaviour
{
    public Camera mainCamera; // Посилання на камеру
    public GameObject prefab; // Посилання на префаб

    void Start()
    {
        // Отримуємо розміри камери
        float height = 2f * mainCamera.orthographicSize;
        float width = height * mainCamera.aspect;

        // Змінюємо розміри префабу
        Vector3 scale = prefab.transform.localScale;
        scale.x = width;
        scale.y = height;
        prefab.transform.localScale = scale;
    }
}