using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public LayerMask ObstacleLayers;

    [SerializeField]private float Speed;

    private Vector3 Destination;
    private bool CanMoving = true;

    private void Start()
    {
        Destination = transform.position;
        Swipes.Swipe += OnNotify;
    }
    private void OnNotify(Notifications notification)
    {
        switch (notification)
        {
            case Notifications.UP_SWIPE:
                {
                    StartMoving();
                    break;
                }
        }
    }

    private void StartMoving()
    {
        Vector3 NewPosition = transform.position;
        Destination = new Vector3(NewPosition.x, NewPosition.y + 1, NewPosition.z);
        CanMoving = !Physics2D.Linecast(transform.position, Destination, ObstacleLayers);
        if (CanMoving)
        {
            transform.position = Destination;
            CanMoving = false;
        }
    }
}