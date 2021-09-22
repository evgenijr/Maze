using UnityEngine;

public class Swipes : MonoBehaviour
{
    public delegate void SwipeEvent(Notifications notification);
    public static event SwipeEvent Swipe;

    private Vector2 FirstPressPosition;
    private Vector2 SecondPressPosition;
    private Vector2 CurrentSwipe;

    private void Update()
    {
        WaitSwipe();
    }
    private void WaitSwipe()
    {
        if (Input.GetMouseButtonDown(0))
            FirstPressPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        if (Input.GetMouseButtonUp(0)) 
        {
            SecondPressPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            CurrentSwipe = new Vector2(SecondPressPosition.x - FirstPressPosition.x, SecondPressPosition.y - FirstPressPosition.y);
            CurrentSwipe.Normalize();
            Swipe(GetTypeOfSwipe(CurrentSwipe));
        }
    }
    private Notifications GetTypeOfSwipe(Vector3 Swipe)
    {
        if (Swipe.y > 0 && Swipe.x > -0.5f && Swipe.x < 0.5f)
        {
            return Notifications.UP_SWIPE;
        }
        if (Swipe.x < 0 && Swipe.y > -0.5f && Swipe.y < 0.5f)
        {
            return Notifications.LEFT_SWIPE;
        }
        if (Swipe.x > 0 && Swipe.y > -0.5f && Swipe.y < 0.5f)
        {
            return Notifications.RIGHT_SWIPE;
        }
        if (Swipe.y < 0 && Swipe.x > -0.5f && Swipe.x < 0.5f)
        {
            return Notifications.NONE;
        }
        return Notifications.NONE;
    }
}
