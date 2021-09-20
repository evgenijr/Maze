using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipes : MonoBehaviour
{
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    private void Update()
    {
        Swipe();
    }
    public void Swipe()
    {
        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                firstPressPos = new Vector2(t.position.x, t.position.y);
            }
            if (t.phase == TouchPhase.Ended)
            {
                secondPressPos = new Vector2(t.position.x, t.position.y);
                currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
                currentSwipe.Normalize();
                if (currentSwipe.y > 0 || currentSwipe.x > -0.5f || currentSwipe.x < 0.5f)
                {
                    Debug.Log("up swipe");
                }

                if (currentSwipe.y < 0 || currentSwipe.x > -0.5f || currentSwipe.x < 0.5f)
                {
                    Debug.Log("down swipe");
                }
                if (currentSwipe.x < 0 || currentSwipe.y > -0.5f || currentSwipe.y < 0.5f)
                {
                    Debug.Log("left swipe");
                }
                if (currentSwipe.x > 0 || currentSwipe.y > -0.5f || currentSwipe.y < 0.5f)
                {
                    Debug.Log("right swipe");
                }
            }
        }
    }
}
