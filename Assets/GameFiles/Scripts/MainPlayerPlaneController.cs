using UnityEngine;
using UnityEngine.Accessibility;

public class MainPlayerPlaneController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float damping = 0.1f;
    
    private Vector3 velocity;
    private Vector2 previousPosition;
    
    private float xMin, xMax, yMin, yMax;

    private void Start()
    {
        Camera camera = Camera.main;
        Vector2 screenMin = camera.ScreenToWorldPoint(Vector2.zero);
        Vector2 screenMax = camera.ScreenToWorldPoint(new Vector2(camera.pixelWidth, camera.pixelHeight));
        xMin = screenMin.x;
        xMax = screenMax.x;
        yMin = screenMin.y;
        yMax = screenMax.y;
    }

    private void FixedUpdate()
    {
        TransformPosition();
    }

    private void TransformPosition()
    {
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
                Vector2 displacement = touchPosition - previousPosition;
                Vector3 movement = new Vector3(displacement.x, displacement.y, 0f);
                transform.position += movement * speed * Time.deltaTime + velocity * Time.deltaTime;
                float x = Mathf.Clamp(transform.position.x, xMin, xMax);
                float y = Mathf.Clamp(transform.position.y, yMin, yMax);
                transform.position = new Vector3(x, y, transform.position.z);
                previousPosition = touchPosition;
                velocity += movement * speed * Time.deltaTime;
                if (displacement.magnitude < 0.1f)
                {
                    velocity = Vector3.Lerp(velocity, Vector3.zero, damping);
                }
            }
        }
        else
        {
            velocity = Vector3.Lerp(velocity, Vector3.zero, damping);
        }
    }
}