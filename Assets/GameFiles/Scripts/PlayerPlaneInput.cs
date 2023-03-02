
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerPlaneInput : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    [SerializeField] private Transform player;
    private void Update()
    {
        MoveToHorizontal();
    }

    private void MoveToHorizontal()
    {
       //if()
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))
        {
            if (eventData.delta.x > 0)
            {
                player.position += Vector3.right;
            }
            else
            {
                player.position += Vector3.left;
            }
        }
        else
        {
            if (eventData.delta.y > 0)
            {
                player.position += Vector3.up;
            }
            else
            {
                player.position += Vector3.down;
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }
}
