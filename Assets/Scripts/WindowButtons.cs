using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowButtons : MonoBehaviour
{
    private bool fullscreen = true;

    void OnEnable()
    {
#if UNITY_WEBGL
        this.gameObject.SetActive(false);
#endif
    }

    void Update()
    {
        if(Screen.fullScreen != this.fullscreen)
        {
            this.fullscreen = Screen.fullScreen;
            SetChildrenActive(this.fullscreen);
        }
    }

    private void SetChildrenActive(bool active)
    {
        foreach(Transform child in this.transform) child.gameObject.SetActive(active);
    }
}
