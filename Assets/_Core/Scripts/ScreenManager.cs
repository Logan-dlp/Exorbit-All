using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    [SerializeField] private Vector2 resolutionScreen;
    [SerializeField] private bool fullscreen;

    private void Start()
    {
        ApplyResolution((int)resolutionScreen.x, (int)resolutionScreen.y, fullscreen);
    }

    private void ApplyResolution(int _resolutionX, int _resolutionY, bool _fullscreen)
    {
        Screen.SetResolution(_resolutionX, _resolutionY, _fullscreen);
    }
}
