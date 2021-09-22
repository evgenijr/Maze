using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public LayerMask mask;
    [SerializeField]private float Speed;
    private Rigidbody2D RigidBody;

    private Vector3 Destination;
    private bool CanMoving = false;
    private void Start()
    {
        RigidBody = GetComponent<Rigidbody2D>();
        Destination = transform.position;
        Swipes.Swipe += OnNotify;
    }
    private void OnNotify(Notifications notification)
    {
        switch (notification)
        {
            case Notifications.UP_SWIPE:
                {
                    if(!CanMoving)
                    StartMoving();
                    break;
                }
        }
    }

    private void StartMoving()
    {
        Vector3 NewPosition = transform.position;
        Destination = new Vector3(NewPosition.x, NewPosition.y + 1, NewPosition.z);
        CanMoving = !Physics2D.Linecast(transform.position, Destination, mask);
        if (CanMoving)
        {
            RigidBody.MovePosition(Destination);
            CanMoving = false;
        }
    }
}
