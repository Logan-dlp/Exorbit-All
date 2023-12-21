using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    [Header("Screen Settings")]
    [SerializeField] private Vector2 resolutionScreen;
    [SerializeField] private bool fullscreen;

    [Header("Cursor Settings")] 
    [SerializeField] private bool visibleCursor;
    [SerializeField] private CursorLockMode lockmodeCursor;

    private void Start()
    {
        ApplyResolution(resolutionScreen.x, resolutionScreen.y, fullscreen);
        ApplyCursor(visibleCursor, lockmodeCursor);
    }

    public void ApplyCursor(bool _visible, CursorLockMode _lockMode)
    {
        Cursor.visible = _visible;
        Cursor.lockState = _lockMode;
    }

    private void ApplyResolution(float _resolutionX, float _resolutionY, bool _fullscreen)
    {
        Screen.SetResolution((int)_resolutionX, (int)_resolutionY, _fullscreen);
    }
}
