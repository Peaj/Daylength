using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
    [DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);
    [DllImport("user32.dll")]
    private static extern IntPtr GetActiveWindow();

    public Vector2Int WindowSize = new Vector2Int(1024, 768);
    public KeyCode QuitKey = KeyCode.Escape;

    void Update()
    {
        if(Input.GetKey(this.QuitKey)) Quit();
    }

    public void Quit()
    {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

    public void Minimize()
    {
        ShowWindow(GetActiveWindow(), 2);
    }

    public void Maximize()
    {
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
    }

    public void Normalize()
    {
        Screen.SetResolution(this.WindowSize.x, this.WindowSize.y, false);
    }

    public void ToggleFullscreen()
    {
        if(Screen.fullScreen) Normalize();
        else Maximize();
    }
}
