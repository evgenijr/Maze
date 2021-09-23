using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public delegate void LevelInfoNotifications(Notifications notification);
    public static event LevelInfoNotifications LevelEvent;
    private void Start()
    {
        PlayerCollider.TriggerEvent += OnNotify;
        UIManager.UIEvent += OnNotify;
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
            case Notifications.START_CLICK:
                {
                    StartNotify();
                    break;
                }
        }
    }

    public void RestartNotify()
    {
        LevelEvent(Notifications.LEVEL_RESTART);
    }
    public void StartNotify()
    {
        LevelEvent(Notifications.LEVEL_START);
    }
}
