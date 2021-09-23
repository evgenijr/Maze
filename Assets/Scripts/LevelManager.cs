using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public delegate void LevelInfoNotifications(Notifications notification);
    public static event LevelInfoNotifications LevelEvent;
    private void Start()
    {
        PlayerCollider.TriggerEvent += OnNotify;
    }
    private void OnNotify(Notifications notification)
    {
        switch (notification)
        {
            case Notifications.COLLIDES_FINISH:
                {
                    RestartNotify();
                    break;
                }
        }
    }

    public void RestartNotify()
    {
        LevelEvent(Notifications.LEVEL_RESTART);
    }
}
