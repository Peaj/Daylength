using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyEvent : MonoBehaviour
{
    public KeyCode Key;
    public UnityEvent OnKeyDown;

    void Update()
    {
        if(Input.GetKeyDown(this.Key)) this.OnKeyDown.Invoke();
    }
}
