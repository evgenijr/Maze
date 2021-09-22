using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private float Angle;

    private float TempAngle;
    private void Start()
    {
        TempAngle = Angle;
        Swipes.Swipe += OnNotify;
    }
    private void OnNotify(Notifications notification)
    {
        switch (notification)
        {
            case Notifications.LEFT_SWIPE:
                {
                    TempAngle = -Angle;
                    Rotate();
                    break;
                }
            case Notifications.RIGHT_SWIPE:
                {
                    TempAngle = Angle;
                    Rotate();
                    break;
                }
        }
    }

    private void Rotate()
    {
        if(!LeanTween.isTweening(gameObject))
        LeanTween.rotateAroundLocal(gameObject, Vector3.forward, TempAngle, Speed).setEaseOutCubic();
    }


}
