using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]private LayerMask ObstacleLayers;

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
            case Notifications.RIGHT_SWIPE:
                {
                    CanMoving = false;
                    break;
                }
            case Notifications.LEFT_SWIPE:
                {
                    CanMoving = false;
                    break;
                }
        }
    }

    private bool GetCanMoving()
    {
        Vector3 NewPosition = transform.position;
        Destination = new Vector3(NewPosition.x, NewPosition.y + 1, NewPosition.z);
        if (!LeanTween.isTweening(transform.parent.gameObject))
        {
            CanMoving = !Physics2D.Linecast(transform.position, Destination, ObstacleLayers);
        }
        return CanMoving;
    }

    private void StartMoving()
    {
        if (GetCanMoving())
        {
            transform.position = Destination;
            CanMoving = false;
        }
    }
}