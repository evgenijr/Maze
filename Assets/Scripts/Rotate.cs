using UnityEngine;

public class Rotate : Observer
{
    [SerializeField] private float speed;
    [SerializeField] private float angle;

    private float _angle;
    private void Start()
    {
        _angle = angle;
        Subject.AddObserver(this);
    }
    public override void OnNotify(Notifications notification)
    {
        switch (notification)
        {
            case Notifications.LEFT_SWIPE:
                {
                    _angle = -angle;
                    rot();
                    break;
                }
            case Notifications.RIGHT_SWIPE:
                {
                    _angle = angle;
                    rot();
                    break;
                }
        }
    }

    public void rot()
    {
        if(!LeanTween.isTweening(gameObject))
        LeanTween.rotateAroundLocal(gameObject, Vector3.forward, _angle, speed).setEaseOutCubic().callOnCompletes();
    }


}
