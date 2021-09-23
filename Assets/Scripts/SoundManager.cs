using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource RotateSource;
    [SerializeField] private AudioSource SwooshSource;
    private void Start()
    {
        Swipes.Swipe += OnNotify;
    }
    private void OnNotify(Notifications notification)
    {
        switch (notification)
        {
            case Notifications.LEFT_SWIPE:
                {
                    PlaySound(RotateSource);
                    break;
                }
            case Notifications.RIGHT_SWIPE:
                {
                    PlaySound(RotateSource);
                    break;
                }
            case Notifications.UP_SWIPE:
                {
                    PlaySound(SwooshSource);
                    break;
                }
        }
    }
    private void PlaySound(AudioSource SoundSource)
    {
        SoundSource.Play();
    }
}
