using UnityEngine;

public class MainPlayerPlaneController : MonoBehaviour
{
    // Скорость перемещения самолета
    public float speed = 5f;

    // Ограничения области движения
    private float xMin, xMax, yMin, yMax;

    // Текущая скорость перемещения
    private Vector3 velocity;

    // Коэффициент затухания скорости
    public float damping = 0.1f;

    // Предыдущая позиция пальца
    private Vector2 previousPosition;

    private void Start()
    {
        // Определение границ области движения
        Camera camera = Camera.main;
        Vector2 screenMin = camera.ScreenToWorldPoint(Vector2.zero);
        Vector2 screenMax = camera.ScreenToWorldPoint(new Vector2(camera.pixelWidth, camera.pixelHeight));
        xMin = screenMin.x;
        xMax = screenMax.x;
        yMin = screenMin.y;
        yMax = screenMax.y;
    }

    private void Update()
    {
        // Обработка сенсорного управления
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = touch.position;

            if (touch.phase == TouchPhase.Began)
            {
                previousPosition = touchPosition;
            }

            if (touch.phase == TouchPhase.Moved)
            {
                // Вычисляем вектор смещения на основе перемещения пальца
                Vector2 displacement = touchPosition - previousPosition;
                Vector3 movement = new Vector3(displacement.x, displacement.y, 0f);

                // Перемещаем самолет на вектор смещения с использованием текущей скорости
                transform.position += movement * speed * Time.deltaTime + velocity * Time.deltaTime;

                // Ограничение области движения
                float x = Mathf.Clamp(transform.position.x, xMin, xMax);
                float y = Mathf.Clamp(transform.position.y, yMin, yMax);
                transform.position = new Vector3(x, y, transform.position.z);

                // Обновляем предыдущую позицию пальца
                previousPosition = touchPosition;

                // Обновляем текущую скорость
                velocity += movement * speed * Time.deltaTime;

                // Применяем затухание скорости при отсутствии перемещения пальца
                if (displacement.magnitude < 0.1f)
                {
                    velocity = Vector3.Lerp(velocity, Vector3.zero, damping);
                }
            }
        }
        else
        {
            // Применяем затухание скорости при отсутствии сенсорного ввода
            velocity = Vector3.Lerp(velocity, Vector3.zero, damping);
        }
    }
}