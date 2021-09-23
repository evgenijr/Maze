using UnityEngine;
using UnityEngine.UI; 

public class UIManager : MonoBehaviour
{
    [SerializeField] private LeanTweenType TextEaseType;
    [SerializeField] private float TextLeanSpeed;
    [SerializeField] private Vector3 TargetTextScale;
    public delegate void UIManagerNotofications(Notifications notification);
    public static event UIManagerNotofications UIEvent;

    [SerializeField] private GameObject StartButton;
    [SerializeField] private Text HintText;
    private void Start()
    {

        LeanTween.scale(HintText.gameObject, TargetTextScale, TextLeanSpeed).setEase(TextEaseType).setLoopPingPong();
    }
    private void OnNotify(Notifications notification)
    {
        switch (notification)
        {
            case Notifications.COLLIDES_FINISH:
                {
                    
                    break;
                }
        }
    }
    public void ClickStart()
    {
        UIEvent(Notifications.START_CLICK);
        StartButton.SetActive(false);
        HintText.gameObject.SetActive(false);
    }
}
