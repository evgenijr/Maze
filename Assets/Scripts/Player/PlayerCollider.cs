using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public delegate void PlayerColliderNotifications(Notifications notification);
    public static event PlayerColliderNotifications TriggerEvent;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Finish"))
        {
            TriggerEvent(Notifications.COLLIDES_FINISH);
            Debug.Log("Finish");
        }
    }
}