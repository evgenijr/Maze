using UnityEngine;

public class PlayerMove : Observer
{
    [SerializeField]private float speed;
    private void Start()
    {
        Subject.AddObserver(this);
    }
    public override void OnNotify(Notifications notification)
    {
        switch (notification)
        {
            case Notifications.UP_SWIPE:
                {
                    move();
                    break;
                }
        }
    }

    private void move()
    {
        float pos = transform.position.y;
        if (!LeanTween.isTweening(gameObject))
        LeanTween.moveY(gameObject, pos + 1, speed);
    }
}
